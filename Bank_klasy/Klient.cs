using System;

namespace BankApp
{
    public class Klient
    {
        public int Id { get; }
        public string ImieNazwisko { get; }
        public int NrKonta { get; }
        public decimal Saldo { get; set; }

        public Klient(int id, string imieNazwisko, int nrKonta, decimal saldo)
        {
            Id = id;
            ImieNazwisko = imieNazwisko;
            NrKonta = nrKonta;
            Saldo = saldo;
        }
    }
}