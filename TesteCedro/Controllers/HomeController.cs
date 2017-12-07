using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TesteCedro.Models;

namespace TesteCedro.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            Rota rota = new Rota();
            List<Produto> ListaProdutos = rota.PegaProdutos().ToList();
            return View("Lista", ListaProdutos);
        }

        [HttpGet]
        public IActionResult AdicionaProduto()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AdicionaProduto(Produto produto)
        {

            if (!ModelState.IsValid)
            {
                return View();
            }
            else
            {
                Rota rota = new Rota();
                rota.AdicionaProduto(produto);
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public IActionResult EditaProduto(int id)
        {
            Rota rota = new Rota();
            Produto produto = rota.PegaProdutos().Single(item => item.IDProduto == id);
            return View(produto);
        }

        [HttpPost]
        public IActionResult EditaProduto(Produto produto)
        {
            if (!ModelState.IsValid)
            {
                return View(produto);
            }

            Rota rota = new Rota();
            rota.EditaProduto(produto);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult ExcluiProduto(int id)
        {
            Rota rota = new Rota();
            Produto produto = rota.PegaProdutos().Single(item => item.IDProduto == id);
            return View(produto);
        }

        [HttpPost]
        public IActionResult ExcluiProduto(Produto produto)
        {
            Rota rota = new Rota();
            rota.ExcluiProduto(produto.IDProduto);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult DetalhaProduto(int id)
        {
            Rota rota = new Rota();
            Produto produto = rota.PegaProdutos().Single(item => item.IDProduto == id);
            return View(produto);
        }

        [HttpGet]
        public IActionResult CompraProduto(int id)
        {
            Rota rota = new Rota();
            Produto produto = rota.PegaProdutos().Single(item => item.IDProduto == id);
            return View(produto);
        }

        public IActionResult Lista()
        {
            return View("Index");
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
