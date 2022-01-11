using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TodoList.Infrastructure.Common.Interfaces;
using TodoList.Infrastructure.Persistence;

namespace TodoList.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection  AddInfrastructure(this IServiceCollection  service, IConfiguration configuration)
    {
        service.AddDbContext<TodoListDbContext>(opt =>
            opt.UseSqlServer(
                configuration.GetConnectionString("SqlServerConnection"),
                b => b.MigrationsAssembly(typeof(TodoListDbContext).Assembly.FullName)));

        service.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<TodoListDbContext>());

        return service;
    }
}