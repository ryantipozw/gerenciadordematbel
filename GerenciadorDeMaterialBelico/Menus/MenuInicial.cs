using GerenciadorDeMaterialBelico.Exceptions;
using GerenciadorDeMaterialBelico.Itens;
using GerenciadorDeMaterialBelico.Listagem;
using System.Text.Json;

namespace GerenciadorDeMaterialBelico.Menus;

internal class MenuInicial : IMenu
{
    public void MostrarMenu()
    {
        Enfeites.Titulo("Gerenciador de Material Bélico - TG 02-026");
        IMenu.Write("1.Adicionar Armamento\n");
        IMenu.Write("2.Atualizar Armamento\n");
        IMenu.Write("3.Adicionar Peças (Indisponível)\n");
        IMenu.Write("4.Consultar Armamento\n");
        IMenu.Write("0.Sair do programa\n\n");
        IMenu.WriteInput("Selecione uma opção acima: ");
        try
        {
        var opcaoDigitada = int.Parse(Console.ReadLine());
            switch (opcaoDigitada)
            {
                case 1:
                    Console.Clear();
                    MenuAdicionarArmamento menuAdicionarArmamento = new();
                    menuAdicionarArmamento.MostrarMenu(); break;
                case 2:
                    Console.Clear();
                    MenuAtualizarArmamento menuAtualizarArmamento = new();
                    menuAtualizarArmamento.MostrarMenu(); break;
                case 3:
                    Console.Clear();
                    MenuAdicionarPecas menuAdicionarPecas = new();
                    menuAdicionarPecas.MostrarMenu(); break;
                case 4:
                    Console.Clear();
                    MenuConsultarArmamento menuConsultarArmamento = new();
                    menuConsultarArmamento.MostrarMenu(); break;
                case 5:
                    Console.Clear();

                    ListaDeFuzis.Serializar();

                    Console.ReadKey(); break;
                case 6:
                    Console.Clear();

                    for (int i = 5; i < 100; i++)
                    {
                        MQ762M968 fuzil = new(i, true, true, true, true);
                        ListaDeFuzis.AdicionarFuzil(i, fuzil);
                    }

                    Console.ReadKey(); break;
                case 0:
                    Console.Clear();
                    string text = "TG 02-026 --- Aqui se aprende a ser combatente, aqui é formado um bom cidadão.";
                    Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n\n");
                    Console.Write("                      ");
                    foreach (var letra in text)
                    {
                        Console.Write(letra);
                        Thread.Sleep(10);
                    }
                    Thread.Sleep(1500);
                    break;

                default:
                    Console.WriteLine("");
                    IMenu.Write("Digite uma opção válida!");
                    Thread.Sleep(1500);
                    Console.Clear();
                    this.MostrarMenu();  break;
            }
        }
        catch (System.FormatException ex)
        {
            IMenu.Write($"Erro: {ex.GetType().Name}");
            Console.WriteLine();
            IMenu.Write("Digite uma das opções acima!");
            Thread.Sleep(2000);
            Console.Clear();
            this.MostrarMenu();
        }
        catch (Exception ex)
        {
            ExcecaoGenerica.MostrarExcecao(ex);
        }
    }
}
