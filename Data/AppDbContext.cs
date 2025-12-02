using Microsoft.EntityFrameworkCore;
using TaskFlow.API.Models;

namespace TaskFlow.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Projeto> Projetos { get; set; }
        public DbSet<Tarefa> Tarefas { get; set; }
        public DbSet<Comentario> Comentarios { get; set; }
        public DbSet<ProjetoUsuario> ProjetosUsuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuração N:N (Projeto <-> Usuario)
            modelBuilder.Entity<ProjetoUsuario>()
                .HasKey(pu => new { pu.IdProjeto, pu.IdUsuario });

            modelBuilder.Entity<ProjetoUsuario>()
                .HasOne(pu => pu.Projeto)
                .WithMany(p => p.Membros)
                .HasForeignKey(pu => pu.IdProjeto)
                .OnDelete(DeleteBehavior.Restrict); // Evitar deleção em cascata perigosa

            modelBuilder.Entity<ProjetoUsuario>()
                .HasOne(pu => pu.Usuario)
                .WithMany(u => u.ProjetosOndeEhMembro)
                .HasForeignKey(pu => pu.IdUsuario)
                .OnDelete(DeleteBehavior.Restrict);

            // Configuração 1:N (Usuario Criador -> Projetos)
            modelBuilder.Entity<Projeto>()
                .HasOne(p => p.Criador)
                .WithMany(u => u.ProjetosCriados)
                .HasForeignKey(p => p.IdUsuarioCriador)
                .OnDelete(DeleteBehavior.Restrict);

            // Configuração 1:N (Usuario -> Tarefas)
            modelBuilder.Entity<Tarefa>()
                .HasOne(t => t.Responsavel)
                .WithMany(u => u.TarefasAtribuidas)
                .HasForeignKey(t => t.IdUsuarioResponsavel)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }

}

