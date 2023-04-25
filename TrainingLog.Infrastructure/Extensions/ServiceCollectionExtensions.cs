// using Microsoft.EntityFrameworkCore;
// using Microsoft.Extensions.Configuration;
// using Microsoft.Extensions.DependencyInjection;
// using Microsoft.Extensions.Options;
//
// namespace TrainingLog.Infrastructure.Extensions;
//
// public static class ServiceCollectionExtensions
// {
//     public static IServiceCollection AddDatabase<T>(this IServiceCollection services, IConfiguration configuration,
//         string connectionString) where T : DbContext
//     {
//         services.AddDbContext<T>(options =>
//             options.UseSqlServer(configuration.GetConnectionString(connectionString)));
//
//         return services;
//     }
// }