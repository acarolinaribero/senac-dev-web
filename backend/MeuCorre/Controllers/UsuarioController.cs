using MeuCorre.Application.UseCases.Usuarios;
using Microsoft.AspNetCore.Mvc;

namespace MeuCorre.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        ///sumary
        ///Cria um novo usuário.
        ///<param name="=ommand"<>/param>
        ///<sumary><
        [HttpPost]


        public IActionResult CriarUsuario([FromBody] CriarUsuarioCommands commands)
        {

        }
    }
}
    
