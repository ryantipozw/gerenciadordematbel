using GerenciadorDeMaterialBelico.Listagem;

namespace GerenciadorDeMaterialBelico.Menus.Consultas;

internal class ConsultaSemCondicoes : IMenu
{
    public void MostrarMenu()
    {
        Enfeites.Titulo("Consulta de fuzis SEM condições");
        IMenu.Write("A seguir está todos os fuzis que estão sem condições: ");
        ListaDeFuzis.MostrarFuzisSemCondicoes();
        IMenu.Write("Pressione qualquer tecla para retornar.");
        Console.ReadKey();
        Console.Clear();
        MenuConsultarArmamento menuConsultarArmamento = new MenuConsultarArmamento();
        menuConsultarArmamento.MostrarMenu();
    }
}
