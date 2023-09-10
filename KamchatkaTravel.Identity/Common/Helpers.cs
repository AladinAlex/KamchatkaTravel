using KamchatkaTravel.Identity.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KamchatkaTravel.Identity.Common
{
    public static class Helpers
    {
        public static string GetErrorString(IEnumerable<IdentityError> Errors)
        {
            StringBuilder result = new();
            int counter = 0;
            foreach (var error in Errors)
            {
                counter++;
                result.AppendLine("\r\n");
                result.AppendLine(
                    counter.ToString() +
                    ". Code: " +
                    error.Code +
                    ";" +
                    "Description: " +
                    error.Description +
                    ";"
                );
            }
            return result.ToString();
        }

        public static IdentityResponse BaseResponse(IdentityResult? result, string methodName)
        {
            if (result == null)
                return new IdentityResponse();

            if (result.Succeeded)
                return new IdentityResponse(ResponseStatus.Success);
            else
            {
                string errors = GetErrorString(result.Errors);
                return new IdentityResponse(ResponseStatus.Error, methodName + ". " + errors);
            }
        }
    }
}
