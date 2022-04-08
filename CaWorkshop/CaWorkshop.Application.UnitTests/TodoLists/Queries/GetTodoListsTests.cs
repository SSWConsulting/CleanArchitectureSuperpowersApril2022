using CaWorkshop.Application.TodoLists.Queries.GetTodoLists;

namespace CaWorkshop.Application.UnitTests.TodoLists.Queries.GetTodoLists;

[Collection(nameof(QueryCollection))]
public class GetTodoListsTests
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetTodoListsTests(TestFixture testFixture)
    {
        _context = testFixture.Context;
        _mapper = testFixture.Mapper;
    }

    [Fact]
    public async Task Handle_ReturnsCorrectVmAndListCount()
    {
        // Arrange
        var query = new GetTodoListsQuery();
        var handler = new GetTodoListsQueryHandler(_context, _mapper);

        // Act
        var result = await handler.Handle(query, CancellationToken.None);

        // Assert
        result.Should().BeOfType<TodosVm>();
        result.Lists.Should().HaveCount(1);
        result.Lists.First().Items.Should().HaveCount(4);
    }

    [Fact]
    public async Task Handle_ReturnsCorrectVmAndListCount1()
    {
        // Arrange
        var query = new GetTodoListsQuery();
        var handler = new GetTodoListsQueryHandler(_context, _mapper);

        // Act
        var result = await handler.Handle(query, CancellationToken.None);

        // Assert
        result.Should().BeOfType<TodosVm>();
        result.Lists.Should().HaveCount(1);
        result.Lists.First().Items.Should().HaveCount(4);
    }
}
