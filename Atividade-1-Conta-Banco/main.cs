using System;
using System.Collections.Generic;

class Program
{

    static List<Conta> listaContas;

    public static void Main(string[] args)
    {

        listaContas = new List<Conta>();

        void headerConta(Conta conta)
        {
            Console.WriteLine("-----------------------\n\t CONTA DE " + conta.Name.ToUpper() + "\n\tSaldo R${0}\n-----------------------", conta.saldo);
        }

        void pressEnter()
        {
            Console.Write("\nPressione ENTER");
            Console.ReadLine();
        }

        int trataErroInput(string varStr)
        {
            var opcao = 0;
            if (int.TryParse(varStr, out opcao)) // TryParse returns a boolean showing whether the parse worked
            {
                // then perform your behavior safely
                return opcao;
            }

            opcao = 5;

            return opcao;
        }

        int menuPrincipal()
        {
            int opcao;
            Console.Clear();
            Console.WriteLine("\n\t\tPrograma Bancario\n\n");
            Console.WriteLine("[1] Entra de Conta;\n[2] Registro de Conta;\n[0] Sair;");
            Console.Write("Digite o número da acão: ");

            string input = Console.ReadLine();

            opcao = trataErroInput(input);

            return opcao;

        }

        void loginConta()
        {
            Console.Clear();
            Console.WriteLine("\n\tLogin de Conta");

            Console.Write("\nDigite seu cpf: ");
            //long cpf = long.Parse(Console.ReadLine());

            string input = Console.ReadLine();
            long cpf;

            if (long.TryParse(input, out cpf)) // TryParse returns a boolean showing whether the parse worked
            {
                // then perform your behavior safely
                if (listaContas.Exists(c => c.CPF == cpf))
                {
                    Conta conta = listaContas.Find(c => c.CPF == cpf);
                    Console.WriteLine("\nBem Vindo " + conta.Name + "!");

                    pressEnter();

                    menuOpcoes(conta);

                }
                else
                {
                    Console.WriteLine("\nA conta de CPF: " + cpf + " não existe!");
                    pressEnter();

                }
            }
            else
            {
                loginConta();
            }

        }

        void criaConta()
        {
            Console.Clear();
            Console.WriteLine("\n\t\tRegistro de Conta");

            Console.Write("\nDigite seu nome: ");
            string nome = Console.ReadLine();

            Console.Write("\nDigite seu cpf: ");
            //long cpf = long.Parse(Console.ReadLine());

            string input = Console.ReadLine();
            long cpf;

            if (long.TryParse(input, out cpf)) // TryParse returns a boolean showing whether the parse worked
            {
                // then perform your behavior safely
                listaContas.Add(new Conta(nome, cpf));

                Console.WriteLine("\nConta criada com sucesso!");
            }
            else
            {
                Console.WriteLine("\nErro de digitação!");
                pressEnter();
                criaConta();
            }

            pressEnter();

        }

        void saque(Conta conta)
        {
            Console.Clear();

            headerConta(conta);
            Console.WriteLine("\n\t\tSaque");

            Console.WriteLine("Saldo disponivel: R$" + conta.getSaldo());

            Console.Write("\nDigite valor a sacar: (R$)");
            //float valor = float.Parse(Console.ReadLine());

            string input = Console.ReadLine();
            float valor;

            if (float.TryParse(input, out valor)) // TryParse returns a boolean showing whether the parse worked
            {
                // then perform your behavior safely
                conta.sacar(valor);
                conta.verSaldo();


                pressEnter();

            }
            else
            {
                Console.WriteLine("\nErro de digitação!");
                pressEnter();
                saque(conta);
            }

        }

        void deposito(Conta conta)
        {

            Console.Clear();

            headerConta(conta);
            Console.WriteLine("\n\t\tDeposito");

            Console.WriteLine("Saldo disponivel: R$" + conta.getSaldo());

            Console.WriteLine("\nDigite valor a depositar: (R$)");
            // float valor = float.Parse(Console.ReadLine());

            string input = Console.ReadLine();
            float valor;

            if (float.TryParse(input, out valor)) // TryParse returns a boolean showing whether the parse worked
            {
                // then perform your behavior safely

                conta.depositar(valor);
                conta.verSaldo();

                pressEnter();
            }
            else
            {
                Console.WriteLine("\nErro de digitação!");
                pressEnter();
                deposito(conta);
            }
        }


        void menuOpcoes(Conta conta)
        {

            int opcao = 1;

            while (opcao != 0)
            {

                Console.Clear();

                headerConta(conta);

                Console.WriteLine("\n\tMenu de Opções");

                Console.WriteLine("[1] sacar;\n[2] depositar;\n[3] Extrato;\n[0] Desconectar");
                Console.Write("Digite o número da acão: ");

                string input = Console.ReadLine();

                opcao = trataErroInput(input);

                switch (opcao)
                {
                    case 1:
                        saque(conta);
                        break;

                    case 2:
                        deposito(conta);
                        break;

                    case 3:
                        Console.Clear();

                        headerConta(conta);
                        conta.verExtrato();

                        pressEnter();
                        break;
					
                    case 0:

                        Console.WriteLine("\nVolte sempre " + conta.Name + "!");
                        pressEnter();
                        break;
					
                    default:
                        Console.WriteLine("\nOpção Invalida!");
                        pressEnter();
                        break;
                }
            }
        }

        Conta test = new Conta("test", 123);
        listaContas.Add(test);
        test.depositar(1000);

        int opcao = 1;

        // SISTEMA PRINCIPAL

        while (opcao != 0)
        {

            opcao = menuPrincipal();

            switch (opcao)
            {
                case 1:
                    loginConta();

                    break;

                case 2:
                    criaConta();
                    break;

                case 0:
					Console.Clear();
                    Console.WriteLine("Saindo...");
                    break;

                default:
                    Console.WriteLine("\nOpção Invalida!");
                    pressEnter();
                    break;
            }
        }

    }
}


