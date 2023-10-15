using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Reflection;
using Zuri_Portfolio_Explore.Domains.DTOs;
using Zuri_Portfolio_Explore.Domains.DTOs.Response;
using Zuri_Portfolio_Explore.Domains.Models;

namespace Zuri_Portfolio_Explore.Repository.Services
{
    public class AuthService : IAuthService
    {

        //public async Task<ApiResponse<bool>> Login(UserLoginDTO user)
        //{
          
        //    User? user_login = await db_context.Users.Where(u => u.Email == user.Email).Include(x => x.Org).FirstOrDefaultAsync();

        //    var userindb = mapper.Map<CreateUserDTO>(user_login);

        //    // ensure user exists
        //    if (user_login is null)
        //    {
        //        response.success = false;
        //        response.message = "User not found";
        //        response.statusCode = HttpStatusCode.Unauthorized;
        //        response.data = new Dictionary<string, string>() {
        //            { "email", user.Email }
        //        };

        //        return response;
        //    }

        //    // ensure password is correct
        //    try
        //    {
        //        var passwordIsValid = authentication.verifyPasswordHash(user.Password, user_login.PasswordHash);

        //        if (!passwordIsValid)
        //        {
        //            response.success = false;
        //            response.message = "Incorrect password";
        //            response.statusCode = HttpStatusCode.Unauthorized;
        //        }
        //        else
        //        {
        //            // get role (even if it's null) and create token
        //            var role = user_login.IsAdmin == true ? "admin" : "user";
        //            var token = authentication.createToken(user_login.Id.ToString(), role);

        //            response.success = true;

        //            // get user data and add token
        //            var res = user_login
        //                .GetType()
        //                .GetProperties(BindingFlags.Instance | BindingFlags.Public)
        //                .ToDictionary(prop => prop.Name, prop => Convert.ToString(prop.GetValue(user_login, null)));

        //            // remove sensitive data
        //            res.Remove("PasswordHash");
        //            res.Remove("LunchReceivers");
        //            res.Remove("LunchSenders");
        //            res.Remove("Withdrawals");
        //            res.Remove("IsDeleted");
        //            res.Remove("Org");

        //            res.Add("access_token", token);
        //            res.Add("organization_name", user_login.Org?.Name ?? "Default Organization");

        //            response.data = res!;
        //            response.message = "User authenticated successfully";
        //            response.statusCode = HttpStatusCode.OK;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        response.success = false;
        //        response.message = ex.Message;
        //        response.statusCode = HttpStatusCode.InternalServerError;
        //    }

        //    return response;
        //}


    }

    public interface IAuthService
    {
    }
}
