using FrangoZe.Infrastructure.Banco.DAL;
using FrangoZe.Web.Models.Model;
using System.Text;

namespace FrangoZe.Web.ViewModels;

public class ReservaProdutoViewModel
{
    private static DataAccessObject<Reserva> daoReserva = new();
    private static DataAccessObject<Produto> daoProduto = new();
    public List<Reserva> reservas = daoReserva.GetAll("Reserva");
    public List<Produto> produtos = daoProduto.GetAll("Produto");
    public Reserva Reserva { get; set; }
    public List<Produto> Produtos { get; set; }
}
