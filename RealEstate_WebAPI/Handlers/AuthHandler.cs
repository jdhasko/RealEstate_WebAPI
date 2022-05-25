using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using RealEstate_WebAPI.Models;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;

namespace RealEstate_WebAPI.Handlers
{
    public class AuthHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        public AuthHandler(IOptionsMonitor<AuthenticationSchemeOptions> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock)
            : base(options, logger, encoder, clock)
        {
        }
        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if (!Request.Headers.ContainsKey("Authorization"))
                return AuthenticateResult.Fail("No authorization header were found.");
            try
            {
                var authorizationHeaderValue = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);
                var bytes = Convert.FromBase64String(authorizationHeaderValue.Parameter);
                string[] credentials = Encoding.UTF8.GetString(bytes).Split(':');
                string username = credentials[0];
                string password = credentials[1];

                using (var context = new realestatedbContext())
                {
                    Auth auth = context.Auths.Where(x => x.Username == username).FirstOrDefault();



                    if (auth == null)
                    {
                        return AuthenticateResult.Fail("Authentication failed!");

                    }
                    else
                    {
                        var claims = new[] { new Claim(ClaimTypes.Name, auth.Username) };
                        var identity = new ClaimsIdentity(claims, Scheme.Name);
                        var principal = new ClaimsPrincipal(identity);
                        var ticket = new AuthenticationTicket(principal, Scheme.Name);
                        return AuthenticateResult.Success(ticket);
                    }
                }
            }
            catch (Exception ex)
            {
                return AuthenticateResult.Fail(ex);

            }
            return AuthenticateResult.Fail("Authentication failed!");

        }

    }
}
