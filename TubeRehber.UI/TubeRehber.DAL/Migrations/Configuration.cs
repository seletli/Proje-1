namespace TubeRehber.DAL.Migrations
{
    using TubeRehber.Model.Entities;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;


    internal sealed class Configuration : DbMigrationsConfiguration<TubeRehber.DAL.Context.TubeRehberContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(TubeRehber.DAL.Context.TubeRehberContext context)
        {
            

            List<Member> defaultMembers = new List<Member>();
            List<Category> defaultCategories = new List<Category>();

            defaultMembers.Add(new Member
            {
                Name = "Samet",
                SurName = "Seletli",
                UserName = "SametSeletli",
                BirthDate = new DateTime(1990, 12, 21),
                Email = "sametseletli@gmail.com",
                Role = Role.Admin,
                Password = "1990",
                Status = Core.Entity.Enum.Status.Active

            });

            defaultCategories.Add(new Category {CategoryName="E�itim",Status=Core.Entity.Enum.Status.Active,});
            defaultCategories.Add(new Category { CategoryName = "E�lence", Status = Core.Entity.Enum.Status.Active, });
            defaultCategories.Add(new Category { CategoryName = "Film ve Dizi", Status = Core.Entity.Enum.Status.Active, });
            defaultCategories.Add(new Category { CategoryName = "Gezi", Status = Core.Entity.Enum.Status.Active, });
            defaultCategories.Add(new Category { CategoryName = "Haber", Status = Core.Entity.Enum.Status.Active, });
            defaultCategories.Add(new Category { CategoryName = "Spor", Status = Core.Entity.Enum.Status.Active, });
            defaultCategories.Add(new Category { CategoryName = "Ki�isel Geli�im", Status = Core.Entity.Enum.Status.Active, });
            defaultCategories.Add(new Category { CategoryName = "Moda", Status = Core.Entity.Enum.Status.Active, });
            defaultCategories.Add(new Category { CategoryName = "M�zik", Status = Core.Entity.Enum.Status.Active, });
            defaultCategories.Add(new Category { CategoryName = "Oyun", Status = Core.Entity.Enum.Status.Active, });
          
          

            context.Categories.AddRange(defaultCategories);
            context.Members.AddRange(defaultMembers);
            base.Seed(context);

           
        }
        

       


    }
    
}
