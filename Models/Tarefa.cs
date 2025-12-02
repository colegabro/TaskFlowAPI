using System.Text.Json.Serialization;
using static TaskFlow.API.Models.Enums;

namespace TaskFlow.API.Models
{
    public class Tarefa
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public StatusTarefa Status { get; set; }
        public PrioridadeTarefa Prioridade { get; set; }
        public DateTime DataVencimento { get; set; }

        // FK Projeto (1:N - Projeto tem N Tarefas)
        public int IdProjeto { get; set; }
        [JsonIgnore]
        public Projeto Projeto { get; set; }

        // FK Responsavel (1:N - Usuario tem N Tarefas)
        public int? IdUsuarioResponsavel { get; set; }
        public Usuario? Responsavel { get; set; }

        // Relacionamento 1:N (Tarefa tem N Comentarios)
        public ICollection<Comentario> Comentarios { get; set; }


    }
}
