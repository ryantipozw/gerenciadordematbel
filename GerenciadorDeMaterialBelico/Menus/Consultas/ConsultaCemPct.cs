using GerenciadorDeMaterialBelico.Listagem;

namespace GerenciadorDeMaterialBelico.Menus.Consultas;

internal class ConsultaCemPct : IMenu
{
    public void MostrarMenu()
    {
        Enfeites.Titulo("Consulta 100%");
        IMenu.Write("A seguir está todos os fuzis que estão 100%: \n");
        ListaDeFuzis.MostrarFuzisCompletos();
        IMenu.Write("Pressione qualquer tecla para retornar.");
        Console.ReadKey();
        Console.Clear();
        MenuConsultarArmamento menuConsultarArmamento = new MenuConsultarArmamento();
        menuConsultarArmamento.MostrarMenu();
    }
}
