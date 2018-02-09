using LocalizationCRUD.Models;
using LocaliztionCRUD.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LocalizationCRUD.Controllers
{
    public class LabelController : Controller
    {
        // GET: Label
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SearchCriteria(SearchClassLabel data)
        {
            using (MobileWarehouseEntities db = new MobileWarehouseEntities())
            {
                IQueryable<RisorseLocalizzazioneLabel> x = null;
                if (data.idModulo.HasValue)
                {
                    x = db.RisorseLocalizzazioneLabel.Where((System.Linq.Expressions.Expression<Func<RisorseLocalizzazioneLabel, bool>>)(l => l.idModulo == data.idModulo));
                }
                else
                {
                    x = db.RisorseLocalizzazioneLabel;
                }

                if (data.labelFor != null)
                {
                    x = x.Where(l => l.labelFor == data.labelFor);
                }
                if (data.lingua != null)
                {
                    x = x.Where(p => p.lingua == data.lingua);
                }
                if (data.label != null)
                {
                    x = x.Where(p => p.label == data.label);
                }

                data.ResultList = x.ToList();

            }
            return View(data);
        }



        //public ActionResult Search()
        //{
        //    List<RisorseLocalizzazioneLabel> pippo = new List<RisorseLocalizzazioneLabel>();



        //    return View(pippo);
        //}

        public ActionResult Insert(RisorseLocalizzazioneLabel data)
        {

            //if (data.idModulo != 0 && !string.IsNullOrEmpty(data.labelFor) && !string.IsNullOrEmpty(data.lingua) && !string.IsNullOrEmpty(data.label))
            //{
            //    using (MobileWarehouseEntities db = new MobileWarehouseEntities())
            //    {
            //        db.RisorseLocalizzazioneLabel.Add(data);


            //        db.SaveChanges();


            //    }
            //}
           

            //return View("Index");
            return View();
        }

        public ActionResult DoInsert(RisorseLocalizzazioneLabel data)
        {

            if (data.idModulo != 0 && !string.IsNullOrEmpty(data.labelFor) && !string.IsNullOrEmpty(data.lingua) && !string.IsNullOrEmpty(data.label))
            {
                using (MobileWarehouseEntities db = new MobileWarehouseEntities())
                {
                    db.RisorseLocalizzazioneLabel.Add(data);


                    db.SaveChanges();


                }
            }


            return View("Index");
        }



        public ActionResult Edit(int idModulo, string labelFor, string lingua, string label)
        {
          
                        
                return View();
        }

        public ActionResult DoEdit(RisorseLocalizzazioneLabel data)
        {
            RisorseLocalizzazioneLabel x = null;
            using (MobileWarehouseEntities db = new MobileWarehouseEntities())
            {
                x = db.RisorseLocalizzazioneLabel.Where(l => l.idModulo == data.idModulo && l.labelFor == data.labelFor && l.lingua == data.lingua).FirstOrDefault();

                if(x != null)
                {
                    x.label = data.label;

                }
                else
                {
                    x = new RisorseLocalizzazioneLabel();

                    x.idModulo = data.idModulo;
                    x.labelFor = data.labelFor;
                    x.lingua = data.lingua;
                    x.label = data.lingua;

                    db.RisorseLocalizzazioneLabel.Add(x);
                }

                db.SaveChanges();
            }
            return View("Index");
        }

        public ActionResult Delete(int idModulo, string labelFor, string lingua)
        {
            RisorseLocalizzazioneLabel x = null;
            using (MobileWarehouseEntities db = new MobileWarehouseEntities())
            {
                x = db.RisorseLocalizzazioneLabel.Where(l => l.idModulo == idModulo && l.labelFor == labelFor && l.lingua == lingua).FirstOrDefault();

            
            }


            return View(x);
        }

        public ActionResult DoDelete(int idModulo, string labelFor, string lingua)
        {
            RisorseLocalizzazioneLabel x = null;
            using (MobileWarehouseEntities db = new MobileWarehouseEntities())
            {
                x = db.RisorseLocalizzazioneLabel.Where(l => l.idModulo == idModulo && l.labelFor == labelFor && l.lingua == lingua).FirstOrDefault();

                   if(x != null)
                    {
                        db.RisorseLocalizzazioneLabel.Remove(x);
                        db.SaveChanges();
                    }
            }


            return View("Index");
        }

    }
}
 