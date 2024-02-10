using System;

namespace BankApp
{
    public class Logowanie
    {
        public static Klient Zaloguj(int id, ListaKlientow listaKlientow)
        {
            foreach (var klient in listaKlientow.PobierzListeKlientow())
            {
                if (klient.Id == id)
                {
                    return klient;
                }
            }
            return null;
        }
    }
}