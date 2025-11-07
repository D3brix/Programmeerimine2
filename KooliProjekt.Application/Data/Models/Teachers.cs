using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KooliProjekt.Application.Data
{
    public class Teacher
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        [MinLength(1)]
        public string Title { get; set; }
        public bool IsDone { get; set; }
        public string Name { get; set; }    
        public string Subject { get; set; } 
    }
}
