using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AuthLearning.Resource.Model
{
    public class WordDetail
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "nvarchar(10)")]
        public string DictionaryForm { get; set; }
        [Column(TypeName = "nvarchar(10)")]
        public string MasuForm { get; set; }
    }
}
