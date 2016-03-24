using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TimeCapture.Models;

namespace TimeCapture.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult TimeCapture()
        {
            ViewBag.Message = "Time capture page.";

            int currentUserId = 2;

            using (var db = new AderantEntities5())
            {
                var userInfo = (from u in db.Users
                                join c in db.Contacts on u.ContactID equals c.ID
                                join l in db.Lookups on u.RoleID equals l.ID
                                where u.ID == currentUserId
                                select new
                                {
                                    Id = currentUserId,
                                    Name = c.FirstName + " " + c.LastName + " (" + l.Description + ")",
                                    IsLawyer = (l.Code == "L") ? true : false,
                                }).FirstOrDefault();

                ViewBag.UserInfo = userInfo.Name;
                ViewBag.Id = userInfo.Id;
                ViewBag.IsLawyer = userInfo.IsLawyer;
            }

            return View();
        }


        public ActionResult GetLawyerByAssistant(int assistantID)
        {
            using (var db = new AderantEntities5())
            {
                // var layerList = db.Authorizations.Where(x => x.AssistantID == assistantID).ToList();

                var lawyerList = (from a in db.Authorizations
                                  join u in db.Users on a.LawyerID equals u.ID
                                  join c in db.Contacts on u.ContactID equals c.ID
                                  where a.AssistantID == assistantID
                                  select new
                                  {
                                      LawyerID = a.LawyerID,
                                      LawyerName = c.FirstName + " " + c.LastName
                                  }).ToList();
                return Json(lawyerList, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult GetAssistant()
        {
            using (var db = new AderantEntities5())
            {
                var AssistantList = (from u in db.Users
                                     join c in db.Contacts on u.ContactID equals c.ID
                                     where u.RoleID == 2
                                     select new
                                     {
                                         AssistantID = u.ID,
                                         AssistantName = c.FirstName + " " + c.LastName
                                     }).ToList();
                return Json(AssistantList, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult GetRecords(int? lawyerId)
        {
            lawyerId = 1;

            using (var db = new AderantEntities5())
            {
                var recordlist = (from r in db.Recordings
                                  join c in db.Clients on r.ClientID equals c.ID
                                  join o in db.Offices on r.OfficeID equals o.ID
                                  join t in db.Tasks on r.TaskID equals t.ID
                                  where r.LawyerID == lawyerId
                                  select new
                                  {
                                      Id = r.ID,
                                      Title = c.ClientName + " - " + o.OfficeLocation + " - " + t.TaskName,
                                      ClientId = r.ClientID,
                                      OfficeId = r.OfficeID,
                                      TaskId = r.TaskID,
                                      ActivityId = r.AcitivityID,
                                      StartDateTime = r.StartDateTime,
                                      EndDateTime = r.EndDateTime,
                                      TimeZoneId = r.TimeZoneID,
                                      Comment = r.Comment
                                  }).ToList();
                return Json(recordlist, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult GetClients(int lawyerId)
        {
            using (var db = new AderantEntities5())
            {
                var clients = (from ltc in db.Lawyer_Task_Client
                               join c in db.Clients on ltc.ClientID equals c.ID
                               where ltc.LayerID == lawyerId
                               select new
                               {
                                   Id = c.ID,
                                   Name = c.ClientName
                               }).Distinct().ToList();

                return Json(clients, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult GetOffices(int clientId)
        {
            using (var db = new AderantEntities5())
            {
                var offices = (from o in db.Offices
                               where o.ClientID == clientId
                               select new
                               {
                                   Id = o.ID,
                                   Name = o.OfficeLocation
                               }).Distinct().ToList();

                return Json(offices, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult GetTasks(int officeId)
        {
            using (var db = new AderantEntities5())
            {
                var offices = (from t in db.Tasks
                               where t.OfficeID == officeId
                               select new
                               {
                                   Id = t.ID,
                                   Name = t.TaskName
                               }).Distinct().ToList();

                return Json(offices, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult GetActivities()
        {
            using (var db = new AderantEntities5())
            {
                var offices = (from t in db.Activities
                               select new
                               {
                                   Id = t.ID,
                                   Name = t.ActivityName
                               }).ToList();

                return Json(offices, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult GetTimeZones()
        {
            using (var db = new AderantEntities5())
            {
                var timeZones = (from t in db.TimeZones
                               select new
                               {
                                   Id = t.ID,
                                   Name = t.TimeZoneName
                               }).ToList();

                return Json(timeZones, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult AddRecord(RecordViewModel model)
        {

            return View();
        }
    }
}