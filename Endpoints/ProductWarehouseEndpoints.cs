using FluentValidation;
using Zad7.DTO_s;
using Zad7.Models;
using Zad7.Services;

namespace Zad7.Endpoints
{
    public static class ProductWarehouseEndpoints
    {
        public static void RegisterProductWarehouseEndpoints(this WebApplication application)
        {
            var productWarehouse = application.MapGroup("productwarehouse-dapper");
            productWarehouse.MapPost("", AddProductWarehouse);
        }

        private static async Task<IResult> AddProductWarehouse(
            ProductWarehouseDTO productWarehouseDTO,
            IDbServiceDapper dbServiceDapper,
            IValidator<ProductWarehouseDTO> validator)
        {
            var validate = await validator.ValidateAsync(productWarehouseDTO);
            if (!validate.IsValid)
            {
                return Results.ValidationProblem(validate.ToDictionary());
            }
            return await dbServiceDapper.AddProductToWarehouse(
                new ProductWarehouse
                {
                    IdProduct = productWarehouseDTO.IdProduct,
                    IdWarehouse = productWarehouseDTO.IdWarehouse,
                    Amount = productWarehouseDTO.Amount,
                    CreatedAt = productWarehouseDTO.CreatedAt
                });
        }
    }
}
