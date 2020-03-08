﻿using Microsoft.Extensions.Logging;

namespace JwtAuthDemo.Services
{
    public interface IUserService
    {
        bool IsValidUser(string userName, string password);
    }

    public class UserService : IUserService
    {
        private readonly ILogger<UserService> _logger;
        // inject database for user validation
        public UserService(ILogger<UserService> logger)
        {
            _logger = logger;
        }

        public bool IsValidUser(string userName, string password)
        {
            _logger.LogInformation($"Validating user [{userName}]");
            if (string.IsNullOrWhiteSpace(userName))
            {
                return false;
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                return false;
            }

            if (userName == "admin" && password == "password")
            {
                return true;
            }
            return false;
        }
    }
}