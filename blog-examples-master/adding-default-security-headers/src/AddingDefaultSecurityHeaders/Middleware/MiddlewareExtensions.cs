﻿using System;
using Microsoft.AspNetCore.Builder;

namespace AddingDefaultSecurityHeaders.Middleware
{
public static class MiddlewareExtensions
{
    public static IApplicationBuilder UseSecurityHeadersMiddleware(this IApplicationBuilder app, SecurityHeadersBuilder builder)
    {
        if (app == null)
        {
            throw new ArgumentNullException(nameof(app));
        }

        if (builder == null)
        {
            throw new ArgumentNullException(nameof(builder));
        }

        return app.UseMiddleware<SecurityHeadersMiddleware>(builder.Build());
    }
}
}