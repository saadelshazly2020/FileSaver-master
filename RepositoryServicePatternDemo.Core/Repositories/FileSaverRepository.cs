using ExcelFileReader.Core.Helper;
using RepositoryServicePatternDemo.Core.DTO;
using RepositoryServicePatternDemo.Core.Models;
using RepositoryServicePatternDemo.Core.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RepositoryServicePatternDemo.Core.Repositories
{
    public class FileSaverRepository : IFileSaverRepository
    {
        private readonly FileContext _context;
        public FileSaverRepository(FileContext context) {
            _context = context;
        }
        public bool AddNewFileData(List<FileModel> fileData)
        {
            bool response=true;
            try
            {
                _context.FileSet.AddRange(fileData);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                response = false;
            }

            return response;
        }

        public List<FileModel> GetFileData(int page)
        {
            if (page<=0)
            {
                page = 1;
            }
            int pageSize = 50;
            var skip = (page - 1) * pageSize;
            var data = _context.FileSet.Skip(skip).Take(pageSize).ToList();
            return data;
        }


    }
}
