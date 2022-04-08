using CaWorkshop.Application.TodoLists.Commands.CreateTodoList;
using CaWorkshop.Application.TodoLists.Commands.DeleteTodoList;
using CaWorkshop.Application.TodoLists.Commands.UpdateTodoList;
using CaWorkshop.Application.TodoLists.Queries.GetTodoLists;
using CaWorkshop.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CaWorkshop.WebUI.Controllers;

public class TodoListsController : ApiControllerBase
{
    // GET: api/TodoLists
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TodoList>>> GetTodoLists()
    {
        return await Mediator.Send(new GetTodoListsQuery());
    }

    // POST: api/TodoLists
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<int>> PostTodoList(CreateTodoListCommand command)
    {
        return await Mediator.Send(command);
    }

    // PUT: api/TodoLists/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutTodoList(int id, UpdateTodoListCommand command)
    {
        if (id != command.Id)
        {
            return BadRequest();
        }

        await Mediator.Send(command);

        return NoContent();
    }

    // DELETE: api/TodoLists/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTodoList(DeleteTodoListCommand command)
    {
        await Mediator.Send(command);

        return NoContent();
    }
}
