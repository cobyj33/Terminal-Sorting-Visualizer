using System;
using System.Collections.Generic;
using System.Threading;
using System.Linq;

public class NumberVisualizer : Visualizer<double> {
  public void SetData(List<int> data) {
    Data = data.Select(val => (double)val).ToList();
  }

  public void SetData(List<float> data) {
    Data = data.Select(val => (double)val).ToList();
  }

  public NumberVisualizer(List<double> data) : base(data) {
    SetGraph(new NumberSortingGraph(data));
  }

  public NumberVisualizer(List<int> data) : base(data.Select(val => (double)val).ToList())  {
    SetGraph(new NumberSortingGraph(data));
  }

  public NumberVisualizer(List<float> data) : base(data.Select(val => (double)val).ToList())  { 
    SetGraph(new NumberSortingGraph(data));
  }

}