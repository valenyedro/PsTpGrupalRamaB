using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public DbSet<TicketStatus> TicketStatus { get; set; }
        public DbSet<ExecutionStatus> ExecutionStatus { get; set; }
        public DbSet<TicketPriority> TicketPriority { get; set; }
        public DbSet<TicketCategory> TicketCategory { get; set; }
        public DbSet<ApprovalStatus> ApprovalStatus { get; set; }
        public DbSet<Ticket> Ticket { get; set; }
        public DbSet<TicketBody> TicketBody { get; set; }





        public DbSet<TicketComment> TicketComment { get; set; }
        public DbSet<TicketsReceptors> TicketReceptors { get; set; }

        public DbSet<TicketLog> TicketLogs { get; set; }

        public DbSet<TicketAction> TicketActions { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TicketStatus>(entity =>
            {
                entity.ToTable("TicketStatus");
                entity.HasKey(t => t.idStatus);
                entity.Property(t => t.idStatus).ValueGeneratedOnAdd();
                entity.Property(t => t.description).HasColumnName("description");

                entity.HasData(
                    new TicketStatus
                    {
                        idStatus = 1,
                        description = "En curso"
                    });
            });

            modelBuilder.Entity<ExecutionStatus>(entity =>
            {
                entity.ToTable("ExecutionStatus");
                entity.HasKey(t => t.idExecutionStatus);
                entity.Property(t => t.idExecutionStatus).ValueGeneratedOnAdd();
                entity.Property(t => t.description).HasColumnName("description");

                entity.HasData(
                    new ExecutionStatus
                    {
                        idExecutionStatus = 1,
                        description = "En curso"
                    });
            });

            modelBuilder.Entity<TicketPriority>(entity =>
            {
                entity.ToTable("TicketPriority");
                entity.HasKey(t => t.idPriority);
                entity.Property(t => t.idPriority).ValueGeneratedOnAdd();
                entity.Property(t => t.description).HasColumnName("description");

                entity.HasData(
                    new TicketPriority
                    {
                        idPriority = 1,
                        description = "Baja"
                    });
            });

            modelBuilder.Entity<TicketCategory>(entity =>
            {
                entity.ToTable("TicketCategory");
                entity.HasKey(t => t.idCategory);
                entity.Property(t => t.idCategory).ValueGeneratedOnAdd();
                entity.Property(t => t.name).HasColumnName("name");
                entity.Property(t => t.reqApproval).HasColumnName("reqApproval");
                entity.Property(t => t.description).HasColumnName("description");

                entity.HasData(
                    new TicketCategory
                    {
                        idCategory = 1,
                        name = "name Category",
                        reqApproval = false,
                        description = "Baja"
                    });
            });

            modelBuilder.Entity<TicketBody>(entity =>
            {
                entity.ToTable("TicketBody");
                entity.HasKey(t => t.idTicketBody);
                entity.Property(t => t.idTicketBody).ValueGeneratedOnAdd();
                entity.Property(t => t.title).HasColumnName("title");
                entity.Property(t => t.description).HasColumnName("description");
                entity.Property(t => t.file).HasColumnName("file");

                entity.HasData(
                    new TicketBody
                    {
                        idTicketBody = 1,
                        title = "Solicitud de pagos",
                        description = "Por favor solicito...",
                        file = "Ruta archivo"
                    },
                    new TicketBody
                    {
                        idTicketBody = 2,
                        title = "Solicitud de Factura",
                        description = "Hola equipo! Solicito...",
                        file = "Ruta archivo"
                    });
            });

            modelBuilder.Entity<ApprovalStatus>(entity =>
            {
                entity.ToTable("ApprovalStatus");
                entity.HasKey(t => t.idApprovalStatus);
                entity.Property(t => t.idApprovalStatus).ValueGeneratedOnAdd();
                entity.Property(t => t.description).HasColumnName("description");

                entity.HasData(
                    new ApprovalStatus
                    {
                        idApprovalStatus = 1,
                        description = "Baja",
                    });
            });

            modelBuilder.Entity<Ticket>(entity =>
            {
                entity.ToTable("Ticket");
                entity.HasKey(t => t.idTicket);
                entity.Property(t => t.idTicket).ValueGeneratedOnAdd();
                entity.Property(t => t.idUser).HasColumnName("idUser");
                entity.Property(t => t.idStatus).HasColumnName("idStatus");
                entity.Property(t => t.idExecutionStatus).HasColumnName("idExecutionStatus");
                entity.Property(t => t.idPriority).HasColumnName("idPriority");
                entity.Property(t => t.idCategory).HasColumnName("idTicketCategory");
                entity.Property(t => t.idUserExecutor).HasColumnName("idUserExecutor");
                entity.Property(t => t.idApprovalStatus).HasColumnName("idAprovvaStatus");
                entity.Property(t => t.idTicketBody).HasColumnName("idTicketBody");
                entity.Property(t => t.minApproveReq).HasColumnName("minApproveReq");
                entity.Property(t => t.countOpen).HasColumnName("countOpen");
                entity.Property(t => t.countDisapproved).HasColumnName("countDisapproved");
                entity.Property(t => t.countApproved).HasColumnName("countApproved");

                entity
                    .HasOne<TicketStatus>(t => t.ticketStatus)
                    .WithMany(s => s.tickets)
                    .HasForeignKey(c => c.idStatus);

                entity
                    .HasOne<ExecutionStatus>(t => t.executionStatus)
                    .WithMany(s => s.tickets)
                    .HasForeignKey(c => c.idExecutionStatus);

                entity
                    .HasOne<TicketPriority>(t => t.ticketPriority)
                    .WithMany(s => s.tickets)
                    .HasForeignKey(c => c.idPriority);

                entity
                    .HasOne<TicketCategory>(t => t.ticketCategory)
                    .WithMany(s => s.tickets)
                    .HasForeignKey(c => c.idCategory);

                entity
                    .HasOne<TicketBody>(t => t.ticketBody)
                    .WithOne(s => s.ticket)
                    .HasForeignKey<Ticket>(t => t.idTicketBody);

                entity
                    .HasOne<ApprovalStatus>(t => t.approvalStatus)
                    .WithMany(s => s.tickets)
                    .HasForeignKey(c => c.idApprovalStatus);

                entity.HasData(
                    new Ticket
                    {
                        idTicket = 1,
                        idUser = 1,
                        idStatus = 1,
                        idExecutionStatus = 1,
                        idPriority = 1,
                        idCategory = 1,
                        idUserExecutor = 1,
                        idApprovalStatus = 1,
                        idTicketBody = 1,
                        minApproveReq = 1,
                        countOpen = 1,
                        countDisapproved = 1,
                        countApproved = 1,
                    });
            });

            
            modelBuilder.Entity<TicketAction>(entity =>
            {
                entity.ToTable("TicketAction");
                entity.HasKey(t => t.idAction);
                entity.Property(t => t.idAction).ValueGeneratedOnAdd();
                entity.Property(t => t.actionDescription).HasColumnName("actionDescription");

                entity
                    .HasOne<TicketLog>(t => t.ticketLog)
                    .WithMany(s => s.ticketActions)
                    .HasForeignKey(c => c.idAction);

                
                entity.HasData(
                    new TicketAction
                    {
                        idAction = 1,
                        actionDescription = "descripcion de la accion"
                    });
                
            }); 
      
            modelBuilder.Entity<TicketLog>(entity =>
            {
                entity.ToTable("TicketLog");
                entity.HasKey(t => t.idTicketLog);
                entity.Property(t => t.idTicketLog).ValueGeneratedOnAdd();
                entity.Property(t => t.idTicket).HasColumnName("idTicket");
                entity.Property(t => t.idUser).HasColumnName("idUser");
                entity.Property(t => t.idUserCategory).HasColumnName("idUserCategory");
                entity.Property(t => t.dateHistory).HasColumnName("dateHistory");
                entity.Property(t => t.idAction).HasColumnName("idAction");
                
                entity
                    .HasOne<Ticket>(t => t.ticket)
                    .WithMany(s => s.ticketLogs)
                    .HasForeignKey(c => c.idTicketLog);

                
                entity.HasData(
                    new TicketLog
                    {
                        idTicketLog = 1,
                        idTicket = 1,
                        idUser = 1,
                        idUserCategory = 1,
                        dateHistory = DateTime.Now,
                        idAction = 1
                    });
                
            });

            modelBuilder.Entity<TicketsReceptors>(entity =>
            {
                entity.ToTable("TicketReceptors");
                entity.HasKey(t => t.idTicketReceptors);
                entity.Property(t => t.idTicketReceptors).ValueGeneratedOnAdd();
                entity.Property(t => t.idUser).HasColumnName("idUser");
                entity.Property(t => t.idTicket).HasColumnName("idTicket");

                entity
                    .HasOne<Ticket>(t => t.ticket)
                    .WithMany(s => s.ticketReceptors)
                    .HasForeignKey(c => c.idTicketReceptors);
                
                entity.HasData(
                    new TicketsReceptors
                    {
                        idTicketReceptors = 1,
                        idUser = 1,
                        idTicket = 1
                    });
                
            });


            modelBuilder.Entity<TicketComment>(entity =>
            {
                entity.ToTable("TicketComment");
                entity.HasKey(t => t.idComment);
                entity.Property(t => t.idComment).ValueGeneratedOnAdd();
                entity.Property(t => t.idUser).HasColumnName("idUser");
                entity.Property(t => t.comment).HasColumnName("comment");
                entity.Property(t => t.dateComment).HasColumnName("dateComment");

                
                entity
                    .HasOne<Ticket>(t => t.ticket)
                    .WithMany(s => s.ticketComments)
                    .HasForeignKey(c => c.idComment);
                
                entity.HasData(
                    new TicketComment
                    {
                        idComment = 1,
                        idUser = 1,
                        comment = "Comentario",
                        dateComment = DateTime.Now
                    });
                
            });


            

            

           

            

            


            /*
            entity
                    .HasOne<Cliente>(c => c.Cliente)
                    .WithMany(s => s.carritos)
                    .HasForeignKey(c => c.ClienteId);

            entity
                .HasOne<Orden>(c => c.Orden)
                .WithOne(o => o.Carrito)
                .HasForeignKey<Orden>(o => o.CarritoId);
            */


            }
    }
}
