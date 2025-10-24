
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
    }
}
