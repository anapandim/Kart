using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kart
{
    public class Rank
    {
        public String CodigoPiloto { get; set; }

        public String NomePiloto { get; set; }

        public int QuantidadeVoltas { get; set; }

        public DateTime Hora { get; set; }

        public double TempoTotal { get; set; }

        public static explicit operator Rank(Log l)
        {
            var campos = l.Piloto.Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
            return new Rank { QuantidadeVoltas = l.NumeroVolta, CodigoPiloto = campos[0].Trim(), NomePiloto = campos[1].Trim(), Hora = l.Hora };
        }
        
        public override bool Equals(object obj)
        {
            return this.CodigoPiloto.Equals(((Rank)obj).CodigoPiloto);
        }

        public override int GetHashCode()
        {
            return this.CodigoPiloto.GetHashCode();
        }

        public override string ToString()
        {
            return String.Format("{0,3} {1,-15} {2,3}", CodigoPiloto, NomePiloto, QuantidadeVoltas);
        }
    }
}
