﻿using CarBook.Application.Dtos;
using CarBook.Application.Features.Mediator.Results.AppUserResults;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace CarBook.Application.Tools
{
	public class JwtTokenGenerator
	{
		public static TokenResponseDto GenerateToken(GetCheckAppUserQueryResult result)
		{
			var claims = new List<Claim>();
			if (!string.IsNullOrWhiteSpace(result.Role))
				claims.Add(new Claim(ClaimTypes.Role, result.Role));
			claims.Add(new Claim(ClaimTypes.NameIdentifier, result.Id.ToString()));

			if (!string.IsNullOrWhiteSpace(result.Username))
				claims.Add(new Claim("Username", result.Username));

			var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtTokenDefaults.Key));
			var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

			var expireDate = DateTime.UtcNow.AddDays(JwtTokenDefaults.Expire);

			JwtSecurityToken token = new JwtSecurityToken(issuer: JwtTokenDefaults.ValidIssuer, audience: JwtTokenDefaults.ValidAudience, claims: claims, notBefore: DateTime.UtcNow, expires: expireDate, signingCredentials: signingCredentials);

			JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
			return new TokenResponseDto(tokenHandler.WriteToken(token), expireDate);
		}
	}
}
