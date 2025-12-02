using System.Text.Json.Serialization;

namespace TaskFlow.API.Models
{
    public class Usuario
    {




        public int Id { get; set; }
        public string NomeCompleto { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string SenhaHash { get; set; } = string.Empty; // RNF2: Hash robusto [cite: 23]
        public DateTime DataCadastro { get; set; } = DateTime.Now;

        // Relacionamentos 1:N (Usuario criou N Projetos)
        [JsonIgnore]
        public ICollection<Projeto> ProjetosCriados { get; set; }

        // Relacionamentos N:N (Usuario é membro de N Projetos)
        [JsonIgnore]
        public ICollection<ProjetoUsuario> ProjetosOndeEhMembro { get; set; }

        // Relacionamento 1:N (Usuario é responsável por N Tarefas)
        [JsonIgnore]
        public ICollection<Tarefa> TarefasAtribuidas { get; set; }


    }
}
