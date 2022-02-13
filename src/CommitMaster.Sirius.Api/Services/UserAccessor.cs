using System;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace CommitMaster.Sirius.Api.Services;

public class UserAccessor 
{
    private readonly IHttpContextAccessor _accessor;

    public UserAccessor(IHttpContextAccessor accessor)
    {
        _accessor = accessor;
    }

    public Guid GetUserId()
    {
        return IsAuthenticated()
            ? Guid.Parse(_accessor!.HttpContext!.User.GetUserId())
            : Guid.Empty;
    }
        
    public string GetUserEmail()
    {
        return IsAuthenticated()
            ? _accessor!.HttpContext!.User.GetUserEmail()
            : null;
    }

    public bool IsAuthenticated()
    {
        return _accessor?.HttpContext?.User.Identity?.IsAuthenticated ?? false;
    }
}
    
public static class ClaimsPrincipalExtensions
{
    public static string GetUserId(this ClaimsPrincipal principal)
    {
        if (principal == null)
        {
            throw new ArgumentException(nameof(principal));
        }

        var claim = principal.FindFirst(ClaimTypes.NameIdentifier);
        return claim?.Value;
    }

    public static string GetUserEmail(this ClaimsPrincipal principal)
    {
        if (principal == null)
        {
            throw new ArgumentException(nameof(principal));
        }

        var claim = principal.FindFirst(ClaimTypes.Email);
        return claim?.Value;
    }
}
