﻿using CaWorkshop.WebUI.Models;
using Microsoft.EntityFrameworkCore;

namespace CaWorkshop.WebUI.Data;

// Database initialisation strategies - https://jasontaylor.dev/ef-core-database-initialisation-strategies/

public class ApplicationDbContextInitialiser
{
    private readonly ApplicationDbContext _context;

    public ApplicationDbContextInitialiser(ApplicationDbContext context)
    {
        _context = context;
    }

    public void Update()
    {
        if (_context.Database.IsSqlServer())
        {
            _context.Database.Migrate();
        }
        else
        {
            _context.Database.EnsureCreated();
        }
    }

    public void Seed()
    {
        if (_context.TodoLists.Any())
        {
            return;
        }

        var list = new TodoList
        {
            Title = "Todo List",
            Items =
                {
                    new TodoItem { Title = "Make a todo list" },
                    new TodoItem { Title = "Check off the first item" },
                    new TodoItem { Title = "Realise you've already done two things on the list!"},
                    new TodoItem { Title = "Reward yourself with a nice, long nap" },
                }
        };

        _context.TodoLists.Add(list);
        _context.SaveChanges();
    }
}
