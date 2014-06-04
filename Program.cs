using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lotto
{
    class Program
    {
        private static void Main(string[] args)
        {
            List<int> kayttajanNumerot = new List<int>();
            List<int> lisaNumerot = new List<int>();


            List<int> arvotutVarsinaisetNumerot = new List<int>();
            List<int> arvotutLisaNumerot = new List<int>();


            alustaLista(ref kayttajanNumerot,7);
            alustaLista(ref lisaNumerot, 2);

            alustaLista(ref arvotutVarsinaisetNumerot, 7);
            alustaLista(ref arvotutLisaNumerot, 2);


            Console.WriteLine("Anna varsinainen lottorivi :");

            kysyNumerot(ref kayttajanNumerot);
            tulostaListanNumerot(ref kayttajanNumerot);
            
            Console.WriteLine("\n\nAnna kaksi lisänumeroa :");

            kysyNumerot(ref lisaNumerot);
            tulostaListanNumerot(ref lisaNumerot);

            arvoNumeroita(ref arvotutVarsinaisetNumerot);
            Console.WriteLine("\n\nArvotut varsinaiset numerot :");
            tulostaListanNumerot(ref arvotutVarsinaisetNumerot);

            arvoNumeroita(ref arvotutLisaNumerot);
            Console.WriteLine("\n\nArvotut  lisänumerot :");
            tulostaListanNumerot(ref arvotutLisaNumerot);


            int oikeita;
            int oikeitaVara;

            OikeitaVastauksia(ref kayttajanNumerot, ref arvotutVarsinaisetNumerot,out oikeita);
            OikeitaVastauksia(ref lisaNumerot, ref arvotutLisaNumerot, out oikeitaVara,true);


            Apuluokka.InsertWideLineSepatator();

            Console.WriteLine("Oikeita varsinaisia numeroita : {0}", oikeita+"\n");
            Console.WriteLine("Oikeita varanumeroita : {0}",oikeitaVara);
 
            Apuluokka.InsertLineSepatator();



            Apuluokka.Pause();
        }

        private static void OikeitaVastauksia(ref List<int> lisaNumerot, ref List<int> arvotutLisaNumerot, out int oikeitaVara, bool p)
        {
            oikeitaVara = 0;
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    if (lisaNumerot[i] == arvotutLisaNumerot[j])
                        oikeitaVara++;
                }
            }
        }

        private static void OikeitaVastauksia(ref List<int> kayttajanNumerot, ref List<int> arvotutVarsinaisetNumerot, out int oikeita)
        {
            oikeita = 0;
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    if (kayttajanNumerot[i] == arvotutVarsinaisetNumerot[j])
                        oikeita++;
                }
            }
        }



        private static void arvoNumeroita(ref List<int> arvotutVarsinaisetNumerot)
        {   
            Random rnd = new Random();  // Seeds using system clock
            int luku = -2;


            for (int i = 0; i < arvotutVarsinaisetNumerot.Count(); i++)
            {
                do
                {
                    luku = rnd.Next(1, 40); // creates a number between 1 and 39}
                }
                while (arvotutVarsinaisetNumerot.Contains(luku));

                arvotutVarsinaisetNumerot.RemoveAt(i);      // Muuten lista paisuu vaan !
                arvotutVarsinaisetNumerot.Insert(i, luku);
 
            }


        }

        private static void tulostaListanNumerot(ref List<int> kayttajanNumerot)
        {
            Console.WriteLine("\n\nListan alkiot :");
            kayttajanNumerot.Sort();
            for(int i=0;i<kayttajanNumerot.Count();i++)
                Console.Write("{0} ",kayttajanNumerot.ElementAt(i));

        }

        private static void kysyNumerot(ref List<int> lista)
        {
            int luku=-1;
            bool OKJatkaa = false;
            bool parsetusOnnistui = false;

            Console.WriteLine();

            for (int i = 0; i < lista.Count(); i++)
            {
                OKJatkaa = false;
                parsetusOnnistui = false;

                Console.Write("Anna luku {0} : ",i+1);
                while (!OKJatkaa)
                {
                    if (!int.TryParse(Console.ReadLine(), out luku))
                    {
                        Console.WriteLine("Parsetus epäonnistui !");
                        parsetusOnnistui = false;
                    }

                    else
                        parsetusOnnistui = true;

                    if (lista.Contains(luku))
                        Console.WriteLine("Luku on annettu jo !");

                    else if ((luku < 1 || luku > 39) && parsetusOnnistui)
                        Console.WriteLine("Sallitun lukualueen ulkopuolella !");

                    else if (parsetusOnnistui)
                    {
                        Console.WriteLine("OK, luku lisätty lappuun !");
                        lista.RemoveAt(i);      // Muuten lista paisuu vaan !
                        lista.Insert(i, luku);
                        Apuluokka.WL();
                        OKJatkaa = true;

                    }
                }
            }
        }

        private static void alustaLista(ref List<int> lista,int koko)
        {
            for (int i = 0; i < koko; i++)
                lista.Add(-1);
        }
    }
}
