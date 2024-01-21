﻿using Nano.Security.Models;

namespace Nano.App.Api.Requests.Identity;

/// <inheritdoc />
public class ConfirmEmailRequest : BaseRequestPost
{
    /// <summary>
    /// Confirm Email.
    /// </summary>
    public virtual ConfirmEmail ConfirmEmail { get; set; } = new();

    /// <inheritdoc />
    public ConfirmEmailRequest()
    {
        this.Action = "email/confirm";
    }

    /// <inheritdoc />
    public override object GetBody()
    {
        return this.ConfirmEmail;
    }
}