using LocalizationCRUD.Models;
using LocaliztionCRUD.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LocalizationCRUD.Controllers
{
    public class MessageController : Controller
    {
        // GET: Message
        public ActionResult Index()
        {
            return View();
        }



        public ActionResult SearchCriteria(SearchClassMessage data)
        {
            using (MobileWarehouseEntities db = new MobileWarehouseEntities())
            {
                IQueryable<RisorseLocalizzazioneMessage> x = null;
                if (data.idModulo.HasValue)
                {
                    x = db.RisorseLocalizzazioneMessage.Where(l => l.idModulo == data.idModulo);
                }
                else
                {
                    x = db.RisorseLocalizzazioneMessage;
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
        //    List<RisorseLocalizzazioneMessage> pippo = new List<RisorseLocalizzazioneMessage>();



        //    return View(pippo);
        //}

        public ActionResult Insert(RisorseLocalizzazioneMessage data)
        {

            //if (data.idModulo != 0 && !string.IsNullOrEmpty(data.labelFor) && !string.IsNullOrEmpty(data.lingua) && !string.IsNullOrEmpty(data.label))
            //{
            //    using (MobileWarehouseEntities db = new MobileWarehouseEntities())
            //    {
            //        db.RisorseLocalizzazioneMessage.Add(data);


            //        db.SaveChanges();


            //    }
            //}


            //return View("Index");
            return View();
        }

        public ActionResult DoInsert(RisorseLocalizzazioneMessage data)
        {

            if (data.idModulo != 0 && !string.IsNullOrEmpty(data.labelFor) && !string.IsNullOrEmpty(data.lingua) && !string.IsNullOrEmpty(data.label))
            {
                using (MobileWarehouseEntities db = new MobileWarehouseEntities())
                {
                    db.RisorseLocalizzazioneMessage.Add(data);


                    db.SaveChanges();


                }
            }


            return View("Index");
        }



        public ActionResult Edit(int idModulo, string labelFor, string lingua, string label)
        {


            return View();
        }

        public ActionResult _PartialEdit(int idModulo, string labelFor, string lingua, string label)
        {
            return PartialView();
        }

        public ActionResult _PartialDelete(int idModulo, string labelFor, string lingua, string label)
        {
            return PartialView();
        }

        public ActionResult DoEdit(RisorseLocalizzazioneMessage data)
        {
            RisorseLocalizzazioneMessage x = null;
            using (MobileWarehouseEntities db = new MobileWarehouseEntities())
            {
                x = db.RisorseLocalizzazioneMessage.Where(l => l.idModulo == data.idModulo && l.labelFor == data.labelFor && l.lingua == data.lingua).FirstOrDefault();

                if (x != null)
                {
                    x.label = data.label;

                }
                else
                {
                    x = new RisorseLocalizzazioneMessage();

                    x.idModulo = data.idModulo;
                    x.labelFor = data.labelFor;
                    x.lingua = data.lingua;
                    x.label = data.lingua;

                    db.RisorseLocalizzazioneMessage.Add(x);
                }

                db.SaveChanges();
            }
            return View("Index");
        }

        public ActionResult Delete(int idModulo, string labelFor, string lingua)
        {
            RisorseLocalizzazioneMessage x = null;
            using (MobileWarehouseEntities db = new MobileWarehouseEntities())
            {
                x = db.RisorseLocalizzazioneMessage.Where(l => l.idModulo == idModulo && l.labelFor == labelFor && l.lingua == lingua).FirstOrDefault();


            }


            return View(x);
        }

        public ActionResult DoDelete(int idModulo, string labelFor, string lingua)
        {
            RisorseLocalizzazioneMessage x = null;
            using (MobileWarehouseEntities db = new MobileWarehouseEntities())
            {
                x = db.RisorseLocalizzazioneMessage.Where(l => l.idModulo == idModulo && l.labelFor == labelFor && l.lingua == lingua).FirstOrDefault();

                if (x != null)
                {
                    db.RisorseLocalizzazioneMessage.Remove(x);
                    db.SaveChanges();
                }
            }


            return SearchCriteria(new SearchClassMessage());
        }

    }
}
 


