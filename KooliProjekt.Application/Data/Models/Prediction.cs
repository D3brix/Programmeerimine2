using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KooliProjekt.Application.Data.Models
{
    public class Prediction
    {
        public int Id { get; set; }
        public int score1 {  get; set; }
        public int score2 { get; set; } 
         public int starttime { get; set; }
        public int endtime { get; set; }
        public int points { get; set; }


        public Game Game { get; set; }
        public int GameId { get; set; }
        public Team Team1 { get; set; }
        public int Team1Id {  get; set; }

        public Team Team2 { get; set; }
        public int Team2Id { get; set; }
    }
}
