using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ToDo.Models
{
    public class List
    {
        [Key]
        public int ListID { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }

        public virtual ICollection<Task> Tasks { get; set; }
    }
}