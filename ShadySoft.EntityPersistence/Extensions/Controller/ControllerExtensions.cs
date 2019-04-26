using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShadySoft.EntityPersistence.Extensions.Controller
{
    public static class ControllerExtensions
    {
        public static TEntity GetFoundEntity<TEntity>(this HttpContext httpContext) where TEntity : class
        {
            if (httpContext == null)
                throw new ArgumentNullException(nameof(httpContext));

            return httpContext.Items["entity"] as TEntity;
        }
    }
}
