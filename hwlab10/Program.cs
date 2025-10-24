
public interface IPrintable
{
    void PrintInfo();
}

public class Book : IPrintable
{
    public string Title { get; set; }
    public string Author { get; set; }

    public Book(string title, string author)
    {
        Title = title;
        Author = author;
    }

    public void PrintInfo()
    {
        Console.WriteLine($"Книга: \"{Title}\", Автор: {Author}");
    }
}

public class Magazine : IPrintable
{
    public string Name { get; set; }
    public int Issue { get; set; }

    public Magazine(string name, int issue)
    {
        Name = name;
        Issue = issue;
    }

    public void PrintInfo()
    {
        Console.WriteLine($"Журнал: \"{Name}\", Номер: {Issue}");
    }
}

public interface IPerson
{
    string GetDescription();
}

public class Student : IPerson
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string Group { get; set; }

    public Student(string name, int age, string group)
    {
        Name = name;
        Age = age;
        Group = group;
    }

    public string GetDescription()
    {
        return $"Студент: {Name}, Возраст: {Age}, Группа: {Group}";
    }
}

public class Teacher : IPerson
{
    public string Name { get; set; }
    public string Department { get; set; }
    public string Subject { get; set; }

    public Teacher(string name, string department, string subject)
    {
        Name = name;
        Department = department;
        Subject = subject;
    }

    public string GetDescription()
    {
        return $"Преподаватель: {Name}, Кафедра: {Department}, Предмет: {Subject}";
    }
}

class Program
{
    static async Task<int> GetDataAsync()
    {
        await Task.Delay(2000);
        return 42;
    }

    static async Task<List<Student>> LoadStudentsAsync()
    {
        Console.WriteLine("Загрузка данных о студентах...");
        await Task.Delay(1500);

        return new List<Student>
        {
            new Student("Иван", 19, "ИТ-21"),
            new Student("Мария", 21, "ИТ-22"),
            new Student("Алексей", 20, "ИТ-21"),
            new Student("Екатерина", 22, "ИТ-23"),
            new Student("Дмитрий", 18, "ИТ-20")
        };
    }

    static async Task Main(string[] args)
    {
        // задание 1 
        Console.WriteLine("=== ЗАДАНИЕ 1 - АНОНИМНЫЕ ТИПЫ ===");

        var student = new { Name = "Анна", Age = 20, Group = "ИТ-21" };

        Console.WriteLine($"Имя: {student.Name}, Возраст: {student.Age}, Группа: {student.Group}");

        var students = new[]
        {
            new { Name = "Иван", Age = 19, Group = "ИТ-21" },
            new { Name = "Мария", Age = 21, Group = "ИТ-22" },
            new { Name = "Алексей", Age = 20, Group = "ИТ-21" },
            new { Name = "Екатерина", Age = 22, Group = "ИТ-23" },
            new { Name = "Дмитрий", Age = 18, Group = "ИТ-20" }
        };

        Console.WriteLine("\nСписок студентов:");
        Console.WriteLine("");
        Console.WriteLine("Имя Возраст Группа");
        Console.WriteLine("");

        foreach (var s in students)
        {
            Console.WriteLine($"│ {s.Name,-11} │ {s.Age,-6} │ {s.Group,-7} │");
        }

        Console.WriteLine("");
        // задание 2 
        Console.WriteLine("\n=== ЗАДАНИЕ 2 - ЛЯМБДА-ВЫРАЖЕНИЯ ===");

        List<int> numbers = Enumerable.Range(1, 20).ToList();
        Console.WriteLine("Исходный список: " + string.Join(", ", numbers));

        List<int> evenNumbers = numbers.FindAll(n => n % 2 == 0);
        Console.WriteLine("Чётные числа: " + string.Join(", ", evenNumbers));

        List<int> multiplesOf3 = numbers.FindAll(n => n % 3 == 0);
        Console.WriteLine("Числа, кратные 3: " + string.Join(", ", multiplesOf3));
        // задание 3
        Console.WriteLine("\n=== ЗАДАНИЕ 3 - ИНТЕРФЕЙСЫ ===");
        List<IPrintable> printables = new List<IPrintable>
        {
            new Book("Война и мир", "Л. Толстой"),
            new Magazine("Наука и жизнь", 5),
            new Book("Преступление и наказание", "Ф. Достоевский"),
            new Magazine("Техника молодёжи", 12)
        };

        foreach (var item in printables)
        {
            item.PrintInfo();
        }
        // задание 4 
        Console.WriteLine("\n=== ЗАДАНИЕ 4 - LINQ-ЗАПРОСЫ ===");

        string[] cities = { "Москва", "Санкт-Петербург", "Казань", "Краснодар", "Новосибирск", "Калининград", "Владивосток" };

        var citiesStartingWithK = cities.Where(c => c.StartsWith("К"));
        Console.WriteLine("Города на 'К': " + string.Join(", ", citiesStartingWithK));
        var sortedByLength = cities.OrderBy(c => c.Length);
        Console.WriteLine("Города по длине: " + string.Join(", ", sortedByLength));

        var longCities = cities.Where(c => c.Length > 6);
        Console.WriteLine("Города длиннее 6 символов: " + string.Join(", ", longCities));
        // задание 5 
        Console.WriteLine("\n=== ЗАДАНИЕ 5 - АСИНХРОННОЕ ПРОГРАММИРОВАНИЕ ===");
        Console.WriteLine("Ждём данные…");

        int result = await GetDataAsync();
        Console.WriteLine($"Данные получены! Результат: {result}");
    }
}

