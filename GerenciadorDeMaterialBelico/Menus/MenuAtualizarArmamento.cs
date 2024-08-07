namespace GerenciadorDeMaterialBelico.Menus;
internal class MenuAtualizarArmamento : Menu
{
    public static void MostrarMenu()
    {
        Enfeites.Titulo($"Atualizar Armamento");
        Menu.Write("Digite o número do fuzil a ser atualizado: ");
    }
}
