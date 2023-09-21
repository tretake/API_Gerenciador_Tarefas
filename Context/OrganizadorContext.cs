using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using API_Gerenciador_Tarefas.Models;

namespace API_Gerenciador_Tarefas.Context
{
    public class OrganizadorContext : DbContext
    {
        public OrganizadorContext(DbContextOptions<OrganizadorContext> options) : base(options)
        {

        }


        public DbSet<Tarefa> Tarefas { get; set; }
    }
}