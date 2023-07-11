using Microsoft.EntityFrameworkCore;

namespace CricBook.Models.Repository
{
    static public class FieldRepository
    {
        static public Field GetField(int id)
        {
            CricbookContext cx = new CricbookContext();
            Field f = cx.Fields.Find(id = id);
            return f;
        }
        static public List<Field> GetFields()
        {
            CricbookContext cx = new CricbookContext();
            List<Field> fields = cx.Fields.ToList();
            return fields;
        }

    }
}
