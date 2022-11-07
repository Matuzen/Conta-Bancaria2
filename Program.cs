using System;
using System.Globalization;
using Conta.Entities;


namespace Conta
{
    class Program
    {
        static void Main(string[] args)
        {
            ContaBancaria contaBancaria;
            Console.Write("Entre o número da conta: ");
            int numero = int.Parse(Console.ReadLine());
            Console.Write("Entre o titular da conta: ");
            string titular = Console.ReadLine();
            Console.Write("Haverá depósito inicial? (s/n) ");
            char resp = char.Parse(Console.ReadLine());

            if (resp == 's' || resp == 'S')
            {
                Console.Write("Entre o valor do depósito inicial: ");
                double depositoInicial = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                contaBancaria = new ContaBancaria(numero, titular, depositoInicial);
            }

            else
            {
                contaBancaria = new ContaBancaria(numero, titular);
            }

            Console.WriteLine();
            Console.WriteLine("Dados da conta:");
            Console.Write(contaBancaria);

            Console.WriteLine();
            Console.Write("Entre um valor para depósito: ");
            double valor = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            contaBancaria.Deposito(valor);
            Console.WriteLine();
            Console.WriteLine("Dados da conta atualizados: ");
            Console.WriteLine(contaBancaria);
            Console.WriteLine();
            Console.Write("Entre um valor para saque: ");
            valor = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            contaBancaria.Saque(valor);
            Console.WriteLine("Dados da conta atualizados: ");
            Console.WriteLine(contaBancaria);
           
            Console.WriteLine();
            Console.Write("Deseja agendar um pagamento? (s/n) ");
            resp = char.Parse(Console.ReadLine());

            if (resp == 's' || resp == 'S')
            {
                Console.Write("Entre com a data (dd/MM/yyyy): ");
                DateTime data = DateTime.Parse(Console.ReadLine());
                if (data < DateTime.Now)
                {
                    Console.WriteLine("Erro: A data nao pode ser menor do que hoje! ");
                }

                Console.Write("Digite o valor do boleto: ");
                double boleto = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                if (boleto > contaBancaria.Saldo)
                {
                    Console.WriteLine("Erro: O valor do boleto ultrapassa o seu saldo");
                }

                else
                {
                    contaBancaria.Boleto(boleto);
                    Console.WriteLine("Dados atualizados: " + contaBancaria);
                }
            }

        }
    }
}
