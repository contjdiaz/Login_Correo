using System;
using System.Collections.Generic;
using System.Text;

namespace WebSite_Correo.Entity
{
    public class usuarios
    {
        public int id { get; set; }
        public string dni { get; set; }
        public string nombres { get; set; }
        public string apellidos { get; set; }
        public string cargo { get; set; }
        public string email { get; set; }
        public string contrasena { get; set; }
    }
}
