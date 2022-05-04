using System;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Xml.Linq;
using System.Collections.Generic;
using System.Net;

namespace lab_9
{
    class Program
    {
        static void Main(string[] args)
        {
            AppContext context = new AppContext();
            context.Database.EnsureCreated();
            Console.WriteLine(context.Books.Find(1));
            //context.Books.Remove(context.Books.Find(1));
            //context.Books.Add(new Book() { Title = "PHP", EditionYear = 2000, Authorid = 1 });
            //Book book = context.Books.Find(2);
            //book.EditionYear = 2010;
            //context.Books.Update(book);
            //context.SaveChanges();
            IQueryable<Book> books = from b in context.Books
                                     select b;
            Console.WriteLine("____________________");
            Console.WriteLine(string.Join("\n", books));
            var booksWithAutors = from book in context.Books
                                  join author in context.Authors
                                  on book.Authorid equals author.Id
                                  select new { Title = book.Title, Author = author.Name };
            Console.WriteLine(string.Join("\n", booksWithAutors));
            foreach (var item in booksWithAutors)
            {
                Console.WriteLine(item.Author);
            }
            //zapisz Linq ktore zwroci liste rekordow z polami id ksiazki i nawziwsko autora dla ksiazek wydanych po 2019
            var bookWithName = from book in context.Books
                               join author in context.Authors
                               on book.Authorid equals author.Id
                               where book.EditionYear >= 2019
                               select new { Idksiazki = book.Id, Name = author.Name };
            Console.WriteLine(string.Join("\n", bookWithName));
            //context.Books.Join(
            //    context.Authors,
            //    book => book.Authorid,
            //    author => author.Id,
            //    (book, author) => new { Title = book.Title, Author = author.Name }
            //    );
            string xml =
                "<books>" +
                    "<book>" +
                        "<id>1</id>" +
                        "<title>C#</title>" +
                        "<editionYear>2000</editionYear>" +
                    "</book>" +
                    "<book>" +
                        "<id>2</id>" +
                        "<title>Java</title>" +
                        "<editionYear>2002</editionYear>" +
                    "</book>" +
                "</books>";
            XDocument doc = XDocument.Parse(xml);
            var xmlBooks = doc
                .Elements("books")
                .Elements("book")
                .Select(x => new
                {
                    Id = x.Element("id").Value,
                    Title = x.Element("title").Value,
                    EditionYear = x.Element("editionYear").Value
                });
            Console.WriteLine("-------------");
            Console.WriteLine(string.Join("\n",xmlBooks));
            WebClient client = new WebClient();
            client.Headers.Add("Accept", "application/xml");
            string xmlRate=client.DownloadString("http://api.nbp.pl/api/exchangerates/tables/C");
            XDocument rateDoc = XDocument.Parse(xmlRate);
            var xmlRatee=rateDoc
                .Elements("ArrayOfExchangeRatesTable")
                .Elements("ExchangeRatesTable")
                .Elements("Rates")
                .Elements("Rate")
                .Select(x => new
                {
                    Code=x.Element("Code").Value,
                    Bid=x.Element("Bid").Value,
                    Ask=x.Element("Ask").Value,
                });
            Console.WriteLine("-------------");
            Console.WriteLine(string.Join("\n", xmlRatee));
        }

    }
    public record Book
    {
        public int Id { get; set; }
        public int Authorid { get; set; }
        public int EditionYear { get; set; }
        public string Title { get; set; }
    }
    public record Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    class AppContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("DATASOURCE=d:\\database\\data.db");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Book>()
                .ToTable("books")
                .HasData(
                    new Book() { Id = 1, Authorid = 1, EditionYear = 2020, Title = "C# 9.0" },
                    new Book() { Id = 2, Authorid = 2, EditionYear = 2018, Title = "Asp.Net" },
                    new Book() { Id = 3, Authorid = 2, EditionYear = 2021, Title = "Java" },
                    new Book() { Id = 4, Authorid = 1, EditionYear = 2019, Title = "F#" }
                );
            modelBuilder
                .Entity<Author>()
                .ToTable("authors")
                .HasData(
                    new Author() { Id = 1, Name = "Maciej" },
                    new Author() { Id = 2, Name = "Adam" }
                );
        }
    }
}
