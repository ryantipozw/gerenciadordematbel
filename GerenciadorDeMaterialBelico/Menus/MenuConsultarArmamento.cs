namespace GerenciadorDeMaterialBelico.Menus;
internal class MenuConsultarArmamento : Menu
{
    public static void MostrarMenu()
    {
        Enfeites.Titulo("Consulta de Armamento");
        Menu.Write("Digite o numero do fuzil que deseja consultar: ");
    }
}
