using F1ApiBase.Models;
using F1ApiBase.Services.Interfaces;

namespace F1ApiBase.Services
{
    public class CircuitoService : ICircuitoService
    {
        private static List<Circuito> _circuitos = new List<Circuito>
        {
            new Circuito { Id = 1, Nombre = "Circuit de Monaco", Pais = "Mónaco", LongitudKm = 3.337 },
            new Circuito { Id = 2, Nombre = "Autodromo Nazionale Monza", Pais = "Italia", LongitudKm = 5.793 },
            new Circuito { Id = 3, Nombre = "Silverstone Circuit", Pais = "Reino Unido", LongitudKm = 5.891 }
        };

        public IEnumerable<Circuito> GetAllCircuitos()
        {
            return _circuitos;
        }

        public Circuito? GetCircuitoById(int id)
        {
            return _circuitos.FirstOrDefault(c => c.Id == id);
        }

        public Circuito AddCircuito(Circuito newCircuito)
        {
            newCircuito.Id = _circuitos.Any() ? _circuitos.Max(c => c.Id) + 1 : 1;
            _circuitos.Add(newCircuito);
            return newCircuito;
        }

        public bool UpdateCircuito(Circuito updatedCircuito)
        {
            var existingCircuito = _circuitos.FirstOrDefault(c => c.Id == updatedCircuito.Id);
            if (existingCircuito == null)
            {
                return false;
            }

            existingCircuito.Nombre = updatedCircuito.Nombre;
            existingCircuito.Pais = updatedCircuito.Pais;
            existingCircuito.LongitudKm = updatedCircuito.LongitudKm;
            return true;
        }

        public bool DeleteCircuito(int id)
        {
            var circuitoToRemove = _circuitos.FirstOrDefault(c => c.Id == id);
            if (circuitoToRemove == null)
            {
                return false;
            }
            _circuitos.Remove(circuitoToRemove);
            return true;
        }
    }
}
