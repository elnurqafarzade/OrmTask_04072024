using Microsoft.EntityFrameworkCore;
using OrmTask_04072024.DAL;
using OrmTask_04072024.Models;
using static System.Reflection.Metadata.BlobBuilder;

namespace OrmTask_04072024
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Books book = new Books()
            {
                Id =4,
                Name = "Bele buyua biler zerdust",
                CostPrice = 18,
                SalePrice = 26,
                GenreId = 2
            };
            //CreateGenre(new Genre()
            //{
            //    Name = "English"
            //});

            //var books = BookGetAll();
            //foreach (var item in books)
            //{
            //    Console.WriteLine(item);
            //}

            UpdateBook(4,book);
            Console.WriteLine(GetBookById(4));
        }
        
        static void CreateBook(Books book)
        {
            DataContext datab = new DataContext();
            datab.Books.Add(book);
            datab.SaveChanges();
        }
        static void CreateGenre(Genre genre)
        {
            DataContext data = new DataContext();
            data.Genres.Add(genre);
            Console.WriteLine("yaradildi");
            data.SaveChanges();
        }

        static Books GetBookById(int id)
        {
            DataContext data = new DataContext();

            return data.Books.Include(b => b.Genres).FirstOrDefault(b => b.Id == id);

        }

        static Genre GetGenreById(int id)
        {
            DataContext data = new DataContext();

            var db = data.Genres.Find(id);
            return db;

        }

        public void DeleteBook(int id)
        {
            DataContext data = new DataContext();
            var book = data.Books.Find(id);
            if (book != null)
            {
                data.Books.Remove(book);
                data.SaveChanges();
            }
        }

        public void DeleteGenre(int id)
        {
            DataContext data = new DataContext();
            var genre = data.Genres.Find(id);
            if (genre != null)
            {
                data.Genres.Remove(genre);
                data.SaveChanges();
            }
        }

        static void UpdateBook(int id, Books books) 
        {
            DataContext data = new DataContext();
            var existBook = data.Books.FirstOrDefault(b => b.Id == id);
            if (existBook is null) 
            {
                throw new NullReferenceException("Null ola bilmez");
            }
            existBook.Name = books.Name;
            existBook.GenreId = books.GenreId;
            existBook.SalePrice = books.SalePrice;
            existBook.CostPrice = books.CostPrice;
            data.SaveChanges();
        }
      
        static void UpdateGenre(int id, Genre genre)
        {
            DataContext data = new DataContext();
            var existGenre = data.Genres.FirstOrDefault(g => g.Id == id);
            if (existGenre == null)
            {
                throw new NullReferenceException();
            }
            existGenre.Name = genre.Name;
            data.SaveChanges();
        }

        static List<Books> BookGetAll()
        {
            DataContext data = new DataContext();

            return data.Books.Include(b => b.Genres).ToList();
        }

        static List<Genre> GenreGetAll()
        {
            DataContext data = new DataContext();

            return data.Genres.Include("Genre").ToList();
        }
    }
}
