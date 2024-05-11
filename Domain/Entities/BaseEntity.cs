namespace Domain.Entities;

public class BaseEntity
{
	public DateTime CreationDate { get; set; }
	public DateTime? ModifiedDate { get; set; }
	public bool Active { get; set; }
}
