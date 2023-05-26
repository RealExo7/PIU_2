using LibrarieModele;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace NivelStocareDate
{
    public class AdministrareFisier
    {
        private string numeFisier;

        public AdministrareFisier(string numeFisier)
        {
            this.numeFisier = numeFisier;
        }

        public void ScrieInFisier(List<Cheltuiala> cheltuieli)
        {
            using (StreamWriter writer = new StreamWriter(numeFisier, true))
            {
                foreach (Cheltuiala cheltuiala in cheltuieli)
                {
                    string linie = $"{cheltuiala.Categoria},{cheltuiala.Suma},{cheltuiala.Data}";
                    writer.WriteLine(linie);
                }
            }
        }

        public List<Cheltuiala> CitesteDinFisier()
        {
            List<Cheltuiala> cheltuieli = new List<Cheltuiala>();

            using (StreamReader reader = new StreamReader(numeFisier))
            {
                string linie;
                while ((linie = reader.ReadLine()) != null)
                {
                    string[] detalii = linie.Split(',');
                    if (detalii.Length == 3)
                    {
                        string categoria = detalii[0];
                        decimal suma = decimal.Parse(detalii[1]);
                        DateTime data = DateTime.Parse(detalii[2]);

                        Cheltuiala cheltuiala = new Cheltuiala(categoria, suma, data);
                        cheltuieli.Add(cheltuiala);
                    }
                }
            }

            return cheltuieli;
        }

        public void StergeCheltuieliDinFisier(List<Cheltuiala> cheltuieliDeSters)
        {
            List<Cheltuiala> cheltuieliExistente = CitesteDinFisier();

            // Elimină cheltuielile din lista existentă
            cheltuieliExistente.RemoveAll(c => cheltuieliDeSters.Any(cs => cs.Categoria == c.Categoria && cs.Suma == c.Suma && cs.Data == c.Data));

            // Sterge conținutul fișierului
            File.WriteAllText(numeFisier, string.Empty);

            // Scrie lista actualizată de cheltuieli în fișier
            ScrieInFisier(cheltuieliExistente);
        }


    }
}
