using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace NicosiaAssingment.Helpers;

public static class AuthHelper
{
	public const string LecturerRole = "Lecturer";
	public const string StudentRole = "Student";
	private const string UserIdClaimKey = "userId";

	public static string GetRole(this HttpContext httpContext)
	{
		if (httpContext.User.Identity is ClaimsIdentity identity)
		{
			return identity.FindFirst(ClaimTypes.Role).Value;
		}

		return StudentRole;
	}

	public static string GetUserId(this HttpContext httpContext)
	{
		if (httpContext.User.Identity is ClaimsIdentity identity)
		{
			return identity.FindFirst(UserIdClaimKey).Value;
		}

		return int.MinValue.ToString();
	}

	public static JwtSecurityToken GetJwtToken(
		string email,
		string signingKey,
		string issuer,
		string audience,
		TimeSpan expiration,
		Claim[] additionalClaims = null)
	{
		var claims = new[]
		{
			new Claim(JwtRegisteredClaimNames.Sub, email),
			new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
		};

		if (additionalClaims is not null)
		{
			var claimList = new List<Claim>(claims);
			claimList.AddRange(additionalClaims);
			claims = claimList.ToArray();
		}

		var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(signingKey));
		var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

		return new JwtSecurityToken(
			issuer: issuer,
			audience: audience,
			expires: DateTime.UtcNow.Add(expiration),
			claims: claims,
			signingCredentials: creds
		);
	}
}
