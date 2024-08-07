namespace GerenciadorDeMaterialBelico.Menus;

internal class Menu
{
    protected static string margem = "        ";
    protected static void Write(string texto)
    {
        Console.WriteLine($"{margem}{texto}");
    }
    
}
