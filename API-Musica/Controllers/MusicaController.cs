using API_Musica.Model;
using API_Musica.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Musica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusicaController : ControllerBase
    {
        private readonly IMusicaService _musicaService;

        public MusicaController(IMusicaService musicaService)
        {
            _musicaService = musicaService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Musica>>> GetAllMusicas()
        {
            return await _musicaService.GetAllMusicas();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Musica>> GetIdMusica(int id)
        {
            var result = await _musicaService.findById(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpGet("autor/{autor}")]
        public async Task<ActionResult<List<Musica>>> GetAutores(string autor)
        {
            var result = await _musicaService.findByAutor(autor);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<Musica>>> UpdateMusica(int id, Musica m)
        {
            var result = await _musicaService.UpdateMusica(id, m);
            if (result is null) return NotFound();

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Musica>> DeleteMusica(int id)
        {
            var result = await _musicaService.DeletarMusica(id);
            if (result is null) return NotFound();

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<List<Musica>>> AddMusica(Musica m)
        {
            var result = await _musicaService.AddMusica(m);
            return Ok(result);
        }

    }
}
