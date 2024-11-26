using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.Security.Principal;
using System.Text;


namespace FrangoZe.Web.Models.Model;

public class Reserva
{
	public Reserva()
	{
		Produtos = new List<Produto>();
	}
	private DateTime HoraCriada = new();
	public int Id { get; set; }
	public List<Produto>? Produtos { get; set; }
	public int QuantidadeDeProdutos { get; set; }
	public string Cliente_Nome { get; set; }
	public Cliente_Endereco? Endereco { get; set; }
	public TimeOnly? Hora_Reserva { get; set; } = TimeOnly.FromDateTime(DateTime.Now); 
	public TimeOnly? Hora_Entrega { get; set; } 
    public string FormaDePagamento { get; set; }

    public string MostrarPagamento()
	{
		if (FormaDePagamento == "pix") return "Pago por Pix";
		if (FormaDePagamento == "dinheiro") return "Pago em Dinheiro";
		if (FormaDePagamento == "cartao") return "Pago no Cartão";
		return "Não foi pago";
	}
    public string MostrarHREntrega()
	{
		if (Hora_Entrega is null)
		{
			return "-";
		}
		return Hora_Entrega.ToString();
	}

	public string MostrarEndereco()
	{
		if (Endereco is null)
		{
			return "-";
		}
		return $"{Endereco.Endereco}, {Endereco.Numero}, {Endereco.Bairro}";
	}

	public string MostrarProdutosEscolhidos()
	{
		StringBuilder stringBuilder = new StringBuilder();


        foreach (var item in Produtos)
        {
			if (item.Quantidade != 0)
			{
				stringBuilder.Append($"{item.Quantidade}x {item.Nome}\n ");
			}
        }
		return stringBuilder.ToString();
    }

	public decimal MostrarTotal()
	{
		decimal total = 0;

		foreach (var item in Produtos)
		{
			if (item.Quantidade != 0)
			{
				total += item.Quantidade * item.Preco;
			}
		}
		return total;
	}
}
