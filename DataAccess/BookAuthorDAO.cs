using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class BookAuthorDAO
    {
        public static List<BookAuthor> GetBookAuthors()
        {
            var listBookAuthors = new List<BookAuthor>();
            try
            {
                using (var context = new EBookStoreContext())
                {
                    listBookAuthors = context.BookAuthors.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return listBookAuthors;
        }

        public static BookAuthor GetBookAuthorById(int BookId, int AuthorId)
        {
            var BookAuthor = new BookAuthor();
            try
            {
                using (var context = new EBookStoreContext())
                {
                    BookAuthor = context.BookAuthors.FirstOrDefault(
                        x => x.BookId == BookId && x.AuthorId == AuthorId);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return BookAuthor;
        }

        public static void SaveBookAuthor(BookAuthor BookAuthor)
        {
            try
            {
                using (var context = new EBookStoreContext())
                {
                    context.BookAuthors.Add(BookAuthor);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void UpdateBookAuthor(BookAuthor BookAuthor)
        {
            try
            {
                using (var context = new EBookStoreContext())
                {
                    context.Entry<BookAuthor>(BookAuthor).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void DeleteBookAuthor(BookAuthor BookAuthor)
        {
            try
            {
                using (var context = new EBookStoreContext())
                {
                    var u = context.BookAuthors.SingleOrDefault(
                        x => x.BookId == BookAuthor.BookId && x.AuthorId == BookAuthor.AuthorId);
                    context.BookAuthors.Remove(u);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
