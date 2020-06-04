using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinesSystem.Models
{
    [Table("Cars")]
    public class Car
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }

        public string Model { get; set; }
        public string Number { get; set; }
        [ManyToOne]
        public CarOwner Owner { get; set; }
    }
}
