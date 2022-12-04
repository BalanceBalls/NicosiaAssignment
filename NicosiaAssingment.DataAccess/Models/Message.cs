using System.ComponentModel.DataAnnotations.Schema;

namespace NicosiaAssingment.DataAccess.Models;

[Table("Messages")]
public class Message
{
	public int Id { get; set; }
	public User Sender { get; set; }
	public int SenderId { get; set; }
	public User Approver { get; set; }
	public int? ApproverId { get; set; }
	public bool IsApproved { get; set; }
	public string Content { get; set; }
	public Section TargetSection { get; set; }
	public int TargetSectionId { get; set; }
}
