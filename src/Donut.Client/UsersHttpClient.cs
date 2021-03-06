﻿// Copyright (c) Lykke Corp.
// See the LICENSE file in the project root for more information.

namespace Donut.Client
{
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// An HTTP client for managing users of the authorization server.
    /// </summary>
    public sealed class UsersHttpClient : HttpClientBase, IUsersClient
    {
        private const string ApiPath = "/api/user";

#pragma warning disable CA1054
        /// <summary>
        /// Initializes a new instance of the <see cref="UsersHttpClient"/> class.
        /// </summary>
        /// <param name="serviceUrl">The service url.</param>
        /// <param name="innerHandler">The inner handler.</param>
        public UsersHttpClient(string serviceUrl, HttpMessageHandler innerHandler = null)
            : base(serviceUrl, innerHandler)
        {
        }

        /// <summary>
        /// Adds the specified user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The new user.</returns>
        public async Task AddUserAsync(User user, CancellationToken cancellationToken = default) =>
            await this.SendAsync<User>(HttpMethod.Post, this.RelativeUrl(ApiPath), user, cancellationToken).ConfigureAwait(false);
    }
}