using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Academia_DKP.Models;
using Amazon.DynamoDBv2.Model;
using FakeItEasy.Sdk;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Academia_DKP.Controllers
{
    public class EspecialidadesController : Controller
    {

        public ActionResult Index()
        {
            CrudEspecialidade crudEspecialidade = new CrudEspecialidade();
            var especialidades = crudEspecialidade.ObterEspecialidades();
              
            return View(especialidades);
        }

       public ActionResult Details(int id )
        {
            
            CrudEspecialidade crudEspecialidade = new CrudEspecialidade();          
            var espe = crudEspecialidade.ObterEspecialidadeId(id);
            return View(espe);

        }



        public ActionResult Insere()
        {
            return View();
        }

        public ActionResult Create(Especialidade especialidade)
        {
            try
            {

                CrudEspecialidade crudEspecialidade = new CrudEspecialidade();
            crudEspecialidade.InserirEspecialidade(especialidade);

                return RedirectToAction(nameof(Index));
               
            }
            catch
            {
                 
                return View();
              
            }
            
        }

        public ActionResult Edit(Especialidade especialidade)
        {
           
            CrudEspecialidade crudEspecialidade = new CrudEspecialidade();
            var especialidades = crudEspecialidade.UpdateEspecialidade(especialidade);

            return RedirectToAction(nameof(Index));

        }

        public ActionResult Editar(int id)
        {
            CrudEspecialidade crudEspecialidade = new CrudEspecialidade();
            var espe = crudEspecialidade.ObterEspecialidadeId(id);
            return View(espe);
       
        }

        public ActionResult Delete()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                CrudEspecialidade crudEspecialidade = new CrudEspecialidade();
              var especialidade = crudEspecialidade.DeleteEspecialidade(id);

                return RedirectToAction(nameof(Index));
                

            }
            catch
            {
                return View("Não foi possivel deletar");
            }
        }
       
    }
    
}
