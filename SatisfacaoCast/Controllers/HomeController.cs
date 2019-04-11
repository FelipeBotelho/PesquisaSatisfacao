using SatisfacaoCast.Models;
using SatisfacaoCast.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SatisfacaoCast.Controllers
{
    public class HomeController : Controller
    {
        private readonly VotoRepository _votorepo;

        public HomeController()
        {
            this._votorepo = new VotoRepository();
        }

        public ActionResult Index()
        {
            return View(new VotoModel());
        }

        public  ActionResult Votar(VotoModel model)
        {
           this._votorepo.Votar(new Repository.Contratos.Voto { TipoVoto = model.IdTipoVoto });
            return View("Computado");
        }
    }
}