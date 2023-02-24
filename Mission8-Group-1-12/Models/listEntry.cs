using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Mission8_Group_1_12.Models
{
    public class listEntry
    {
        [Required]
        [Key]
        public int TaskID { get; set; }

        [Required]
        public string Task { get; set; }

        public string DueDate { get; set; }
       
        [Required]
        [Range (1,4)]
        public int Quadrant { get; set; }

        public int CategoryID { get; set; }

        public bool Completed { get; set; }


        //Building foreign key relationship
        public Category Category { get; set; }

    }
}
