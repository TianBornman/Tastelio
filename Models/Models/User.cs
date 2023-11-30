using System;

namespace Models.Models
{
	public class User : BaseModel
	{
		public Guid Id { get; set; }
		public string? Email { get; set; }
		public string? Firstname { get; set; }
		public string? Lastname { get; set; }
		public string? Password { get; set; }
		public Guid PasswordSalt { get; set; }
	}
}
