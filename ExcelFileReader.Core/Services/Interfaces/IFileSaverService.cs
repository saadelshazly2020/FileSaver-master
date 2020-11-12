using System;
using System.Collections.Generic;
using System.Text;
using ExcelFileReader.Core.DTO;

namespace ExcelFileReader.Core.Services.Interfaces
{
    public interface IFileSaverService 
    {
        List<FileModelDTO> GetFileData(int page);
        bool AddNewFileData(List<FileModelDTO> fileData);
    }
}
