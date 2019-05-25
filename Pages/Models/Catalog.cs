using System;
using System.ComponentModel.DataAnnotations;

namespace EntertainmentCatalog.Models
{
    public class log
    {

        public int ID { get; set; }
        public string Title { get; set; }

        
        public string Genre { get; set; }
        public string System { get; set; }

        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
    }
}