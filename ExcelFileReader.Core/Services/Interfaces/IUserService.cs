using System;
using System.Collections.Generic;
using System.Text;
using ExcelFileReader.Core.DTO;

namespace ExcelFileReader.Core.Services.Interfaces
{
    public interface IUserService
    {
        bool GetUser(string Username,string Pass);

    }
}
