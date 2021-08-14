using System;
using System.ComponentModel.DataAnnotations;

namespace DeadlockTest.Data.Models
{
    public class BaseModel
    {
        [Key]
        public int Id { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ModificationDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
