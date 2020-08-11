using Football.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Football.Data.Specification
{
    public class GameSpecification : BaseSpecification<Game>
    {
        public GameSpecification(int id): base(item => item.Id == id) { }
        public GameSpecification(int homePlayerId, int awayPlayerId): base(item => item.HomePlayerId == homePlayerId && item.AwayPlayerId == awayPlayerId) { }
        public GameSpecification(DateTime date): base(item => item.GameDate == date) { }
    }
}
