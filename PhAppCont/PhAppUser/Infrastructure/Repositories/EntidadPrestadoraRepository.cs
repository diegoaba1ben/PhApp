using Microsoft.EntityFrameworkCore;
using PhAppUser.Application.Interfaces;
using PhAppUser.Domain.Entities;
using PhAppUser.Infrastructure.Context;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhAppUser.Infrastructure.Repositories
{
    /// <summary>
    /// Repositorio para la entidad EntidadPrestadora que interactúa con la base de datos.
    /// </summary>
    public class EntidadPrestadoraRepository : IEntidadPrestadoraRepository
    {
        private readonly PhAppUserDbContext _context;

        /// <summary>
        /// Constructor de EntidadPrestadoraRepository.
        /// </summary>
        /// <param name="context">El contexto de la base de datos.</param>
        public EntidadPrestadoraRepository(PhAppUserDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Obtiene todas las entidades EntidadPrestadora con paginación.
        /// </summary>
        /// <param name="pageNumber">Número de página.</param>
        /// <param name="pageSize">Tamaño de la página.</param>
        /// <returns>Una lista de entidades EntidadPrestadora.</returns>
        public async Task<IEnumerable<EntidadPrestadora>> GetAllAsync(int pageNumber, int pageSize)
        {
            return await _context.EntidadesPrestadoras
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        /// <summary>
        /// Obtiene una entidad EntidadPrestadora por su ID.
        /// </summary>
        /// <param name="id">El ID de la entidad a buscar.</param>
        /// <returns>La entidad EntidadPrestadora si se encuentra, o null si no se encuentra.</returns>
        public async Task<EntidadPrestadora> GetByIdAsync(int id)
        {
            return await _context.EntidadesPrestadoras.FindAsync(id);
        }

        /// <summary>
        /// Agrega una nueva EntidadPrestadora a la base de datos.
        /// </summary>
        /// <param name="entidadPrestadora">La entidad EntidadPrestadora a agregar.</param>
        public async Task AddAsync(EntidadPrestadora entidadPrestadora)
        {
            try
            {
                await _context.EntidadesPrestadoras.AddAsync(entidadPrestadora);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                throw new DbUpdateException("Error al agregar la entidad EntidadPrestadora", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error inesperado al agregar la entidad", ex);
            }
        }

        /// <summary>
        /// Actualiza una entidad EntidadPrestadora existente en la base de datos.
        /// </summary>
        /// <param name="entidadPrestadora">La entidad EntidadPrestadora con los nuevos valores.</param>
        public async Task UpdateAsync(EntidadPrestadora entidadPrestadora)
        {
            try
            {
                var entidadExistente = await _context.EntidadesPrestadoras.FindAsync(entidadPrestadora.Id);

                if (entidadExistente != null)
                {
                    _context.Entry(entidadExistente).CurrentValues.SetValues(entidadPrestadora);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    throw new KeyNotFoundException($"La EntidadPrestadora con ID {entidadPrestadora.Id} no fue encontrada");
                }
            }
            catch (DbUpdateException ex)
            {
                throw new Exception($"Error al intentar actualizar la Entidad Prestadora con ID {entidadPrestadora.Id}", ex);
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocurrió un error inesperado al actualizar la entidad con ID {entidadPrestadora.Id}", ex);
            }
        }

        /// <summary>
        /// Actualiza parcialmente una propiedad de la entidad EntidadPrestadora en el repositorio.
        /// </summary>
        /// <param name="entidadPrestadora">La Entidad Prestadora para actualizar parcialmente</param>

        /// <summary>
        /// Actualiza parcialmente las propiedades de una entidad EntidadPrestadora en el repositorio.
        /// </summary>
        /// <param name="entidadPrestadora">La Entidad Prestadora para actualizar parcialmente</param>
        public async Task UpdatePartialAsync(EntidadPrestadora entidadPrestadora)
        {
            try
            {
                var entidadExistente = await _context.EntidadesPrestadoras.FindAsync(entidadPrestadora.Id);

                if (entidadExistente != null)
                {
                    // Validación y actualización para EntSalud
                    if (entidadExistente is EntSalud entidadSaludExistente && entidadPrestadora is EntSalud entidadSaludActualizada)
                    {
                        // Validación del nuevo valor de Cobertura
                        if (string.IsNullOrEmpty(entidadSaludActualizada.Cobertura))
                        {
                            throw new ArgumentException("La cobertura no puede ser nula o vacía. Por favor revise sus datos.");
                        }

                        // Si la validación pasa, se actualiza la propiedad
                        entidadSaludExistente.Cobertura = entidadSaludActualizada.Cobertura;
                        await _context.SaveChangesAsync();

                        // Mensaje de confirmación exitosa
                        Console.WriteLine("La Entidad Salud ha  sido actualizada exitosamente.");

                    }
                    // Caso para Pension
                    else if (entidadExistente is Pension entidadPensionExistente)
                    {
                        // En este caso, no hay propiedades que validar, solo indicamos que la actualización es correcta
                        await _context.SaveChangesAsync(); // Aseguramos que no hay cambios que hacer, pero confirmamos que todo está en orden.
                        Console.WriteLine("Contenido completo y actualizado para la entidad Pension.");
                    }
                    else
                    {
                        throw new InvalidOperationException("El tipo de entidad no está soportado para la actualización.");
                    }
                }
                else
                {
                    throw new KeyNotFoundException($"La Entidad Prestadora con ID {entidadPrestadora.Id} no fue encontrada.");
                }
            }
            catch (DbUpdateException ex)
            {
                throw new Exception($"Error al intentar actualizar la Entidad Prestadora con ID {entidadPrestadora.Id}", ex);
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocurrió un error inesperado al actualizar parcialmente la entidad con ID {entidadPrestadora.Id}", ex);
            }
        }
        /// <summary>
        /// Elimina una EntidadPrestadora por su ID.
        /// </summary>
        /// <param name="id">El ID de la entidad a eliminar.</param>
        public async Task DeleteAsync(int id)
        {
            try
            {
                var entidadPrestadora = await _context.EntidadesPrestadoras.FindAsync(id);

                if (entidadPrestadora != null)
                {
                    _context.EntidadesPrestadoras.Remove(entidadPrestadora);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    throw new KeyNotFoundException($"La EntidadPrestadora con ID {id} no fue encontrada");
                }
            }
            catch (DbUpdateException ex)
            {
                throw new InvalidOperationException($"Error al eliminar la EntidadPrestadora con ID {id}", ex);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Ocurrió un error inesperado al eliminar la entidad con ID {id}", ex);
            }
        }
    }
}

