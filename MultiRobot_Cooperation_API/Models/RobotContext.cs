using Microsoft.EntityFrameworkCore;

namespace MultiRobot_Cooperation_API.Models
{
    public class RobotContext : DbContext
    {
        public RobotContext(DbContextOptions<RobotContext> options)
            :base(options)
        {

        }
        public DbSet<Robot> RobotSet { get; set; }
    }
}
