using System;
using System.Threading;
using System.Collections;
using System.Collections.Generic;
using System.Text;

public class Visualizer<T> : TerminalDisplay where T : IComparable<T> {
  public virtual List<T> Data { get; set; }
  public void SetData(List<T> data) {
    Data = data;
  }


  private ISortingGraph<T> graph;
  public ISortingGraph<T> Graph { get => graph;
  set {
    ReplaceGraphic(graph, value);
    graph = value;
    }
  }
  public SortingAlgorithm CurrentSortingAlgorithm { get; set; } = new BubbleSort();
  public int FrameTime { get; set; } = 100;
  const int MinFrameTime = 5;
  const int MaxFrameTime = 500;
  public Visualizer(List<T> data) {
    Graph = new SortingGraph<T>(data);
    EventSystem.instance.AddAction(new KeyAction(ConsoleKey.Spacebar, TogglePlayback));
    EventSystem.instance.AddAction(new KeyAction(ConsoleKey.Add, DecreaseFrameTime));
    EventSystem.instance.AddAction(new KeyAction(ConsoleKey.Subtract, IncreaseFrameTime));
    EventSystem.instance.AddAction(new KeyAction(ConsoleKey.R, Randomize));
    this.Data = data;
  }

  public void IncreaseFrameTime() => FrameTime = Math.Min(FrameTime + 5, MaxFrameTime);
  public void DecreaseFrameTime() => FrameTime = Math.Max(FrameTime - 5, MinFrameTime);

  public void TogglePlayback() {
    if (CurrentSortingAlgorithm.Stopped) {
      Visualize();
    } else {
      Stop();
    }
  }

  public void Randomize() {
    bool wasStopped = CurrentSortingAlgorithm.Stopped;
    Stop();
    Data = new List<T>(Data);
    DataManipulation.Randomize(Data);
    if (!wasStopped) {
      Visualize();
    }
  }

  public void SetGraph(ISortingGraph<T> Graph) {
    this.Graph = Graph;
    this.Graph.Data = Data;
  }

  public void Stop() {
    CurrentSortingAlgorithm.Stop();
    CurrentSortingAlgorithm.OnModification -= Update;
    CurrentSortingAlgorithm.OnFinish -= Update;
  }

  public void Visualize() {
    Stop();
    CurrentSortingAlgorithm.OnModification += Update;
    CurrentSortingAlgorithm.OnFinish += Update;
    CurrentSortingAlgorithm.Sort(Data);
  }
  
  // public void Visualize(SortingAlgorithm algorithm) {
  //   Stop();
  //   CurrentSortingAlgorithm = algorithm;
  //   CurrentSortingAlgorithm.OnModification += Update;
  //   CurrentSortingAlgorithm.OnFinish += Update;
  //   CurrentSortingAlgorithm.Sort(Data);
  // }


  public override string GetTerminalGraphic() {
    StringBuilder builder = new StringBuilder();
    Terminal.Clear();
    Graph.Data = Data;
    builder.AppendLine(new String('■', Console.WindowWidth));
    builder.AppendLine(Terminal.GetCenteredString(" Algorithm Name: " + CurrentSortingAlgorithm.Name));
    
    builder.AppendLine(base.GetTerminalGraphic());

    builder.AppendLine( " Percent Sorted: " + Math.Round( DataManipulation.GetPercentSorted( Data ) * 100 )  );
    builder.AppendLine(new String('■', Console.WindowWidth));
    
    builder.AppendLine(Terminal.GetCenteredString("< Left Arrow to Last Algorithm | Right Arrow to Next Algorithm >"));

    if (CurrentSortingAlgorithm.Stopped) {
      builder.AppendLine(Terminal.GetCenteredString("Space to Resume"));
    } else {
      builder.AppendLine(Terminal.GetCenteredString("Space to Pause"));
    }

    builder.AppendLine(Terminal.GetCenteredString("R to Randomize"));
    builder.AppendLine(Terminal.GetCenteredString($"Press + to Speed Up ( Current FPS: { 1000 / FrameTime }  ) Press - to Slow Down"));
    builder.AppendLine(Terminal.GetCenteredString("Press ESC to Cancel"));
    return builder.ToString();
  }

  public override void Display() {
    // Console.WriteLine("Graphics: " + GetGraphicCount() ); 
    Console.WriteLine(GetTerminalGraphic());
    // Console.WriteLine(Thread.CurrentThread.Name);
  }

  public void Update() {
    Thread.Sleep(FrameTime);
    Display();
  }


}