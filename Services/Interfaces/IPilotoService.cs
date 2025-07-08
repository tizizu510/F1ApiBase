using F1ApiBase.Models;

namespace F1ApiBase.Services.Interfaces
{
    public interface IPilotoService
    {
        IEnumerable<Piloto> GetAllPilotos();
        Piloto? GetPilotoById(int id);
        Piloto AddPiloto(Piloto newPiloto);
        bool UpdatePiloto(Piloto updatedPiloto);
        bool DeletePiloto(int id);
        IEnumerable<Piloto> GetPilotosByCircuitoId(int circuitoId);
    }
}
