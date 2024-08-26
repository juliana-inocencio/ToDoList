using Microsoft.EntityFrameworkCore;
using System;
using ToDoList.Context;

namespace ToDoList.Repository;

public class ToDoRepository : IToDoRepository
{
    private readonly AppDbContext _context;

    public ToDoRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<ToDoItem>> GetAllAsync()
    {
        return await _context.ToDoItems.ToListAsync();
    }

    public async Task<ToDoItem> GetByIdAsync(int id)
    {
        return await _context.ToDoItems.FindAsync(id);
    }

    public async Task<ToDoItem> GetByTituloAsync(string titulo)
    {
        return await _context.ToDoItems.FirstOrDefaultAsync(t => t.Titulo == titulo);
    }

    public async Task AddAsync(ToDoItem toDoItem)
    {
        _context.ToDoItems.Add(toDoItem);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(ToDoItem toDoItem)
    {
        _context.Entry(toDoItem).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var toDoItem = await _context.ToDoItems.FindAsync(id);
        if (toDoItem != null)
        {
            _context.ToDoItems.Remove(toDoItem);
            await _context.SaveChangesAsync();
        }
    }
}
