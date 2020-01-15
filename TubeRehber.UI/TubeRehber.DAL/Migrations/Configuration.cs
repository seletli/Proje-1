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

            defaultCategories.Add(new Category {CategoryName="Eðitim",Status=Core.Entity.Enum.Status.Active,});
            defaultCategories.Add(new Category { CategoryName = "Eðlence", Status = Core.Entity.Enum.Status.Active, });
            defaultCategories.Add(new Category { CategoryName = "Film ve Dizi", Status = Core.Entity.Enum.Status.Active, });
            defaultCategories.Add(new Category { CategoryName = "Gezi", Status = Core.Entity.Enum.Status.Active, });
            defaultCategories.Add(new Category { CategoryName = "Haber", Status = Core.Entity.Enum.Status.Active, });
            defaultCategories.Add(new Category { CategoryName = "Spor", Status = Core.Entity.Enum.Status.Active, });
            defaultCategories.Add(new Category { CategoryName = "Kiþisel Geliþim", Status = Core.Entity.Enum.Status.Active, });
            defaultCategories.Add(new Category { CategoryName = "Moda", Status = Core.Entity.Enum.Status.Active, });
            defaultCategories.Add(new Category { CategoryName = "Müzik", Status = Core.Entity.Enum.Status.Active, });
            defaultCategories.Add(new Category { CategoryName = "Oyun", Status = Core.Entity.Enum.Status.Active, });
          
          

            context.Categories.AddRange(defaultCategories);
            context.Members.AddRange(defaultMembers);
            base.Seed(context);

           
        }
        

       


    }
    
}
