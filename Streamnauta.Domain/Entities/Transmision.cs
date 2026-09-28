using System;

namespace Streamnauta.Domain.Entities
{
    public class Transmision
    {
        public Guid Id { get; private set; }
        public Guid CanalId { get; private set; }
        public string Titulo { get; private set; }
        public DateTimeOffset FechaInicio { get; private set; }
        public DateTimeOffset? FechaFin { get; private set; }

        public Transmision(
            Guid canalId,
            string titulo,
            DateTimeOffset fechaInicio)
        {
            if (canalId == Guid.Empty)
            {
                throw new ArgumentException(
                    "El identificador del canal es obligatorio.",
                    nameof(canalId));
            }

            if (string.IsNullOrWhiteSpace(titulo))
            {
                throw new ArgumentException(
                    "El título de la transmisión es obligatorio.",
                    nameof(titulo));
            }

            Id = Guid.NewGuid();
            CanalId = canalId;
            Titulo = titulo.Trim();
            FechaInicio = fechaInicio;
            FechaFin = null;
        } // Cierra el constructor

        public void Finalizar(DateTimeOffset fechaFin)
        {
            if (FechaFin.HasValue)
            {
                throw new InvalidOperationException(
                    "La transmisión ya fue finalizada.");
            }

            if (fechaFin < FechaInicio)
            {
                throw new ArgumentException(
                    "La fecha de fin no puede ser anterior al inicio.",
                    nameof(fechaFin));
            }

            FechaFin = fechaFin;
        } // Cierra el método
    } // Cierra la clase
} // Cierra el namespace