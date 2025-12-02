using static TaskFlow.API.Models.Enums;

namespace TaskFlow.API.Models
{
    public class ProjetoUsuario
    {
        public int IdProjeto { get; set; }
        public Projeto Projeto { get; set; }

        public int IdUsuario { get; set; }
        public Usuario Usuario { get; set; }

        public PapelUsuario Papel { get; set; } // Ex: Admin, Membro

    }
}
