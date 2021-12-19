using LiteDB;
using Microsoft.Extensions.Options;

namespace SouthernCross.Data.Context
{
    public class LiteDbContext : ILiteDbContext
    {
        public LiteDbContext(IOptions<LiteDbOptions> options)
        {
            Database = new LiteDatabase(options.Value.DatabaseLocation);
        }

        public LiteDatabase Database { get; }
    }
}
