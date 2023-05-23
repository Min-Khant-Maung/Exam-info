using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace exam_info.Models.ViewModel
{
    public class ExamViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Subject { get; set; }
        public int Marks { get; set; }
        public int Duration { get; set; }
    }
}
