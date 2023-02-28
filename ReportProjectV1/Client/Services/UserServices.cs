using ReportProjectV1.Shared.Models;

namespace ReportProjectV1.Server.Services
{
    public class UserServices : IGenericServices<User>
    {

        public IEnumerable<User> getAll => items.Values;



        public User AddUser(User User)
        {


            if (User.IDUser == 0)
            {
                int key = items.Count;
                while (items.ContainsKey(key)) { key++; };
                User.IDUser = key;
            }
            items[User.IDUser] = User;
            return User;

        }
        public void DeleteUser(int id) => items.Remove(id);



        public User UpdateUser(User User) => AddUser(User);

    }
}
