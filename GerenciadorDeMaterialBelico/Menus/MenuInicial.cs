namespace GerenciadorDeMaterialBelico.Menus;

internal class MenuInicial : Menu
{
    public static void MostrarMenu()
    {
        Enfeites.Titulo("Gerenciador de Material Bélico - TG 02-026");
        Menu.Write("1.Adicionar Armamento");
        Menu.Write("2.Atualizar Armamento");
        Menu.Write("3.Adicionar Peças");
        Menu.Write("4.Consultar Armamento");
        Menu.Write("0.Sair do programa\n");
        Console.Write($"{margem}Selecione uma opção acima: ");
    }
}
