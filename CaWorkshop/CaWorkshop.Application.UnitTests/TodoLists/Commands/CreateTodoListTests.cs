using CaWorkshop.Application.TodoLists.Commands.CreateTodoList;
using Microsoft.EntityFrameworkCore;

namespace CaWorkshop.Application.UnitTests.TodoLists.Commands.CreateTodoList;

public class CreateTodoListTests : TestFixture
{
    [Fact]
    public async Task Handle_ShouldPersistTodoList()
    {
        var command = new CreateTodoListCommand
        {
            Title = "Bucket List"
        };

        var handler = new CreateTodoListCommandHandler(Context);

        var id = await handler.Handle(command,
            CancellationToken.None);

        var entity = await Context.TodoLists
            .FirstAsync(tl => tl.Id == id);

        entity.Should().NotBeNull();
        entity.Title.Should().Be(command.Title);
    }
}
