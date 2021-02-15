using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthLearning.Resource.Model
{
    public class UserStore
    {
        public List<User> Users => new List<User>
        {
            new User()
            {
                Id = 1,
                Name = "Airatjon",
                Age = 28
            },
            new User()
            {
                Id = 2,
                Name = "Sasajon",
                Age = 28
            },
            new User()
            {
                Id = 3,
                Name = "Papajon",
                Age = 28
            },
        };
    }
}
