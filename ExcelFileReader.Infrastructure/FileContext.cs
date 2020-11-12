
using Microsoft.EntityFrameworkCore;
using ExcelFileReader.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExcelFileReader.Repository
{
    public class FileContext: DbContext
    {
        public FileContext(DbContextOptions<FileContext> options)
           : base(options)
        { }

        public DbSet<FileEntity> FileSet { get; set; }
    }
}
