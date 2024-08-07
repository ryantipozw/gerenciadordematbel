namespace GerenciadorDeMaterialBelico.Menus;
internal class MenuAdicionarArmamento : Menu
{
    public static void MostrarMenu()
    {
        Enfeites.Titulo($"Adicionar Armamento");
        Menu.Write("Digite o número do fuzil a ser adicionado: ");
    }
}
