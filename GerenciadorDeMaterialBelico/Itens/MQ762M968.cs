using GerenciadorDeMaterialBelico.Menus;
using System.Text.Json.Serialization;

namespace GerenciadorDeMaterialBelico.Itens;

internal class MQ762M968
{
    public MQ762M968(int NumeroDoFuzil, bool Telha, bool AlcaDeMira, bool FundoDoDeposito, bool Condicao, string Observacao = "")
    {
        this.NumeroDoFuzil = NumeroDoFuzil;
        this.Telha = Telha;
        this.AlcaDeMira = AlcaDeMira;
        this.FundoDoDeposito = FundoDoDeposito;
        this.Condicao = Condicao;
        this.Observacao = Observacao;
    }
    //[JsonPropertyName("numeroDoFuzil")]
    public int NumeroDoFuzil { get; set; }
    //[JsonPropertyName("possuitelha")]
    public bool Telha { get; set; }
    //[JsonPropertyName("alcaDeMira")]
    public bool AlcaDeMira { get; set; }
    //[JsonPropertyName("fundoDoDeposito")]
    public bool FundoDoDeposito { get; set; }
    //[JsonPropertyName("condicao")]
    public bool Condicao { get; set; }
    //[JsonPropertyName("observacao")]
    public string Observacao { get; set; }

    private string Verificacao(bool verificando)
    {
        if (verificando)
        {
            return "Sim";
        }
        else
        {
            return "Não";
        }
    }

    public void InfoFuzil()
    {
        
        IMenu.Write($"O fuzil {NumeroDoFuzil} possui: \n");
        IMenu.Write($"Telha: {Verificacao(Telha)}.");
        IMenu.Write($"Alça de mira: {Verificacao(AlcaDeMira)}.");
        IMenu.Write($"Fundo do Depósito: {Verificacao(FundoDoDeposito)}.\n");
        IMenu.Write($"O fuzil está em condições: {Verificacao(Condicao)}."); 
        IMenu.Write($"Observação: {Observacao}");
        
    }
}
