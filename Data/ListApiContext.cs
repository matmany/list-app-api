using Microsoft.EntityFrameworkCore;
using ListApi.Models;

namespace ListApi
{
  public class ListApiContext : DbContext
  {
    public ListApiContext(DbContextOptions<ListApiContext> options)
        : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Category> Category { get; set; }
    public DbSet<ListGroup> ListGroups { get; set; }
    public DbSet<List> Lists { get; set; }
    public DbSet<Artefact> Artefacts { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<ArtefactTag> ArtefactTags { get; set; }
  }
}