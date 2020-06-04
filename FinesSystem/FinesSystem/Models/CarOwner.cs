using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinesSystem.Models
{
    [Table("CarOwners")]
    public class CarOwner
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string DriverLicenseNumber { get; set; }
        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<Car> Cars { get; set; }
    }
}
