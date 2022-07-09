using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Text;



public class SortingGraph<T> : ISortingGraph<T> where T : IComparable<T> {
  public ITerminalGraphic Parent { get; set; }
  public List<T> Data { get; set; } 
  protected const char barChar = '■';
  // private const char barChar = '*';
  

  public SortingGraph(List<T> Data) {
    this.Data = Data;
  }

  protected const float graphHeight = 0.5f;
  protected virtual List<float> GetRatios() {
    if (Data.Count == 1) {
      return new List<float>();
    }
    
    List<float> sortedTestList = new List<float>(Data.Count);
    for (int i = 0; i < sortedTestList.Capacity; i++) {
      sortedTestList.Add(0.0f);
    }
    
    for (int i = 0; i < Data.Count; i++) {
      if (i == 0) {
        sortedTestList[i] = Data[i].CompareTo(Data[i + 1]) < 1 ? 1.0f : 0.5f;
      } else if (i == Data.Count - 1) {
        sortedTestList[i] = Data[i].CompareTo(Data[i - 1]) > -1 ? 1.0f : 0.5f;
      } else {
        sortedTestList[i] = Data[i].CompareTo(Data[i - 1]) > -1 && Data[i].CompareTo(Data[i + 1]) < 1 ? 1.0f : 0.5f;
      }
    }
    
    return sortedTestList;
  }

  public virtual string GetTerminalGraphic() {
    StringBuilder terminalGraphic = new StringBuilder();
    if (Data.Count == 0) {
      return "  ";
    }
    
    int windowWidth = Console.WindowWidth;
    int windowHeight = Console.WindowHeight;
    float maxLineHeight = windowHeight * graphHeight;
    List<float> ratios = GetRatios();
    List<float> lines = DataManipulation.Collapse(ratios, windowWidth);

    for (int row = (int)maxLineHeight - 1; row >= 0; row--) {
      float currenAcceptedRatio = row / maxLineHeight;
      terminalGraphic.AppendLine( String.Join(String.Empty, lines.Select(line => line > currenAcceptedRatio ? barChar : ' ' )) );
    }

    return terminalGraphic.ToString();
  }
}