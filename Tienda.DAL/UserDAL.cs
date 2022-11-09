using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tienda.Contratos;
using Tienda.Entities;

namespace Tienda.DAL
{
    public class UserDAL : IUser
    {

        string dbconexion;

        public UserDAL()
        {
            dbconexion = ConfigurationManager.ConnectionStrings["ConectarProductos"].ConnectionString;
        }
        public async Task<ObservableCollection<Usuario>> ObtenerUsuario(string usuario, string contrasenia)
        {
            ObservableCollection<Usuario> ListaUsuario = new ObservableCollection<Usuario>();
            using (SqlConnection cn = new SqlConnection(dbconexion))
            {
                SqlCommand cmd = new SqlCommand("ObtenerPorNombreCon", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Usuario", usuario);
                cmd.Parameters.AddWithValue("@Contrasenia", contrasenia);
                try
                {
                    await cn.OpenAsync();
                    SqlDataReader sdr = await cmd.ExecuteReaderAsync();
                    if (sdr.HasRows)
                    {
                        while (sdr.Read())
                        {
                            ListaUsuario.Add(new Usuario
                            {
                                UsuarioId = Convert.ToInt32(sdr["UsuarioId"]),
                                usuario = sdr["Usuario"].ToString(),
                                Contrasenia = sdr["Contrasenia"].ToString(),
                                Estado = Convert.ToBoolean(sdr["Estado"])
                            });
                        }
                        cn.Close();
                    }
                    else
                    {
                        ListaUsuario = null;
                    }
                }
                catch (Exception)
                {
                    cn.Close();
                }
                return (ListaUsuario);
            }
        }
    }
}
