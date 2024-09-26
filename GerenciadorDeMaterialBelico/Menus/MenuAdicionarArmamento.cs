using GerenciadorDeMaterialBelico.Exceptions;
using GerenciadorDeMaterialBelico.Itens;
using GerenciadorDeMaterialBelico.Listagem;

namespace GerenciadorDeMaterialBelico.Menus;
internal class MenuAdicionarArmamento : IMenu
{
    public void MostrarMenu()
    {
        try
        {
        Enfeites.Titulo($"Adicionar Armamento");
        IMenu.WriteInput("Digite o número do fuzil a ser adicionado (digite 'z' para retornar): ");
        string numeroDoFuzil = IMenu.Validacao();
        
        IMenu.WriteInput($"O fuzil {numeroDoFuzil} possui telha? (S/N): ");
        string inputTelha = Console.ReadLine()!;
        bool indicador = false;
        bool possuiTelha = IMenu.OptionSelect(inputTelha, indicador, this);

        IMenu.WriteInput($"O fuzil {numeroDoFuzil} possui alça de mira? (S/N): ");
        string inputAlca = Console.ReadLine()!;
        bool possuiAlca = IMenu.OptionSelect(inputAlca, indicador, this);

        IMenu.WriteInput($"O fuzil {numeroDoFuzil} possui fundo do depósito? (S/N): ");
        string inputFundo = Console.ReadLine()!;
        bool possuiFundo = IMenu.OptionSelect(inputFundo, indicador, this);

        IMenu.WriteInput($"O fuzil {numeroDoFuzil} está em condições de uso? (S/N): ");
        string inputCondicao = Console.ReadLine()!;
        bool condicao = IMenu.OptionSelect(inputCondicao, indicador, this);

        IMenu.WriteInput("Observação (opcional): ");
        string? observacao = Console.ReadLine();
        MQ762M968 fuzil = new(int.Parse(numeroDoFuzil), possuiTelha, possuiAlca, possuiFundo, condicao, observacao);
        ListaDeFuzis.AdicionarFuzil(int.Parse(numeroDoFuzil), fuzil);

        Console.WriteLine("");
        IMenu.Write($"O fuzil {numeroDoFuzil} foi adicionado a lista!");
        Thread.Sleep(500);
        IMenu.RetornarAoMenuInicial();
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
