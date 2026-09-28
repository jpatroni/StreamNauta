
using System;

namespace Streamnauta.Domain.Entities
{
    public class Canal
    {
        // PROPIEDADES
        public Guid Id { get; private set; }
        public string Nombre { get; private set; }
        public string Plataforma { get; private set; }
        public string IdExterno { get; private set; }

        // CONSTRUCTOR
        public Canal(
            string nombre,
            string plataforma,
            string idExterno)
        {
            // Reglas de negocio
            if (string.IsNullOrWhiteSpace(nombre))
            {
                throw new ArgumentException(
                    "El nombre del canal es obligatorio.");
            }

            if (string.IsNullOrWhiteSpace(plataforma))
            {
                throw new ArgumentException(
                    "La plataforma es obligatoria.");
            }

            if (string.IsNullOrWhiteSpace(idExterno))
            {
                throw new ArgumentException(
                    "El ID externo es obligatorio.");
            }

            // Inicialización
            Id = Guid.NewGuid();
            Nombre = nombre.Trim();
            Plataforma = plataforma.Trim();
            IdExterno = idExterno.Trim();
        }

        // MÉTODO PARA CAMBIAR EL NOMBRE
        public void CambiarNombre(string nuevoNombre)
        {
            if (string.IsNullOrWhiteSpace(nuevoNombre))
            {
                throw new ArgumentException(
                    "El nombre del canal es obligatorio.");
            }

            Nombre = nuevoNombre.Trim();
        }
    }
}
