using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoItemApi.Models;
using ToDoItemApi.Services;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace ToDoItemApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ToDoListController : ControllerBase
    {
        private IRepository _repository;

        public ToDoListController(IRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Create a ToDoItem
        /// </summary>
        /// <remarks>
        /// Create a ToDoItem
        /// </remarks>
        /// <response code="200">Success</response>
        /// <response code="400">ID already exists</response>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Create(ToDoItem toDoItem)
        {
            try
            {
                _repository.Create(toDoItem);
                return Ok();
            }
            catch (System.ArgumentException)
            {
                return BadRequest("Already exists!");
            }
        }

        /// <summary>
        /// Get all ToDo items
        /// </summary>
        /// <remarks>
        /// Get all ToDo items in a list
        /// </remarks>
        /// <response code="200">Return all ToDo items in a list</response>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<List<ToDoItem>> GetAll()
        {
            var list = _repository.GetAll();
            return Ok(list);
        }

        /// <summary>
        /// Get a ToDo items by ID
        /// </summary>
        /// <remarks>
        /// Get a ToDo items by ID
        /// </remarks>
        /// <param name="id">ToDoItem description</param>
        /// <response code="200">Return all ToDo items in list</response>
        /// <response code="404">If request id does not exist</response>
        /// <returns></returns>
        [HttpGet("{id}", Name = "GetById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<ToDoItem> GetById(long id)
        {
            var toDoItem = _repository.GetById(id);
            if (toDoItem == null)
            {
                return NotFound();
            }
            return Ok(toDoItem);
        }
    }
}
