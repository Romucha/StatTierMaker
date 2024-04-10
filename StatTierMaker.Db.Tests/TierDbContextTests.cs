using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Moq;

namespace StatTierMaker.Db.Tests
{
    public class TierDbContextTests
    {
        [Fact]
        public void Constructor_Normal()
        {
            IConfiguration configuration = new Mock<IConfiguration>().Object;
            DbContextOptions<TierDbContext> dbContextOptions = new DbContextOptionsBuilder<TierDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString())
                                                                                                           .ConfigureWarnings(b => b.Ignore(InMemoryEventId.TransactionIgnoredWarning)).Options;
            var dbcontext = new TierDbContext(dbContextOptions, configuration);
        }
    }
}