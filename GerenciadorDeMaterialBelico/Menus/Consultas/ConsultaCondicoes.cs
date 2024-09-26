using GerenciadorDeMaterialBelico.Listagem;

namespace GerenciadorDeMaterialBelico.Menus.Consultas;

internal class ConsultaCondicoes : IMenu
{
    public void MostrarMenu()
    {
        Enfeites.Titulo("Consulta de fuzis em condições");
        IMenu.Write("A seguir está todos os fuzis que estão em condições: \n");
        ListaDeFuzis.MostrarFuzisEmCondicoes();
        IMenu.Write("Pressione qualquer tecla para retornar.");
        Console.ReadKey();
        Console.Clear();
        MenuConsultarArmamento menuConsultarArmamento = new MenuConsultarArmamento();
        menuConsultarArmamento.MostrarMenu();
    }
}
