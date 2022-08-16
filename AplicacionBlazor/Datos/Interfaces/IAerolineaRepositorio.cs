using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Interfaces
{
    public interface IAerolineaRepositorio
    {
        Task<bool> Nuevo(Aerolinea aerolinea);

        Task<bool> Actualizar(Aerolinea aerolinea);
        Task<bool> Eliminar(Aerolinea aerolinea);
        Task<IEnumerable<Aerolinea>> GetLista();
        Task<Aerolinea> GetPorCodigo(string codigo);

    }
}
