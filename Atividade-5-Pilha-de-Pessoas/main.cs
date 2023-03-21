using System;
using System.Collections.Generic;

class Program
{	
	static Stack<Pessoa> pilhaPessoas; // Define pilha de pessoas.
	
	static void InserirPessoa()
	{
		bool longCpf = false; // Tratamento de erro
		
		while(!longCpf)
		{
			Console.Clear();
			Console.WriteLine("_______Registro de Pessoa_______");
			
			Console.Write("\nDigite seu nome: ");
			string nome = Console.ReadLine();
			
			Console.Write("\nDigite seu CPF: ");
			string input = Console.ReadLine();

			longCpf = long.TryParse( input, out long cpf); // Tratamento de erro

			if(longCpf)
			{
				pilhaPessoas.Push(new Pessoa(nome, cpf)); // Empurra nova pessoa na pilha.
	
				Console.WriteLine($"\nPessoa {nome} Adicionada!");
			}
			else
			{
				Console.WriteLine("\nDigito CPF invalido!");
			}
			
			Console.WriteLine("\nPress [Enter] para continuar!");
			Console.Read();
			Console.Clear();
		}
	}

	static void RemoverPessoa()
	{
		Console.Clear();
		Console.WriteLine("_______Remove Pessoa_______");
		
		bool temPessoa = pilhaPessoas.TryPop(out Pessoa p); // Tenta Remover pessoa da pilha, 
		if(temPessoa) 										// se não estiver vazia.
		{
			Console.WriteLine($"\nPessoa {p.nome} Removida!");
		} 
		else 
		{
			Console.WriteLine($"\nPilha Vazia!");
		}

		Console.WriteLine("\nPress [Enter] para continuar!");
		Console.Read();
		Console.Clear();
	}
	
	static void MostrarPessoa()
	{
		Console.Clear();
		Console.WriteLine("_______Pilha de Pessoa_______");
		
		if(pilhaPessoas.Count == 0) 
		{
			Console.WriteLine("\nPilha Vazia!");
		}
		else 
		{
			foreach (Pessoa p in pilhaPessoas) 							// Busca cada pessoa da pilha.
			{
				Console.WriteLine($"\n Nome: {p.nome} - Cpf: {p.cpf}");	// Mostra cada pessoa da pilha.
			}
			
		}

		Console.WriteLine("\nPress [Enter] para continuar!");
		Console.Read();
		Console.Clear();
	}

	static void PessoasTest()
	{
		pilhaPessoas.Push(new Pessoa("João Victor", 123));
		pilhaPessoas.Push(new Pessoa("Roberto Bastos", 234));
		pilhaPessoas.Push(new Pessoa("Gui Lasteca", 345));
		pilhaPessoas.Push(new Pessoa("Daniel Bravo", 456));
		pilhaPessoas.Push(new Pessoa("André Pato", 567));
	}
	
    public static void Main(string[] args)
    {
		int input = 0;
		bool validInput = false;

		pilhaPessoas = new Stack<Pessoa>(); // Cria a pilha de pessoas.
		PessoasTest();						// Teste inicial de pessoas na pilha.
		
        do
        {
			validInput = false;

			// Impede que o menu quebre caso o usuário aperte ENTER sem digitar um número.
			while (!validInput)
			{
				Console.Clear();
				// Menu da aplicação.
	            Console.WriteLine("_______MENU DE PESSOA_______");
	            Console.WriteLine("[1] Insira Pessoa\n[2] Remove Pessoa\n[3] Mostra Pilha de Pessoas\n[4] Fechar Programa");
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
			
			switch(input)
			{
			case 1:
				InserirPessoa();
				break;
	
			case 2: 
				RemoverPessoa();
				break;
	
			case 3:
				MostrarPessoa();
				break;

			case 4:
				Console.WriteLine("Saindo..");
				break;

			default:
				Console.WriteLine("Digito invalido!");
				break;
			}

        } while (input != 4);
		
    }
}

public class Pessoa
{
	public string nome;
	public long cpf;
	
	public Pessoa(string nome, long cpf) // Constructor Pessoa.
	{
		this.nome = nome;
		this.cpf = cpf;
	}
}