using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmarketWPF
{
    public interface IProveedorDetails
    {
        string Nombre { get; set; }
        string NIT { get; set; }
        string Foto { get; set; }
    }
}
