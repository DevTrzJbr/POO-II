using System;
using System.Collections.Generic;

class Program
{
    public static void Main(string[] args)
    {

        AgendaTelefonica Contato = new AgendaTelefonica();

		Contato.inserir("joao", "123");
		Contato.inserir("Andre", "321");
		Contato.inserir("JOse", "234");
		Contato.inserir("Barnabe", "345");
		Contato.inserir("Mileto", "456");

		Console.WriteLine(Contato.buscaNumero("joao"));

		Contato.remover("joao");

		Console.WriteLine(Contato.buscaNumero("joao"));

		Console.WriteLine(Contato.tamanho());

		
		
    }


}

public class AgendaTelefonica
{
    Dictionary<string, string> agenda = new Dictionary<string, string>();

    public void inserir(string nome, string numero)
    {
        agenda.Add(nome, numero);
    }

	public string buscaNumero(string nome){
		if(agenda.ContainsKey(nome)){
			return agenda.GetValueOrDefault(nome);
		}
		return "nao existe";
	}

	public void remover(string nome) {
		if(agenda.ContainsKey(nome)){
			 agenda.Remove(nome);
		}
	}

	public int tamanho(){
		return agenda.Count;
	}
}