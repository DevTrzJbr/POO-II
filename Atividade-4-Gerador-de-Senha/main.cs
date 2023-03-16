using System;
using System.Collections.Generic;

class Program
{
    public static void Main(string[] args)
    {
		int input = 0;
		bool validInput = false;

		Senha senha = new Senha(); // Cria um objeto senha da classe Senha.
		
        do
        {
			validInput = false;

			// Impede que o menu quebre caso o usuário aperte ENTER sem digitar um número.
			while (!validInput)
			{
				Console.Clear();
				// Menu da aplicação.
	            Console.WriteLine("_______MENU DE SENHA_______");
	            Console.WriteLine("[1] Pegar Senha\n[2] Chamar Senha\n[3] Fechar Programa");
	            Console.Write("Digite uma opção: ");
			    string userInput = Console.ReadLine();
			
			    if (int.TryParse(userInput, out input))
			    {
			        validInput = true;
			    }
			    else
			    {
					/*
					*	Cada read e clear serve para pausar o sistema 
					*	antes de seguir para a proxima função.
					*/
			        Console.Write("Entrada inválida! Por favor, tente novamente. (Press Enter)");
					Console.Read();
					Console.Clear();
			    }
			}
            switch (input)
            {
                case 1:
					Console.Clear();
					senha.pegaSenha();

					// Pausa o programa para ver o resultado.
					Console.Write("(Press Enter)");
					Console.Read();
                    break;

                case 2:
					Console.Clear();
                    senha.chamaSenha();

					// Pausa o programa para ver o resultado.
					Console.Write("(Press Enter)");
					Console.Read();
                    break;

                case 3:
					Console.Clear();
                    Console.WriteLine("Saindo...");
                    break;

                default:
					Console.Clear();

					// Pausa o programa para ver o resultado.
                    Console.WriteLine("Opcao Invalida! (Press Enter)");
					Console.Read();
                    break;
            }

        } while (input != 3);
    }
}

public class Senha
{
	private Queue<int> senha;
	int numeroSenha = 0;

	// Constructor inicia a pilha quando cria um novo objeto.
	public Senha()
	{
		senha = new Queue<int>();
	}

	public void pegaSenha(){
		senha.Enqueue(++numeroSenha); // Adiciona o numero da senha dentro da pilha.
		Console.WriteLine("Sua senha é: " + numeroSenha); // Mostra o número para o usuário.
	}

	public void chamaSenha()
	{
		senha.TryDequeue(out int result); // Tenta retornar algum resultado da pilha. Caso pilha vazia retorna 0.
		if(result != 0)
		{
			Console.WriteLine("A senha da vez é: " + result); // Mostra a senha chamada da pilha.
		} else {
			Console.WriteLine("Fila Vazia");
			numeroSenha = 0; // Zera o numero das senhas caso a fila esteja vazia.
		}
	}
}