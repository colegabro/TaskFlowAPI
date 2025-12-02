namespace TaskFlow.API.Models
{
    public class Comentario
    {
        public int Id { get; set; }
        public string Texto { get; set; } = string.Empty;
        public DateTime DataHora { get; set; } = DateTime.Now;

        // FK Tarefa
        public int IdTarefa { get; set; }
        public Tarefa Tarefa { get; set; }

        // FK Autor
        public int IdUsuarioAutor { get; set; }
        public Usuario Autor { get; set; }


    }
}
