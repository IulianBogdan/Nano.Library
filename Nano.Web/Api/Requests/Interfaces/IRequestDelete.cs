﻿namespace Nano.Web.Api.Requests.Interfaces
{
    /// <summary>
    /// Base interface for delete requests (DELETE).
    /// </summary>
    public interface IRequestDelete : IRequest
    {
        /// <summary>
        /// Get Body.
        /// </summary>
        object GetBody();
    }
}