using ExcelFileReader.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
namespace ExcelFileReader.Core.Interfaces
{
    public interface IFileSaverRepository
    {
        List<FileEntity> GetFileData(int page);
       bool AddNewFileData(List<FileEntity> fileData);
    }
}
