
using System.Reflection;

class Good
{
    public int Id { get; set; }
    public string Title { get; set; }
    public double Price { get; set; }
    public string Category { get; set; }
}
class Program
{
    static void Main()
    {
        List<Good> goods = new List<Good>() 
{
new Good()
{ Id = 1, Title = "Nokia 1100", Price = 450.99, Category = "Mobile" },
new Good()
{ Id = 2, Title = "Iphone 4", Price = 5000, Category = "Mobile" },
new Good()
{ Id = 3, Title = "Refregirator 5000", Price = 2555, Category = "Kitchen" },
new Good()
{ Id = 4, Title = "Mixer", Price = 150, Category = "Kitchen" },
new Good()
{ Id = 5, Title = "Magnitola", Price = 1499, Category = "Car" },
new Good()
 { Id = 6, Title = "Samsung Galaxy", Price = 3100, Category = "Mobile" },
new Good()
 { Id = 7, Title = "Auto Cleaner", Price = 2300, Category = "Car" },
new Good()
 { Id = 8, Title = "Owen", Price = 700, Category = "Kitchen" },
new Good()
 { Id = 9, Title = "Siemens Turbo", Price = 3199, Category = "Mobile" },
new Good()
 { Id = 10, Title = "Lighter", Price = 150, Category = "Car" }
};
        while (true)
        {
            Console.WriteLine("\nВыберите номер задания для проверки:");
            Console.WriteLine("1) Выбрать товары категории Mobile, цена которых превышает 1000 грн.");
            Console.WriteLine("2) Вывести название и цену тех товаров, которые не относятся к категории Kitchen, цена которых превышает 1000 грн.");
            Console.WriteLine("3) Вычислить среднее значение всех цен товаров.");
            Console.WriteLine("4) Вывести список категорий без повторений.");
            Console.WriteLine("5) Вывести названия и категории товаров в алфавитном порядке, упорядоченных по названию.");
            Console.WriteLine("6) Посчитать суммарное количество товаров категорий Сar и Mobile.");
            Console.WriteLine("7) Вывести список категорий и количество товаров каждой категории.");
            Console.WriteLine("8) Выйти из программы.");

            int choice;
            while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 8)
            {
                Console.WriteLine("Некорректный ввод. Пожалуйста, введите число от 1 до 8.");
            }

            if (choice == 8)
            {
                Console.WriteLine("Выход из программы...");
                break;
            }

            switch (choice)
            {
                case 1:
                    Console.Clear();
                    SelectMobilesOverPrice(goods, 1000);
                    break;
                case 2:
                    Console.Clear();
                    SelectNonKitchenOverPrice(goods, 1000);
                    break;
                case 3:
                    Console.Clear();
                    CalculateAveragePrice(goods);
                    break;
                case 4:
                    Console.Clear();
                    PrintUniqueCategories(goods);
                    break;
                case 5:
                    Console.Clear();
                    PrintProductsOrderedByName(goods);
                    break;
                case 6:
                    Console.Clear();
                    CountCarAndMobileProducts(goods);
                    break;
                case 7:
                    Console.Clear();
                    PrintCategoryCounts(goods);
                    break;
                default:
                    Console.WriteLine("Неверный выбор. Пожалуйста, выберите номер задания от 1 до 7.");
                    break;
            }
        }


    }

    private static void SelectMobilesOverPrice(List<Good> goods, int v)
    {
        var good = goods.Where(x => x.Category == "Mobile" && x.Price > v);
        foreach (var product in good)
        {
            Console.WriteLine($"Имя: {product.Category}, Цена: {product.Price}");
        }
    }

    private static void SelectNonKitchenOverPrice(List<Good> goods, int v)
    {
        var good = goods.Where(x => x.Category != "Kitchen" && x.Price > v);
        foreach(var product in good)
        {
            Console.WriteLine($"Имя: {product.Category}, Цена: {product.Price}");
        }
    }

    private static void CalculateAveragePrice(List<Good> goods)
    {
        var good = goods.Average(x => x.Price);

            Console.WriteLine($"Средняя цена товаров: {good}");
    }

    private static void PrintUniqueCategories(List<Good> goods)
    {
        var good = goods.Select(x => x.Category).Distinct();
        foreach (var product in good)
        {
            Console.WriteLine(product);
        }
    }

    private static void PrintProductsOrderedByName(List<Good> goods)
    {
        var good = goods.Select(x => new {x.Category, x.Title}).OrderBy(x => x.Title);
        foreach (var product in good)
        {
            Console.WriteLine($"Название товара: {product.Title} Категория: {product.Category}");
        }
    }

    private static void CountCarAndMobileProducts(List<Good> goods)
    {
        var good = goods.Where(x => x.Category == "Car").Count() + goods.Where(y=> y.Category == "Mobile").Count();
        Console.WriteLine($"Cуммарное количество товаров категорий Сar и Mobile: {good}");
    }

    private static void PrintCategoryCounts(List<Good> goods)
    {
        var good = goods.GroupBy(g => g.Category).Select(group => new { Category = group.Key, Count = group.Count() });

        foreach (var product in good)
        {
            Console.WriteLine($"Категория: {product.Category}, Количество товаров: {product.Count}");
        }

    }
}