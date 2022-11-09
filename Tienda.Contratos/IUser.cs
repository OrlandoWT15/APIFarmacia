using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tienda.Entities;

namespace Tienda.Contratos
{
    public interface IUser
    {
        //Usuario
        Task<ObservableCollection<Usuario>> ObtenerUsuario(string usuario, string contrasenia);
    }
}
