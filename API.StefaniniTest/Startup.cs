using API.StefaniniTest.Domain.Interfaces.UnitOfWork;
using API.StefaniniTest.Domain.Validators;
using API.StefaniniTest.Infrastructure.UnitIOfWork;
using FluentValidation;

namespace API.StefaniniTest
{
    public static class Startup
    {
        public static void ConfigureRepositories(IServiceCollection services)
        {
            services.AddTransient<IUnitOfWork, UnitOfWork>();
        }

        public static void ConfigureValidators(this IServiceCollection services)
        {
            services.AddValidatorsFromAssemblyContaining<DeleteOrderCommandValidator>();
            services.AddValidatorsFromAssemblyContaining<DeleteOrderItemsCommandValidator>();
            services.AddValidatorsFromAssemblyContaining<DeleteProductCommandValidator>();
            services.AddValidatorsFromAssemblyContaining<InsertProductCommandValidator>();
            services.AddValidatorsFromAssemblyContaining<UpdateProductCommandValidator>();
            services.AddValidatorsFromAssemblyContaining<ChangesSituationOrderCommandValidator>();
            services.AddValidatorsFromAssemblyContaining<UpsertOrderCommandValidator>();
            services.AddValidatorsFromAssemblyContaining<ItemOrderModelValidator>();
            services.AddValidatorsFromAssemblyContaining<SearchOrdersQueryValidator>();
        }
    }
}
