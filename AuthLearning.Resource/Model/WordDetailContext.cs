using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthLearning.Resource.Model
{
    public class WordDetailContext : DbContext
    {
        public WordDetailContext( DbContextOptions<WordDetailContext> options ) : base ( options )
        {

        }

        public DbSet<WordDetail> WordDetails { get; set; }
    }
}
