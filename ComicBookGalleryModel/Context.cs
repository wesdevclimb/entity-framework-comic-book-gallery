using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComicBookGalleryModel.Models;

namespace ComicBookGalleryModel
{
    class Context : DbContext
    {
        public DbSet<ComicBook> ComicBooks { get; set; }
    }
}
