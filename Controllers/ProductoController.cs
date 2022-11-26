using MasVeterinarias.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Rotativa.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MasVeterinarias.Controllers
{
    public class ProductoController : Controller
    {
        private IWebHostEnvironment _enviroment;

        public ProductoController(IWebHostEnvironment env)
        {
            _enviroment = env;
        }

        public ActionResult Index()
        {
            IEnumerable<Producto> Producto = null;
            using (var Client = new HttpClient())
            {
                Client.BaseAddress = new Uri("https://masveterinarias-api.azurewebsites.net/api/");
                var responseTask = Client.GetAsync("Producto");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readjob = result.Content.ReadAsAsync<IList<Producto>>();
                    readjob.Wait();
                    Producto = readjob.Result;
                }


            }
            return View(Producto);
        }

        //POST: Producto
        public ActionResult Create()
        {

            return View();

        }

        [HttpPost]
        public async Task<ActionResult> Create(Producto producto)
        {
            
            using (var Client = new HttpClient())
            {
                producto.Imagen = producto.ImageProducts.FileName;
                producto.VeterinariaId = 3;
                var json = await Client.PostAsJsonAsync("https://masveterinarias-api.azurewebsites.net/api/Producto", producto);
                if (json.IsSuccessStatusCode)
                    return RedirectToAction("Index");
            }
            ModelState.AddModelError(string.Empty, "Ha ocurrido un error");
            return View(producto);
        }

        // GET: bY Id
        public ActionResult Edit(int id)
        {
            Producto Producto = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://masveterinarias-api.azurewebsites.net/api/");
                var responseTask = client.GetAsync("Producto/" + id.ToString());
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readtask = result.Content.ReadAsAsync<Producto>();
                    readtask.Wait();
                    Producto = readtask.Result;
                }
            }

            return View(Producto);
        }


        [HttpPost]
        public ActionResult Edit(Producto Producto)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://masveterinarias-api.azurewebsites.net/api/Producto");

                //HTTP POST
                var putTask = client.PutAsJsonAsync("?id=" + Producto.Id, Producto);
                putTask.Wait();

                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    return RedirectToAction("Index");
                }
            }
            return View(Producto);
        }

        public ActionResult Detalles()
        {
            IEnumerable<Producto> Producto = null;
            using (var Client = new HttpClient())
            {
                Client.BaseAddress = new Uri("https://masveterinarias-api.azurewebsites.net/api/");
                var responseTask = Client.GetAsync("Producto");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readjob = result.Content.ReadAsAsync<IList<Producto>>();
                    readjob.Wait();
                    Producto = readjob.Result;
                }


            }
            return View(Producto);


        }


        public ActionResult Details(int id)
        {
            Producto Producto = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://masveterinarias-api.azurewebsites.net/api/");
                var responseTask = client.GetAsync("Producto/" + id.ToString());
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readtask = result.Content.ReadAsAsync<Producto>();
                    readtask.Wait();
                    Producto = readtask.Result;
                }
            }

            return View(Producto);
        }


        public ActionResult Delete(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://masveterinarias-api.azurewebsites.net/api/");

                //HTTP DELETE
                var deleteTask = client.DeleteAsync("Producto/" + id.ToString());


                var result = deleteTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    return RedirectToAction("Index");
                }
            }

            return RedirectToAction("Index");
        }

        /*
        public ActionResult ListadoProductosPDF()
        {
            IEnumerable<Producto> Producto = null;
            using (var Client = new HttpClient())
            {
                Client.BaseAddress = new Uri("https://masveterinarias-api.azurewebsites.net/api/");
                var responseTask = Client.GetAsync("Producto");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readjob = result.Content.ReadAsAsync<IList<Producto>>();
                    readjob.Wait();
                    Producto = readjob.Result;
                }
            }

           
            return new ViewAsPdf("ListadoProductosPDF", Producto)
            {

            };                
        }
        */

    }
}
