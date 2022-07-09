using System;

public interface ITerminalGraphic {
  public ITerminalGraphic Parent { get; set; }
  public string GetTerminalGraphic();
}