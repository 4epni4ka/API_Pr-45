using API_Леготкин.Context;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using API_Леготкин.Model;
using System.Linq;

namespace API_Леготкин.Controllers
{

    [Route("арі/TasksController")]

    public class TasksController : Controller
    {
        [Route("List")]
        [HttpGet]
        [ProducesResponseType(typeof(List<Tasks>), 200)]
        [ProducesResponseType(500)]
        public ActionResult List()
        {
            try
            {
                IEnumerable<Tasks> Tasks = new TasksContext().Tasks;
                return Json(Tasks);
            }
            catch (Exception exp)
            {
                return StatusCode(500);
            }
        }

        [Route("Item")]
        [HttpGet]
        [ProducesResponseType(typeof(Tasks), 200)]
        [ProducesResponseType(500)]
        public ActionResult Item(int Id)
        {
            try
            {
                Tasks Task = new TasksContext().Tasks.Where(x => x.Id == Id).First();
                return Json(Task);
            }
            catch (Exception exp)
            {
                return StatusCode(500);
            }
        }
    }
}