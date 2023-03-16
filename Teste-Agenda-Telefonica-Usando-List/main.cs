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

        Console.WriteLine("A agenda possui " + Contato.tamanho() + " contatos na lista!\n\n");

        Contato.imprimir();



    }


}

public class Contato
{

    public string Nome;
    public string Numero;

    public Contato(string nome, string numero)
    {
        this.Nome = nome;
        this.Numero = numero;
    }

}

public class AgendaTelefonica
{
    List<Contato> Agenda;

    public AgendaTelefonica()
    {
        Agenda = new List<Contato>();
    }

    public void inserir(string nome, string numero)
    {
        Agenda.Add(new Contato(nome, numero));
        Console.WriteLine("O Contato de " + nome + " foi adicionado a agenda!\n\n");
    }

    public string buscaNumero(string nome)
    {

        if (Agenda.Exists(c => c.Nome == nome))
        {
            Contato contato = Agenda.Find(c => c.Nome == nome);
            return "O número de " + nome + " é " + contato.Numero + "\n\n";
        }
        return "O número de " + nome + " não existe!\n\n";
    }

    public void remover(string nome)
    {
        if (Agenda.Exists(c => c.Nome == nome))
        {
            Contato contato = Agenda.Find(c => c.Nome == nome);
            Agenda.Remove(contato);
            Console.WriteLine("O contato de " + nome + " foi removido da Agenda!\n\n");
        }
        else
        {
            Console.WriteLine("O contato de " + nome + " não existe!\n\n");
        }
    }

    public int tamanho()
    {
        return Agenda.Count;
    }

    public void imprimir()
    {
        foreach (Contato contato in Agenda)
        {
            Console.WriteLine("Nome: " + contato.Nome);
            Console.WriteLine("Numero: " + contato.Numero + "\n\n");
        }
    }
}