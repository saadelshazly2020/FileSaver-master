using RepositoryServicePatternDemo.Core.Repositories.Interfaces;
using RepositoryServicePatternDemo.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using RepositoryServicePatternDemo.Core.DTO;

namespace RepositoryServicePatternDemo.Core.Services.Interfaces
{
    public interface IFileSaverService 
    {
        List<FileModelDTO> GetFileData();
        bool AddNewFileData(List<FileModelDTO> fileData);
    }
}
