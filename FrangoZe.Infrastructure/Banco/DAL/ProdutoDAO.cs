using FrangoZe.Domain.Model;
using LiteDB;

namespace FrangoZe.Infrastructure.Banco.DAL;
public class ProdutoDAO
{
    private readonly string prod = "Produto";
    public void Insert(Produto p)
    {
        using var db = new LiteDatabase(Connection.cn);
        var col = db.GetCollection<Produto>(prod);
        col.Insert(p);
    }
    public void Update(Produto p)
    {
        using var db = new LiteDatabase(Connection.cn);
        var col = db.GetCollection<Produto>(prod);
        col.Update(p);
    }
    public Produto GetById(int id)
    {
        using var db = new LiteDatabase(Connection.cn);
        var col = db.GetCollection<Produto>(prod);
        var produto = col.FindById(id);
        return produto;
    }
    public List<Produto> GetAll()
    {
        using var db = new LiteDatabase(Connection.cn);
        var col = db.GetCollection<Produto>(prod);
        var list = new List<Produto>();
        var colItems = col.FindAll();

        foreach (var item in colItems)
        {
            list.Add(item);
        }
        return list;
    }
    public void Delete(int id)
    {
        using var db = new LiteDatabase(Connection.cn);
        var col = db.GetCollection<Produto>(prod);
        col.Delete(id);
    }
}
