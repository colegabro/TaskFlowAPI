namespace TaskFlow.API.Models
{
    public class Enums
    {


        public enum StatusProjeto { Planejado, EmAndamento, Concluido, Cancelado }
        public enum StatusTarefa { A_Fazer, Em_Andamento, Concluido, Bloqueado }
        public enum PrioridadeTarefa { Baixa, Media, Alta }
        public enum PapelUsuario { Membro, Admin }

    }
}
