using exam_info.Models;
using exam_info.Models.DAO;
using exam_info.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
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

        public IActionResult Entry()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Entry(ExamViewModel examViewModel)
        {
            
            bool isSuccess = false;
            try
            {
                Exam exam = new Exam();
                //audit columns
                exam.Id = Guid.NewGuid().ToString();

                //ui columns
                exam.Name = examViewModel.Name;
                exam.Subject = examViewModel.Subject;
                exam.Type = examViewModel.Type;
                exam.Marks = examViewModel.Marks;
                exam.Duration = examViewModel.Duration;

                _applicationDBContext.Exams.Add(exam);//Ading the records Students DBSet
                _applicationDBContext.SaveChanges();//Saving the records to the database
                isSuccess = true;
            }
            catch(Exception ex)
            {

            }
            if (isSuccess)
            {
                ViewBag.msg = "Success";
            }
            else
            {
                ViewBag.msg = "Failed";
            }
            return RedirectToAction("List");
        }


        private static string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }
    }
}
