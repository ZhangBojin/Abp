using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Ow.Domain.Entities;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Identity;

namespace Ow.EntityFrameworkCore
{
    [ConnectionStringName("Default")]
    public class OwDbContext:AbpDbContext<OwDbContext>
    {
        public DbSet<IdentityUser> Users { get; set; }

        public OwDbContext(DbContextOptions<OwDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityUser>(entity =>
            {
                entity.HasKey(e => e.Id);
            });
            modelBuilder.Entity<IdentityUserLogin>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });
            });
            modelBuilder.Entity<IdentityUserOrganizationUnit>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.OrganizationUnitId });
            });
            modelBuilder.Entity<IdentityUserRole>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });
            });
            modelBuilder.Entity<IdentityUserToken>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });
            });
        }
    }
}
