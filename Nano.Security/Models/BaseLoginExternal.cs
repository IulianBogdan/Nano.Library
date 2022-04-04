﻿namespace Nano.Security.Models
{
    /// <summary>
    /// Base Login External (abstract).
    /// </summary>
    public abstract class BaseLoginExternal : BaseLogin
    {

    }

    /// <summary>
    /// Base Login External (abstract).
    /// </summary>
    /// <typeparam name="TProvider">The provider type.</typeparam>
    public abstract class BaseLoginExternal<TProvider> : BaseLoginExternal
        where TProvider : BaseLoginExternalProvider, new()
    {
        /// <summary>
        /// Provider.
        /// </summary>
        public TProvider Provider { get; set; } = new();
    }
}
