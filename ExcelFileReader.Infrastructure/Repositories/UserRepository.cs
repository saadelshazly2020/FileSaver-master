
using ExcelFileReader.Core.DTO;
using ExcelFileReader.Core.Entities;
using ExcelFileReader.Core.Interfaces;
using ExcelFileReader.Core.Services.Interfaces;
using ExcelFileReader.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExcelFileReader.Infrastructure
{
    public class UserRepository : IUserRepository
    {
        private readonly FileContext _context;
        public UserRepository(FileContext context) {
            _context = context;
        }

        public UserDTO GetUser(string Username, string Pass)
        {
            UserDTO userDTO = new UserDTO() { UserName = "Admin", Password = "123" };
           return userDTO;
        }
    }
}
