using System;
using System.Collections;
using System.Collections.Generic;

public class BubbleSort : SortingAlgorithm {
  public BubbleSort() {
    name = "Bubble Sort";
  }

  public override void Sort<T>(List<T> target) {
    if (target.Count <= 1) { return; }
    stopped = false;


    bool sorted = false;
    while (!sorted) {
      sorted = true;
      for (int i = 1; i < target.Count; i++) {
        if (stopped) { return; }
        InvokeOnComparison();
        if (target[i].CompareTo(target[i - 1]) == -1) {
          sorted = false;
          InvokeOnArrayAccess();
          InvokeOnModification();
          T temp = target[i];
          target[i] = target[i - 1];
          target[i - 1] = temp;
        }
      }

    InvokeOnFinish();
      
  }

  }

  
}