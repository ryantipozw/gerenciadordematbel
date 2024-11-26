using LiteDB;
namespace FrangoZe.Infrastructure.Banco.DAL;

public class DataAccessObject<T> where T : class 
{
    public void Insert(T cl, string columnName)
    {
        using var db = new LiteDatabase(Connection.cn);
        var col = db.GetCollection<T>(columnName);
        col.Insert(cl);
    }
    public void Update(T cl, string columnName)
    {
        using var db = new LiteDatabase(Connection.cn);
        var col = db.GetCollection<T>(columnName);
        col.Update(cl);
    }
    public T GetById(int id, string columnName)
    {
        using var db = new LiteDatabase(Connection.cn);
        var col = db.GetCollection<T>(columnName);
        var idToBeFound = col.FindById(id);
        return idToBeFound;
    }
    public List<T> GetAll(string columnName)
    {
        using var db = new LiteDatabase(Connection.cn);
        var col = db.GetCollection<T>(columnName);
        var list = new List<T>();
        var colItems = col.FindAll();

        foreach (var item in colItems)
        {
            list.Add(item);
        }
        return list;
    }
    public void Delete(int id, string columnName)
    {
        using var db = new LiteDatabase(Connection.cn);
        var col = db.GetCollection<T>(columnName);
        col.Delete(id);
    }
}
