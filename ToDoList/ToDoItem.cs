using ToDoList.Enum;
namespace ToDoList;

public class ToDoItem
{
    public int Id { get; set; }
    public string Titulo { get; set; }
    public string Descricao { get; set; }
    public DateTime Prazo { get; set; }
    public bool Concluido { get; set; }
    public Status Satus { get; set; }
    public bool EstaAtrasado => !Concluido && DateTime.Now > Prazo;
}