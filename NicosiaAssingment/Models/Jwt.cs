namespace NicosiaAssingment.Models
{
	public class Jwt
	{
		public string Issuer { get; set; }
		public string Audience { get; set; }
		public string SigningKey { get; set; }
		public int TokenTimeout { get; set; }
	}
}
