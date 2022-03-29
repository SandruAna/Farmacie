using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Admin;
using Med;
using System.Configuration;

namespace Farmacie
{
    class Program
    {
        static void Main(string[] args)
        {

            if(args.Length==0)
            {
                Console.WriteLine("nu merge lniai de comanda");
            }
            else
            {
                Console.WriteLine("merge linia de comanda " + args.Length);
            }

            string numeFisier = ConfigurationManager.AppSettings["NumeFisier"];
            AdminMed_Fisier adminMed = new AdminMed_Fisier(numeFisier);
            int nrMed = adminMed.GetNrMed();

            string optiune;
            do
            {
                Console.WriteLine("F. Afisare medicament din fisier");
                Console.WriteLine("S. Salvare medicament in fisier");
                Console.WriteLine("C. Citire de la tastatura");
                Console.WriteLine("L. Cautare dupa nume si name");
                Console.WriteLine("X. Inchidere program");
                Console.WriteLine("Alegeti o optiune");
                optiune = Console.ReadLine();
                switch (optiune.ToUpper())
                {
                    case "F":
                        Medicament[] med = adminMed.GetMedicamente(out nrMed);
                        AfisareMedicamente(med, nrMed);
                        break;
                    case "S":
                        Medicament med1 = new Medicament(nrMed, "Nurofen", "Forte");
                        nrMed++;
                        //adaugare student in fisier
                        adminMed.AddMed(med1);
                        break;
                    case "C":
                        string sir = string.Empty;
                        sir += nrMed;
                        sir += " ";
                        Console.WriteLine("Introduceti datele: nume, name");
                        sir += Console.ReadLine();
                        Medicament med2 = new Medicament(sir);
                        adminMed.AddMed(med2);
                        nrMed++;
                        break;
                    case "L":
                        string nume, name;
                        Console.WriteLine("Introduceti numele:");
                        nume = Console.ReadLine();
                        Console.WriteLine("Introduceti name:");
                        name = Console.ReadLine();
                        Console.WriteLine(adminMed.VerifMed(nume, name).ConversieLaSir_PentruFisier());
                        break;
                    case "X":
                        return;
                    default:
                        Console.WriteLine("Optiune inexistenta");
                        break;
                }
            } while (optiune.ToUpper() != "X");

            Console.ReadKey();
        }
        public static void AfisareMedicamente(Medicament[] med, int nrMedicamente)
        {
            Console.WriteLine("Medicamentele  sunt:");
            for (int contor = 0; contor < nrMedicamente; contor++)
            {
                string infoMedicamente = string.Format("Medicamentul cu id-ul #{0}: {1} {2} ",
                   med[contor].Id,
                  med[contor].Nume,
                   med[contor].Name
                   );

                Console.WriteLine(infoMedicamente);
            }
        }
    }
}
