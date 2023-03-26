using System.Collections.Generic;
using System.Xml.Linq;

namespace Exercise_3;

/*
                    Задание 3
Создайте приложение «Список книг для прочтения».
Приложение должно позволять добавлять книги в список,
удалять книги из списка, проверять есть ли книга в списке, и т. д.
Используйте механизм свойств, перегрузки операторов, индексаторов.
 */

class Program
{
    static void Main(string[] args)
    {
        Book book_one = new Book("TXT#1", "Anton A.V", 1999);
        Book book_two = new Book("TXT#2", "Harper Lee", 2020);
        Book book_tree = new Book("TXT#3", "George K.S", 2023);
        // Console.WriteLine(book_one);
        // Console.WriteLine(book_two);
        // Console.WriteLine(book_tree);
        List_Book _list_book = new List_Book();
        _list_book.Add(book_one);
        _list_book.Add(book_two);
        _list_book.Add(book_tree);
        _list_book.Show_books();
        _list_book.Remove(book_two);
        _list_book.Show_books();

        Console.WriteLine($"{book_one} \nЕсть в списке? {_list_book.Contains(book_one)}");
        Console.WriteLine($"{book_two} \nЕсть в списке? {_list_book.Contains(book_two)}");

        _list_book += new Book("TXT#3", "IVAN I.I", 2014);
        _list_book.Show_books();

        _list_book -= book_one;
        _list_book.Show_books();

        Console.Read();
    }
}

class Book
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int Year { get; set; }
    public Book(string title, string author, int year)
    {
        this.Title = title;
        this.Author = author;
        this.Year = year;
    }
    public override string ToString()
    {
        return string.Format
            (
            $"\nBook" +
            $"\nTitle: {Title}" +
            $"\nYear: {Year}" +
            $"\nAuthor: {Author}");
    }
}
class List_Book
{
    private List<Book> Books;
    public List_Book()
    {
        Books = new List<Book>();
    }
    public int Count
    {
        get { return Books.Count; }  
    }
    public Book this[int index]  // перегрузка индексаторов
    {
        get { return Books[index]; }
        set { Books[index] = value; }
    }
    public void Add(Book book)  // перегрузка добавить 
    {
        Books.Add(book);
    }
    public void Remove(Book book)  // перегрузка удалить 
    {
        Books.Remove(book);
    }
    public bool Contains(Book book)  // проверка списка 
    {
        return Books.Contains(book);
    }
    public static List_Book operator +(List_Book list, Book book)
    {
        list.Add(book);
        return list;
    }

    public static List_Book operator -(List_Book list, Book book)
    {
        list.Remove(book);
        return list;
    }
    public void Show_books()
    {
        foreach (Book book in Books)
        {
            Console.WriteLine(book);
        }
        Console.WriteLine($"Количество книг в списке: {Books.Count()}");
    }
}