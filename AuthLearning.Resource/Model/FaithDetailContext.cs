using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthLearning.Resource.Model
{
    public class FaithDetailContext : DbContext
    {
        public DbSet<WordDetail> Words { get; set; }
        public FaithDetailContext(DbContextOptions<FaithDetailContext> options)
            : base(options)
        {
            Database.EnsureCreated();
            UpdateMockData();
        }

        void UpdateMockData( ) 
        {
            if (Words == null)
                Words.Add(new WordDetail() { MasuForm = "MasuForm", DictionaryForm = "DictionaryForm" });
        }
    }
}
