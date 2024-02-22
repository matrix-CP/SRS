using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SRS.Models;

namespace SRS.Repositories
{
    public interface IUserRepository
    {
        public void Register(tblUser user);
        public tblUser Login(tblUser user);
    }
}