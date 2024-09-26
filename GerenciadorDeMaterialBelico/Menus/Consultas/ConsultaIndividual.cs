using GerenciadorDeMaterialBelico.Listagem;

namespace GerenciadorDeMaterialBelico.Menus.Consultas;

internal class ConsultaIndividual : IMenu
{
    public void MostrarMenu()
    {
        try 
        { 
        Enfeites.Titulo("Consulta Individual");
        IMenu.WriteInput("Digite o numero do fuzil a ser consultado: ");
        string numeroDoFuzil = Console.ReadLine();
        bool ver = ListaDeFuzis.VerificarSeExiste(int.Parse(numeroDoFuzil));
        while (!ver)
        {
            IMenu.WriteInput($"O fuzil {numeroDoFuzil} não existe na lista, digite outro número: ");
            numeroDoFuzil = null;
            numeroDoFuzil += Console.ReadLine();
            ver = ListaDeFuzis.VerificarSeExiste(int.Parse(numeroDoFuzil!));
        }     
            ListaDeFuzis.ExibirInformacoesDoFuzil(int.Parse(numeroDoFuzil));
            IMenu.Write("Pressione qualquer tecla para voltar.");
            Console.ReadKey();
            Console.Clear();
            MenuConsultarArmamento menuConsultarArmamento = new MenuConsultarArmamento();
            menuConsultarArmamento.MostrarMenu();
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
            Console.WriteLine($"Tipo da Exceção: {ex.GetType().Name}");
            Console.WriteLine($"\nMensagem de Erro: {ex.Message}");
            Console.WriteLine($"\nStack Trace: {ex.StackTrace}");
            Console.WriteLine($"\nExceção original: {ex.InnerException}");
        }
    }
}
