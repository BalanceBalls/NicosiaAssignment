namespace NicosiaAssingment.Dtos;

public class PendingMessageRequestDto
{
	public int MessageId { get; set; }
	public string SectionName { get; set; }
	public string Content { get; set; }
	public string SenderName { get; set; }
	public string? ApproverName { get; set; }
	public bool IsApproved { get; set; } = false;
}
