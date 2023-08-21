using API_Musica.Model;

namespace API_Musica.Service
{
    public interface IMusicaService
    {
        Task<List<Musica>> AddMusica(Musica musica);
        Task<List<Musica>> GetAllMusicas();
        Task<List<Musica>> UpdateMusica(int id, Musica musica);
        Task<List<Musica>> DeletarMusica(int id);
        Task<Musica> findById(int id);
        Task<List<Musica>> findByAutor(string autor);
    }
}
