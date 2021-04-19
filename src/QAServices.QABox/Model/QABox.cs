using System;
using System.ComponentModel.DataAnnotations;

namespace QAServices.QABox
{
    public class QABox
    {
        [Required]
        [Range(0, 1000)]
        public int Id { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public string Description { get; set; }
        
        public bool Free { get; set; }

    }
}
