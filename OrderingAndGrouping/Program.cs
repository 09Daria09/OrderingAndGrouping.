
class Employee
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
    public int DepId { get; set; }
}
class Department
{
    public int Id { get; set; }
    public string Country { get; set; }
    public string City { get; set; }
}
class Program
{
    static void Main()
    {
        List<Department> departments = new List<Department>()
{ new Department(){ Id = 1, Country = "Ukraine", City = "Odesa"},
 new Department(){ Id = 2, Country = "Ukraine", City = "Kyiv" },
 new Department(){ Id = 3, Country = "France", City = "Paris" },
 new Department(){ Id = 4, Country = " Ukraine ", City = "Lviv"}
};
        List<Employee> employees = new List<Employee>()
 {
 new Employee()
 {
 Id = 1, FirstName = "Tamara", LastName = "Ivanova", Age = 22, DepId = 2
 },
 new Employee()
 {
 Id = 2, FirstName = "Nikita", LastName = "Larin", Age = 33, DepId = 1
 },
 new Employee()
 {
 Id = 3, FirstName = "Alica", LastName = "Ivanova", Age = 43, DepId = 3
 },
 new Employee()
 {
 Id = 4, FirstName = "Lida", LastName = "Marusyk", Age = 22, DepId = 2
 },
 new Employee()
 {
 Id = 5, FirstName = "Lida", LastName = "Voron", Age = 36, DepId = 4
 },
 new Employee()
 {
 Id = 6, FirstName = "Ivan", LastName = "Kalyta", Age = 22, DepId = 2
 },
 new Employee()
 {
 Id = 7, FirstName = "Nikita", LastName = "Krotov", Age = 27, DepId = 4
 }
 };
        while (true)
        {
            Console.WriteLine("\nВыберите номер задания для проверки:");
            Console.WriteLine("1) Упорядочить имена и фамилии сотрудников по алфавиту, которые проживают в Украине. Выполнить запрос немедленно.");
            Console.WriteLine("2) Отсортировать сотрудников по возрастам по убыванию. Вывести Id, FirstName, LastName, Age. Выполнить запрос немедленно");
            Console.WriteLine("3) Сгруппировать студентов по возрасту. Вывести возраст и сколько раз он встречается в списке.");
            Console.WriteLine("4) Выйти из программы.");

            int choice;
            while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 4)
            {
                Console.WriteLine("Некорректный ввод. Пожалуйста, введите число от 1 до 4.");
            }

            if (choice == 4)
            {
                Console.WriteLine("Выход из программы...");
                break;
            }

            switch (choice)
            {
                case 1:
                    Console.Clear();
                    OrderEmployeesByNamesInUkraine(employees, departments);
                    break;
                case 2:
                    Console.Clear();
                    SortEmployeesByAgeDescending(employees);
                    break;
                case 3:
                    Console.Clear();
                    GroupStudentsByAge(employees);
                    break;
                default:
                    Console.WriteLine("Неверный выбор. Пожалуйста, выберите номер задания от 1 до 3.");
                    break;
            }
        }

    }

    private static void GroupStudentsByAge(List<Employee> employees)
    {
        var user = employees.GroupBy(x => x.Age).Select(g => new
            {
                Age = g.Key,
                Count = g.Count(),
                Names = g.Select(x => x.FirstName + " " + x.LastName).ToList() 
            }).ToList();

        foreach (var i in user)
        {
            Console.WriteLine($"Возраст: {i.Age}, Количество: {i.Count}, Имена: {String.Join(", ", i.Names)}");
        }
    }


    private static void SortEmployeesByAgeDescending(List<Employee> employees)
    {
        var user = employees.OrderByDescending(x=>x.Age).ToList();

        foreach (var i in user)
        {
            Console.WriteLine($"ID {i.Id}   {i.FirstName} {i.LastName}\t Возраст: {i.Age}");
        }
    }

    private static void OrderEmployeesByNamesInUkraine(List<Employee> employees, List<Department> departments)
    {
        var user = employees.Join(departments, em => em.DepId, dep => dep.Id, (em, dep) => new { em.FirstName, em.LastName, dep.Country })
            .Where(x => x.Country == "Ukraine").OrderBy(x => x.FirstName).ThenBy(x => x.LastName).ToList();
        foreach (var i in user)
        {
            Console.WriteLine($"{i.FirstName} {i.LastName}\tСтрана: {i.Country}");
        }
    }
}