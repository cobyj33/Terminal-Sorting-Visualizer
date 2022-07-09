using System;
using System.Collections;
using System.Collections.Generic;

public class SelectionSort : SortingAlgorithm {
  public SelectionSort() {
    name = "Selection Sort";
  }

  public override void Sort<T>(List<T> target) {
    if (target.Count <= 1) { return; }
    stopped = false;

    for (int i = 0; i < target.Count; i++) {
      int minIndex = i;
      for (int j = i; j < target.Count; j++) {
        if (Stopped) { return; }
        InvokeOnComparison();
        InvokeOnArrayAccess();
        if (target[j].CompareTo(target[minIndex]) < 0) {
          minIndex = j;
        }
      }

      T temp = target[i];
      target[i] = target[minIndex];
      target[minIndex] = temp;
      InvokeOnModification();
      InvokeOnArrayAccess();
    }

    InvokeOnFinish();
  }

  
}