using ExcelFileReader.Core.Helper;
using RepositoryServicePatternDemo.Core.DTO;
using RepositoryServicePatternDemo.Core.Models;
using RepositoryServicePatternDemo.Core.Repositories.Interfaces;
using RepositoryServicePatternDemo.Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RepositoryServicePatternDemo.Core.Services
{
    public class FileSaverService : IFileSaverService
    {
        private readonly IFileSaverRepository _fileRepo;
        FileMapping _fileMapping;

        public FileSaverService(IFileSaverRepository fileRepo)
        {
            _fileMapping = new FileMapping();
            _fileRepo = fileRepo;
        }


        public List<FileModelDTO> GetFileData(int page)
        {
            List<FileModel> data = _fileRepo.GetFileData(page);
            var mappedData = _fileMapping.GetDataMapping(data);
            return mappedData;
        }
       

        public bool AddNewFileData(List<FileModelDTO> fileData)
        {

            var mappedData = _fileMapping.AddDataMapping(fileData);
            var isSaved = _fileRepo.AddNewFileData(mappedData);
            return isSaved;
        }




    }
}
