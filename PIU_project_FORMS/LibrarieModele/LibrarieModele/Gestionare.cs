using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarieModele
{
    public class Gestionare
    {
        private List<Cheltuiala> cheltuieli;

        public Gestionare()
        {
            cheltuieli = new List<Cheltuiala>();
        }

        public void AdaugaCheltuiala(string categoria, decimal suma, DateTime data)
        {
            Cheltuiala cheltuiala = new Cheltuiala(categoria, suma, data);
            cheltuieli.Add(cheltuiala);
        }

        public void AdaugaCheltuiala(Cheltuiala chelt)
        {
            
            cheltuieli.Add(chelt);
        }

        public List<Cheltuiala> SorteazaDupaCategorie()
        {
            cheltuieli.Sort((c1, c2) => c1.Categoria.CompareTo(c2.Categoria));
            return cheltuieli;
        }

        public List<Cheltuiala> SorteazaDupaSuma()
        {
            cheltuieli.Sort((c1, c2) => c1.Suma.CompareTo(c2.Suma));
            return cheltuieli;
        }

        public List<Cheltuiala> SorteazaDupaData()
        {
            cheltuieli.Sort((c1, c2) => c1.Data.CompareTo(c2.Data));
            return cheltuieli;
        }

        public List<Cheltuiala> CautaDupaCategorie(string categoria)
        {
            return cheltuieli.FindAll(cheltuiala => cheltuiala.Categoria.Equals(categoria));
        }
    }

    public class Cheltuiala
    {
        public string Categoria { get; set; }
        public decimal Suma { get; set; }
        public DateTime Data { get; set; }

        public Cheltuiala(string categoria, decimal suma, DateTime data)
        {
            Categoria = categoria;
            Suma = suma;
            Data = data;
        }
    }

}
