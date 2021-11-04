using System;

namespace BankAPI
{
    public class Conta
    {
        private TipoConta TipoConta { get; set; }
        private string Name {get; set; }
        private double Saldo {get; set; }
        private double Credito {get; set; }
        
        public Conta(TipoConta tipoConta, string name, double saldo, double credito)
        {
            this.TipoConta = tipoConta;
            this.Name = name;
            this.Saldo = saldo;
            this.Credito = credito;

        }
        public bool Sacar (double valorSaque)
        {
            //Validação de saldo suficiente
            if(this.Saldo - valorSaque <(this.Credito *-1))
            {
                Console.WriteLine("Saldo insuficiente");
                return false;                            
            } else if (valorSaque > this.Saldo)
            {
                Console.WriteLine("Esta operação consumirá parcialemente o seu crédito, estando sujeita a cobrança de juros. Deseja continuar?");
                Console.WriteLine("Digite 1 para Sim ou qualquer outra tecla para Não:");
                int opcaoUsuario = int.Parse(Console.ReadLine());
                if(opcaoUsuario != 1)
                {
                    Console.WriteLine("Você não confirmou a operação de saque.");
                    return false;
                }                                  
                
            }
            
            this.Saldo -= valorSaque;
            Console.WriteLine();
            Console.WriteLine("Saque de {0} relizado com sucesso!", valorSaque);
            Console.WriteLine();
            Console.WriteLine("O saldo atual da conta de {0} é de R$ {1}.", this.Name, this.Saldo);
            return true;
        }

        public void Depositar (double valorDeposito)
        {
            this.Saldo += valorDeposito;
            Console.WriteLine("O saldo atual da conta de {0} é de {1}", this.Name, this.Saldo);
        }

        public void Transferir(double valorTransferencia, Conta contaDestino)
        {
            if(this.Sacar(valorTransferencia))
            {
                contaDestino.Depositar(valorTransferencia);
            }
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "Tipo de Conta: " + this.TipoConta + " | ";
            retorno += "Nome: " + this.Name + " | ";
            retorno += "Saldo: R$ " + this.Saldo + " | ";
            retorno += "Crédito: R$ " + this.Credito + " | ";
            return retorno;
        }

    }
}