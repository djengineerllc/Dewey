using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace DeweyUI.Models
{
    public class DemoData
    {
        [Key]
        public int IntegerData { get; set; }
        public DateTime DateTimeData { get; set; }
        public string StringData { get; set; }
        public string StringData2 { get; set; }
        public decimal NumData { get; set; }
    }

    public class DemoDataDBContext : DbContext
    {
        public DbSet<DemoData> DemoData { get; set; }
    }
}