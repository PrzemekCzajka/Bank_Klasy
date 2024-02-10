using System;

namespace BankApp
{
    public class Przelew
    {
        public static bool WykonajPrzelew(Klient nadawca, Klient odbiorca, decimal kwota)
        {
            if (nadawca.Saldo < kwota)
            {
                Console.WriteLine("Niewystarczające środki na koncie.");
                return false;
            }

            nadawca.Saldo -= kwota;
            odbiorca.Saldo += kwota;
            Console.WriteLine("Przelew zrealizowany pomyślnie.");
            return true;
        }
    }
}