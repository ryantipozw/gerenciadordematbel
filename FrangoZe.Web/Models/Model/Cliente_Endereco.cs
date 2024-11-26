namespace FrangoZe.Web.Models.Model;

public class Cliente_Endereco
{
	public int? Id { get; set; }
	//public int Cliente_Id { get; set; }
	public string? Endereco { get; set; }
	public int? Numero { get; set; }
	public string? Bairro { get; set; }
	public string Cidade { get; set; } = "Ourinhos";
	public string Estado { get; set; } = "SP";
}
