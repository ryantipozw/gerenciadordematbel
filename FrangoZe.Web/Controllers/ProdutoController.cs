using FrangoZe.Infrastructure.Banco.DAL;
using FrangoZe.Web.Models.Model;
using Microsoft.AspNetCore.Mvc;

namespace FrangoZe.Web.Controllers
{
	public class ProdutoController : Controller
	{
		private readonly DataAccessObject<Produto> _dao;
		public ProdutoController(DataAccessObject<Produto> dao)
		{
			_dao = dao;
		}
		public IActionResult Index()
		{
			var produtos = _dao.GetAll("Produto");
			return View(produtos);
		}

		public IActionResult Adicionar()
		{
			return View();
		}

		public IActionResult Editar(int id)
		{
			Produto produto = _dao.GetById(id, "Produto");
			return View(produto);
		}

		public IActionResult Deletar(int id)
		{
			Produto produto = _dao.GetById(id, "Produto");
			return View(produto);
		}

		public IActionResult ApagarConfirmado(int id)
		{
			_dao.Delete(id, "Produto");
			return RedirectToAction("Index");
		}

		[HttpPost]
		public IActionResult Adicionar(Produto produto)
		{
			_dao.Insert(produto, "Produto");
			return RedirectToAction("Index");
		}

		[HttpPost]
		public IActionResult Alterar(Produto produto)
		{
			_dao.Update(produto, "Produto");
			return RedirectToAction("Index");
		}
	}
}
