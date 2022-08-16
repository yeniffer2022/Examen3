using Blazor.Data;
using Datos.Interfaces;
using Datos.Repositorios;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Modelos;
using System.Security.Claims;

namespace Blazor.Controllers
{
    public class LoginController : Controller
    {
        private readonly MySQLConfiguracion _configuracion;
        private ILoginRepositorio _loginRepositorio;
        private IUsuarioRepositorio _usuarioRepositorio;
        public LoginController(MySQLConfiguracion configuracion)
        {
            _configuracion = configuracion;
            _loginRepositorio = new LoginRepositorio(configuracion.CadenaConexion);
            _usuarioRepositorio = new UsuarioRepositorio(configuracion.CadenaConexion);
        }

        [HttpPost("/account/login")]
        public async Task<IActionResult> Login(Login login)
        {
            string rol = string.Empty;
            try
            {
                bool usuarioValido = await _loginRepositorio.ValidarUsuario(login);
                if (usuarioValido)
                {
                    Usuario usu = await _usuarioRepositorio.GetPorCodigo(login.Codigo);
                    if (usu.EstaActivo)
                    {
                        rol = usu.Rol;

                        var claims = new[]
                        {
                            new Claim(ClaimTypes.Name, usu.Codigo),
                            new Claim(ClaimTypes.Role, rol)
                        };

                        ClaimsIdentity clainsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                        ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(clainsIdentity);


                        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal,
                          new AuthenticationProperties { IsPersistent = true, ExpiresUtc = DateTime.UtcNow.AddHours(2) });


                    }
                    else
                    {
                        return LocalRedirect("/login/El usuario esta inactivo");
                    }

                }
                else
                {
                    return LocalRedirect("/login/Datos de usuario invalidos");
                }
            }
            catch (Exception ex)
            {

            }
            return LocalRedirect("/");
        }

        [HttpGet("/account/logout")]

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return LocalRedirect("/login");
        }
    }
}
