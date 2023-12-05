using System.ComponentModel.DataAnnotations;

namespace Template.Application.Features.Note.Shared.Dto
{
    public class NoteDto
    {
        public int Id { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = "Min Lenght is 3") ]
        [MaxLength(20, ErrorMessage = "Max Lenght is 20") ]
        public string Title { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = "Min Lenght is 3")]
        public string Content { get; set; }

        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}