using Modelos;

namespace Blazor.Interfaces
{
    public interface IAerolineaServicio
    {
        Task<bool> Nuevo(Aerolinea aerolinea);

        Task<bool> Actualizar(Aerolinea aerolinea);
        Task<bool> Eliminar(Aerolinea aerolinea);
        Task<IEnumerable<Aerolinea>> GetLista();
        Task<Aerolinea> GetPorCodigo(string codigo);
    }
}
