using GerenciadorDeMaterialBelico.Exceptions;
using GerenciadorDeMaterialBelico.Listagem;
using System.Linq.Expressions;

namespace GerenciadorDeMaterialBelico.Menus;
internal class MenuAtualizarArmamento : IMenu
{
    public void MostrarMenu()
    {
        Enfeites.Titulo($"Atualizar Armamento");
        IMenu.WriteInput("Digite o número do fuzil a ser atualizado (digite 'z' para retornar): ");
        try
        {
            string numeroDoFuzil = Console.ReadLine();
            while (numeroDoFuzil == "")
            {
                IMenu.WriteInput("Digite um número válido! ");
                numeroDoFuzil += Console.ReadLine();
            }
            if (numeroDoFuzil == "z")
            {
                IMenu.RetornarAoMenuInicial();
            }
            else
            {
                bool verificacao = ListaDeFuzis.VerificarSeExiste(int.Parse(numeroDoFuzil!));
                while (!verificacao)
                {
                    IMenu.WriteInput($"O fuzil {numeroDoFuzil} não existe na lista, digite outro número: ");
                    numeroDoFuzil = null;
                    numeroDoFuzil += Console.ReadLine();
                    verificacao = ListaDeFuzis.VerificarSeExiste(int.Parse(numeroDoFuzil!));
                }
                ListaDeFuzis.AtualizarArmamento(numeroDoFuzil);
                IMenu.RetornarAoMenuInicial();
            }
        }
        catch (Exception ex)
        {
            ExcecaoGenerica.MostrarExcecao(ex);
        }
    }
}

