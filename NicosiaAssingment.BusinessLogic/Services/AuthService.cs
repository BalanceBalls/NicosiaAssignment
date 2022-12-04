using AutoMapper;
using NicosiaAssingment.DataAccess.Repositories;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace NicosiaAssingment.BusinessLogic.Services;

public class AuthService : IAuthService
{
	private readonly INicosiaRepository _nicosiaRepository;
	private readonly IMapper _mapper;

	public AuthService(INicosiaRepository nicosiaRepository, IMapper mapper)
	{
		_nicosiaRepository = nicosiaRepository;
		_mapper = mapper;
	}

	public async Task<UserCredentialsBlo> AuthenticateCredentials(string email, string password, string signingKey)
	{
		var userCreds = await _nicosiaRepository.GetUserByEmail(email);

		if (userCreds is null)
			throw new ArgumentException($"User with {email} was not found");

		using var sha256 = SHA256.Create();
		var userInputHash = SHA256Sum(password, signingKey);
		if (userInputHash.ToLower() != userCreds.PwdHash.ToLower())
			throw new Exception("Incorrect password");

		return _mapper.Map<UserCredentialsBlo>(userCreds);
	}


	private static string SHA256Sum(string signingInput, string sharedSecret)
	{
		var encoding = new UTF8Encoding();
		var keyByte = encoding.GetBytes(sharedSecret);
		using (var hmacsha256 = new HMACSHA256(keyByte))
		{
			hmacsha256.ComputeHash(encoding.GetBytes(signingInput));
			return ByteToString(hmacsha256.Hash);
		}
	}

	private static string ByteToString(byte[] buff)
	{
		string sbinary = "";
		for (int i = 0; i < buff.Length; i++)
			sbinary += buff[i].ToString("X2");
		return sbinary;
	}
}
