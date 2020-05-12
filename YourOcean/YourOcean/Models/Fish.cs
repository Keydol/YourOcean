using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace YourOcean.Models
{
    [Table("Fish")]
    public class Fish
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { set; get; }
        public string Name { set; get; }
        public DateTime StartDateTime { set; get; }
        public DateTime EndDateTime { set; get; }
        public int DedicatedTime { set; get; }
        public bool Alive { set; get; }
    }
}
