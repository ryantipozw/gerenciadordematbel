using GerenciadorDeMaterialBelico.Itens;
using GerenciadorDeMaterialBelico.Menus;

public class Program
{
    static void Main(string[] args)
    {
        MenuInicial.MostrarMenu();
        var opcaoDigitada = int.Parse(Console.ReadLine());
        try
        {
            switch (opcaoDigitada)
            {
                case 1: 
                    Console.Clear();
                    MenuAdicionarArmamento.MostrarMenu(); break;
                case 2: 
                    Console.Clear();
                    MenuAtualizarArmamento.MostrarMenu(); break;
                case 3: 
                    Console.Clear();
                    MenuAdicionarPecas.MostrarMenu(); break;
                case 4:
                    Console.Clear();
                    MenuConsultarArmamento.MostrarMenu(); break;
                case 0:
                    Console.Clear();
                    for (int i = 0; i < 2; i++)
                    {
                        Console.WriteLine("Saindo do programa.");
                        Thread.Sleep(500);
                        Console.Clear();
                        Console.WriteLine("Saindo do programa..");
                        Thread.Sleep(500);
                        Console.Clear();
                        Console.WriteLine("Saindo do programa...");
                        Thread.Sleep(500);
                        Console.Clear();
                    } break;



                default: Console.WriteLine("Digite uma opção válida!"); break;
            }
        }
        catch 
        {

        }
    }
}
