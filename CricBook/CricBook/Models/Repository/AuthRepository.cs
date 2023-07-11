using Microsoft.EntityFrameworkCore;

namespace CricBook.Models.Repository
{
    static public class AuthRepository
    {
        static public void addUser(User user)
        {
            CricbookContext cx = new CricbookContext();
            cx.Add(user);
        }
    }
}
