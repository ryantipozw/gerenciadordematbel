using FrangoZe.Domain.Interfaces;
using FrangoZe.Domain.Model;
using LiteDB;

namespace FrangoZe.Infrastructure.Banco.DAL;
public class ClienteDAO : IDAO<Cliente>
{
    private readonly string cl = "Cliente";
    public void Insert(Cliente c)
    {
        using var db = new LiteDatabase(Connection.cn);
        var col = db.GetCollection<Cliente>(cl);
        col.Insert(c);
    }
    public void Update(Cliente c)
    {
        using var db = new LiteDatabase(Connection.cn);
        var col = db.GetCollection<Cliente>(cl);
        col.Update(c);
    }
    public Cliente GetById(int id)
    {
        using var db = new LiteDatabase(Connection.cn);
        var col = db.GetCollection<Cliente>(cl);
        var cliente = col.FindById(id);
        return cliente;
    }
    public List<Cliente> GetAll()
    {
        using var db = new LiteDatabase(Connection.cn);
        var col = db.GetCollection<Cliente>(cl);
        var list = new List<Cliente>();
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
        var col = db.GetCollection<Cliente>(cl);
        col.Delete(id);
    }
}
