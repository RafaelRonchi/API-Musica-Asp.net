using API_Musica.Data;
using API_Musica.Model;
using Microsoft.EntityFrameworkCore;

namespace API_Musica.Service
{
    public class MusicaService : IMusicaService
    {
        private readonly DataContext _dataContext;

        public MusicaService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<Musica>> AddMusica(Musica musica)
        {
            _dataContext.Musicas.Add(musica);
            await _dataContext.SaveChangesAsync();

            return await GetAllMusicas();
        }

        public async Task<List<Musica>> DeletarMusica(int id)
        {
            var musica = await findById(id);
            if (musica is null) return null;

            _dataContext.Musicas.Remove(musica);
            await _dataContext.SaveChangesAsync();

            return await GetAllMusicas();
        }

        public async Task<List<Musica>> findByAutor(string autor)
        {
            var musicas = await _dataContext.Musicas.Where(m => m.Autor == autor).ToListAsync(); ;
            if (musicas is null) return null;

            return musicas;
        }

        public async Task<Musica> findById(int id)
        {
            var musica = await _dataContext.Musicas.FindAsync(id);
            if (musica is null) return null;
            return musica;
        }

        public async Task<List<Musica>> GetAllMusicas()
        {
            var musicas = await _dataContext.Musicas.ToListAsync();
            return musicas;
        }

        public async Task<List<Musica>> UpdateMusica(int id, Musica musica)
        {
            var musicaExist = await findById(id);
            if (musicaExist is null) return null;

            musicaExist.Produtora = musica.Produtora;
            musicaExist.Autor = musica.Autor;
            musicaExist.Album = musica.Album;
            musicaExist.Tempo = musica.Tempo;
            musicaExist.Nome = musica.Nome;

            await _dataContext.SaveChangesAsync();
            return await GetAllMusicas();

        }
    }
}
