using System;
using System.Collections.Generic;
using System.Linq;

public class QuickSort : SortingAlgorithm {
  public QuickSort() {
    name = "Quick Sort";
  }
  public override void Sort<T>(List<T> target) {
    if (target.Count <= 1) { return; }
    stopped = false;
    Sort(target, 0, target.Count - 1);
  }

  public void Sort<T>(List<T> target, int start, int end) where T : IComparable<T> {
    if (start < end && !stopped) {
      var partition = Partition(target, start, end);
      Sort(target, start, partition.Item1);
      Sort(target, partition.Item2 + 1, end);
    }
  }

  public (int, int) Partition<T>(List<T> target, int start, int end) where T : IComparable<T> {
    List<T> left = new List<T>();
    List<T> middle = new List<T>();
    List<T> right = new List<T>();

    T pivot = target[start];

    for (int i = start; i <= end; i++) {
      if (target[i].CompareTo(pivot) < 0) {
        left.Add(target[i]);
      } else if (target[i].CompareTo(pivot) > 0) {
        right.Add(target[i]);
      } else if (target[i].CompareTo(pivot) == 0) {
        middle.Add(target[i]);
      }
    }

    List<T> combined = left.Concat(middle).Concat(right).ToList();

    for (int i = start; i <= end; i++) {
      if (!(target[i].Equals(combined[i - start]))) {
        target[i] = combined[i - start];
        InvokeOnModification();
      } else {
        target[i] = combined[i - start];
      }
    }

    return (start + left.Count, start + left.Count);
  }
}