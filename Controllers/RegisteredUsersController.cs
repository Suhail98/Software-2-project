using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace UserPackage
{
    public class RegisteredUsersController : ApiController, IUserFinder, IListAllUsers
    {
        private ISearchUserRepo[] searchUserRepos = new ISearchUserRepo[]{ new AdminstratorDataBase(), new NormalUserDataBase(), new StoreOwnerDataBase() };
        private IListUserRepo[] listUserRepos = new IListUserRepo[] {new NormalUserDataBase(), new StoreOwnerDataBase() };

        public User findUser(string email)
        {
            User user = null;
            for (int i = 0; i < searchUserRepos.Length; i++)
            {
                user = searchUserRepos[i].searchByEmail(email);
                if (user != null) break;
            }
            user.setString(email);
            return user;
        }
        public List<User> listAllUsers()
        {
            List<User> clientUsers = new List<User>();
            for (int i = 0; i < listUserRepos.Length; i++)
                clientUsers.AddRange(listUserRepos[i].listUsers());
            foreach(User user in clientUsers)
            {
                Console.WriteLine("name : " + user.getUserName() + " " + "email : " + user.getEmail()
                     + " " + "password : " + user.getPassword());
            }
            return clientUsers;
        }
    }
}
