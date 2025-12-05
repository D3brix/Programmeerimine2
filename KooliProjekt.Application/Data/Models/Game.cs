using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KooliProjekt.Application.Data.Models
{
    public class Game : Entity
    {
        // Id inherited from Entity
        [Required]
        [MaxLength(50)]
        [MinLength(1)]
        public string Title { get; set; }
        public DateTime Begins { get; set; }
        public DateTime Ends { get; set; }

        public DateTime Date { get; set; }

        public int Team1Score { get; set; }
        public int Team2Score { get; set; }

        public Team Team1 { get; set; }
        public int Team1Id { get; set; }

        public Team Team2 { get; set; }
        public int Team2Id { get; set; }

        public Tournament Tournament { get; set; }
        public int TournamentId { get; set; }  

    }
}
