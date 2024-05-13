namespace Domain.Entities;

public class Reservation : BaseEntity
{
	public Guid Id { get; set; }
	public DateTime StartDate { get; set; }
	public DateTime EndDate { get; set; }
}
