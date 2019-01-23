namespace AuctionSystem.Services.Implementations
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using AutoMapper.QueryableExtensions;
    using Data;
    using Interfaces;
    using Microsoft.EntityFrameworkCore;
    using Models.Category;

    public class CategoriesService : BaseService, ICategoriesService
    {
        public CategoriesService(AuctionSystemDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<T>> GetAllCategoriesWithSubCategoriesAsync<T>()
            where T : BaseCategoryServiceModel
        {
            var subCategories = await this.Context.Categories
                .ProjectTo<T>()
                .ToArrayAsync();

            return subCategories;
        }
    }
}