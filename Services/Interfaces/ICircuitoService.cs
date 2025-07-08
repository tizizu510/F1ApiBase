using F1ApiBase.Models;

namespace F1ApiBase.Services.Interfaces
{
    public interface ICircuitoService
    {
        IEnumerable<Circuito> GetAllCircuitos();
        Circuito? GetCircuitoById(int id);
        Circuito AddCircuito(Circuito newCircuito);
        bool UpdateCircuito(Circuito updatedCircuito);
        bool DeleteCircuito(int id);
    }
}
