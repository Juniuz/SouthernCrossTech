using System.IO;
using LiteDB;
using Microsoft.Extensions.Options;

namespace SouthernCross.Data.Context
{
    public class LiteDbContext : ILiteDbContext
    {
        public LiteDbContext(IOptions<LiteDbOptions> options)
        {
            string directoryPath = CreateDatabaseDirectory(options.Value.FolderName);
            Database = new LiteDatabase($@"{directoryPath}\{options.Value.DatabaseName}");
        }

        public LiteDatabase Database { get; }

        private static string CreateDatabaseDirectory(string folderName)
        {
            var path = $@"{Directory.GetCurrentDirectory()}\{folderName}";

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            return path;
        }
    }
}
