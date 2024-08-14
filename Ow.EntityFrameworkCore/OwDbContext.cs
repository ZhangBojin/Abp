using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Ow.Domain.Entities;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Ow.EntityFrameworkCore
{
    [ConnectionStringName("Default")]
    public class OwDbContext:AbpDbContext<OwDbContext>
    {
        public DbSet<Books> Books { get; set; }
        public OwDbContext(DbContextOptions<OwDbContext> options) : base(options)
        {
        }
    }
}
