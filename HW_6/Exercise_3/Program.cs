namespace Exercise_3;

/*
                    Задание 3
Создать базовый класс «Музыкальный инструмент»
и производные классы
«Скрипка»,
«Тромбон»,
«Укулеле»,
«Виолончель».
С помощью конструктора установить
имя каждого музыкального инструмента и его характеристики.
Реализуйте для каждого из классов методы:
■ Sound — издает звук музыкального инструмента
(пишем текстом в консоль);
■ Show — отображает название музыкального инстру-
мента;
■ Desc — отображает описание музыкального инстру-
мента;
■ History — отображает историю создания музыкаль-
ного инструмента.
 */
class Program
{
    static void Main(string[] args)
    {
        do
        {
            short choices = 0;
            Console.WriteLine
                ("___Device menu___" +
                "\n1.Violin" +
                "\n2.Trombone" +
                "\n3.Ukulele" +
                "\n4.Cello" +
                "\n5.Exit"
                );
            Console.Write("choices: "); choices = short.Parse(Console.ReadLine());
            switch (choices)
            {
                case 1:
                    MusicalInstrument _violin = new Violin
            ("Violon",
            "The perfect instrument",
            "Скрипка является одним из самых старых и известных музыкальных инструментов," +
            "\nкоторый появился в Европе в XVI веке. Развитие скрипки началось с итальянского" +
            "\nмастера Андреа Амати, который создал первую скрипку в 1555 году. После этого" +
            "\nмногие другие итальянские мастера, такие как Страдивари, Джузеппе" +
            "\nГуарнери и Николо Амати, усовершенствовали дизайн и звучание скрипки.");
                    _violin.Sound();
                    _violin.Show();
                    _violin.Desc();
                    _violin._History();
                    break;
                case 2:
                    MusicalInstrument _trombone = new Trombone
            ("Trombone",
            "The perfect instrument",
            "Тромбон имеет длинную историю, которая началась в 15 веке," +
            "\nкогда музыканты начали использовать «съездный» трубный" +
            "\nинструмент, который можно было изменять по длине, чтобы" +
            "\nпроизводить различные звуки. В 18 веке инструмент был" +
            "\nусовершенствован и получил свой современный вид.");
                    _trombone.Sound();
                    _trombone.Show();
                    _trombone.Desc();
                    _trombone._History();
                    break;
                case 3:
                    MusicalInstrument _ukulele = new Ukulele
            ("Ukulele",
            "The perfect instrument",
            "Укулеле - это небольшой струнный инструмент с корпусом " +
            "\nв форме гитары, который был разработан на Гавайских" +
            "\nостровах в XIX веке. Инструмент имеет четыре струны" +
            "\nи звучит очень мягко и приятно.");
                    _ukulele.Sound();
                    _ukulele.Show();
                    _ukulele.Desc();
                    _ukulele._History();
                    break;
                case 4:
                    MusicalInstrument _cello = new Cello
            ("Cello",
            "The perfect instrument",
            "История создания виолончели уходит в глубину истории" +
            "\nмузыкальной культуры. Она развивалась на протяжении" +
            "\nмногих столетий и прошла долгий путь от своих древних" +
            "\nпредшественников до современной формы.");
                    _cello.Sound();
                    _cello.Show();
                    _cello.Desc();
                    _cello._History();
                    break;
                case 5:
                    Console.WriteLine("Exit");
                    return;
                    break;
                default:
                    Console.WriteLine("ERROR : wrong choice!");
                    break;
            }
        } while (true);
        Console.Read();
    }

}
class MusicalInstrument
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string History { get; set; }

    public MusicalInstrument(string name, string description, string history)
    {
        Name = name;
        Description = description;
        History = history;
    }
    public virtual void Sound(){ }
    public virtual void Show() { }
    public virtual void Desc() { }
    public virtual void _History(){ }
}
class Violin : MusicalInstrument
{
    public Violin(string name, string description, string history) : base(name, description, history){ }
    public override void Sound()
    {
        Console.WriteLine("vilo-vilo");
    }
    public override void Show()
    {
        Console.WriteLine($"Musical instrument: {Name}");
    }
    public override void Desc()
    {
        Console.WriteLine($"Description of the musical instrument: {Description}");
    }
    public override void _History()
    {
        Console.WriteLine($"History of musical instrument: {History}");
    }
}
class Trombone : MusicalInstrument
{
    public Trombone(string name, string description, string history) : base(name, description, history)
    {
    }
    public override void Sound()
    {
        Console.WriteLine("Trombone-Trom");
    }
    public override void Show()
    {
        Console.WriteLine($"Musical instrument: {Name}");
    }
    public override void Desc()
    {
        Console.WriteLine($"Description of the musical instrument: {Description}");
    }
    public override void _History()
    {
        Console.WriteLine($"History of musical instrument: {History}");
    }
}
class Ukulele : MusicalInstrument
{
    public Ukulele(string name, string description, string history) : base(name, description, history)
    {
    }

    public override void Sound()
    {
        Console.WriteLine("Ukulele-lele");
    }
    public override void Show()
    {
        Console.WriteLine($"Musical instrument: {Name}");
    }
    public override void Desc()
    {
        Console.WriteLine($"Description of the musical instrument: {Description}");
    }
    public override void _History()
    {
        Console.WriteLine($"History of musical instrument: {History}");
    }
}
class Cello : MusicalInstrument
{
    public Cello(string name, string description, string history) : base(name, description, history)
    {
    }

    public override void Sound()
    {
        Console.WriteLine("Cello-loo");
    }
    public override void Show()
    {
        Console.WriteLine($"Musical instrument: {Name}");
    }
    public override void Desc()
    {
        Console.WriteLine($"Description of the musical instrument: {Description}");
    }
    public override void _History()
    {
        Console.WriteLine($"History of musical instrument: {History}");
    }
}