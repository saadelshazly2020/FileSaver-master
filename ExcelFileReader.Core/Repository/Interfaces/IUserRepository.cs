using System;
using System.Collections.Generic;
using System.Text;
using ExcelFileReader.Core.DTO;

namespace ExcelFileReader.Core.Services.Interfaces
{
    public interface IUserRepository 
    {
        UserDTO GetUser(string Username,string Pass);

    }
}
