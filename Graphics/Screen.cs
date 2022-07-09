using System;

public class Screen : TerminalDisplay {
    public Screen() : base() { }

    public override void Display() {
        Terminal.Clear();
        Console.WriteLine(GetTerminalGraphic());
    }
}