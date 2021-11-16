using System;
using System.Collections.Generic;

namespace BankAPI
{
    class Program
    {
        static List<Conta> listaContas = new List<Conta>();        
        static void Main(string[] args)
        {
            Console.WriteLine("BankAPI a seu dispor!");
            string opcaoUsuario = ObterOpcaoUsuario();
            while (opcaoUsuario.ToUpper() != "X")
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
						Transferencia();
						break;
					case "4":
						Saque();
						break;
					case "5":
						Deposito();
						break;
                    case "C":
						Console.Clear();
						break;

					default:
						Console.WriteLine("Opção inválida. Pressione qualquer tecla para retornar ao menu inicial.");
						Console.ReadLine();
						break;                      
				}

				opcaoUsuario = ObterOpcaoUsuario();
			}
			
			Console.WriteLine("Obrigado por utilizar nossos serviços. Aperte qualquer botão para finalizar a sessão.");
			Console.ReadLine();
            Console.WriteLine("Sessão finalizada");
        }
        private static void ListarContas()
		{
			Console.WriteLine("Contas existentes:");
            Console.WriteLine();

			if (listaContas.Count == 0)
			{
				Console.WriteLine("Nenhuma conta cadastrada!");
				return;
			}

			for (int i = 0; i < listaContas.Count; i++)
			{
				Conta conta = listaContas[i];
				Console.Write("#{0} - ", i);
				Console.WriteLine(conta);  
			}
		}

        private static void Transferencia()
		{
			Console.Write("Digite o número da conta de origem: ");
			int indiceContaOrigem = int.Parse(Console.ReadLine());
			//Verifica a existência da conta indicada / Checks if the account exists.
			while (0 > indiceContaOrigem || indiceContaOrigem +1 > listaContas.Count)
			{
				Console.WriteLine("Conta inexistente. Digite o número da conta: ");
				indiceContaOrigem = int.Parse(Console.ReadLine());
			}

            Console.Write("Digite o número da conta de destino: ");
			int indiceContaDestino = int.Parse(Console.ReadLine());
			//Verifica a existência da conta indicada / Checks if the account exists.
			while (0 > indiceContaDestino || indiceContaDestino +1 > listaContas.Count)
			{
				Console.WriteLine("Conta inexistente. Digite o número da conta: ");
				indiceContaDestino = int.Parse(Console.ReadLine());
			}

			Console.Write("Digite o valor a ser transferido: ");
			double valorTransferencia = double.Parse(Console.ReadLine());

            listaContas[indiceContaOrigem].Transferir(valorTransferencia, listaContas[indiceContaDestino]);
		}
        private static void Saque()
		{
			Console.Write("Digite o número da conta: ");
			int indiceConta = int.Parse(Console.ReadLine());
			//Verifica a existência da conta indicada / Checks if the account exists.
			while (0 > indiceConta || indiceConta +1 > listaContas.Count)
			{
				Console.WriteLine("Conta inexistente. Digite o número da conta: ");
				indiceConta = int.Parse(Console.ReadLine());
			}		

			Console.Write("Digite o valor a ser sacado: ");
			double valorSaque = double.Parse(Console.ReadLine());

            listaContas[indiceConta].Sacar(valorSaque);
		}
        private static void Deposito()
		{
			Console.Write("Digite o número da conta: ");
			int indiceConta = int.Parse(Console.ReadLine());
			//Verifica a existência da conta indicada / Checks if the account exists.
			while (0 > indiceConta || indiceConta +1 > listaContas.Count)
			{
				Console.WriteLine("Conta inexistente. Digite o número da conta: ");
				indiceConta = int.Parse(Console.ReadLine());
			}	
 
			Console.Write("Digite o valor a ser depositado: ");
			double valorDeposito = double.Parse(Console.ReadLine());

            listaContas[indiceConta].Depositar(valorDeposito);
		}

        private static void InserirConta()
        {
            Console.WriteLine("Inserir nova conta");

			Console.Write("Digite 1 para Conta Física ou 2 para Conta Jurídica: ");
			int entradaTipoConta = int.Parse(Console.ReadLine());
            while (entradaTipoConta < 1 || entradaTipoConta > 2)
            {				
                Console.WriteLine("Tipo de conta inexistente. Digite 1 para Conta Física ou 2 para Conta Jurídica: ");
                entradaTipoConta = int.Parse(Console.ReadLine());
            }

			Console.Write("Digite o nome do cliente: ");
			string entradaNome = Console.ReadLine();

			Console.Write("Digite o saldo inicial: ");
			double entradaSaldo = double.Parse(Console.ReadLine());

			Console.Write("Digite o valor do crédito disponível do cliente: ");
			double entradaCredito = double.Parse(Console.ReadLine());

			Conta novaConta = new Conta(tipoConta: (TipoConta)entradaTipoConta,
										saldo: entradaSaldo,
										credito: entradaCredito,
										name: entradaNome);

			listaContas.Add(novaConta);
            Console.WriteLine("Nova conta adicionada em nome de {0}!", entradaNome);
		}
    
		//Menu Inicial / Start Menu
        private static string ObterOpcaoUsuario()
        {
			Console.WriteLine();
            Console.WriteLine("### Menu Inicial ###");
            Console.WriteLine();
            Console.WriteLine("Informe a opção desejada:");
            Console.WriteLine();
            Console.WriteLine("1- Listar contas");
            Console.WriteLine("2- Inserir nova conta");
            Console.WriteLine("3- Transferência");
            Console.WriteLine("4- Saque");
            Console.WriteLine("5- Depósito");
            Console.WriteLine("C- Limpar Tela");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
