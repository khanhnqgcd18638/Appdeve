using AppDev.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppDev.Controllers
{
    public class StaffController : Controller
    {
        private ApplicationUser _user;
        private ApplicationDbContext _context;
        private UserManager<ApplicationUser> _usermanager;
        public StaffController()
        {
            _user = new ApplicationUser();
            _context = new ApplicationDbContext();
            _usermanager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
        }
        // GET: Staff
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult TraineeManagement(string searchString)
        {

            var trainee = _context.Users.Where(t => t.Roles.Any(r => r.RoleId == "4")).ToList();
            if (!String.IsNullOrEmpty(searchString))
            {
                
                trainee = _context.Users
                    .Where(t => t.Roles.Any(r => r.RoleId == "4") && t.UserName.Contains(searchString) == true)
                    .ToList();
            }
            return View(trainee);
        }
        public ActionResult DeleteTrainee(string id)
        {
            var removeTrainee = _context.Users.SingleOrDefault(t => t.Id == id);
            _context.Users.Remove(removeTrainee);
            _context.SaveChanges();
            return RedirectToAction("TraineeManagement");
        }

        public ActionResult UpdateTrainee(string id)
        {
            var trainee = _context.Users
                .OfType<Trainee>()
                .SingleOrDefault(t => t.Id == id);
            var updateTrainee = new Trainee()
            {
                Id = trainee.Id,
                Email = trainee.Email,
                UserName = trainee.UserName,
                Age = trainee.Age,
                DateofBirth = trainee.DateofBirth,
                Education = trainee.Education,
                MainProgrammingLang = trainee.MainProgrammingLang,
                ToeicScore = trainee.ToeicScore,
                ExpDetail = trainee.ExpDetail,
                Department = trainee.Department,
                Location = trainee.Location

            };
            return View(updateTrainee);
        }
        [HttpPost]
        public ActionResult UpdateTrainee(Trainee detaisTrainee)
        {
            var traineesearch = _context.Users.OfType<Trainee>().FirstOrDefault(t => t.Id == detaisTrainee.Id);
            traineesearch.UserName = detaisTrainee.UserName;
            traineesearch.Age = detaisTrainee.Age;
            traineesearch.DateofBirth = detaisTrainee.DateofBirth;
            traineesearch.Education = detaisTrainee.Education;
            traineesearch.MainProgrammingLang = detaisTrainee.MainProgrammingLang;
            traineesearch.ToeicScore = detaisTrainee.ToeicScore;
            traineesearch.ExpDetail = detaisTrainee.ExpDetail;
            traineesearch.Department = detaisTrainee.Department;
            traineesearch.Location = detaisTrainee.Location;
            _context.SaveChanges();
            return RedirectToAction("TraineeManagement");
        }
        public ActionResult DetailsTrainee(string id)
        {
            var trainee = _context.Users.SingleOrDefault(t => t.Id == id);
            return View(trainee);
        }
        public ActionResult TrainerProfile()
        {
            var trainer = _context.Users.Where(t => t.Roles.Any(r => r.RoleId == "3")).ToList();
            return View(trainer);
        }
        public ActionResult DetailsTrainer(string id)
        {
            var trainer = _context.Users.SingleOrDefault(t => t.Id == id);
            return View(trainer);
        }
        public ActionResult UpdateTrainer(string id)
        {
            var trainer = _context.Users.OfType<Trainer>().SingleOrDefault(t => t.Id == id);
            var updateTrainerView = new Trainer()
            {
                Id = trainer.Id,
                Email = trainer.Email,
                UserName = trainer.UserName,
                Education = trainer.Education,
                WorkPlace = trainer.WorkPlace,
                Telephone = trainer.Telephone,
                Type = trainer.Type
            };
            return View(updateTrainerView);
        }
        [HttpPost]
        public ActionResult UpdateTrainer(Trainer detailsTrainer)
        {
            var trainer = _context.Users.OfType<Trainer>().SingleOrDefault(t => t.Id == detailsTrainer.Id);
            trainer.UserName = detailsTrainer.UserName;
            trainer.Education = detailsTrainer.Education;
            trainer.WorkPlace = detailsTrainer.WorkPlace;
            trainer.Telephone = detailsTrainer.Telephone;
            trainer.Type = detailsTrainer.Type;
            _context.SaveChanges();
            return RedirectToAction("TrainerProfile");
        }

    }
}