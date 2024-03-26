using System.ComponentModel.DataAnnotations;

namespace PersonalSiteMVC.Models
{
    public class ContactViewModel
    {
        [Required(ErrorMessage = "*Name is required")]//Makes the field required
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "*Email is required")]
        [DataType(DataType.EmailAddress)]//This ensures minimal email formatting (chars + @ + chars + . + chars
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "*Subject is required")]
        public string Subject { get; set; } = null!;

        [Required(ErrorMessage = "*Message is required")]
        [DataType(DataType.MultilineText)]//Makes the text box for this field bigger
        public string Message { get; set; } = null!;
    }
}
