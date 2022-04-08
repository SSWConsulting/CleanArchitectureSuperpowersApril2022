using System;
using CaWorkshop.Infrastructure.Data;
using Duende.IdentityServer.EntityFramework.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace CaWorkshop.Application.UnitTests;

public static class DbContextFactory
{
    public static ApplicationDbContext Create()
    {
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

        var operationalStoreOptions = Options.Create(
            new OperationalStoreOptions());

        var context = new ApplicationDbContext(
            options, operationalStoreOptions);

        var initialiser = new ApplicationDbContextInitialiser(context);

        initialiser.Seed();

        return context;
    }

    public static void Destroy(ApplicationDbContext context)
    {
        context.Database.EnsureDeleted();
        context.Dispose();
    }
}
