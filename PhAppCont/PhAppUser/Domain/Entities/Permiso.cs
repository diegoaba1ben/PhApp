using System;
using System.ComponentModel.DataAnnotations;

namespace PhAppUser.Domain.Entities
{
    public class Permiso
    {
        [Key]
        public int Id { get; private set; }

        [Required(ErrorMessage = "El nombre del permiso es obligatorio.")]
        [StringLength(50, MinimumLength = 3)]
        public string Nombre { get; private set; } = string.Empty;

        [Required(ErrorMessage = "La descripción es obligatoria.")]
        [StringLength(100)]
        public string Descripcion { get; private set; } = string.Empty;

        [Required]
        public DateTime FechaCreacion { get; private set; } = DateTime.UtcNow;

        public int CreadorPermisoId { get; private set; }

        public int CategoriaId { get; private set; } // Añadido para la relación
        public Categoria Categoria { get; private set; } = new Categoria();

        // Constructor privado para el builder
        private Permiso() { }

        // Método builder
        public static PermisoBuilder Builder() => new PermisoBuilder();

        public class PermisoBuilder
        {
            private readonly Permiso _permiso = new Permiso();

            public PermisoBuilder WithNombre(string nombre)
            {
                _permiso.Nombre = nombre;
                return this;
            }

            public PermisoBuilder WithDescripcion(string descripcion)
            {
                _permiso.Descripcion = descripcion;
                return this;
            }

            public PermisoBuilder WithCreadorPermisoId(int creadorPermisoId)
            {
                _permiso.CreadorPermisoId = creadorPermisoId;
                return this;
            }

            public PermisoBuilder WithCategoria(Categoria categoria)
            {
                _permiso.Categoria = categoria;
                _permiso.CategoriaId = categoria.Id; // Asignar el ID de la categoría
                return this;
            }

            public Permiso Build()
            {
                // Validaciones adicionales pueden ser agregadas aquí
                return _permiso;
            }
        }
    }
}



