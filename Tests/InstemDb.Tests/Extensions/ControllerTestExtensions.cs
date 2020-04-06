using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace InstemDb.Tests.Extensions
{
    public static class ControllerTestExtensions
    {
        public static TController WithTestUser<TController>(this TController controller)
            where TController : Microsoft.AspNetCore.Mvc.Controller
        {
            controller.ControllerContext = new Microsoft.AspNetCore.Mvc.ControllerContext
            {
                HttpContext = new DefaultHttpContext
                {
                    User = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, TestConstants.TestUsername)
                    }))
                }
            };

            return controller;
        }
    }
}
