using System;
using System.Collections;
using System.Collections.Generic;

public class MergeSort : SortingAlgorithm {
  public MergeSort() {
    name = "Merge Sort";
  }

  public override void Sort<T>(List<T> target) {
    if (target.Count <= 1) { return; }
    stopped = false;
    Sort(target, 0, target.Count - 1);
  }

  private void Sort<T>(List<T> target, int start, int end) where T : IComparable<T> {
    if (start < end && !stopped) {
      int mid = (start + end) / 2;
      Sort(target, start, mid);
      Sort(target, mid + 1, end);
      Merge(target, start, mid, end);
      InvokeOnModification();
    }
  }

  private void Merge<T>(List<T> target, int start, int mid, int end) where T : IComparable<T> {
    List<T> mergedList = new List<T>();
    int leftIndex = start;
    int rightIndex = mid + 1;

    for (int i = 0; i <= (end - start); i++) {
      if (leftIndex > mid) {
        mergedList.Add(target[rightIndex]);
        rightIndex++;
      } else if (rightIndex > end) {
        mergedList.Add(target[leftIndex]);
        leftIndex++;
      } else if (target[leftIndex].CompareTo(target[rightIndex]) < 0) {
        mergedList.Add(target[leftIndex]);
        leftIndex++;
      } else if (target[leftIndex].CompareTo(target[rightIndex]) > 0) {
        mergedList.Add(target[rightIndex]);
        rightIndex++;
      } else if (target[leftIndex].CompareTo(target[rightIndex]) == 0)  {  
        mergedList.Add(target[leftIndex]);
        leftIndex++;
      }
    }

    for (int i = start; i <= end; i++) {
      target[i] = mergedList[i - start];
      InvokeOnModification();
    }
  }

  
}