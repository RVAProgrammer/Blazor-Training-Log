using Microsoft.EntityFrameworkCore;
using TrainingLog.Infrastructure.Models;

namespace TrainingLog.Infrastructure.Context;

public class TrainingLogContext : DbContext
{
    public TrainingLogContext(DbContextOptions<TrainingLogContext> options) : base(options)
    {

    }
    public virtual DbSet<Race> Races { get; set; }
    public virtual DbSet<TrainingEvent> TrainingEvents { get; set; }
    public virtual DbSet<EventType> EventTypes { get; set; }
}