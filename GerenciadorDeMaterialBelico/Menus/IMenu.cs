using GerenciadorDeMaterialBelico.Listagem;
using System.Runtime.CompilerServices;

namespace GerenciadorDeMaterialBelico.Menus
{
    internal interface IMenu
    {
        void MostrarMenu();
        protected static string margem = "        ";
        public static void Write(string texto)
        {
            string text = $"{margem}{texto}";
            foreach (var letra in text)
            {
                Console.Write(letra);
                Thread.Sleep(1);
            }
        }
        public static void WriteInput(string texto)
        {
            //Console.Write($"{margem}{texto}");
            string text = $"{margem}{texto}";
            foreach (var letra in text)
            {
                Console.Write(letra);
                Thread.Sleep(5);
            }
        }
        public static bool OptionSelect(string opcao, bool valor, IMenu menu)
        {
            if (opcao == "s" || opcao == "S")
            {
                valor = true;
            }
            else
            {
                if (opcao == "n" || opcao == "N")
                {
                    valor = false;
                }
                else
                {
                    IMenu.Write("Resposta inválida. Digite 'S' para sim ou 'N' para não. Insira os dados novamente.");
                    Thread.Sleep(3000);
                    Console.Clear();
                    menu.MostrarMenu();
                }
            }
            return valor;
        }
        protected static string Validacao()
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
                while (verificacao)
                {
                    IMenu.WriteInput($"O fuzil {numeroDoFuzil} já existe na lista, digite outro número: ");
                    numeroDoFuzil = null;
                    numeroDoFuzil += Console.ReadLine();
                    verificacao = ListaDeFuzis.VerificarSeExiste(int.Parse(numeroDoFuzil!));
                }
            }
            return numeroDoFuzil;
        }
        public static void RetornarAoMenuInicial()
        {
            IMenu.Write("Retornando ao menu inicial...");
            Thread.Sleep(1000);
            Console.Clear();
            MenuInicial menu = new();
            menu.MostrarMenu();
        }
    }
}
