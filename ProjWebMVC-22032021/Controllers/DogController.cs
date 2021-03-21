using Data;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjWebMVC_22032021.Controllers
{
    public class DogController : Controller
    {
        // GET: Dog
        public ActionResult Index()
        {
            var lst = this.Crud().Select();
            return View(lst);
        }

        public ActionResult Create()
        {
            return View();
        }

        //Método de envio dos dados
        [HttpPost]
        // Evitar que se falsifique o envio de dados para o servidor. Recebe apenas requisições do controlador
        [ValidateAntiForgeryToken]

        public ActionResult Create(Dog dog)
        {
            if (ModelState.IsValid)
            {
                this.Crud().Insert(dog);
                return RedirectToAction("Index");
            }
            return View(dog);
        }

        public ActionResult Edit(int id)
        {
            var dog = this.Crud().SelectById(id);
            return View(dog);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Dog dog)
        {
            if (ModelState.IsValid)
            {
                this.Crud().Update(dog);
                return RedirectToAction("Index");
            }
            return View(dog);
        }

        public ActionResult Details(int id)
        {
            var dog = this.Crud().SelectById(id);
            return View(dog); 
        }

        public ActionResult Delete(int id)
        {
            var dog = this.Crud().SelectById(id);
            return View(dog);
        }

        //O ActionName precisa ser o mesmo "Delete", como a orientação a objetos não permite
        //métodos com o mesmo nome e parametros é necessário utilizar esse recurso.
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(int id)
        {
            this.Crud().Delete(id);
            return RedirectToAction("Index");
        }

        private IDogDB Crud()
        {
            return new DogDB();
        }

    }
}