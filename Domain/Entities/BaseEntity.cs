namespace Domain.Entities;

public class BaseEntity
{
	public DateTime CreationDate { get; set; } = DateTime.Now;
	public DateTime? ModifiedDate { get; set; }
	public bool Active { get; set; } = true;
}
