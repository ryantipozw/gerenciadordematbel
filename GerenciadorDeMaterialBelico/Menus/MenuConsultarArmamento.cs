using GerenciadorDeMaterialBelico.Exceptions;
using GerenciadorDeMaterialBelico.Listagem;
using GerenciadorDeMaterialBelico.Menus.Consultas;

namespace GerenciadorDeMaterialBelico.Menus;
internal class MenuConsultarArmamento : IMenu
{
    public void MostrarMenu()
    {
        Enfeites.Titulo("Consulta de Armamento");
        IMenu.Write("1.Consulta individual\n");
        IMenu.Write("2.Fuzis 100%\n");
        IMenu.Write("3.Fuzis em condições\n");
        IMenu.Write("4.Fuzis sem condições\n");
        IMenu.Write("0.Voltar ao menu principal\n\n");
        IMenu.WriteInput("Digite uma opção acima: ");
        try
        {
        var opcaoDigitada = int.Parse(Console.ReadLine());
            switch (opcaoDigitada)
            {
                case 1:
                    Console.Clear();
                    ConsultaIndividual consultaIndividual = new();
                    consultaIndividual.MostrarMenu(); break;
                case 2:
                    Console.Clear();
                    ConsultaCemPct consultaCemPct = new();
                    consultaCemPct.MostrarMenu(); break;
                case 3:
                    Console.Clear();
                    ConsultaCondicoes consultaCondicoes = new();
                    consultaCondicoes.MostrarMenu(); break;
                case 4:
                    Console.Clear();
                    ConsultaSemCondicoes consultaSemCondicoes = new();
                    consultaSemCondicoes.MostrarMenu(); break;
                case 0:
                    Console.Clear();
                    MenuInicial menuInicial = new();
                    menuInicial.MostrarMenu();
                    break;

                default:
                    Console.WriteLine("");
                    IMenu.Write("Digite uma opção válida!");
                    Thread.Sleep(1500);
                    Console.Clear();
                    this.MostrarMenu(); break;
            }
        }
        catch (Exception ex)
        {
            ExcecaoGenerica.MostrarExcecao(ex);
        }       
    }
}
