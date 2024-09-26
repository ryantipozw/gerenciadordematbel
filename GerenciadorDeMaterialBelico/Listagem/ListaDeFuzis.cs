using GerenciadorDeMaterialBelico.Exceptions;
using GerenciadorDeMaterialBelico.Itens;
using GerenciadorDeMaterialBelico.Menus;
using System.Text.Json;

namespace GerenciadorDeMaterialBelico.Listagem;

internal class ListaDeFuzis
{
    public static Dictionary<int, MQ762M968> listaDeFuzis = [];
    
    public static string path = "ListaDeFuzis.txt";

    public static string conteudoDaLista = File.ReadAllText(path);

    public static string listaDeFuzisSerializada = JsonSerializer.Serialize(listaDeFuzis);

    public static JsonSerializerOptions options = new JsonSerializerOptions
    {
        PropertyNameCaseInsensitive = true,
        IncludeFields = true
    };
    public static Dictionary<int, MQ762M968> listaDeFuzisDesserializada = JsonSerializer.Deserialize<Dictionary<int, MQ762M968>>(conteudoDaLista, options);


    public static void RegistrarFuzilNaListaJSON()
    {
        try
        {
            string listaDeFuzisSerializada = JsonSerializer.Serialize(listaDeFuzisDesserializada);
            File.WriteAllText(path, listaDeFuzisSerializada);
        }
        catch (Exception ex)
        {
            ExcecaoGenerica.MostrarExcecao(ex);
        }

    }

    public static void AdicionarFuzil(int numeroDoFuzil, MQ762M968 fuzil)
    {
        listaDeFuzisDesserializada.Add(numeroDoFuzil, fuzil);
        RegistrarFuzilNaListaJSON();
    }

    public static void ExibirInformacoesDoFuzil(int numeroDoFuzil)
    {
        //Dictionary<int, MQ762M968> listaDeFuzisDesserializada = JsonSerializer.Deserialize<Dictionary<int, MQ762M968>>(conteudoDaLista, options);
        listaDeFuzisDesserializada[numeroDoFuzil].InfoFuzil();
    }

    public static bool VerificarSeExiste(int numeroDoFuzil)
    {
        //Dictionary<int, MQ762M968> listaDeFuzisDesserializada = JsonSerializer.Deserialize<Dictionary<int, MQ762M968>>(conteudoDaLista, options);
        if (listaDeFuzisDesserializada.ContainsKey(numeroDoFuzil))
        {
            return true;
        }
        return false;
    }
    public static void MostrarFuzisCompletos()
    {
        foreach (var fuzil in listaDeFuzisDesserializada)
        {
            if (fuzil.Value.Telha && fuzil.Value.AlcaDeMira && fuzil.Value.FundoDoDeposito && fuzil.Value.Condicao)
            {
                IMenu.Write($"Fuzil numero: {fuzil.Key.ToString()};\n");
            }
        }
    }
    public static void MostrarFuzisEmCondicoes()
    {
        foreach (var fuzil in listaDeFuzisDesserializada)
        {
            if (fuzil.Value.Condicao)
            {
                IMenu.Write($"Fuzil numero: {fuzil.Key.ToString()};\n");
            }
        }
    }
    public static void MostrarFuzisSemCondicoes()
    {
        foreach (var fuzil in listaDeFuzisDesserializada)
        {
            if (!fuzil.Value.Condicao)
            {
                IMenu.Write($"Fuzil numero: {fuzil.Key.ToString()};\n");
            }
        }
    }
    public static void AtualizarArmamento(string numeroDoFuzil)
    {
        try 
        { 
        MenuAtualizarArmamento menu = new();
        listaDeFuzisDesserializada.Remove(int.Parse(numeroDoFuzil));
        IMenu.WriteInput($"O fuzil {numeroDoFuzil} possui telha? (S/N): ");
        string inputTelha = Console.ReadLine()!;
        bool indicador = false;
        bool possuiTelha = IMenu.OptionSelect(inputTelha, indicador, menu);

        IMenu.WriteInput($"O fuzil {numeroDoFuzil} possui alça de mira? (S/N): ");
        string inputAlca = Console.ReadLine()!;
        bool possuiAlca = IMenu.OptionSelect(inputAlca, indicador, menu);

        IMenu.WriteInput($"O fuzil {numeroDoFuzil} possui fundo do depósito? (S/N): ");
        string inputFundo = Console.ReadLine()!;
        bool possuiFundo = IMenu.OptionSelect(inputFundo, indicador, menu);

        IMenu.WriteInput($"O fuzil {numeroDoFuzil} está em condições de uso? (S/N): ");
        string inputCondicao = Console.ReadLine()!;
        bool condicao = IMenu.OptionSelect(inputCondicao, indicador, menu);

        IMenu.WriteInput("Observação (opcional): ");
        string? observacao = Console.ReadLine();
        MQ762M968 fuzil = new(int.Parse(numeroDoFuzil), possuiTelha, possuiAlca, possuiFundo, condicao, observacao);
        ListaDeFuzis.AdicionarFuzil(int.Parse(numeroDoFuzil), fuzil);

        IMenu.Write($"O fuzil {numeroDoFuzil} foi atualizado da lista!\n");
        } 
        catch (Exception ex)
        {
            ExcecaoGenerica.MostrarExcecao(ex);
        }
    }
    public static void Serializar()
    {
        string json = JsonSerializer.Serialize(listaDeFuzis);
        File.AppendAllText(path, json);
    }
    public static void Desserializar()
    {
        Dictionary<int, MQ762M968> listaDeFuzisDesserializada = JsonSerializer.Deserialize<Dictionary<int, MQ762M968>>(conteudoDaLista, options);
        foreach (var item in listaDeFuzisDesserializada)
        {
            Console.WriteLine(item.Key.ToString(), item.Value.InfoFuzil);
        }
    }
}
