using System;
using System.Collections.Generic;
public interface ITerminalDisplay : ITerminalGraphic {
    public void Display();
    public void AddGraphic(ITerminalGraphic graphic);
    public void RemoveGraphic(ITerminalGraphic graphic);
    public IEnumerable<ITerminalGraphic> GetGraphics();
    public void Clear();
}