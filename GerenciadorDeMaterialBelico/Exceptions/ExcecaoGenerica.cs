using GerenciadorDeMaterialBelico.Menus;

namespace GerenciadorDeMaterialBelico.Exceptions;

internal class ExcecaoGenerica 
{
    public static void MostrarExcecao(Exception ex)
    {
        IMenu.Write("Ocorreu um erro!");
        IMenu.Write($"Erro: {ex.GetType().Name}");
        IMenu.Write($"Mensagem: {ex.Message}");
        IMenu.Write($"Origem: {ex.StackTrace}");
        IMenu.Write(ex.InnerException.ToString());
        IMenu.WriteInput("Pressione Qualquer tecla para voltar ao menu inicial.");
        Console.ReadLine();
        MenuInicial menuInicial = new MenuInicial();
        menuInicial.MostrarMenu();
    }
}
