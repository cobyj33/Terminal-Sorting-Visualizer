using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using System.Collections;

public class NumberSortingGraph : SortingGraph<double> {

  public NumberSortingGraph(List<int> data) : base(data.Select(val => (double)val).ToList()) { }

  public NumberSortingGraph(List<double> data) : base(data) { }

  public NumberSortingGraph(List<float> data) : base(data.Select(val => (double)val).ToList()) { }

  public void SetData(List<int> intData) {
    Data = intData.Select(val => (double)val).ToList();
  }

  public void SetIntData(List<float> intData) {
    Data = intData.Select(val => (double)val).ToList();
  }

  protected override List<float> GetRatios() {
    if (Data.Count == 0) {
      return new List<float>();
    }
    List<float> ratios = new List<float>(Data.Count);
    double maximumDataPoint = Data[0];
    double minimumDataPoint = Data[0];

    for (int i = 0; i < Data.Count; i++) {
      maximumDataPoint = Math.Max(maximumDataPoint, Data[i]);
      minimumDataPoint = Math.Min(minimumDataPoint, Data[i]);
    }

    for (int i = 0; i < Data.Count; i++) {
      ratios.Add( (float)( (Data[i] - minimumDataPoint) / (maximumDataPoint - minimumDataPoint)) );
    }

    return ratios;
  }

  // public override string GetTerminalGraphic() {
  //   StringBuilder terminalGraphic = new StringBuilder();
  //   if (Data.Count == 0) {
  //     return "  ";
  //   }
    
  //   int windowWidth = Console.WindowWidth;
  //   int windowHeight = Console.WindowHeight;
  //   float maxLineHeight = windowHeight * graphHeight;
  //   List<float> ratios = GetRatios();
  //   List<float> lines = DataManipulation.Collapse(ratios, windowWidth);

  //   for (int row = (int)maxLineHeight - 1; row >= 0; row--) {
  //     float currenAcceptedRatio = row / maxLineHeight;
  //     terminalGraphic.AppendLine( String.Join(String.Empty, lines.Select(line => line > currenAcceptedRatio ? barChar : ' ' )) );
  //   }

  //   return terminalGraphic.ToString();
  // }
}