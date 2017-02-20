using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComicBookGalleryModel.Models;

namespace ComicBookGalleryModel
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new Context())
            {
                var series1 = new Series()
                {
                    Title = "The Amazing Spider-Man"
                };
                var series2 = new Series()
                {
                    Title = "The Invincible Iron Man"
                };

                var stanLee = new Artist()
                {
                    Name = "Stan Lee"
                };

                var jackKirby = new Artist()
                {
                    Name = "Jack Kirby"
                };

                var steveDitko = new Artist()
                {
                    Name = "Steve Ditko"
                };

                var comicBook1 = new ComicBook()
                {
                    Series = series1,
                    IssueNumber = 1,
                    PublishedOn = DateTime.Today
                };

                comicBook1.Artists.Add(stanLee);
                comicBook1.Artists.Add(jackKirby);

                var comicBook2 = new ComicBook()
                {
                    Series = series1,
                    IssueNumber = 2,
                    PublishedOn = DateTime.Today
                };

                comicBook2.Artists.Add(stanLee);
                comicBook2.Artists.Add(jackKirby);


                var comicBook3 = new ComicBook()
                {
                    Series = series2,
                    IssueNumber = 1,
                    PublishedOn = DateTime.Today
                };

                comicBook3.Artists.Add(stanLee);
                comicBook3.Artists.Add(steveDitko);

                context.ComicBooks.Add(comicBook1);
                context.ComicBooks.Add(comicBook2);
                context.ComicBooks.Add(comicBook3);
                context.SaveChanges();

                var comicBooks = context.ComicBooks
                    .Include(cb => cb.Series)
                    .Include(cb => cb.Artists)
                    .ToList();
                foreach (var comicBook in comicBooks)
                {
                    var artistNames = comicBook.Artists.Select(a => a.Name).ToList();
                    var artistsDisplayText = string.Join(", ", artistNames);


                    Console.WriteLine(comicBook.DisplayText);
                    Console.WriteLine(artistsDisplayText);
                }

                Console.ReadLine();
            }
        }
    }
}
