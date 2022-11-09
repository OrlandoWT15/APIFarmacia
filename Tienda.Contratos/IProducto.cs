using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tienda.Entities;

namespace Tienda.Contratos
{
    public interface IProducto
    {
        //Medicamento
        Task<ObservableCollection<Medicamento>> ObtenerProductos();
        Task<ObservableCollection<Medicamento>> ObtenerProductosNombre(string nombre);
        Task<ObservableCollection<Medicamento>> ObtenerProductosPresentacion(string nombre);
        Task<ObservableCollection<Medicamento>> ObtenerProductoFechaCad(string fecha);
        ////Usuario
        //Task<ObservableCollection<Usuario>> ObtenerUsuario(string usuario, string contrasenia);
    }
}
