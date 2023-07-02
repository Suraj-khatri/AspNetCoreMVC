using System.ComponentModel.DataAnnotations;

namespace BookStore.Models
{
    public class BookModel
    {
        public int Id { get; set; }
        [StringLength(100,MinimumLength =10)]
        [Required(ErrorMessage ="Please enter the Title of your book.")]
        public string Title { get; set; }


        [StringLength(50, MinimumLength = 5)]
        [Required(ErrorMessage = "Please enter the Author of your book.")]
        public string Author { get; set; }
        [StringLength(500, MinimumLength = 10)]

        public string Description { get; set; }
        public string Category { get; set; }
        public string Language { get; set; }

        [Display(Name ="Total Pages Of Book")]
        [Required(ErrorMessage = "Please enter the Total Pages of your book.")]
        public int? TotalPages { get; set; }

    }
}
