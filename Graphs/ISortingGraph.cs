using System.Collections.Generic;
using System;

public interface ISortingGraph<T> : ITerminalGraphic where T : IComparable<T> {
  public List<T> Data { get; set; }
}