using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AvisFormation.Data;

namespace AvisFormation.web.Controllers
{
    public class AvisController : Controller
    {
        // GET: Avis
        public ActionResult AjouterUnAvis(string NomSeo)
        {
            return View();
        }

        [HttpPost]
        public ActionResult AjouterUnAvis(string Nom,string Description ,string Note, string NomSeo)
        {
            using(var context= new AvisFormationDBEntities())
            {
                var formation=context.Formation.FirstOrDefault(f => f.NomSeo == NomSeo);
                var avis = new Avis();
                avis.Nom = Nom; 
                avis.Description = Description;
                avis.Note = double.Parse(Note);
                avis.DateAvis = DateTime.Now;
                avis.IdFormation = formation.Id;
                avis.UserId = "1";
                
                context.Avis.Add(avis);
                context.SaveChanges();


            }
            return RedirectToAction("DetailsFormation","Formation",new {nomseo=NomSeo});
        }
    }
    }
