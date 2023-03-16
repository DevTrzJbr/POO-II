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

		Contato.imprimir();



    }


}

public class AgendaTelefonica
{
    Dictionary<string, string> Agenda;

    public AgendaTelefonica()
    {
        Agenda = new Dictionary<string, string>();
    }

    public void inserir(string nome, string numero)
    {
        Agenda.Add(nome, numero);
    }

    public string buscaNumero(string nome)
    {
		string numeroBuscado;
        if (Agenda.TryGetValue(nome, out numeroBuscado))
        {
            return "O número de " + nome + " é " + numeroBuscado;
        }
        return "O número de " + nome + " não existe!";
    }

    public void remover(string nome)
    {
        if (Agenda.Remove(nome))
        {
            Console.WriteLine(nome + " foi removido da lista!");
        }
    }

    public int tamanho()
    {
        return Agenda.Count;
    }

    public void imprimir()
    {
        foreach (string chave in Agenda.Keys)
        {
            Console.WriteLine("Nome: " + chave);
            Console.WriteLine("Numero: " + Agenda[chave] + "\n\n");
        }
    }
}