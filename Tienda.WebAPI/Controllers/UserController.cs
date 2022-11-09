using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Tienda.Contratos;
using Tienda.DAL;
using Tienda.Entities;

namespace Tienda.WebAPI.Controllers
{
    public class UserController : ApiController
    {
        private new readonly IUser User;

        ObservableCollection<Usuario> DatosUser;

        public UserController()
        {
            User = new UserDAL();
        }

        //Usuarios
        [HttpGet]
        public async Task<ObservableCollection<Usuario>> Usuario(string x, string y)
        {
            DatosUser = await User.ObtenerUsuario(x, y);

            return DatosUser;
        }
    }
}
