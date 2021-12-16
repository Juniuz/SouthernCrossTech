using LiteDB;

namespace SouthernCross.Data.Context
{
    public interface ILiteDbContext
    {
        LiteDatabase Database { get; }
    }
}
