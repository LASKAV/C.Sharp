namespace Exercise_1;

/*
                    Задание 1
Создайте приложение для менеджмента сотрудников и паролей
Необходимо хранить следующую информацию:
    - Логины сотрудников
    - Пароли сотрудников
Для хранения информации используйте Dictionary<T>
Приложение должно представлять такую функциональность:
    - Добавление логина и пароля сотрудникам
    - Удаление логина сотрудника
    - Изменение информации о логине и пароле сотрудника
    - Получение информации о пароле по логину сотрудника

*/

class Program
{
    static void Main(string[] args)
    {
        Dictionary<string, string> _officer = new Dictionary<string, string>();

        Add_officer(_officer);
        Del_officer(_officer);
        Edit_officer(_officer);
        Get_password(_officer);
        Show_officer(_officer);
        Console.Read();
    }
    static void Show_officer(Dictionary<string,string> _dict)
    {
        foreach (var item in _dict)
        {
             Console.WriteLine($"Логин: {item.Key}, Пароль: {item.Value}");
        }
    }
    // Добавление логина и пароля сотрудникам
    static void Add_officer(Dictionary<string, string> _dict)
    {
        Console.Write("Введите логин сотрудника:");
        string login = Console.ReadLine();
        Console.Write("Введите пароль сотрудника:");
        string password = Console.ReadLine();

        if (_dict.ContainsKey(login))
        {
            Console.WriteLine("Сотрудник с таким логином уже существует.");
        }
        else
        {
            _dict.Add(login, password);
            Console.WriteLine("Сотрудник успешно добавлен.");
        }
    }
    // Удаление логина сотрудника
    static void Del_officer(Dictionary<string, string> _dict)
    {
        Console.Write("Введите логин сотрудника для удаления:");
        string login = Console.ReadLine();

        if (_dict.Remove(login))
        {
            Console.WriteLine("Сотрудник успешно удален.");
        }
        else
        {
            Console.WriteLine("Сотрудник с таким логином не найден.");
        }
    }
    // Изменение информации о логине и пароле сотрудника
    static void Edit_officer(Dictionary<string, string> _dict)
    {
        Console.WriteLine("Введите логин сотрудника для изменения:");
        string login = Console.ReadLine();

        if (_dict.ContainsKey(login))
        {
            Console.Write("Введите новый пароль:");
            string newPassword = Console.ReadLine();
            _dict[login] = newPassword;
            Console.WriteLine("Информация о сотруднике успешно обновлена.");
        }
        else
        {
            Console.WriteLine("Сотрудник с таким логином не найден.");
        }
    }
    // Получение информации о пароле по логину сотрудника
    static void Get_password(Dictionary<string, string> _dict)
    {
        Console.Write("Введите логин сотрудника:");
        string login = Console.ReadLine();

        if (_dict.ContainsKey(login))
        {
            string password = _dict[login];
            Console.WriteLine($"Пароль сотрудника с логином '{login}': {password}");
        }
        else
        {
            Console.WriteLine("Сотрудник с таким логином не найден.");
        }
    }

}

