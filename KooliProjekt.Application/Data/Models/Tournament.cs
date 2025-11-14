using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KooliProjekt.Application.Data.Models
{
    public class Tournament
    {
        // Turniiri omadused (Id, Title jne)

        public IList<Game> Games { get; set; }
    }
}
