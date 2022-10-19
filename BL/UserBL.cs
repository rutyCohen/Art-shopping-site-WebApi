
using DL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class UserBL : IUserBL
    {
        IUserDL iuserDl;

        //ctor
        public UserBL(IUserDL iuserDl)
        {
            this.iuserDl = iuserDl;
        }

        //functions
        public async Task<User> Get(string email, string password)
        {
            return await iuserDl.Get(email, password);
        }

        public async Task<User> Post(User user)
        {
            return await iuserDl.Post(user);
        }

        public async Task Put(int id, User user)
        {
            await iuserDl.Put(id, user);
        }
    }
}

