namespace FrangoZe.Web.Models.Model;

public class Produto
{
	public int Id { get; set; }
	public string Nome { get; set; }
	public string Descricao { get; set; }
	public decimal Preco { get; set; }
    public int Quantidade { get; set; }
    public int QuantidadeNoEstoque { get; set; }
    public int QuantidadeReservado { get; set; }
    public int QuantidadeVendida { get; set; }

}
