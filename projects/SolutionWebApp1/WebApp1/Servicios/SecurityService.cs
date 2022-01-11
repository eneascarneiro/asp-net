using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp1.Models;

namespace WebApp1.Servicios
{
    
    public class SecurityService
    {
        List<UserData> usuariosCorrectos = new List<UserData>();

        public SecurityService()
        {
            usuariosCorrectos.Add(new UserData { id = 0, userName = "maria01", password = "12345" });
            usuariosCorrectos.Add(new UserData { id = 1, userName = "luis01", password = "12345" });
            usuariosCorrectos.Add(new UserData { id = 2, userName = "pepe01", password = "12345" });
        }

        public bool ValidarUsuario(UserData usuario) 
        {
            return usuariosCorrectos.Any(x => x.userName == usuario.userName && x.password == usuario.password);
        }
    }
}
