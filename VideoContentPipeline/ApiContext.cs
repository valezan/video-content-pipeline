using Microsoft.EntityFrameworkCore;
using VideoContentPipeline.Models.v1_0;

namespace VideoContentPipeline
{
    public class ApiContext: DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options)
            : base(options)
        {
        }

        public DbSet<Video> Videos {get; set;}
    }
}