using PcAssembly.Dal;

namespace PcAssembly.Polygon
{
    class Program
    {
        //private DataContext _context;
        static async Task Main(string[] args)
        {
            
            // -----------------------------

            await using var dbContext = new DataContext();
            var cpus = dbContext.CPUs.ToList();
            cpus.ForEach(x => Console.WriteLine(x));

            //await Seed.SeedPublishers(dbContext);

            //await Seed.SeedBooks(dbContext);

            //await Seed.SeedReview(dbContext);

            //// -----------------------------

            //var query = from books in dbContext.Books
            //            select new
            //            {
            //                Title = books.Title ?? "default"
            //            };


            //var result = query.ToList();
        }
    }
}