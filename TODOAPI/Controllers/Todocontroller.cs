using Microsoft.AspNetCore.Mvc;
using TodoApi.Models;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        // In-memory store for ToDo items
        private static List<TodoItem> TodoList = new List<TodoItem>();

        // GET: api/Todo
        [HttpGet]
        public ActionResult<IEnumerable<TodoItem>> GetTodoItems()
        {
            return Ok(TodoList);
        }

        // GET: api/Todo/5
        [HttpGet("{id}")]
        public ActionResult<TodoItem> GetTodoItem(int id)
        {
            var todoItem = TodoList.FirstOrDefault(t => t.Id == id);
            if (todoItem == null)
            {
                return NotFound();
            }
            return Ok(todoItem);
        }

        // POST: api/Todo
        [HttpPost]
        public ActionResult<TodoItem> PostTodoItem(TodoItem todoItem)
        {
            todoItem.Id = TodoList.Count + 1;  // Simple ID generation
            TodoList.Add(todoItem);
            return CreatedAtAction(nameof(GetTodoItem), new { id = todoItem.Id }, todoItem);
        }

        // PUT: api/Todo/5
        [HttpPut("{id}")]
        public IActionResult PutTodoItem(int id, TodoItem todoItem)
        {
            var existingTodo = TodoList.FirstOrDefault(t => t.Id == id);
            if (existingTodo == null)
            {
                return NotFound();
            }
            var title = todoItem.Title;
            var description = todoItem.Description;
            var isCompleted = todoItem.IsCompleted;
            //existingTodo.Task = todoItem.Task;
            //existingTodo.IsCompleted = todoItem.IsCompleted;
            return NoContent();
        }

        // DELETE: api/Todo/5
        [HttpDelete("{id}")]
        public IActionResult DeleteTodoItem(int id)
        {
            var todoItem = TodoList.FirstOrDefault(t => t.Id == id);
            if (todoItem == null)
            {
                return NotFound();
            }

            TodoList.Remove(todoItem);
            return NoContent();
        }
    }
}

