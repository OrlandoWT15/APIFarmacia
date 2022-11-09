using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Collections.ObjectModel;
using Tienda.Entities;
using Tienda.Contratos;
using Tienda.DAL;
using System.Threading.Tasks;

namespace Tienda.WebAPI.Controllers
{
    public class ProductoController : ApiController
    {
        readonly IProducto Prod;

        ObservableCollection<Medicamento> DatosProductos;
        

        public ProductoController()
        {
            Prod = new ProductoDAL();
        }

        //Medicamentos
        [HttpGet]
        public async Task<ObservableCollection<Medicamento>> ListaProductos()
        {
            DatosProductos = await Prod.ObtenerProductos();

            return DatosProductos;
        }
        [HttpGet]
        public async Task<ObservableCollection<Medicamento>> ProductoPorNombre(string x)
        {
            DatosProductos = await Prod.ObtenerProductosNombre(x);

            return DatosProductos;
        }
        [HttpGet]
        public async Task<ObservableCollection<Medicamento>> ProductoPorPresentacion(string x)
        {
            DatosProductos = await Prod.ObtenerProductosPresentacion(x);

            return DatosProductos;
        }
        [HttpGet]
        public async Task<ObservableCollection<Medicamento>> ProductoPorFechaCad(string x)
        {
            DatosProductos = await Prod.ObtenerProductoFechaCad(x);

            return DatosProductos;
        }
        //Usuarios
        //[HttpGet]
        //public async Task<ObservableCollection<Usuario>> Usuario(string x,string y)
        //{
        //    DatosUsuario = await Prod.ObtenerUsuario(x,y);

        //    return DatosUsuario;
        //}
    }
}
