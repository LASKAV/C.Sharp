namespace Exercise_2;

/*
                   Задание 2 
Создайте приложение "Англо-французкий словарь".
Необходимо хранить следующую информацию :
 * Слово на английском языке 
 * Варианты превода на французкий
Для хренения иформации используйте Dictipnary <T>
Приложение должно прежсталять такую функциональность:
 * Добалвение слова и вариантов перевода 
 * Удаление слова 
 * Удаление варианта перевода 
 * Изменение слова
 * Изменение варианта перевода
 * Поиск перевода слова
 */

class Program
{
    static void Main(string[] args)
    {
        Translator translator = new Translator();
        while (true)
        {
            Console.WriteLine("Меню:");
            Console.WriteLine("1. Добавить слово и варианты перевода");
            Console.WriteLine("2. Удалить слово");
            Console.WriteLine("3. Удалить вариант перевода");
            Console.WriteLine("4. Изменить слово");
            Console.WriteLine("5. Изменить вариант перевода");
            Console.WriteLine("6. Поиск перевода слова");
            Console.WriteLine("7. Выход");
            Console.Write("Выберите опцию: ");
            int option = Convert.ToInt32(Console.ReadLine());

            switch (option)
            {
                case 1:
                    Console.Write("Введите английское слово: ");
                    string englishWord = Console.ReadLine();
                    Console.Write("Введите варианты перевода через запятую: ");
                    string translationsInput = Console.ReadLine();
                    List<string> translations = translationsInput.Split(',').Select(t => t.Trim()).ToList();
                    translator.AddWord(englishWord, translations);
                    break;
                case 2:
                    Console.Write("Введите английское слово для удаления: ");
                    string wordToRemove = Console.ReadLine();
                    translator.RemoveWord(wordToRemove);
                    break;
                case 3:
                    Console.Write("Введите английское слово: ");
                    string wordForTranslationRemoval = Console.ReadLine();
                    Console.Write("Введите вариант перевода для удаления: ");
                    string translationToRemove = Console.ReadLine();
                    translator.RemoveTranslation(wordForTranslationRemoval, translationToRemove);
                    break;
                case 4:
                    Console.Write("Введите английское слово для изменения: ");
                    string wordToUpdate = Console.ReadLine();
                    Console.Write("Введите новое английское слово: ");
                    string newWord = Console.ReadLine();
                    translator.UpdateWord(wordToUpdate, newWord);
                    break;
                case 5:
                    Console.Write("Введите английское слово: ");
                    string wordForTranslationUpdate = Console.ReadLine();
                    Console.Write("Введите старый вариант перевода: ");
                    string oldTranslation = Console.ReadLine();
                    Console.Write("Введите новый вариант перевода: ");
                    string newTranslation = Console.ReadLine();
                    translator.UpdateTranslation(wordForTranslationUpdate, oldTranslation, newTranslation);
                    break;
                case 6:
                    Console.Write("Введите английское слово для поиска: ");
                    string wordToSearch = Console.ReadLine();
                    translator.SearchTranslation(wordToSearch);
                    break;
                case 7:
                    Console.WriteLine("До свидания!");
                    return;
                default:
                    Console.WriteLine("Некорректная опция! Попробуйте снова.");
                    break;
            }
            Console.WriteLine();
        }
        Console.Read();

    }
}

class Translator {
        private Dictionary<string, List<string>> dictionary = new Dictionary<string, List<string>>();

        public void AddWord(string englishWord, List<string> frenchTranslations)
        {
            if (!dictionary.ContainsKey(englishWord))
            {
                dictionary[englishWord] = frenchTranslations;
            }
            else
            {
                Console.WriteLine("Слово уже существует в словаре!");
            }
        }
        public void RemoveWord(string englishWord)
        {
            if (dictionary.ContainsKey(englishWord))
            {
                dictionary.Remove(englishWord);
            }
            else
            {
                Console.WriteLine("Слово не найдено в словаре!");
            }
        }
        public void RemoveTranslation(string englishWord, string frenchTranslation)
        {
            if (dictionary.ContainsKey(englishWord))
            {
                if (dictionary[englishWord].Contains(frenchTranslation))
                {
                    dictionary[englishWord].Remove(frenchTranslation);
                }
                else
                {
                    Console.WriteLine("Вариант перевода не найден!");
                }
            }
            else
            {
                Console.WriteLine("Слово не найдено в словаре!");
            }
        }
        public void UpdateWord(string englishWord, string newEnglishWord)
        {
            if (dictionary.ContainsKey(englishWord))
            {
                List<string> translations = dictionary[englishWord];
                dictionary.Remove(englishWord);
                dictionary[newEnglishWord] = translations;
            }
            else
            {
                Console.WriteLine("Слово не найдено в словаре!");
            }
        }
        public void UpdateTranslation(string englishWord, string oldFrenchTranslation, string newFrenchTranslation)
        {
            if (dictionary.ContainsKey(englishWord))
            {
                List<string> translations = dictionary[englishWord];
                if (translations.Contains(oldFrenchTranslation))
                {
                    translations.Remove(oldFrenchTranslation);
                    translations.Add(newFrenchTranslation);
                }
                else
                {
                    Console.WriteLine("Вариант перевода не найден!");
                }
            }
            else
            {
                Console.WriteLine("Слово не найдено в словаре!");
            }
        }
        public void SearchTranslation(string englishWord)
        {
            if (dictionary.ContainsKey(englishWord))
            {
                List<string> translations = dictionary[englishWord];
                Console.WriteLine($"Перевод слова '{englishWord}':");
                foreach (string translation in translations)
                {
                    Console.WriteLine(translation);
                }
            }
            else
            {
                Console.WriteLine("Слово не найдено в словаре!");
            }
        }
}
