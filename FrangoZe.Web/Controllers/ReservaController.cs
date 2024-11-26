using Microsoft.AspNetCore.Mvc;
using FrangoZe.Infrastructure.Banco.DAL;
using FrangoZe.Web.ViewModels;
using FrangoZe.Web.Models;
using FrangoZe.Web.Models.Model;

namespace FrangoZe.Web.Controllers
{
	public class ReservaController : Controller
	{
		private readonly DataAccessObject<Reserva> _dao;
		private readonly DataAccessObject<Produto> _daoP;
		public ReservaController(DataAccessObject<Reserva> dao, DataAccessObject<Produto> daop)
		{
			_dao = dao;
			_daoP = daop;
		}
		public IActionResult Index()
		{
			ReservaProdutoViewModel reservaProdutoViewModel = new ReservaProdutoViewModel();
			return View(reservaProdutoViewModel);
		}

		public IActionResult Criar()
		{
			ReservaProdutoViewModel reservaProdutoViewModel1 = new ReservaProdutoViewModel();
			return View(reservaProdutoViewModel1);
		}

		public IActionResult Editar(int id)
		{
			ReservaProdutoViewModel reserva = new();
			reserva.Reserva = _dao.GetById(id, "Reserva");
			return View(reserva);
		}

		public IActionResult Apagar(int id)
		{
			Reserva reserva = _dao.GetById(id, "Reserva");
			return View(reserva);
		}

		public IActionResult ApagarConfirmado(int id)
		{
			var listProdutos = _daoP.GetAll("Produto");
			var reserva = _dao.GetById(id, "Reserva");

			foreach (var prod in reserva.Produtos)
			{
				listProdutos.Find(x => x.Id == prod.Id).QuantidadeVendida += prod.Quantidade;
				listProdutos.Find(x => x.Id == prod.Id).QuantidadeReservado -= prod.Quantidade;
				_daoP.Update(listProdutos.Find(x => x.Id == prod.Id), "Produto");
			}
			_dao.Insert(reserva, "ReservaHistorico");
			_dao.Delete(id, "Reserva");
			return RedirectToAction("Index");
		}

		public IActionResult Cancelar(int id)
		{
			var listProdutos = _daoP.GetAll("Produto");
			var reserva = _dao.GetById(id, "Reserva");

			foreach (var prod in reserva.Produtos)
			{
				listProdutos.Find(x => x.Id == prod.Id).QuantidadeNoEstoque += prod.Quantidade;
				listProdutos.Find(x => x.Id == prod.Id).QuantidadeReservado -= prod.Quantidade;
				_daoP.Update(listProdutos.Find(x => x.Id == prod.Id), "Produto");
			}
			_dao.Delete(id, "Reserva");
			return RedirectToAction("Index");
		}

		[HttpPost]
		public IActionResult Criar(Reserva reserva)
		{
			var listProdutos = _daoP.GetAll("Produto");


			foreach (var prod in reserva.Produtos)
			{
				if (prod.Quantidade < listProdutos.Find(x => x.Id == prod.Id).QuantidadeNoEstoque)
				{
					listProdutos.Find(x => x.Id == prod.Id).QuantidadeNoEstoque -= prod.Quantidade;
					listProdutos.Find(x => x.Id == prod.Id).QuantidadeReservado += prod.Quantidade;
					_daoP.Update(listProdutos.Find(x => x.Id == prod.Id), "Produto");
				} else
				{
					return RedirectToAction("Criar");
				}
			}
			_dao.Insert(reserva, "Reserva");
			return RedirectToAction("Index");
		}

		[HttpPost]
		public IActionResult Alterar(Reserva reserva)
		{
			_dao.Update(reserva, "Reserva");
			return RedirectToAction("Index");
		}
	}
}
