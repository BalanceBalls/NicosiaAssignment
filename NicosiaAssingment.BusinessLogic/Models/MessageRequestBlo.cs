namespace NicosiaAssingment.BusinessLogic.Models;

public class MessageRequestBlo
{
	public int SectionId { get; set; }
	public string Content { get; set; }
	public int SenderId { get; set; }
	public int? ApproverId { get; set; }
	public bool IsApproved { get; set; } = false;
}
