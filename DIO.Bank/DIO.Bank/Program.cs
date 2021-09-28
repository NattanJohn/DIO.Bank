using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIO.Bank
{
    class Program
    {
        static List<Conta> listContas = new List<Conta>();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();
            while(opcaoUsuario !="7")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarContas();
                        break;
                    case "2":
                        InserirConta();
                        break;
                    case "3":
                        Transferir();
                        break;
                    case "4":
                        Sacar();
                        break;
                    case "5":
                        Depositar();
                        break;
                    case "6":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }
                opcaoUsuario = ObterOpcaoUsuario();
            }
            Console.WriteLine("Obrigado por usar os serviços da John Bank's");
            Console.ReadLine();
        }

        private static void Transferir()
        {
            Console.Write("Digite o numero da conta de origem: ");
            int indiceContaOrigem = int.Parse(Console.ReadLine());

            Console.Write("Digite o numero da conta de destino: ");
            int indiceContaDestino = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor que você quer transferir");
            double valorTransferencia = double.Parse(Console.ReadLine());

            listContas[indiceContaOrigem].Transferir(valorTransferencia, listContas[indiceContaDestino]);
        }

        private static void Sacar()
        {
            Console.Write("Digite o numero da sua conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor que você quer sacar: ");
            double valorSaque = double.Parse(Console.ReadLine());

            listContas[indiceConta].Sacar(valorSaque);

        }

        private static void Depositar()
        {
            Console.Write("Digite o numero da sua conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor que você quer depositar: ");
            double valorDeposito = double.Parse(Console.ReadLine());

            listContas[indiceConta].Depositar(valorDeposito);

        }
        private static void InserirConta()
        {
            Console.WriteLine("Inserir nova Conta");

            Console.WriteLine("Digite 1 para conta fisica ou 2 para conta juridica: ");
            int entradaTipoConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Informe o nome do cliente: ");
            string entradaNome = Console.ReadLine();

            Console.WriteLine("Informe o saldo inicial: ");
            double entradaSaldo = double.Parse(Console.ReadLine());

            Console.WriteLine("Informe o crédito: ");
            double entradaCredito = double.Parse(Console.ReadLine());

            Conta novaConta = new Conta(tipoConta: (TipoConta)entradaTipoConta, 
                saldo: entradaSaldo, 
                credito: entradaCredito, 
                nome: entradaNome);
            listContas.Add(novaConta);
        }

        private static void ListarContas()
        {
            Console.WriteLine("Listar Contas");

            if (listContas.Count ==0)
            {
                Console.WriteLine("Nenhuma conta cadastrada!");
                return;
            }
            for (int i=0; i <listContas.Count; i++)
            {
                Conta conta = listContas[i];
                Console.Write("#{0} - ", i);
                Console.WriteLine(conta);

            }
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("John Bank's ao seus serviços");
            Console.WriteLine(" Informe a opção desejada");

            Console.WriteLine("1 - Listar Contas");
            Console.WriteLine("2 - Criar nova Conta");
            Console.WriteLine("3 - Transferir");
            Console.WriteLine("4 - Sacar");
            Console.WriteLine("5 - Depositar");
            Console.WriteLine("6 - Limpar Tela");
            Console.WriteLine("7 - Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
