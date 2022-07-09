using System;
using System.Collections;
using System.Collections.Generic;

public class InsertionSort : SortingAlgorithm {
  public InsertionSort() {
    name = "Insertion Sort";
  }

  public void Swap<T>(List<T> target, int first, int second) {
    T temp = target[first];
    target[first] = target[second];
    target[second] = temp;
    InvokeOnModification();
  }

  public void Insert<T>(List<T> target, int sourceIndex, int destinationIndex) {
    for (int i = destinationIndex; i < sourceIndex; i++) {
      Swap(target, i, sourceIndex);
    }
  }

  public override void Sort<T>(List<T> target) {
    if (target.Count < 2) { return; }
    stopped = false;

    for (int i = 1; i < target.Count; i++) {
      for (int j = i - 1; j >= 0; j--) {
        if (stopped) { return; }
        if (j == 0 && target[i].CompareTo(target[j]) <= 0 ) {
          Insert(target, i, j);
          break;
        } else if (target[j].CompareTo(target[i]) < 0 ) {
          Insert(target, i, j + 1);
          break;
        }
      }
    }
  }
}