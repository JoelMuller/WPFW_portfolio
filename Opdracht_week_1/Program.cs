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
    // public void iets (Coordinaat a, Coordinaat b) : Coordinaat{    }
}

interface Tekener
{
    // even kijken wat ik in de interfaces moet zetten
    public void Teken(Tekenbaar T);
}

interface Tekenbaar
{
    public void TekenConsole(ConsoleTekener T);
}

class ConsoleTekener
{
    public void SchrijfOp(Coordinaat Positie, string Text)
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

    public void VoegPadToe(Pad pad)
    {
        SchrijfOp(pad.van, "#");
        Coordinaat start = pad.van;
        Coordinaat end = pad.naar;
        //https://stackoverflow.com/questions/57871642/how-to-yield-coordinate-pairs-from-a-start-point-to-an-end-point

        int dx = Math.Sign(end.x - start.x);
        int dy = Math.Sign(end.y - start.y);
        int steps = Math.Max(Math.Abs(end.x - start.x), Math.Abs(end.y - start.y)) + 1;

        int x = start.x;
        int y = start.y;

        for (int i = 1; i <= steps; ++i)
        {
            x = x == end.x ? end.x : x + dx;
            y = y == end.y ? end.y : y + dy;

            var huidig = new Coordinaat(x, y);
            SchrijfOp(huidig, "=");
        }

        SchrijfOp(pad.naar, "#");
    }

    public void VoegItemToe(Attractie attractie)
    {

    }

    public void SchrijfOp(Coordinaat Positie, string Text)
    {
        if (Positie.x < 0 || Positie.y < 0)
            throw new Exception("Kan niet tekenen in het negatieve!");
        Console.SetCursorPosition(Positie.x, Positie.y);
        Console.WriteLine(Text);
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
    private float? lengteBerekend;
    public ConsoleTekener tekener { get; set; }
    public Coordinaat van { get; set; }
    public Coordinaat naar { get; set; }
}

//zelf werkend krijgen niet kijken naar de opdracht eisen
//tekent nu de van en naar locaties iets verzinnen zodat het tussen de van en naar een rij aan # tekent, while loop?
class Starter
{
    public static void Main(string[] args)
    {
        Kaart k = new Kaart(30, 30);
        Pad p1 = new Pad();
        p1.van = new Coordinaat(2, 5);
        p1.naar = new Coordinaat(12, 30);
        k.VoegPadToe(p1);
        Pad p2 = new Pad();
        p2.van = new Coordinaat(26, 4);
        p2.naar = new Coordinaat(10, 5);
        k.VoegPadToe(p2);
        k.VoegItemToe(new Attractie(k, new Coordinaat(15, 15)));
        k.VoegItemToe(new Attractie(k, new Coordinaat(20, 15)));
        k.VoegItemToe(new Attractie(k, new Coordinaat(5, 18)));
        //k.TekenConsole(new ConsoleTekener());
        new ConsoleTekener().SchrijfOp(new Coordinaat(0, k.hoogte + 1), "Deze kaart is schaal 1:1000");
        System.Console.Read();
    }
}