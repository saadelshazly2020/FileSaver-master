using Microsoft.EntityFrameworkCore;
using RepositoryServicePatternDemo.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryServicePatternDemo.Core
{
    public class FileContext: DbContext
    {
        public FileContext(DbContextOptions<FileContext> options)
           : base(options)
        { }

        public DbSet<FileModel> FileSet { get; set; }
    }
}
