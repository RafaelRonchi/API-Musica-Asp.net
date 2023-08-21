namespace API_Musica.Model
{
    public class Musica
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Album { get; set; } = string.Empty;
        public string Autor { get; set; } = string.Empty;
        public string Produtora { get; set; } = string.Empty;
        public int Tempo { get; set; } = 0;

    }
}
