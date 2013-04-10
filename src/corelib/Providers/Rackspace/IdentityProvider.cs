﻿using JSIStudios.SimpleRESTServices.Client;
using net.openstack.Core.Domain;

namespace net.openstack.Providers.Rackspace
{
    public class IdentityProvider : IExtendedIdentityProvider
    {
        private readonly IdentityProviderFactory _factory;

        public IdentityProvider() : this(null, null, null, null, null)
        {}

        public IdentityProvider(CloudIdentity defaultIdentity)
            : this(defaultIdentity, null, null, null, null)
        { }

        public IdentityProvider(string usInstanceUrlBase, string ukInstanceUrlBase)
            : this(null, null, null, usInstanceUrlBase, ukInstanceUrlBase)
        { }

        public IdentityProvider(CloudIdentity defaultIdentity, string usInstanceUrlBase, string ukInstanceUrlBase)
            : this(defaultIdentity, null, null, usInstanceUrlBase, ukInstanceUrlBase)
        { }

        public IdentityProvider(IRestService restService, ICache<UserAccess> tokenCache, string usInstanceUrlBase, string ukInstanceUrlBase)
            : this(null, restService, tokenCache, usInstanceUrlBase, ukInstanceUrlBase)
        {}

        public IdentityProvider(IRestService restService, ICache<UserAccess> tokenCache)
            : this(null, restService, tokenCache, null, null)
        { }

        public IdentityProvider(CloudIdentity defaultIdentity, IRestService restService, ICache<UserAccess> tokenCache, string usInstanceUrlBase, string ukInstanceUrlBase)
        {
            _factory = new IdentityProviderFactory(defaultIdentity, restService, tokenCache, usInstanceUrlBase, ukInstanceUrlBase);
        }

        public Role[] ListRoles(CloudIdentity identity)
        {
            var provider = GetProvider(identity);
            return provider.ListRoles(identity);
        }

        public Role AddRole(Role role, CloudIdentity identity)
        {
            var provider = GetProvider(identity);
            return provider.AddRole(role, identity: identity);
        }

        public Role GetRole(string roleId, CloudIdentity identity)
        {
            var provider = GetProvider(identity);
            return provider.GetRole(roleId, identity: identity);
        }

        public Role[] GetRolesByUser(string userId, CloudIdentity identity)
        {
            var provider = GetProvider(identity);
            return provider.GetRolesByUser(userId, identity: identity);
        }

        public User[] ListUsers(CloudIdentity identity)
        {
            var provider = GetProvider(identity);
            return provider.ListUsers(identity);
        }

        public User GetUserByName(string name, CloudIdentity identity)
        {
            var provider = GetProvider(identity);
            return provider.GetUserByName(name, identity: identity);
        }

        public UserAccess Authenticate(CloudIdentity identity)
        {
            var provider = GetProvider(identity);
            return provider.Authenticate(identity);
        }

        public bool AddRoleToUser(string userId, string roleId, CloudIdentity identity)
        {
            var provider = GetProvider(identity);
            return provider.AddRoleToUser(userId, roleId, identity: identity);
        }

        public User GetUser(string userId, CloudIdentity identity)
        {
            var provider = GetProvider(identity);
            return provider.GetUser(userId, identity: identity);
        }

        public NewUser AddUser(NewUser newUser, CloudIdentity identity)
        {
            var provider = GetProvider(identity);
            return provider.AddUser(newUser, identity: identity);
        }

        public User UpdateUser(User user, CloudIdentity identity)
        {
            var provider = GetProvider(identity);
            return provider.UpdateUser(user, identity: identity);
        }

        public bool DeleteUser(string userId, CloudIdentity identity)
        {
            var provider = GetProvider(identity);
            return provider.DeleteUser(userId, identity: identity);
        }

        public bool SetUserPassword(string userId, string password, CloudIdentity identity)
        {
            var provider = GetProvider(identity);
            return provider.SetUserPassword(userId, password, identity: identity);
        }

        public bool SetUserPassword(User user, string password, CloudIdentity identity)
        {
            var provider = GetProvider(identity);
            return provider.SetUserPassword(user, password, identity: identity);
        }

        public bool SetUserPassword(string userId, string username, string password, CloudIdentity identity)
        {
            var provider = GetProvider(identity);
            return provider.SetUserPassword(userId, username, password, identity: identity);
        }

        public UserCredential UpdateUserCredentials(User user, string apiKey, CloudIdentity identity)
        {
            var provider = GetProvider(identity);
            return provider.UpdateUserCredentials(user, apiKey, identity: identity);
        }

        public UserCredential UpdateUserCredentials(string userId, string username, string apiKey, CloudIdentity identity)
        {
            var provider = GetProvider(identity);
            return provider.UpdateUserCredentials(userId, username, apiKey, identity: identity);
        }

        public UserCredential[] ListUserCredentials(string userId, CloudIdentity identity)
        {
            var provider = GetProvider(identity);
            return provider.ListUserCredentials(userId, identity: identity);
        }

        public UserCredential UpdateUserCredentials(string userId, string apiKey, CloudIdentity identity)
        {
            var provider = GetProvider(identity);
            return provider.UpdateUserCredentials(userId, apiKey, identity: identity);
        }

        public bool DeleteUserCredentials(string userId, CloudIdentity identity)
        {
            var provider = GetProvider(identity);
            return provider.DeleteUserCredentials(userId, identity: identity);
        }

        public Tenant[] ListTenants(CloudIdentity identity)
        {
            var provider = GetProvider(identity);
            return provider.ListTenants(identity);
        }

        public UserAccess GetUserAccess(CloudIdentity identity, bool forceCacheRefresh = false)
        {
            var provider = GetProvider(identity);
            return provider.GetUserAccess(identity, forceCacheRefresh);
        }

        public UserCredential GetUserCredential(string userId, string credentialKey, CloudIdentity identity)
        {
            var provider = GetProvider(identity);
            return provider.GetUserCredential(userId, credentialKey, identity: identity);
        }

        public string GetToken(CloudIdentity identity, bool forceCacheRefresh = false)
        {
            var provider = GetProvider(identity);
            return provider.GetToken(identity, forceCacheRefresh);
        }

        public bool DeleteRoleFromUser(string userId, string roleId, CloudIdentity identity)
        {
            var provider = GetProvider(identity);
            return provider.DeleteRoleFromUser(userId, roleId, identity: identity);
        }

        public IdentityToken GetTokenInfo(CloudIdentity identity, bool forceCacheRefresh = false)
        {
            var provider = GetProvider(identity);
            return provider.GetTokenInfo(identity);
        }

        private IExtendedIdentityProvider GetProvider(CloudIdentity identity)
        {
            return _factory.Get(identity);
        }
    }
}