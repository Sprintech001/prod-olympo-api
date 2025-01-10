// using Microsoft.AspNetCore.Http;
// using System.Threading.Tasks;
// using YourNamespace.Services; // Adicione o namespace do serviço de autenticação

// public class AuthorizationMiddleware
// {
//     private readonly RequestDelegate _next;
//     private readonly IAuthenticationService _authService; // Adicione o serviço de autenticação

//     public AuthorizationMiddleware(RequestDelegate next, IAuthenticationService authService)
//     {
//         _next = next;
//         _authService = authService; // Inicialize o serviço de autenticação
//     }

//     public async Task InvokeAsync(HttpContext context)
//     {
//         var isAuthenticated = await _authService.IsAuthenticatedAsync(context.User.Identity.Name); 

//         if (!isAuthenticated)
//         {
//             context.Response.StatusCode = StatusCodes.Status401Unauthorized;
//             await context.Response.WriteAsync("Unauthorized access.");
//             return;
//         }

//         await _next(context);
//     }
// }
