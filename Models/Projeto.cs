using static TaskFlow.API.Models.Enums;

namespace TaskFlow.API.Models
{
    public class Projeto
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public DateTime DataInicio { get; set; }
        public DateTime? DataTermino { get; set; }
        public StatusProjeto Status { get; set; }

        // FK Criador
        public int IdUsuarioCriador { get; set; }
        public Usuario Criador { get; set; }

        // Relacionamento 1:N (Projeto tem N Tarefas)
        public ICollection<Tarefa> Tarefas { get; set; }

        // Relacionamento N:N (Projeto tem N Membros)
        public ICollection<ProjetoUsuario> Membros { get; set; }

    }
}

