using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public  class Aerolinea
    {
        [Required(ErrorMessage = "El código es obligatorio")]
        public string Codigo { get; set; }     
        public DateTime Fecha { get; set; }
        public string Origen { get; set; }   
        public string Destino { get; set; }  
        public string Avion { get; set; }     
        public int Cantidad { get; set; }     
        public string  Piloto { get; set; }
        

    }
}
