using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoC_.Common.models
{
    public class Jogo
    {
        public Time Time1 { get; set; }
        public Time Time2 { get; set; }

        public Jogo(Time time1, Time time2)
        {
            Time1 = time1;
            Time2 = time2;
        }

        public void simutlar()
        {
            int somaTime1 = Time1.SomarJogabilidade();
            int somaTime2 = Time2.SomarJogabilidade();
            int diferencaJogabilidade = Math.Abs(somaTime1 - somaTime2);

            Random random = new Random();

            int golsTime1, golsTime2;
            if (diferencaJogabilidade <= 20)
            {
                golsTime1 = random.Next(0, 3);
                golsTime2 = golsTime1 + random.Next(-1, 2);

                golsTime2 = Math.Max(golsTime2, 0);
            }
            else
            {
                if(somaTime1 > somaTime2)
                {
                    golsTime2 = random.Next(0, 3);
                    golsTime1 = golsTime2 + random.Next(1, 4);
                }
                else
                {
                    golsTime1 = random.Next(0, 3);
                    golsTime2 = golsTime1 + random.Next(1, 4);
                }
            }
            
            Console.WriteLine($"Resultado: {Time1.NomeTime} {golsTime1} x {golsTime2} {Time2.NomeTime}");
            
        }

    }
}