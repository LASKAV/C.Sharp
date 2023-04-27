using System;

namespace Exercise_2
{
    public class Journal
    {
        public string Name { get; set; }
        public string Publisher { get; set; }
        public DateTime Date { get; set; }
        public int PageCount { get; set; }

        public override string ToString()
        {
            return
                $"Название журнала: {Name}" +
                $"\nНазвание издательства: {Publisher}" +
                $"\nДата выпуска: {Date:dd.MM.yyyy}" +
                $"\nКоличество страниц: {PageCount}";
        }
        
    }
}

