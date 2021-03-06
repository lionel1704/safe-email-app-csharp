﻿using System;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace SafeMessages.Services
{
    internal class CredentialCacheService
    {
        private const string AuthRspKey = "AuthRsp";

        public void Delete()
        {
            try
            {
                SecureStorage.RemoveAll();
            }
            catch (Exception)
            {
                // ignore acct not existing
            }
        }

        public async Task<string> Retrieve()
        {
            var authResponse = await SecureStorage.GetAsync(AuthRspKey);
            if (authResponse == null)
            {
                throw new NullReferenceException("authResponse");
            }

            return authResponse;
        }

        public async Task Store(string authRsp)
        {
            await SecureStorage.SetAsync(AuthRspKey, authRsp);
        }
    }
}
