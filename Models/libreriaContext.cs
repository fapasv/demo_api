
namespace libreria_api.Models
{
    public partial class libreriaContext : DbContext
    {
        public libreriaContext()
        {
        }

        public libreriaContext(DbContextOptions<libreriaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AuditLog> AuditLogs { get; set; } = null!;
        public virtual DbSet<Ejercicio> Ejercicios { get; set; } = null!;
        public virtual DbSet<Libro> Libros { get; set; } = null!;
        public virtual DbSet<Respuestum> Respuesta { get; set; } = null!;

        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ejercicio>(entity =>
            {
                entity.ToTable("ejercicios");

                entity.HasIndex(e => e.IdLibro, "IX_ejercicios_id_libro");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Enunciado)
                    .HasColumnType("character varying")
                    .HasColumnName("enunciado");

                entity.Property(e => e.IdLibro).HasColumnName("id_libro");

                entity.HasOne(d => d.IdLibroNavigation)
                    .WithMany(p => p.Ejercicios)
                    .HasForeignKey(d => d.IdLibro)
                    .HasConstraintName("fk_libro");
            });

            modelBuilder.Entity<Libro>(entity =>
            {
                entity.ToTable("libros");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Titulo)
                    .HasColumnType("character varying")
                    .HasColumnName("titulo");
            });

            modelBuilder.Entity<Respuestum>(entity =>
            {
                entity.HasKey(e => new { e.IdEjercicio, e.IdUsuario })
                    .HasName("pk_ejercicio_usuario");

                entity.ToTable("respuesta");

                entity.Property(e => e.IdEjercicio).HasColumnName("id_ejercicio");

                entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

                entity.Property(e => e.Valor)
                    .HasColumnType("character varying")
                    .HasColumnName("valor");

                entity.HasOne(d => d.IdEjercicioNavigation)
                    .WithMany(p => p.Respuesta)
                    .HasForeignKey(d => d.IdEjercicio)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
