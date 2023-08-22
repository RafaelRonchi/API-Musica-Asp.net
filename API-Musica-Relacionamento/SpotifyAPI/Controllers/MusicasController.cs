﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SpotifyAPI.Models;
using SpotifyAPI.Services;

namespace SpotifyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusicasController : ControllerBase
    {
        private readonly IMusicaService _musicaService;

        public MusicasController(IMusicaService musicaService)
        {
            _musicaService = musicaService;
        }

        [HttpGet]
        public async Task<ActionResult<List<MusicaModel>>> GetMusicas()
        {
            var musicas = await _musicaService.GetAllMusicasAsync();
            return Ok(musicas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MusicaModel>> GetMusica(int id)
        {
            var musica = await _musicaService.GetMusicaByIdAsync(id);
            if (musica == null)
                return NotFound($"Musica com ID {id} não encontrada.");

            return Ok(musica);
        }
        [HttpGet("genero/{genero}")]
        public async Task<ActionResult<List<MusicaModel>>> GetMusica(string genero)
        {
            var musicas = await _musicaService.GetMusicasByGeneroAsync(genero);
            if (musicas == null || musicas.Count == 0)
                return NotFound($"Musica com o genero {genero} não encontrada.");

            return Ok(musicas);
        }
        [HttpPost]
        public async Task<ActionResult<int>> CreateMusica(MusicaModel musica)
        {
            if (musica == null)
                return BadRequest("Dados inválidos para criar uma nova música.");

            var id = await _musicaService.CreateMusicAsync(musica);
            return CreatedAtAction(nameof(GetMusica), new { id }, id);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<int>> UpdateMusica(int id, MusicaModel musica)
        {
            if (id != musica.Id)
            {
                return BadRequest("Id da música na URL não corresponde ao ID no corpo da requisição");
            }

            await _musicaService.UpdateMusicaAsync(musica);

            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<int>> DeleteMusica(int id)
        {
            var musica = await _musicaService.GetMusicaByIdAsync(id);
            
            if (musica == null)
            {
                return NotFound($"Musica com o ID {id} não encontrada.");
            }

            await _musicaService.DeleteMusicaAsync(id);

            return Ok("Música deleta com sucesso");
        }


    }
}
