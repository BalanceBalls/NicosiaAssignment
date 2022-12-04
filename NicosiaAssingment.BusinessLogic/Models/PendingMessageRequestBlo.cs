
namespace NicosiaAssingment.BusinessLogic.Models;

public class PendingMessageRequestBlo
{
	public int MessageId { get; set; }
	public string SectionName { get; set; }
	public string Content { get; set; }
	public string SenderName { get; set; }
	public string? ApproverName { get; set; }
	public bool IsApproved { get; set; } = false;
}
