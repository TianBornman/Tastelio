using System.ComponentModel.DataAnnotations;

namespace Models.Models
{
	public class LoginModel
	{
		[Required]
		[EmailAddress]
		[MaxLength(50, ErrorMessage = "The {0} field must be shorter than {1} characters")]
		public string? Email { get; set; }		

		[Required]
		[Length(5, 500, ErrorMessage = "The {0} field must be between {1} and {2} characters in length.")]
		public string? Password { get; set; }
	}
}
