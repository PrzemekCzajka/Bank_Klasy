using System;

namespace BankApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ListaKlientow listaKlientow = new ListaKlientow();
     
            bool wyjscie = false;
            while (!wyjscie)
            {
                Console.WriteLine("Witaj w aplikacji Banku Vivaldich!");
                Console.WriteLine("1. Sprawdź listę klientów");
                Console.WriteLine("2. Zaloguj się");
                Console.WriteLine("3. Wyjdź z aplikacji");
                Console.Write("Wybierz opcję: ");

                string opcja = Console.ReadLine();

                switch (opcja)
                {
                    case "1":
                        WyswietlListeKlientow(listaKlientow);
                        break;
                    case "2":
                        Zaloguj(listaKlientow);
                        break;
                    case "3":
                        wyjscie = true;
                        break;
                    default:
                        Console.WriteLine("Nieprawidłowa opcja.");
                        break;
                }

                Console.WriteLine();
            }
        }
        

        static void WyswietlListeKlientow(ListaKlientow listaKlientow)
        {
            Console.WriteLine("Lista klientów:");
            foreach (var klient in listaKlientow.PobierzListeKlientow())
            {
                Console.WriteLine($"ID: {klient.Id}, Imię i nazwisko: {klient.ImieNazwisko}, Nr konta: {klient.NrKonta}, Saldo: {klient.Saldo} ZŁ");
            }
        }

        static void Zaloguj(ListaKlientow listaKlientow)
        {
            Console.Write("Podaj ID klienta: ");
            int id = int.Parse(Console.ReadLine());

            Klient zalogowanyKlient = Logowanie.Zaloguj(id, listaKlientow);
            if (zalogowanyKlient != null)
            {
                Console.WriteLine("Zalogowano jako klient o ID: " + id);
                WykonajOperacje(zalogowanyKlient, listaKlientow);
            }
            else
            {
                Console.WriteLine("Klient o podanym ID nie został znaleziony.");
            }
        }

        static void WykonajOperacje(Klient zalogowanyKlient, ListaKlientow listaKlientow)
        {
            Console.WriteLine("Wybierz opcję:");
            Console.WriteLine("1. Przelew");
            Console.WriteLine("2. Wyloguj");

            string opcja = Console.ReadLine();

            switch (opcja)
            {
                case "1":
                    WykonajPrzelew(zalogowanyKlient, listaKlientow);
                    break;
                case "2":
                    Console.WriteLine("Wylogowano.");
                    break;
                default:
                    Console.WriteLine("Nieprawidłowa opcja.");
                    break;
            }
        }

        static void WykonajPrzelew(Klient zalogowanyKlient, ListaKlientow listaKlientow)
        {
            Console.Write("Podaj numer konta odbiorcy: ");
            int nrKontaOdbiorcy = int.Parse(Console.ReadLine());

            Console.Write("Podaj kwotę do przelania: ");
            decimal kwota = decimal.Parse(Console.ReadLine());

            Klient odbiorca = null;
            foreach (var klient in listaKlientow.PobierzListeKlientow())
            {
                if (klient.NrKonta == nrKontaOdbiorcy)
                {
                    odbiorca = klient;
                    break;
                }
            }

            if (odbiorca == null)
            {
                Console.WriteLine("Konto odbiorcy nie zostało znalezione.");
                return;
            }

            if (Przelew.WykonajPrzelew(zalogowanyKlient, odbiorca, kwota))
            {
                Console.WriteLine("Saldo po wykonaniu przelewu:");
                Console.WriteLine($"Twój stan konta: {zalogowanyKlient.Saldo} ZŁ");
                Console.WriteLine($"Stan konta odbiorcy: {odbiorca.Saldo} ZŁ");
            }
        }
    }
}