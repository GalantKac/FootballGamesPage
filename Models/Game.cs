using System;
using System.Collections.Generic;

namespace Football.Models
{
    public partial class Game
    {
        public int Id { get; set; }
        public int HomePlayerId { get; set; }
        public int AwayPlayerId { get; set; }
        public DateTime GameDate { get; set; }
        public int HomePlayerGoals { get; set; }
        public int AwayPlayerGoals { get; set; }

        public virtual Player AwayPlayer { get; set; }
        public virtual Player HomePlayer { get; set; }
    }
}
