using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace exam_info.Models.DAO
{
    public class ApplicationDBContext:DbContext
    { 
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }
        public DbSet<Exam> Exams { get; set; }
    }
}
