using RepositoryServicePatternDemo.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryServicePatternDemo.Core.Repositories.Interfaces
{
    public interface IFileSaverRepository
    {
        List<FileModel> GetFileData(int page);
       bool AddNewFileData(List<FileModel> fileData);
    }
}
