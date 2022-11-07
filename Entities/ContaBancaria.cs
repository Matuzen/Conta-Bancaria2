using System.Globalization;
using Conta.Entities;

namespace Conta.Entities
{
     class ContaBancaria
    {
        public int Numero { get; private set; } // O n° da conta nao pode ser alterado, mas pode ser acessado
        public string Titular { get; set; }
        public double Saldo { get; private set; }

        public ContaBancaria(int numero, string titular)
        {
            Numero = numero;
            Titular = titular;
            Saldo = 0.0;
        }

        public ContaBancaria(int numero, string titular, double depositoInicial) : this(numero, titular) // Reaproveitar os dois comandos 
        {
            Deposito(depositoInicial);
        }

        public void Deposito(double quantia)
        {
            Saldo += quantia;
            
        }

        public void Saque(double quantia)
        {
            Saldo -= quantia + 5.0; // Quantia + 5.0 que será descontado
            
        }

        public void Boleto(double quantia)
        {
            Saldo -= quantia;
        }

        public override string ToString()
        {
            return "Conta "
                + Numero
                + ", Titular: "
                + Titular
                + ", Saldo: $ "
                + Saldo.ToString("F2", CultureInfo.InvariantCulture); 
        }

    }
}
