using System.Threading.Tasks;

namespace NicosiaAssingment.BusinessLogic.Services;

public interface IAuthService
{
	Task<UserCredentialsBlo> AuthenticateCredentials(string email, string password, string signingKey);
}
