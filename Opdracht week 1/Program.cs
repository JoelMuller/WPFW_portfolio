struct Coordinaat
{
    public int x { get; set; }
    public int y { get; set; }
    public Coordinaat(int getal1, int getal2) : this()
    {
        if (getal1 > 0 && getal2 > 0)
        {
            x = getal1;
            y = getal2;

        }
    }
    //even vragen wat dit nou in de UML betekent
    public void operator +(Coordinaat a, Coordinaat b) : Coordinaat{

    }
}

interface Tekener
{
    // even kijken wat ik in de interfaces moet zetten
    //public Teken;
}

interface Tekenbaar
{
    //public ConsoleTekener tekenConsole;
}

class ConsoleTekener
{
    protected static void SchrijfOp(Coordinaat Positie, string Text)
    {
        if (Positie.x < 0 || Positie.y < 0)
            throw new Exception("Kan niet tekenen in het negatieve!");
        Console.SetCursorPosition(Positie.x, Positie.y);
        Console.WriteLine(Text);
    }
}

class Kaart
{
    public int breedte;
    public int hoogte;
    public Kaart(int breed, int hoog)
    {
        breedte = breed;
        hoogte = hoog;
    }

    // kan nog iets moeten returnen
    public void VoegPadToe(Pad pad)
    {

    }

    public void VoegItemToe()
    {

    }
}
class Attractie
{
    public Kaart kaart;

    //negatieve coordinat wordt gecheckt in de coordinaat class constructor.
    public Coordinaat locatie;

    public Attractie(Kaart kaart, Coordinaat coordinaat)
    {
        this.kaart = kaart;
        locatie = coordinaat;
    }

}

class Pad
{
    public Coordinaat van
    {
        get { return van; }
        set
        {
            van = value;
            lengteBerekend = null; //als variabele van verandert wordt lengteBerekend naar null gezet
        }
    }
    public Coordinaat naar
    {
        get { return naar; }
        set
        {
            naar = value;
            lengteBerekend = null; //als variabele naar verandert wordt lengteBerekend naar null gezet
        }
    }
    private float? lengteBerekend;
}

class Starter
{
    public static void Main(string[] args)
    {
        Kaart k = new Kaart(30, 30);
        Pad p1 = new Pad();
        p1.van = new Coordinaat(2, 5);
        p1.van = new Coordinaat(12, 30);
        k.VoegPadToe(p1);
        Pad p2 = new Pad();
        p2.van = new Coordinaat(26, 4);
        p2.naar = new Coordinaat(10, 5);
        k.VoegPadToe(p2);
        k.VoegItemToe(new Attractie(k, new Coordinaat(15, 15)));
        k.VoegItemToe(new Attractie(k, new Coordinaat(20, 15)));
        k.VoegItemToe(new Attractie(k, new Coordinaat(5, 18)));
        k.TekenConsole(new ConsoleTekener());
        new ConsoleTekener().SchrijfOp(new Coordinaat(0, k.Hoogte + 1), "Deze kaart is schaal 1:1000");
        System.Console.Read();
    }
}