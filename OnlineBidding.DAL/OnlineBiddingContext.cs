using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using OnlineBidding.Model;

namespace OnlineBidding.DAL
{
    public class OnlineBiddingContext : DbContext
    {
        public DbSet<User> User { get; set; }
        public DbSet<Team> Team { get; set; }

        public System.Data.Entity.DbSet<OnlineBidding.Model.UserPoint> UserPoints { get; set; }
    }
}
