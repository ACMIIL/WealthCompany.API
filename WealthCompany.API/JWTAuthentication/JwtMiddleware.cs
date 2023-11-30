//using Microsoft.IdentityModel.Tokens;
//using System.Net;
//using System.Text;

//public class JwtMiddleware
//{
//    private readonly RequestDelegate _next;
//    private readonly IConfiguration _configuration;

//    public JwtMiddleware(RequestDelegate next, IConfiguration configuration)
//    {
//        _next = next;
//        _configuration = configuration;
//    }

//    public async Task Invoke(HttpContext context)
//    {
//        var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

//        if (string.IsNullOrEmpty(token) || !token.StartsWith("Bearer "))
//        {
//            context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
//            return;
//        }

//        AttachUserToContext(context, token);

//        await _next(context);
//    }
//    private void AttachUserToContext(HttpContext context, string token)
//    {
//        try
//        {
//            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Secret"]);
//            var tokenHandler = new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler();
//            var claimsPrincipal = tokenHandler.ValidateToken(token, new TokenValidationParameters
//            {
//                ValidateIssuerSigningKey = true,
//                IssuerSigningKey = new SymmetricSecurityKey(key),
//                ValidateIssuer = false,
//                ValidateAudience = false
//            }, out var validatedToken);

//            // Log token details for debugging
//            Console.WriteLine("Token Validation Successful:");
//            Console.WriteLine($"Token Value: {token}");
//            Console.WriteLine($"Expiration Time: {validatedToken?.ValidTo}");

//            context.User = claimsPrincipal;
//        }
//        catch (Exception ex)
//        {
//            // Handle token validation failure
//            context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
//            Console.WriteLine($"Unauthorized: Token validation failed. Error: {ex.Message}");
//        }
//    }

//}
