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
        public int Score1 {  get; set; }
        public int Score2 { get; set; } 
         public int Starttime { get; set; }
        public int StartTime { get; internal set; }
        public int Endtime { get; set; }
        public int EndTime { get; internal set; }
        public int Points { get; set; }


        public Game Game { get; set; }
        public int GameId { get; set; }
        public Team Team1 { get; set; }
        public int Team1Id {  get; set; }

        public Team Team2 { get; set; }
        public int Team2Id { get; set; }
    }
}
