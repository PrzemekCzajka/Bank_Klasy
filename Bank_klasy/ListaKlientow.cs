using System.Collections.Generic;

namespace BankApp
{
    public class ListaKlientow
    {
        private List<Klient> listaKlientow;

        public ListaKlientow()
        {
            listaKlientow = StworzPrzykladowychKlientow();
        }

        public void DodajKlienta(Klient klient)
        {
            listaKlientow.Add(klient);
        }

        public List<Klient> PobierzListeKlientow()
        {
            return listaKlientow;
        }

        private List<Klient> StworzPrzykladowychKlientow()
        {
            return new List<Klient>
            {
                new Klient(1, "Geralt z Rivii", 111, 1000.0m),
                new Klient(2, "Yennefer z Vengerbergu", 222, 2000.0m),
                new Klient(3, "Triss Merigold", 333, 1500.0m),
                new Klient(4, "Cirilla Fiona Elen Riannon", 444, 3000.0m),
                new Klient(5, "Julian Alfred Pankratz", 555, 2500.0m)
            };
        }
    }
}