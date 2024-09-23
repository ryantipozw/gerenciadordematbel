namespace GerenciadorDeMaterialBelico.Menus
{
    internal class Enfeites
    {
        private static void EnfeiteT(string titulo) 
        {
            for (int i = 0; i < titulo.Length/4; i++)
            {
                Console.Write("====");
                Thread.Sleep(1);
            }
        }
        public static void Titulo(string titulo)
        {
            Enfeites.EnfeiteT($"{Enfeites.margemT}{titulo}{Enfeites.margemT}\n");
            Console.WriteLine($"\n{Enfeites.margemT}{titulo}");
            Enfeites.EnfeiteT($"{Enfeites.margemT}{titulo}{Enfeites.margemT}\n");
            Console.WriteLine();
            Console.WriteLine();
        }
        public static string margemT = "                                      ";
    }
}
