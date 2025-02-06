using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AvisFormation.Data;
using AvisFormation.Web.ViewModels;

namespace AvisFormation.Web.Controllers
{
    public class FormationController : Controller
    {
        // GET: Formation
        public ActionResult ToutesLesFormations()
        {
            var list = new List<Formation>();

            var formations = new List<ToutesLesFormationsViewModel>();

            using (var context = new AvisFormationDBEntities())
            {
                list = context.Formation.ToList();
                foreach (var formation in list)
                {
                    var viewmodel = new ToutesLesFormationsViewModel();

                    viewmodel.Id = formation.Id;
                    viewmodel.Nom = formation.Nom;
                    viewmodel.Description = formation.Description;
                    viewmodel.NomSeo = formation.NomSeo;
                    viewmodel.Url = formation.Url;
                    viewmodel.Avis = formation.Avis.ToList();
                    viewmodel.NombreAvis = formation.Avis.Count;
                    if (formation.Avis.Any())
                    {
                        viewmodel.Note = formation.Avis.Average(x => x.Note);
                    }
                    else
                    {
                        viewmodel.Note = 0;
                    }
                    formations.Add(viewmodel);
                }
            }
            return View(formations);
        }


        public ActionResult DetailsFormation(string nomseo)
        {
            using (var context = new AvisFormationDBEntities())
            {
                var formation = context.Formation.Include("Avis").FirstOrDefault(f => f.NomSeo.Equals(nomseo));

                if (formation == null)
                {
                    return RedirectToAction("ToutesLesFormations");
                }
                return View(formation);
            }
        }
    }
}