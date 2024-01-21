﻿using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Nano.App.Api.Requests.Identity;
using Nano.Models.Interfaces;
using Nano.Security;
using Nano.Security.Models;
using Claim = Nano.Security.Models.Claim;

namespace Nano.App.Api;

/// <summary>
/// Default Identity Api.
/// </summary>
public abstract class BaseIdentityApi<TUser, TIdentity> : BaseApi<TIdentity>
    where TUser : class, IEntityUser<TIdentity>
    where TIdentity : IEquatable<TIdentity>
{
    /// <summary>
    /// Identity Controller.
    /// </summary>
    protected static string IdentityController => $"{typeof(TUser).Name.ToLower()}s";

    /// <inheritdoc />
    protected BaseIdentityApi(ApiOptions apiOptions)
        : base(apiOptions)
    {

    }

    /// <summary>
    /// Sign Up Async.
    /// </summary>
    /// <param name="request">The <see cref="SignUpRequest{TUser}"/>.</param>
    /// <param name="cancellationToken">The <see cref="CancellationToken"/>.</param>
    /// <returns>The instance of <typeparamref name="TUser"/>.</returns>
    public virtual Task<TUser> SignUpAsync(SignUpRequest<TUser, TIdentity> request, CancellationToken cancellationToken = default)
    {
        if (request == null)
            throw new ArgumentNullException(nameof(request));

        return this.InvokeAsync<SignUpRequest<TUser, TIdentity>, TUser>(request, cancellationToken);
    }

    /// <summary>
    /// Sign Up External Callback Async.
    /// </summary>
    /// <typeparam name="TSignUp">The signup type.</typeparam>
    /// <param name="request">The <see cref="BaseSignUpExternalRequest"/>.</param>
    /// <param name="cancellationToken">The <see cref="CancellationToken"/>.</param>
    /// <returns>The <see cref="AccessToken"/>.</returns>
    public virtual Task<TUser> SignUpExternalAsync<TSignUp>(TSignUp request, CancellationToken cancellationToken = default)
        where TSignUp : BaseSignUpExternalRequest
    {
        if (request == null)
            throw new ArgumentNullException(nameof(request));

        return this.InvokeAsync<TSignUp, TUser>(request, cancellationToken);
    }

    /// <summary>
    /// Set Username Async.
    /// </summary>
    /// <param name="request">The <see cref="SetUsernameRequest{TIdentity}"/>.</param>
    /// <param name="cancellationToken">The <see cref="CancellationToken"/>.</param>
    /// <returns>Void.</returns>
    public virtual Task SetUsernameAsync(SetUsernameRequest<TIdentity> request, CancellationToken cancellationToken = default)
    {
        if (request == null)
            throw new ArgumentNullException(nameof(request));

        request.Controller = BaseIdentityApi<TUser, TIdentity>.IdentityController;

        return this.InvokeAsync(request, cancellationToken);
    }

    /// <summary>
    /// Set Password Async.
    /// </summary>
    /// <param name="request">The <see cref="SetPasswordRequest"/>.</param>
    /// <param name="cancellationToken">The <see cref="CancellationToken"/>.</param>
    /// <returns>Void.</returns>
    public virtual Task SetPasswordAsync(SetPasswordRequest request, CancellationToken cancellationToken = default)
    {
        if (request == null)
            throw new ArgumentNullException(nameof(request));

        request.Controller = BaseIdentityApi<TUser, TIdentity>.IdentityController;

        return this.InvokeAsync(request, cancellationToken);
    }

    /// <summary>
    /// Reset Password Async.
    /// </summary>
    /// <param name="request">The <see cref="ResetPasswordRequest"/>.</param>
    /// <param name="cancellationToken">The <see cref="CancellationToken"/>.</param>
    /// <returns>Void.</returns>
    public virtual Task ResetPasswordAsync(ResetPasswordRequest request, CancellationToken cancellationToken = default)
    {
        if (request == null)
            throw new ArgumentNullException(nameof(request));

        request.Controller = BaseIdentityApi<TUser, TIdentity>.IdentityController;

        return this.InvokeAsync(request, cancellationToken);
    }

    /// <summary>
    /// Change Password Async.
    /// </summary>
    /// <param name="request">The <see cref="ChangePasswordRequest{TIdentity}"/>.</param>
    /// <param name="cancellationToken">The <see cref="CancellationToken"/>.</param>
    /// <returns>Void.</returns>
    public virtual Task ChangePasswordAsync(ChangePasswordRequest<TIdentity> request, CancellationToken cancellationToken = default)
    {
        if (request == null)
            throw new ArgumentNullException(nameof(request));

        request.Controller = BaseIdentityApi<TUser, TIdentity>.IdentityController;

        return this.InvokeAsync(request, cancellationToken);
    }

    /// <summary>
    /// Change Email Async.
    /// </summary>
    /// <param name="request">The <see cref="ChangeEmailRequest{TIdentity}"/>.</param>
    /// <param name="cancellationToken">The <see cref="CancellationToken"/>.</param>
    /// <returns>Void.</returns>
    public virtual Task ChangeEmailAsync(ChangeEmailRequest<TIdentity> request, CancellationToken cancellationToken = default)
    {
        if (request == null)
            throw new ArgumentNullException(nameof(request));

        request.Controller = BaseIdentityApi<TUser, TIdentity>.IdentityController;

        return this.InvokeAsync(request, cancellationToken);
    }

    /// <summary>
    /// Confirm Email Async.
    /// </summary>
    /// <param name="request">The <see cref="ConfirmEmailRequest"/>.</param>
    /// <param name="cancellationToken">The <see cref="CancellationToken"/>.</param>
    /// <returns>Void.</returns>
    public virtual Task ConfirmEmailAsync(ConfirmEmailRequest request, CancellationToken cancellationToken = default)
    {
        if (request == null)
            throw new ArgumentNullException(nameof(request));

        request.Controller = BaseIdentityApi<TUser, TIdentity>.IdentityController;

        return this.InvokeAsync(request, cancellationToken);
    }

    /// <summary>
    /// Get Change Email Token Async.
    /// </summary>
    /// <param name="request">The <see cref="GetChangeEmailTokenRequest"/>.</param>
    /// <param name="cancellationToken">The <see cref="CancellationToken"/>.</param>
    /// <returns>Void.</returns>
    public virtual Task<ChangeEmailToken> GetChangeEmailTokenAsync(GetChangeEmailTokenRequest request, CancellationToken cancellationToken = default)
    {
        if (request == null)
            throw new ArgumentNullException(nameof(request));

        request.Controller = BaseIdentityApi<TUser, TIdentity>.IdentityController;

        return this.InvokeAsync<GetChangeEmailTokenRequest, ChangeEmailToken>(request, cancellationToken);
    }

    /// <summary>
    /// Get Confirm Email Token Async.
    /// </summary>
    /// <param name="request">The <see cref="GetConfirmEmailTokenRequest"/>.</param>
    /// <param name="cancellationToken">The <see cref="CancellationToken"/>.</param>
    /// <returns>Void.</returns>
    public virtual Task<ConfirmEmailToken> GetConfirmEmailTokenAsync(GetConfirmEmailTokenRequest request, CancellationToken cancellationToken = default)
    {
        if (request == null)
            throw new ArgumentNullException(nameof(request));

        request.Controller = BaseIdentityApi<TUser, TIdentity>.IdentityController;

        return this.InvokeAsync<GetConfirmEmailTokenRequest, ConfirmEmailToken>(request, cancellationToken);
    }

    /// <summary>
    /// Change Phone Async.
    /// </summary>
    /// <param name="request">The <see cref="ChangePhoneRequest{TIdentity}"/>.</param>
    /// <param name="cancellationToken">The <see cref="CancellationToken"/>.</param>
    /// <returns>Void.</returns>
    public virtual Task ChangePhoneAsync(ChangePhoneRequest<TIdentity> request, CancellationToken cancellationToken = default)
    {
        if (request == null)
            throw new ArgumentNullException(nameof(request));

        request.Controller = BaseIdentityApi<TUser, TIdentity>.IdentityController;

        return this.InvokeAsync(request, cancellationToken);
    }

    /// <summary>
    /// Confirm Phone Async.
    /// </summary>
    /// <param name="request">The <see cref="ConfirmPhoneRequest"/>.</param>
    /// <param name="cancellationToken">The <see cref="CancellationToken"/>.</param>
    /// <returns>Void.</returns>
    public virtual Task ConfirmPhoneAsync(ConfirmPhoneRequest request, CancellationToken cancellationToken = default)
    {
        if (request == null)
            throw new ArgumentNullException(nameof(request));

        request.Controller = BaseIdentityApi<TUser, TIdentity>.IdentityController;

        return this.InvokeAsync(request, cancellationToken);
    }

    /// <summary>
    /// Get Change Phone Token Async.
    /// </summary>
    /// <param name="request">The <see cref="GetChangePhoneTokenRequest"/>.</param>
    /// <param name="cancellationToken">The <see cref="CancellationToken"/>.</param>
    /// <returns>Void.</returns>
    public virtual Task<ChangePhoneNumberToken> GetChangePhoneTokenAsync(GetChangePhoneTokenRequest request, CancellationToken cancellationToken = default)
    {
        if (request == null)
            throw new ArgumentNullException(nameof(request));

        request.Controller = BaseIdentityApi<TUser, TIdentity>.IdentityController;

        return this.InvokeAsync<GetChangePhoneTokenRequest, ChangePhoneNumberToken>(request, cancellationToken);
    }

    /// <summary>
    /// Get Confirm Phone Token Async.
    /// </summary>
    /// <param name="request">The <see cref="GetConfirmPhoneTokenRequest"/>.</param>
    /// <param name="cancellationToken">The <see cref="CancellationToken"/>.</param>
    /// <returns>Void.</returns>
    public virtual Task<ConfirmPhoneNumberToken> GetConfirmPhoneTokenAsync(GetConfirmPhoneTokenRequest request, CancellationToken cancellationToken = default)
    {
        if (request == null)
            throw new ArgumentNullException(nameof(request));

        request.Controller = BaseIdentityApi<TUser, TIdentity>.IdentityController;

        return this.InvokeAsync<GetConfirmPhoneTokenRequest, ConfirmPhoneNumberToken>(request, cancellationToken);
    }

    /// <summary>
    /// Get Reset Password Token Async.
    /// </summary>
    /// <param name="request">The <see cref="GetResetPasswordTokenRequest"/>.</param>
    /// <param name="cancellationToken">The <see cref="CancellationToken"/>.</param>
    /// <returns>Void.</returns>
    public virtual Task<ResetPasswordToken> GetResetPasswordTokenAsync(GetResetPasswordTokenRequest request, CancellationToken cancellationToken = default)
    {
        if (request == null)
            throw new ArgumentNullException(nameof(request));

        request.Controller = BaseIdentityApi<TUser, TIdentity>.IdentityController;

        return this.InvokeAsync<GetResetPasswordTokenRequest, ResetPasswordToken>(request, cancellationToken);
    }

    /// <summary>
    /// Get Password Options Async.
    /// </summary>
    /// <param name="request">The <see cref="GetPasswordOptionsRequest"/>.</param>
    /// <param name="cancellationToken">The <see cref="CancellationToken"/>.</param>
    /// <returns>Void.</returns>
    public virtual Task<SecurityOptions.PasswordOptions> GetPasswordOptionsAsync(GetPasswordOptionsRequest request, CancellationToken cancellationToken = default)
    {
        if (request == null)
            throw new ArgumentNullException(nameof(request));

        request.Controller = BaseIdentityApi<TUser, TIdentity>.IdentityController;

        return this.InvokeAsync<GetPasswordOptionsRequest, SecurityOptions.PasswordOptions>(request, cancellationToken);
    }

    /// <summary>
    /// Remove External Login Async.
    /// </summary>
    /// <param name="request">The <see cref="RemoveExternalLogInRequest"/>.</param>
    /// <param name="cancellationToken">The <see cref="CancellationToken"/>.</param>
    /// <returns>Void.</returns>
    public virtual Task RemoveExternalLoginAsync(RemoveExternalLogInRequest request, CancellationToken cancellationToken = default)
    {
        if (request == null)
            throw new ArgumentNullException(nameof(request));

        request.Controller = BaseIdentityApi<TUser, TIdentity>.IdentityController;

        return this.InvokeAsync(request, cancellationToken);
    }

    /// <summary>
    /// Get User Roles Async.
    /// </summary>
    /// <param name="request">The <see cref="GetRolesRequest{TIdentity}"/>.</param>
    /// <param name="cancellationToken">The <see cref="CancellationToken"/>.</param>
    /// <returns>Void.</returns>
    public virtual Task<IEnumerable<string>> GetRolesAsync(GetRolesRequest<TIdentity> request, CancellationToken cancellationToken = default)
    {
        if (request == null)
            throw new ArgumentNullException(nameof(request));

        request.Controller = BaseIdentityApi<TUser, TIdentity>.IdentityController;

        return this.InvokeAsync<GetRolesRequest<TIdentity>, IEnumerable<string>>(request, cancellationToken);
    }

    /// <summary>
    /// Assign Role Async.
    /// </summary>
    /// <param name="request">The <see cref="AssignRoleRequest{TIdentity}"/>.</param>
    /// <param name="cancellationToken">The <see cref="CancellationToken"/>.</param>
    /// <returns>Void.</returns>
    public virtual Task AssignUserRoleAsync(AssignRoleRequest<TIdentity> request, CancellationToken cancellationToken = default)
    {
        if (request == null)
            throw new ArgumentNullException(nameof(request));

        request.Controller = BaseIdentityApi<TUser, TIdentity>.IdentityController;

        return this.InvokeAsync(request, cancellationToken);
    }

    /// <summary>
    /// Remove Role Async.
    /// </summary>
    /// <param name="request">The <see cref="RemoveRoleRequest{TIdentity}"/>.</param>
    /// <param name="cancellationToken">The <see cref="CancellationToken"/>.</param>
    /// <returns>Void.</returns>
    public virtual Task RemoveUserRoleAsync(RemoveRoleRequest<TIdentity> request, CancellationToken cancellationToken = default)
    {
        if (request == null)
            throw new ArgumentNullException(nameof(request));

        request.Controller = BaseIdentityApi<TUser, TIdentity>.IdentityController;

        return this.InvokeAsync(request, cancellationToken);
    }

    /// <summary>
    /// Get Claims Async.
    /// </summary>
    /// <param name="request">The <see cref="GetClaimsRequest{TIdentity}"/>.</param>
    /// <param name="cancellationToken">The <see cref="CancellationToken"/>.</param>
    /// <returns>Void.</returns>
    public virtual Task<IEnumerable<Claim>> GetClaimsAsync(GetClaimsRequest<TIdentity> request, CancellationToken cancellationToken = default)
    {
        if (request == null)
            throw new ArgumentNullException(nameof(request));

        request.Controller = BaseIdentityApi<TUser, TIdentity>.IdentityController;

        return this.InvokeAsync<GetClaimsRequest<TIdentity>, IEnumerable<Claim>>(request, cancellationToken);
    }

    /// <summary>
    /// Assign Claim Async.
    /// </summary>
    /// <param name="request">The <see cref="AssignClaimRequest{TIdentity}"/>.</param>
    /// <param name="cancellationToken">The <see cref="CancellationToken"/>.</param>
    /// <returns>Void.</returns>
    public virtual Task AssignUserClaimAsync(AssignClaimRequest<TIdentity> request, CancellationToken cancellationToken = default)
    {
        if (request == null)
            throw new ArgumentNullException(nameof(request));

        request.Controller = BaseIdentityApi<TUser, TIdentity>.IdentityController;

        return this.InvokeAsync(request, cancellationToken);
    }

    /// <summary>
    /// Remove Claim Async.
    /// </summary>
    /// <param name="request">The <see cref="RemoveClaimRequest{TIdentity}"/>.</param>
    /// <param name="cancellationToken">The <see cref="CancellationToken"/>.</param>
    /// <returns>Void.</returns>
    public virtual Task RemoveUserClaimAsync(RemoveClaimRequest<TIdentity> request, CancellationToken cancellationToken = default)
    {
        if (request == null)
            throw new ArgumentNullException(nameof(request));

        request.Controller = BaseIdentityApi<TUser, TIdentity>.IdentityController;

        return this.InvokeAsync(request, cancellationToken);
    }
}