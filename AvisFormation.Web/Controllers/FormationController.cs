using AvisFormation.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AvisFormation.Web.Controllers
{
    public class FormationController : Controller
    {
        // GET: Formation
        public ActionResult ToutesLesFormations()
        {
            var list = new List<Formation>();
            using (var context = new AvisFormationDBEntities())
            {
                list = context.Formation.ToList();
            }
                return View(list);
        }
        public ActionResult DetailsFormation(string nomseo)
        {
            var formation = new Formation();
            using (var context = new AvisFormationDBEntities())
            {
                formation = context.Formation.Where(f => f.NomSeo.Equals(nomseo)).FirstOrDefault();
            
            if(formation == null)
            {
                return RedirectToAction("ToutesLesFormations");
            } 
            return View(formation);
            }
        }
    }
}