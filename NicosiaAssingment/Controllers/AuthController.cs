using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System;
using NicosiaAssingment.Models;
using Microsoft.Extensions.Options;
using NicosiaAssingment.BusinessLogic.Services;
using System.Threading.Tasks;
using NicosiaAssingment.Helpers;
using NicosiaAssingment.Dtos;
using Microsoft.AspNetCore.Http;

namespace NicosiaAssingment.Controllers;

[ApiController]
[Route("api/v1/[controller]/[action]")]
public class AuthController : ControllerBase
{
	private readonly Jwt _jwtSettings;
	private readonly IAuthService _authService;

	public AuthController(IOptions<Jwt> jwtSettings, IAuthService authService)
	{
		_jwtSettings = jwtSettings.Value;
		_authService = authService;
	}

	[HttpPost]
	[AllowAnonymous]
	[ProducesResponseType(200)]
	[ProducesResponseType(400)]
	public async Task<ActionResult> Authenticate(LoginCredentialsDto loginUser)
	{
		UserCredentialsBlo userCreds;
		try
		{
			userCreds = await _authService.AuthenticateCredentials(loginUser.Email, loginUser.Password, _jwtSettings.SigningKey);
		}
		catch (Exception ex)
		{
			return StatusCode(StatusCodes.Status400BadRequest, 
				new
				{
					Status = "Login failed",
					Reason = ex.Message,
				});
		}

		var claims = new List<Claim>
		{
			new Claim("userId", userCreds.UserId.ToString()),
			new Claim(ClaimTypes.Role, userCreds.Role)
		};
	
		var token = AuthHelper.GetJwtToken(
			userCreds.Email,
			_jwtSettings.SigningKey,
			_jwtSettings.Issuer,
			_jwtSettings.Audience,
			TimeSpan.FromMinutes(_jwtSettings.TokenTimeout),
			claims.ToArray());

		return Ok(new
		{
			token = new JwtSecurityTokenHandler().WriteToken(token),
			expires = token.ValidTo
		});
	}
}