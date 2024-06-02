using API_Леготкин.Context;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using API_Леготкин.Model;
using System.Linq;

namespace API_Леготкин.Controllers
{

    [Route("api/TasksController")]
    [ApiExplorerSettings(GroupName = "v1")]

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

        /// <summary>
        /// Метод добавления задачи
        /// </summary>
        /// <param name="task">Данные о задачи</param>
        /// <returns>Статус выполнения запроса</returns>
        /// <remarks>Данный метод добавляет задачу в базу данных</remarks>
        [Route("Add")]
        [HttpPut]
        [ApiExplorerSettings(GroupName = "v3")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public ActionResult Add([FromForm]Tasks task)
        {
            try
            {
                TasksContext tasksContext = new TasksContext();
                tasksContext.Tasks.Add(task);
                tasksContext.SaveChanges();
                return StatusCode(200);
            }
            catch (Exception exp)
            {
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Метод изменения задачи
        /// </summary>
        /// <param name="task">Данные о задачи</param>
        /// <returns>Статус выполнения запроса</returns>
        /// <remarks>Данный метод добавляет задачу в базу данных</remarks>
        [Route("Edit")]
        [HttpPut]
        [ApiExplorerSettings(GroupName = "v3")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public ActionResult Edit([FromForm] Tasks task)
        {
            try
            {
                TasksContext tasksContext = new TasksContext();
                var editTask = tasksContext.Tasks.SingleOrDefault(x => x.Id == task.Id);
                if (editTask != null)
                {
                    editTask.Name = task.Name;
                    editTask.Priority = task.Priority;
                    editTask.DateExecute = task.DateExecute;
                    editTask.Comment = task.Comment;
                    editTask.Done = task.Done;
                    tasksContext.SaveChanges();
                    return StatusCode(200);
                }
                else
                    return StatusCode(400);
            }
            catch (Exception exp)
            {
                return StatusCode(500);
            }
        }
        [Route("DeleteItem")]
        [HttpDelete]
        [ApiExplorerSettings(GroupName = "v4")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public ActionResult DeleteItem(int Id)
        {
            try
            {
                TasksContext tasksContext = new TasksContext();
                var editTask = tasksContext.Tasks.SingleOrDefault(x => x.Id == Id);
                if (editTask != null)
                {
                    tasksContext.Tasks.Remove(editTask);
                    tasksContext.SaveChanges();
                    return StatusCode(200);
                }
                else
                    return StatusCode(400);
            }
            catch (Exception exp)
            {
                return StatusCode(500);
            }
        }

        [Route("DeleteAllItems")]
        [HttpDelete]
        [ApiExplorerSettings(GroupName = "v4")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public ActionResult DeleteAllItems()
        {
            try
            {
                TasksContext tasksContext = new TasksContext();
                foreach (var task in tasksContext.Tasks)
                {
                    tasksContext.Remove(task);
                }
                tasksContext.SaveChanges();
                return StatusCode(200);
            }
            catch (Exception exp)
            {
                return StatusCode(500);
            }
        }
    }
}