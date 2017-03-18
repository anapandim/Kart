using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kart
{
    class Program
    {
        static void Main(string[] args)
        {
            String[] linhas;

            DateTime inicioProva = DateTime.MaxValue;

            using (var log = new StreamReader("log.txt"))
            {
                linhas = log.ReadToEnd().Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

                log.Close();
            }

            var lista = new List<Log>();

            foreach (var linha in linhas)
            {
                if (!linha.StartsWith("Hora"))
                {
                    var log = (Log)linha;

                    lista.Add(log);

                    if (inicioProva == DateTime.MaxValue)
                        inicioProva = log.Hora;

                    if (log.NumeroVolta == 4)
                        break;
                }
            }

            lista.Reverse();

            VerificarGanhador(lista, inicioProva);

            Console.ReadKey();
        }

        private static void VerificarGanhador(List<Log> lista, DateTime inicioProva)
        {
            var rank = new HashSet<Rank>();

            foreach (var item in lista)
            {
                var corredor = (Rank)item;
                corredor.TempoTotal = corredor.Hora.Subtract(inicioProva).TotalMilliseconds;
                rank.Add(corredor);
            }

            var podium = rank.OrderByDescending(x => x.QuantidadeVoltas).ThenBy(x => x.Hora).ToArray();

            for (int i = 0; i < podium.Count(); i++)
            {
                if (i == 0)
                {
                    var tempoTotal = podium[i].TempoTotal;

                    Console.WriteLine("Tempo total de prova: {0} ms\n", tempoTotal);
                }

                Console.WriteLine("{0} {1}", i + 1, podium[i]);
            }
        }
    }
}
