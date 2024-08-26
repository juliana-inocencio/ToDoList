using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using ToDoList.Service;

namespace ToDoList.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ToDoController : ControllerBase
{
    private readonly IToDoService _toDoService;

    public ToDoController(IToDoService toDoService)
    {
        _toDoService = toDoService;
    }

    [HttpGet]
    [SwaggerOperation(Summary = "Buscar todas as tarefas", Description = "Retorna uma lista de todas as tarefas cadastradas.")]
    public async Task<ActionResult<IEnumerable<ToDoItem>>> GetAll()
    {
        var items = await _toDoService.GetAllAsync();
        return Ok(items);
    }

    [HttpGet("{id}")]
    [SwaggerOperation(Summary = "Buscar tarefa por ID", Description = "Retorna uma tarefa específica pelo ID.")]
    public async Task<ActionResult<ToDoItem>> GetById(int id)
    {
        var item = await _toDoService.GetByIdAsync(id);
        if (item == null)
            return NotFound();

        return Ok(item);
    }

    [HttpPost]
    [SwaggerOperation(Summary = "Nova tarefa", Description = "Cria uma nova tarefa.")]
    public async Task<ActionResult> Create(ToDoItem toDoItem)
    {
        try
        {
            await _toDoService.AddAsync(toDoItem);
            return CreatedAtAction(nameof(GetById), new { id = toDoItem.Id }, toDoItem);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("{id}")]
    [SwaggerOperation(Summary = "Atualizar tarefa", Description = "Atualiza uma tarefa existente.")]
    public async Task<IActionResult> Update(int id, ToDoItem toDoItem)
    {
        if (id != toDoItem.Id)
            return BadRequest();

        await _toDoService.UpdateAsync(toDoItem);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [SwaggerOperation(Summary = "Deletar tarefa", Description = "Deleta uma tarefa existente pelo ID.")]
    public async Task<IActionResult> Delete(int id)
    {
        await _toDoService.DeleteAsync(id);
        return NoContent();
    }
}