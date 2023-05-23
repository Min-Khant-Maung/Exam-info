using exam_info.Models.DAO;
using exam_info.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace exam_info.Controllers
{
    public class ExamController : Controller
    {
        private readonly ApplicationDBContext _applicationDBContext;

        public ExamController(ApplicationDBContext applicationDBContext)
        {
            _applicationDBContext = applicationDBContext;
        }
        public IActionResult List()
        {

            IList<ExamViewModel> exams = _applicationDBContext.Exams.Select
                 (s => new ExamViewModel
                 {
                     Id = s.Id,
                     Name = s.Name,
                     Subject = s.Subject,
                     Type = s.Type,
                     Marks = s.Marks,
                     Duration = s.Duration
                 }).ToList();
            return View(exams);
        }
    }
}
