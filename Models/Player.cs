using System;
using System.Collections.Generic;

namespace Football.Models
{
    public partial class Player
    {
        public Player()
        {
            GameAwayPlayer = new HashSet<Game>();
            GameHomePlayer = new HashSet<Game>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public int Wins { get; set; }
        public int Ties { get; set; }
        public int Loses { get; set; }
        public int GoalsScored { get; set; }
        public int GoalsConceded { get; set; }

        public virtual ICollection<Game> GameAwayPlayer { get; set; }
        public virtual ICollection<Game> GameHomePlayer { get; set; }
    }
}
