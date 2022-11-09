using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Tienda.Contratos;
using Tienda.Entities;
namespace Tienda.DAL
{
    public class ProductoDAL:IProducto
    {
        string dbconexion;

        public ProductoDAL()
        {
            dbconexion = ConfigurationManager.ConnectionStrings["ConectarProductos"].ConnectionString;
        }

        public async Task <ObservableCollection<Medicamento>> ObtenerProductos()
        {
            ObservableCollection<Medicamento> ListProductos = new ObservableCollection<Medicamento>();

            using (SqlConnection cn = new SqlConnection(dbconexion))
            {
                SqlCommand cmd = new SqlCommand("ObtenerProductos", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    await cn.OpenAsync();
                    SqlDataReader sdr = await cmd.ExecuteReaderAsync();
                    if (sdr.HasRows)
                    {
                        while (sdr.Read())
                        {
                            ListProductos.Add(new Medicamento
                            {
                                Nombre = sdr["Nombre"].ToString(),
                                Presentacion = sdr["Presentacion"].ToString(),
                                FechaCaducidad = Convert.ToDateTime(sdr["FechaCaducidad"]),
                                Precio = Convert.ToInt32(sdr["Precio"]),
                                ImagenPath = sdr["ImagenPath"].ToString(),
                                ProductoId = Convert.ToInt32(sdr["ProductoId"]),
                            });
                        }
                        cn.Close();
                    }
                    else
                    {
                        ListProductos = null;
                    }
                }
                catch (Exception)
                {
                    cn.Close();
                }
                return (ListProductos);
            }
        }
        public async Task<ObservableCollection<Medicamento>> ObtenerProductosNombre(string nombre)
        {
            ObservableCollection<Medicamento> ListaProductos = new ObservableCollection<Medicamento>();
            using (SqlConnection cn = new SqlConnection(dbconexion))
            {
                SqlCommand cmd = new SqlCommand("ObtenerProductoPorNombre", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nombre", nombre);
                try
                {
                    await cn.OpenAsync();
                    SqlDataReader sdr = await cmd.ExecuteReaderAsync();
                    if (sdr.HasRows)
                    {
                        while (sdr.Read())
                        {
                            ListaProductos.Add(new Medicamento
                            {
                                Nombre = sdr["Nombre"].ToString(),
                                Presentacion = sdr["Presentacion"].ToString(),
                                FechaCaducidad = Convert.ToDateTime(sdr["FechaCaducidad"]),
                                Precio = Convert.ToInt32(sdr["Precio"]),
                                ImagenPath = sdr["ImagenPath"].ToString(),
                                ProductoId = Convert.ToInt32(sdr["ProductoId"]),
                            });
                        }
                        cn.Close();
                    }
                    else
                    {
                        ListaProductos = null;
                    }
                }
                catch(Exception)
                {
                    cn.Close();
                }
                return (ListaProductos);
            }
        }
        public async Task<ObservableCollection<Medicamento>> ObtenerProductosPresentacion(string presentacion)
        {
            ObservableCollection<Medicamento> ListaProductos = new ObservableCollection<Medicamento>();
            using (SqlConnection cn = new SqlConnection(dbconexion))
            {
                SqlCommand cmd = new SqlCommand("ObtenerProductoPresentacion", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@presentacion", presentacion);
                try
                {
                    await cn.OpenAsync();
                    SqlDataReader sdr = await cmd.ExecuteReaderAsync();
                    if (sdr.HasRows)
                    {
                        while (sdr.Read())
                        {
                            ListaProductos.Add(new Medicamento
                            {
                                Nombre = sdr["Nombre"].ToString(),
                                Presentacion = sdr["Presentacion"].ToString(),
                                FechaCaducidad = Convert.ToDateTime(sdr["FechaCaducidad"]),
                                Precio = Convert.ToInt32(sdr["Precio"]),
                                ImagenPath = sdr["ImagenPath"].ToString(),
                                ProductoId = Convert.ToInt32(sdr["ProductoId"]),
                            });
                        }
                        cn.Close();
                    }
                    else
                    {
                        ListaProductos = null;
                    }
                }
                catch (Exception)
                {
                    cn.Close();
                }
                return (ListaProductos);
            }
        }
        public async Task<ObservableCollection<Medicamento>> ObtenerProductoFechaCad(string fechacad)
        {
            ObservableCollection<Medicamento> ListaProductos = new ObservableCollection<Medicamento>();
            using (SqlConnection cn = new SqlConnection(dbconexion))
            {
                SqlCommand cmd = new SqlCommand("ObtenerProductoPorFechaCaducidad", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@fechacaducidad", Convert.ToDateTime(fechacad));
                try
                {
                    await cn.OpenAsync();
                    SqlDataReader sdr = await cmd.ExecuteReaderAsync();
                    if (sdr.HasRows)
                    {
                        while (sdr.Read())
                        {
                            ListaProductos.Add(new Medicamento
                            {
                                Nombre = sdr["Nombre"].ToString(),
                                Presentacion = sdr["Presentacion"].ToString(),
                                FechaCaducidad = Convert.ToDateTime(sdr["FechaCaducidad"]),
                                Precio = Convert.ToInt32(sdr["Precio"]),
                                ImagenPath = sdr["ImagenPath"].ToString(),
                                ProductoId = Convert.ToInt32(sdr["ProductoId"]),
                            });
                        }
                        cn.Close();
                    }
                    else
                    {
                        ListaProductos = null;
                    }
                }
                catch (Exception)
                {
                    cn.Close();
                }
                return (ListaProductos);
            }
        }

        
    }
}
