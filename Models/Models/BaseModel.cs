namespace Models.Models
{
	public class BaseModel
	{
		public DateTime CreationDate { get; set; }
		public DateTime? ModifiedDate { get; set; }
		public bool Active { get; set; }
	}
}
