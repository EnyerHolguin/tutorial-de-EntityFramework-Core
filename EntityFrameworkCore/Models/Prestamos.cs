using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFrameworkCore.Models
{
    public class Prestamos
    {
            public string Nombres { get; set; }
            public string Apellidos { get; set; }
            public string Cedula { get; set; }
            public DateTime FechaNacimiento { get; set; } = DateTime.Now;
           
        
    }
}
