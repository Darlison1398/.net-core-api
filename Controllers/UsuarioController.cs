using CadastroUsuarioApi.Data;
using CadastroUsuarioApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CadastroUsuarioApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly DataContext _context;

        public UsuarioController(DataContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
            return Ok(usuario);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var usuarios = await _context.Usuarios.ToListAsync();
            return Ok(usuarios);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
        
            if (usuario == null)
            {
                return NotFound(); // Retorna 404 caso o usuário não seja encontrado
            }

            return Ok(usuario); 
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Usuario usuario)
        {
            if (id != usuario.Id) 
            {
                return BadRequest(); 
            }
        
            _context.Entry(usuario).State = EntityState.Modified;
        
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioExists(id))
                {
                    return NotFound(); 
                }
                else
                {
                    throw; 
                }
            }
        
            return NoContent(); 
        }

        private bool UsuarioExists(int id)
        {
            return _context.Usuarios.Any(e => e.Id == id); 
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return NotFound(); 
            }
        
            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();
        
            return NoContent(); 
        }







        
    }
}
