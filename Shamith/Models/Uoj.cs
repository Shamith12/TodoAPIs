using System.ComponentModel.DataAnnotations;

namespace Shamith.Models
{
    public class Uoj
    {
        [Key]
        public int Todo_Id { get; set; }
        public string Title { get; set; }
        
        public string Sub_Title { get; set; }

        public DateTime Date { get; set; }


    }
}
