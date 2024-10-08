using System;
using System.Collections.Generic;

namespace PhAppUser.Domain.Entities
{
    /// <summary>
    /// Clase que representa una categoría o rol dentro de la organización.
    /// </summary>
    public class Categoria
    {
        /// <summary>
        /// Representa  el identificador único de la categoría.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Representa el nombre de la categoría dentor del sistema
        /// </summary>
        [Required(ErrorMessage = "El campo nombre  es obligatorio.")]
        [RegularExpression(@"^[\p{L}\s'-]+$", ErrorMessage = "El campo Nombre solo acepta letras.")]
        [StringLenght(20, MinimumLenght = 5, ErrorMessage = "El campo debe contener entre 5  y 20 caracteres.")]
        public string Nombre { get; set; }      

        /// <summary>
        /// Represetna la descripción de  la categoría jerárquica.
        /// </summary>
        [Required(ErrorMessage = "El campo de descrpción es obligatorio.")]
        [RegularExpression(@"^[\p{L}\s'-]+$", ErrorMessage = "El campo Nombre solo acepta letras.")]
        [StringLength(50, ErrorMessage = "El campo debe contener 50 caracteres.")]
        public string Descripcion { get; set; } 

        ///  <summary>
        ///  Identificador de la categoría padre
        /// </summary>
        public int?CategoriaPadreId { get; set; }

        /// <summary>
        /// Categoria  padre aplicable, por ejemplo, financiera, administración, etc.
        /// Se permite nulo para que se puedan generar categorías raíz.
        /// </summary>
        public Categoria CategoriaPadre { get; set; }

        /// <summary>
        /// Categoría  hijo aplicable, por ejemplo, contabilidad, tesorería, etc.
        /// </summary>
        public List<Categoria> SubCategorias { get; set; }

        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public Categoria()
        {
            SubCategorias = new List<Categoria>();
        }

        /// <summary>
        /// Método para agregar una subcategoría a la categoría actual.
        /// </summary>
        public void AgregarSubCategoria(Categoria subCategoria)
        {
            if(subCategoria == null)
            {
                throw new ArgumentNullException(nameof(subCategoria), "La subcategoría no puede ser nula.")

                subCategoria.CategoriaPadre = this; //Establece la categoría
                SubCategorias.Add(subCategoria); //Agrega la subcategoría a la lista
            }
        }

        /// <summary>
        /// Método para imprimir la jerarquía de la categoría y sus subcategorías.
        /// </summary>
        public void ImprimirJerarquia(int nivel = 0)
        {
            string indentacion = new string(' ', nivel * 4);
            Console.WriteLine($"{indentacion}- {Nombre}");

            foreach (var subCategoria in SubCategorias)
            {
                subCategoria.ImprimirJerarquia(nivel + 1);
            }
        }
        ///  <summary>
        ///  Método estático para la inicialización de un builder de la clase categoría
        /// </summary>
        /// <returns>Retorna una nueva instancia de CategoriaBuilder</returns>
        public static CategoriaBuilder Crearbuilder()
        {
            return new CategoriaBuilder();
        }

    }
}


