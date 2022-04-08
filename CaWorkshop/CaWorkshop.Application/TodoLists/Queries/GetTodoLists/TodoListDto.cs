using CaWorkshop.Application.Common.Mappings;

namespace CaWorkshop.Application.TodoLists.Queries.GetTodoLists;

public class TodoListDto : IMapFrom<TodoList>
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public string? Colour { get; set; }

    public IList<TodoItemDto> Items { get; set; }
        = new List<TodoItemDto>();
}
