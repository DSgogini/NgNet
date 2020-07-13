using Microsoft.AspNetCore.Identity;
using NgNet.Application.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NgNet.Infrastructure.Identity
{
    public static class IdentityResultExtensions
    {
        public static Result ToApplicationResult(this IdentityResult result)
        {
            return result.Succeeded
                ? Result.Success()
                : Result.Failure(result.Errors.Select(e => e.Description));
        }
    }
}