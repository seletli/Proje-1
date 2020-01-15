using TubeRehber.Model.Entities;
using TubeRehber.Service.Abstract;
using System;


namespace TubeRehber.Service.Concrete
{
    public class CategoryService : BaseService<Category>
    {
        public Category GetCategoryByCategoryName(string Name)
        {
            return GetByDefault(x => x.CategoryName == Name);

            
        }
    }
}
