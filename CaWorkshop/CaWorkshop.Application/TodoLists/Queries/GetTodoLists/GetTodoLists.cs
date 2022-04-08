﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using CaWorkshop.Application.Common.Models;

namespace CaWorkshop.Application.TodoLists.Queries.GetTodoLists;

public class GetTodoListsQuery : IRequest<TodosVm>
{
}

public class GetTodoListsQueryHandler : IRequestHandler<GetTodoListsQuery, TodosVm>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetTodoListsQueryHandler(
        IApplicationDbContext context,
        IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<TodosVm> Handle(GetTodoListsQuery request, CancellationToken cancellationToken)
    {
        return new TodosVm
        {
            PriorityLevels = Enum.GetValues(typeof(PriorityLevel))
                        .Cast<PriorityLevel>()
                        .Select(p => new LookupDto
                        {
                            Value = (int)p,
                            Name = p.ToString()
                        })
                        .ToList(),

            Lists = await _context.TodoLists
                        .ProjectTo<TodoListDto>(_mapper.ConfigurationProvider)
                        .ToListAsync(cancellationToken)
        };
    }
}
