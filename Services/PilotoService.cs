using F1ApiBase.Models;
using F1ApiBase.Services.Interfaces;

namespace F1ApiBase.Services
{
    public class PilotoService : IPilotoService
    {
        private static List<Piloto> _pilotos = new List<Piloto>
        {
            new Piloto { Id = 1, Nombre = "Max Verstappen", Nacionalidad = "Neerlandés", FechaNacimiento = new DateTime(1997, 9, 30), CircuitoId = 1, PuntosEnCircuito = 25, PosicionEnCircuito = 1, TiempoEnCircuito = "1:12.000" },
            new Piloto { Id = 2, Nombre = "Lewis Hamilton", Nacionalidad = "Británico", FechaNacimiento = new DateTime(1985, 1, 7), CircuitoId = 1, PuntosEnCircuito = 18, PosicionEnCircuito = 2, TiempoEnCircuito = "1:12.500" },
            new Piloto { Id = 3, Nombre = "Charles Leclerc", Nacionalidad = "Monegasco", FechaNacimiento = new DateTime(1997, 10, 16), CircuitoId = 2, PuntosEnCircuito = 15, PosicionEnCircuito = 3, TiempoEnCircuito = "1:22.000" },
            new Piloto { Id = 4, Nombre = "Fernando Alonso", Nacionalidad = "Español", FechaNacimiento = new DateTime(1981, 7, 29), CircuitoId = 3, PuntosEnCircuito = 10, PosicionEnCircuito = 5, TiempoEnCircuito = "1:28.000" }
        };

        public IEnumerable<Piloto> GetAllPilotos()
        {
            return _pilotos;
        }

        public Piloto? GetPilotoById(int id)
        {
            return _pilotos.FirstOrDefault(p => p.Id == id);
        }

        public Piloto AddPiloto(Piloto newPiloto)
        {
            newPiloto.Id = _pilotos.Any() ? _pilotos.Max(p => p.Id) + 1 : 1;
            _pilotos.Add(newPiloto);
            return newPiloto;
        }

        public bool UpdatePiloto(Piloto updatedPiloto)
        {
            var existingPiloto = _pilotos.FirstOrDefault(p => p.Id == updatedPiloto.Id);
            if (existingPiloto == null)
            {
                return false;
            }

            existingPiloto.Nombre = updatedPiloto.Nombre;
            existingPiloto.Nacionalidad = updatedPiloto.Nacionalidad;
            existingPiloto.FechaNacimiento = updatedPiloto.FechaNacimiento;
            existingPiloto.CircuitoId = updatedPiloto.CircuitoId;
            existingPiloto.PuntosEnCircuito = updatedPiloto.PuntosEnCircuito;
            existingPiloto.PosicionEnCircuito = updatedPiloto.PosicionEnCircuito;
            existingPiloto.TiempoEnCircuito = updatedPiloto.TiempoEnCircuito;
            return true;
        }

        public bool DeletePiloto(int id)
        {
            var pilotoToRemove = _pilotos.FirstOrDefault(p => p.Id == id);
            if (pilotoToRemove == null)
            {
                return false;
            }
            _pilotos.Remove(pilotoToRemove);
            return true;
        }

        public IEnumerable<Piloto> GetPilotosByCircuitoId(int circuitoId)
        {
            return _pilotos.Where(p => p.CircuitoId == circuitoId).ToList();
        }
    }
}
