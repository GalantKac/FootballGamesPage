using Football.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Football.Interfaces
{
    interface IUnitOfWork
    {
        IRepository<Game> Games { get; }
        IRepository<Player> Players { get; }
        void Save();
    }
}
