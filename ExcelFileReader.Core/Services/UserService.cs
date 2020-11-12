using ExcelFileReader.Core.DTO;
using ExcelFileReader.Core.Entities;
using ExcelFileReader.Core.Interfaces;
using ExcelFileReader.Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExcelFileReader.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        FileMapping _fileMapping;

        public UserService(IUserRepository userRepository)
        {
            _fileMapping = new FileMapping();
            _userRepository = userRepository;
        }

        public bool GetUser(string Username, string Pass)
        {
            var user= _userRepository.GetUser(Username, Pass);
            bool isValid = false;
            if (user.UserName==Username&&user.Password==Pass)
            {
                isValid = true;
            }
            return isValid;
        }
    }
}
