using System;

class Conta
{

    public Conta() { }

    public string Name { get; set; }
    public long CPF { get; set; }
    public float saldo { get; set; }
    public string extrato = "\n\tExtrato\n";

    public Conta(string name, long cpf)
    {
        this.Name = name;
        this.CPF = cpf;
    }
    // Other properties, methods, events...

    public void sacar(float valor)
    {
		if(valor > this.saldo)
		{
			Console.WriteLine("\nSaldo insuficiente!");
		} 
		else 
		{
	        this.saldo = this.saldo - valor;
	        this.extrato = this.extrato + "\n------------\n\tSaque\n\n  -R$" + valor.ToString() + ";";
		}
    }

    public void depositar(float valor)
    {
        this.saldo = this.saldo + valor;
        this.extrato = this.extrato + "\n------------\n\tDeposito\n\n  +R$" + valor.ToString() + ";";
    }

    public void verSaldo()
    {
        Console.WriteLine("\nSaldo: " + this.saldo);
    }

    public float getSaldo()
    {
        return this.saldo;
    }

    public void verExtrato()
    {
        Console.WriteLine(this.extrato + "\n\n#####################\n\nSaldo Total : R$" + this.saldo + "\n-------------------------");

    }
}