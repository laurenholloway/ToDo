using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ToDo.Models
{
    public class Task
    {
        [Key]
        public int TaskID { get; set; }
        public string TaskName { get; set; }
        public string Description { get; set; }
        public bool IsDone { get; set; }
        public DateTime Date { get; set; }

        [ForeignKey("List")]
        public int ListID { get; set; }
        public virtual List List { get; set; }

    }
}