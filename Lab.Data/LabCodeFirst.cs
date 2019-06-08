using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Data.Entity
{
    [Table("Professor")]
    public class Professor
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public DateTime? UltimoLogin { get; set; }

        public virtual ICollection<Nota> Nota { get; set; }
    }

    [Table("Nota")]
    public class Nota
    {
        public int Id { get; set; }
        public int AlunoId { get; set; }
        public int ProfessorId { get; set; }
        public int TurmaId { get; set; }
        public decimal Valor { get; set; }
        public DateTime Data { get; set; }

        public virtual Professor Professor { get; set; }
    }

    public class LabContextCodeFirst : DbContext
    {
        public LabContextCodeFirst() : base("appConnectionString")
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = true;
        }

        public DbSet<Professor> Professor { get; set; }
        public DbSet<Nota> Nota { get; set; }
    }
}
