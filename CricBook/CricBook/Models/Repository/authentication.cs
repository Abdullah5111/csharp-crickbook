using Microsoft.EntityFrameworkCore;

namespace CricBook.Models.Repository
{
    static public class authentication
    {
        static public void addUser(User user)
        {
            CricbookContext cx = new CricbookContext();
            cx.Add(user);
        }

        static public Field GetField(int id)
        {
            CricbookContext cx = new CricbookContext();
            return cx.Fields.Find(id = id);
        }

        static public bool[] getSlots(DateTime d)
        {
            CricbookContext cx = new CricbookContext();
            List<Table> bookings = cx.Tables
            .Where(b => b.Date.Date == d)
            .ToList();

            bool[] boolArray = new bool[24];

            for (int i = 0; i < boolArray.Length; i++)
            {
                boolArray[i] = true;
            }

            for (int i = 0; i < bookings.Count; i++)
            {
                boolArray[bookings[i].StartTime.Hours] = false;
            }

            return boolArray;
        }
    }
}
