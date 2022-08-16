using Blazor.Data;
using Blazor.Interfaces;
using Datos.Interfaces;
using Datos.Repositorios;
using Modelos;

namespace Blazor.Servicios
{
    public class AerolineaServicio : IAerolineaServicio
    {
        private readonly MySQLConfiguracion _configuracion;
        private IAerolineaRepositorio aerolineaRepositorio;

        public AerolineaServicio(MySQLConfiguracion configuracion)
        {
            _configuracion = configuracion;
            aerolineaRepositorio = new AerolineaRepositorio(configuracion.CadenaConexion);
        }
        public async Task<bool> Actualizar(Aerolinea aerolinea)
        {
            return await aerolineaRepositorio.Actualizar(aerolinea);
        }

        public async Task<bool> Eliminar(Aerolinea aerolinea)
        {
            return await aerolineaRepositorio.Eliminar(aerolinea);
        }

        public async Task<IEnumerable<Aerolinea>> GetLista()
        {
            return await aerolineaRepositorio.GetLista();
        }

        public async Task<Aerolinea> GetPorCodigo(string codigo)
        {
            return await aerolineaRepositorio.GetPorCodigo(codigo);
        }

        public async Task<bool> Nuevo(Aerolinea aerolinea)
        {
            return await aerolineaRepositorio.Nuevo(aerolinea);
        }
    }
}
