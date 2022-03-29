using System;
using System.Collections.Generic;
using System.Text;
using Med;
using System.IO;

namespace Admin
{
    class AdminMed_Fisier
    {
        private const int NR_MAX_MED = 50;
        private string numeFisier;

        public AdminMed_Fisier(string numefisier)
        {
            numeFisier = numefisier;
            Stream streamFisierText = File.Open(numeFisier, FileMode.OpenOrCreate);
            streamFisierText.Close();
        }

        public void AddMed(Medicament Med)
        {
            using (StreamWriter streamWriterFisierText = new StreamWriter(numeFisier, true))
            {
                streamWriterFisierText.WriteLine(Med.ConversieLaSir_PentruFisier());
            }
        }

        public Medicament[] GetMedicamente(out int nrMed)
        {
            Medicament[] medicamente = new Medicament[NR_MAX_MED];
            using (StreamReader streamReader = new StreamReader(numeFisier))
            {
                string linieFisier;
                nrMed = 0;

                while ((linieFisier = streamReader.ReadLine()) != null)
                {
                    medicamente[nrMed++] = new Medicament(linieFisier);
                }
            }

            return medicamente;
        }

        public Medicament VerifMed(string nume, string name)
        {
            using (StreamReader streamReader = new StreamReader(numeFisier))
            {
                string linieFisier;
                while ((linieFisier = streamReader.ReadLine()) != null)
                {
                    Medicament med = new Medicament(linieFisier);
                    if (med.Nume == nume && med.Name == name)
                        return med;
                }
            }

            Medicament m = new Medicament();
            return m;
        }

        public int GetNrMed()
        {
            int nr_med = 0;
            using (StreamReader streamReader = new StreamReader(numeFisier))
            {
                while (streamReader.ReadLine() != null)
                {
                    nr_med++;
                }
            }

            return nr_med;
        }
    }
}

