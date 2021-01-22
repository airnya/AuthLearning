using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthLearning.Resource.Model
{
    public class BookStore
    {
        public List<Book> Books => new List<Book>
        {
            new Book()
            {
                Id = 1,
                Author = "T.V. Oyamama",
                Title =  "Book time",
                Price = 240
            },
            new Book()
            {
                Id = 2,
                Author = "T.V. Oypapa",
                Title =  "Time of book",
                Price = 440
            },
            new Book()
            {
                Id = 3,
                Author = "T.V. Oyamama",
                Title =  "Book time",
                Price = 540
            },
        };

        public Dictionary<Guid, int[]> Orders => new Dictionary<Guid, int[]>
        {
            { Guid.Parse("b1754c14-d296-4b0f-a09a-030017f4461f"), new int[] { 1, 3 } },
            { Guid.Parse("0f8fad5b-d9cb-469f-a165-70862228950e"), new int[] { 2, 3, 4 } },
        };
    }
}
