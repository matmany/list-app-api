using Microsoft.EntityFrameworkCore;

namespace ListApi
{
  public class ListApiContext : DbContext
  {
    public ListApiContext(DbContextOptions<ListApiContext> options)
        : base(options)
    {
    }
  }
}