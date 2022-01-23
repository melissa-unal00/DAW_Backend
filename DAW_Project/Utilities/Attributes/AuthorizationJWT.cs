using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DAW_Project.Models;

namespace DAW_Project.Utilities.Attributes
{
    public class AuthorizationJWT : Attribute, IAuthorizationFilter
    {
        private readonly ICollection<Role> _roles;
        private readonly JWTMiddleware _jwtMiddlewaree;

        public AuthorizationJWT(JWTMiddleware _jwtMiddleware)
        {
            _jwtMiddleware = _jwtMiddlewaree;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var unauthorizedStatusCodeObject =
                new JsonResult(new
                {
                    Message = "Unauthorized"
                })
                { StatusCode = StatusCodes.Status401Unauthorized };

            if (_jwtMiddlewaree == null)
            {
                context.Result = unauthorizedStatusCodeObject;
            }

        }
    }
}
