using Dapper;
using Datos.Interfaces;
using Modelos;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Repositorios
{
    public class AerolineaRepositorio : IAerolineaRepositorio
    {

        private string CadenaConexion;

        public AerolineaRepositorio(string cadenaConexion)
        {
            CadenaConexion=cadenaConexion;
        }

        private MySqlConnection Conexion()
        {
            return new MySqlConnection(CadenaConexion);
        }
        public async Task<bool> Actualizar(Aerolinea aerolinea)
        {
            bool result = false;
            try
            {
                using MySqlConnection conexion = Conexion();
                await conexion.OpenAsync();
                string sql = @"UPDATE aerolinea SET  Codigo = @Codigo ,Fecha=@Fecha, Origen = @Origen , Destino = @Destino, Avion=@Avion, 
                                                        Cantidad=@Cantidad, Piloto=@Piloto
                                 WHERE Codigo=@Codigo;";

                result =Convert.ToBoolean(await conexion.ExecuteAsync(sql, aerolinea));

            }
            catch (Exception ex)
            {
            }
            return result;
        }

        public async Task<bool> Eliminar(Aerolinea aerolinea)
        {
            bool result = false;
            try
            {
                using MySqlConnection conexion = Conexion();
                await conexion.OpenAsync();
                string sql = @"DELETE  FROM aerolinea WHERE Codigo=@Codigo;";
                result =Convert.ToBoolean(await conexion.ExecuteAsync(sql, new { aerolinea.Codigo }));

            }
            catch (Exception ex)
            {
            }
            return result;
        }

        public async Task<IEnumerable<Aerolinea>> GetLista()
        {
            IEnumerable<Aerolinea> lista = new List<Aerolinea>();
            try
            {
                using MySqlConnection conexion = Conexion();
                await conexion.OpenAsync();
                string sql = @" SELECT * FROM aerolinea;";
                lista = await conexion.QueryAsync<Aerolinea>(sql);
            }
            catch (Exception ex)
            {
            }
            return lista;
        }

        public async Task<Aerolinea> GetPorCodigo(string codigo)
        {
            Aerolinea aerolinea = new Aerolinea();
            try
            {
                using MySqlConnection conexion = Conexion();
                await conexion.OpenAsync();
                string sql = @" SELECT * FROM aerolinea WHERE Codigo = @Codigo;";
                aerolinea = await conexion.QueryFirstAsync<Aerolinea>(sql, new { codigo });
            }
            catch (Exception)
            {
            }
            return aerolinea;
        }

        public async Task<bool> Nuevo(Aerolinea aerolinea)
        {
            bool result = false;
            try
            {
                using MySqlConnection conexion = Conexion();
                await conexion.OpenAsync();
                string sql = @"INSERT INTO aerolinea (Codigo, Fecha ,Origen, Destino, Avion, Cantidad, Piloto) 
                                 VALUES (@Codigo, @Fecha, @Origen, @Destino, @Avion, @Cantidad, @Piloto);";

                result =Convert.ToBoolean(await conexion.ExecuteAsync(sql, aerolinea));

            }
            catch (Exception ex)
            {
            }
            return result;
        }
    }
}
