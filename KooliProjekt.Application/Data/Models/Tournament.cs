using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KooliProjekt.Application.Data.Models
{
    public class Tournament
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        [MinLength(1)]
        // Turniiri omadused (Id, Title jne)

        public string Title { get; set; }   

        public IList<Game> Games { get; set; }
    }
}
