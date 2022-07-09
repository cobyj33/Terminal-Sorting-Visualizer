using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
class Program {
  private static int SortingAlgIndex = 0;
  private static List<SortingAlgorithm> SortingAlgorithms = new List<SortingAlgorithm>() { new BubbleSort(), new SelectionSort(), new InsertionSort(), new MergeSort(), new QuickSort() };

  public static NumberVisualizer visualizer;
  public static void Main (string[] args) {
    Thread.CurrentThread.Name = "Main Thread";
    Console.WriteLine("Thread: " + System.Threading.Thread.CurrentThread.Name);
    EventSystem eventSystem = EventSystem.instance;
    eventSystem.AddAction(new KeyAction(ConsoleKey.LeftArrow, () => SwitchVisualizer(1) ));
    eventSystem.AddAction(new KeyAction(ConsoleKey.RightArrow, () => SwitchVisualizer(1) ));
    eventSystem.AddAction(new KeyAction(ConsoleKey.Escape, () => UserThread.EndProgram() ));

    visualizer = new NumberVisualizer(GetData());
    visualizer.FrameTime = 200;

    Console.WriteLine("Thread (End of main before event): " + System.Threading.Thread.CurrentThread.Name);
    eventSystem.StartThread();
    Console.WriteLine("Thread (End of main): " + System.Threading.Thread.CurrentThread.Name);

    Console.CancelKeyPress += delegate(object? sender, ConsoleCancelEventArgs e) {
            e.Cancel = true;
            UserThread.EndProgram();
        };
    SwitchVisualizer(1);
  }

  public static List<int> GetData() {
    List<int> data = new List<int>();
    int dataSize = Console.WindowWidth;
    Random random = new Random();
    for (int i = 0; i < dataSize; i++) {
      data.Add( random.Next(0, dataSize));
    }
    return data;
  }

  public static void SwitchVisualizer(int amount) {
    Console.WriteLine("Switching Visualizer");
    Console.WriteLine("Thread: " + System.Threading.Thread.CurrentThread.Name);
    SortingAlgIndex += amount;
    SortingAlgIndex %= SortingAlgorithms.Count;
    visualizer.Stop();
    visualizer.SetData(GetData());
    visualizer.CurrentSortingAlgorithm = SortingAlgorithms[SortingAlgIndex];
    visualizer.Visualize();
  }
}