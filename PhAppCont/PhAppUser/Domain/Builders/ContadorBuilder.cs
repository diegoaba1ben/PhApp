using System;
using PhAppUser.Domain.Entities;

namespace PhAppUser.Domain.Builders
{
    public class UsuarioBuilder
    {
        private Usuario _usuario;

        // Método para crear un usuario de tipo Contador
        public static UsuarioBuilder CrearContador(string tarjProf)
        {
            var contador = new Contador(tarjProf);
            return new UsuarioBuilder { _usuario = contador };
        }

        // Método específico para agregar el número de la tarjeta profesional del Contador
        public UsuarioBuilder ConTarjProf(string tarjProf)
        {
            if (_usuario is Contador contador)
            {
                contador.TarjProf = tarjProf;
            }
            return this;
        }

        // Otros métodos para manejar otros tipos de usuarios pueden añadirse aquí

        // Método para construir y devolver el usuario creado
        public Usuario Build()
        {
            return _usuario;
        }
    }
}
