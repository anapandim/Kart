using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kart
{
    public class Log
    {
        public DateTime Hora { get; set; }

        public String Piloto { get; set; }

        public int NumeroVolta { get; set; }

        public DateTime TempoVolta { get; set; }

        public double VelocidadeMediaVolta { get; set; }

        public static explicit operator Log(String s)
        {
            var campos = s.Split(new char[] { '\t' }, StringSplitOptions.RemoveEmptyEntries);
            return new Log { Hora = Convert.ToDateTime(campos[0]), Piloto = campos[1], NumeroVolta = Convert.ToInt32(campos[2]), TempoVolta = Convert.ToDateTime("0:" + campos[3]), VelocidadeMediaVolta = Convert.ToDouble(campos[4]) };
        }
    }
}
