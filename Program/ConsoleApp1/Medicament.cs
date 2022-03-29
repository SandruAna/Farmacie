using System;
using System.Collections.Generic;
using System.Text;

namespace Med
{
    class Medicament
    {
        private const char SEPARATOR_FISIER = ' ';

        private const int ID = 0;
        private const int NUME = 1;
        private const int NAME = 2;


        public int Id { set; get; }
        public string Nume { set; get; }
        public string Name { set; get; }

        public Medicament()
        {
            Id = 0;
            Nume = "anonim";
            Name = "anonim";

        }
        public Medicament(int id, string nume, string name)
        {
            Id = id;
            Nume = nume;
            Name = name;

        }

        public Medicament(string linieFisier)
        {
            var dateFisier = linieFisier.Split(SEPARATOR_FISIER);
            Id = Convert.ToInt32(dateFisier[ID]);
            Nume = dateFisier[NUME];
            Name = dateFisier[NAME];


        }

        public string ConversieLaSir_PentruFisier()
        {
            string obiectMedicamentePentruFisier = string.Format("{1}{0}{2}{0}{3}",
                SEPARATOR_FISIER,
               Id,
               Nume,
               Name
               );

            return obiectMedicamentePentruFisier;
        }
    }
}

