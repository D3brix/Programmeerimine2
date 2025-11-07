using KooliProjekt.Application.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KooliProjekt.Application.Data.Models
{
    public class ToDoItem
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        [MinLength(1)]
        public string Title { get; set; }
        public bool IsDone { get; set; }

        public ToDoList ToDoList { get; set; }
        public int ToDoListId { get; set; }
    }
}