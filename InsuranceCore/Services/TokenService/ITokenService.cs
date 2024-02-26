﻿using InsuranceCore.Models.DTOs;
using InsuranceCore.Models.DTOs.Immutable;

namespace InsuranceCore.Services.Interface
{
    /// <summary>
    /// Service used to manipulate JWT
    /// </summary>
    public interface ITokenService
    {
        /// <summary>
        /// Generate a unique JWT Bearer token for a user.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<TokenItem> GenerateJwtAccessToken(int userId);

        /// <summary>
        /// Generate a unique JWT refresh token for a user
        /// </summary>
        Task<TokenItem> GenerateRefreshToken(int userId);


        /// <summary>
        /// Ensure tokens are valid and authentic
        /// </summary>
        /// <param name="refreshTokenDto"></param>
        public Task<bool> IsAuthenticAndValidRefreshToken(RefreshTokenDto refreshTokenDto);
    }
}
