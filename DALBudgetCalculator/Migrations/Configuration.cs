namespace DALBudgetCalculator.Migrations
{
    using DALBudgetCalculator.Entities;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MyContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        public class MyContextInitializer : CreateDatabaseIfNotExists<MyContext>
        {
            protected override void Seed(MyContext context)
            {
                context.Categories.Add(new Category { Id = 1, Name = "Гигиена", Image = "Гигиена" });
                context.Categories.Add(new Category { Id = 2, Name = "Еда", Image = "Еда" });
                context.Categories.Add(new Category { Id = 3, Name = "Жилье", Image = "Жилье" });
                context.Categories.Add(new Category { Id = 4, Name = "Здоровье", Image = "Здоровье" });
                context.Categories.Add(new Category { Id = 5, Name = "Кафе", Image = "Кафе" });
                context.Categories.Add(new Category { Id = 6, Name = "Машина", Image = "Машина" });
                context.Categories.Add(new Category { Id = 7, Name = "Одежда", Image = "Одежда" });
                context.Categories.Add(new Category { Id = 8, Name = "Питомцы", Image = "Питомцы" });
                context.Categories.Add(new Category { Id = 9, Name = "Подарки", Image = "Подарки" });
                context.Categories.Add(new Category { Id = 10, Name = "Развлечения", Image = "Развлечения" });
                context.Categories.Add(new Category { Id = 11, Name = "Связь", Image = "Связь" });
                context.Categories.Add(new Category { Id = 12, Name = "Спорт", Image = "Спорт" });
                context.Categories.Add(new Category { Id = 13, Name = "Счета", Image = "Счета" });
                context.Categories.Add(new Category { Id = 14, Name = "Такси", Image = "Такси" });
                context.Categories.Add(new Category { Id = 15, Name = "Транспорт", Image = "Транспорт" });
                context.Categories.Add(new Category { Id = 16, Name = "Зарплата", Image = "Зарплата" });


                context.Operations.Add(new Operation { Id = 1, Amount = -50, Description = "Зубная паста", DateOperation = new DateTime(2020, 1, 11), CategoryId = 1, UserId = 1 });
                context.Operations.Add(new Operation { Id = 2, Amount = -3500, Description = "Продукты", DateOperation = new DateTime(2020, 1, 11), CategoryId = 2, UserId = 1 });
                context.Operations.Add(new Operation { Id = 3, Amount = -4000, Description = "Аренда жилья", DateOperation = new DateTime(2020, 1, 11), CategoryId = 3, UserId = 1 });
                context.Operations.Add(new Operation { Id = 4, Amount = -180, Description = "Анальгин", DateOperation = new DateTime(2020, 1, 11), CategoryId = 4, UserId = 1 });
                context.Operations.Add(new Operation { Id = 5, Amount = -500, Description = "MacDonalds", DateOperation = new DateTime(2020, 1, 11), CategoryId = 5, UserId = 1 });
                context.Operations.Add(new Operation { Id = 6, Amount = -1000, Description = "Фильтра", DateOperation = new DateTime(2020, 1, 11), CategoryId = 6, UserId = 1 });
                context.Operations.Add(new Operation { Id = 7, Amount = -40, Description = "Штаны за 40", DateOperation = new DateTime(2020, 1, 11), CategoryId = 7, UserId = 1 });
                context.Operations.Add(new Operation { Id = 8, Amount = -50, Description = "Корм", DateOperation = new DateTime(2020, 1, 11), CategoryId = 8, UserId = 1 });
                context.Operations.Add(new Operation { Id = 9, Amount = -50, Description = "Наушники", DateOperation = new DateTime(2020, 1, 11), CategoryId = 9, UserId = 1 });
                context.Operations.Add(new Operation { Id = 10, Amount = -50, Description = "Квест-комната", DateOperation = new DateTime(2020, 1, 11), CategoryId = 10, UserId = 1 });
                context.Operations.Add(new Operation { Id = 11, Amount = -125, Description = "Водафон чтоб его", DateOperation = new DateTime(2020, 1, 11), CategoryId = 11, UserId = 1 });
                context.Operations.Add(new Operation { Id = 12, Amount = -250, Description = "Качалка", DateOperation = new DateTime(2020, 1, 11), CategoryId = 12, UserId = 1 });
                context.Operations.Add(new Operation { Id = 13, Amount = -150, Description = "Интернет", DateOperation = new DateTime(2020, 1, 11), CategoryId = 13, UserId = 1 });
                context.Operations.Add(new Operation { Id = 14, Amount = -80, Description = "3040", DateOperation = new DateTime(2020, 1, 11), CategoryId = 14, UserId = 1 });
                context.Operations.Add(new Operation { Id = 15, Amount = -400, Description = "Трамвай, Гепа метро закрыл", DateOperation = new DateTime(2020, 1, 11), CategoryId = 15, UserId = 1 });
                context.Operations.Add(new Operation { Id = 16, Amount = 20000, Description = "Зарплата", DateOperation = new DateTime(2020, 1, 11), CategoryId = 16, UserId = 1 });

            }
        }
    }
}
