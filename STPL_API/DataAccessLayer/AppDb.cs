using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace STPL_API.DataAccessLayer
{
    public class AppDb : DbContext
    {
        public AppDb(DbContextOptions<AppDb> options) : base(options)
        {
        }

        public virtual DbSet<tb_Temp> TbTemp { get; set; }
        public virtual DbSet<TbDevice> TbDevice { get; set; }
        public virtual DbSet<TbRecordTransaction> TbRecordTransaction { get; set; }
        public virtual DbSet<TbRecordData> TbRecordData { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tb_Temp>()
              .HasKey(c => new { c.Id });
            modelBuilder.Entity<TbDevice>()
              .HasKey(c => new { c.id });
            modelBuilder.Entity<TbRecordTransaction>()
              .HasKey(c => new { c.deviceid });
            modelBuilder.Entity<TbRecordTransaction>()
              .HasKey(c => new { c.trans_id });
            modelBuilder.Entity<TbRecordData>()
              .HasKey(c => new { c.recordtrans_id });


        }
    }
}