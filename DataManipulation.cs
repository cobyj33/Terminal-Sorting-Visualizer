using System.Linq;
using System;
using System.Collections;
using System.Collections.Generic;

public static class DataManipulation {

  public static void Randomize<T>(List<T> target) {
    Random random = new Random();
    for (int i = 0; i < target.Count / 2; i++) {
      int swapInt = random.Next(0, target.Count - 1);
      Swap(target, i, swapInt);
    }
  }

  public static void Swap<T>(List<T> target, int first, int second) {
    T temp = target[first];
    target[first] = target[second];
    target[second] = temp;
  }

  public static List<int> Collapse(List<int> original, int newLength) {
    if (newLength >= original.Count) {
      return original;
    }
    
    float segmentSize = (float)original.Count / newLength;
    List<int> newList = new List<int>(newLength);
    for (int i = 0; i < newList.Capacity; i++) {
      newList.Add(0);
    }

    float segmentIndex = 0;
    for (int i = 0; i < newLength; i ++) {
      newList[i] = (int)Math.Round(original.GetRange((int)segmentIndex, (int)segmentSize).Average());

      segmentIndex += segmentSize;
    }

    return newList;
  }

  public static List<float> Collapse(List<float> original, int newLength) {
    if (newLength >= original.Count) {
      return original;
    }
    
    float segmentSize = (float)original.Count / newLength;
    List<float> newList = new List<float>(newLength);
    for (int i = 0; i < newList.Capacity; i++) {
      newList.Add(0);
    }

    float segmentIndex = 0;
    for (int i = 0; i < newLength; i ++) {
      newList[i] = original.GetRange((int)segmentIndex, (int)segmentSize).Average();
      segmentIndex += segmentSize;
    }

    return newList;
  }

  public static List<bool> Collapse(List<bool> original, int newLength) {
    List<int> intList = new List<int>();
    for (int i = 0; i < original.Count; i++) {
      intList.Add(original[i] ? 1 : 0);
    } 
    List<int> collapsedIntList = Collapse(intList, newLength);


    List<bool> boolList = new List<bool>();
    for (int i = 0; i < collapsedIntList.Count; i++) {
      boolList.Add(collapsedIntList[i] < 0.5 ? false : true);
    }

    return boolList;
    
  }

  public static float GetPercentSorted<T>(List<T> target) where T : IComparable<T> {
    float percent = 0;
    float percentPerSorted = 1f / target.Count;
    
    for (int i = 0; i < target.Count; i++) {
      if (i == 0) {
        percent += target[i].CompareTo(target[i + 1]) < 1 ? percentPerSorted : 0;
      } else if (i == target.Count - 1) {
        percent += target[i].CompareTo(target[i - 1]) > -1 ? percentPerSorted : 0;
      } else {
        percent += target[i].CompareTo(target[i - 1]) > -1 && target[i].CompareTo(target[i + 1]) < 1  ? percentPerSorted : 0;
      }
    }
    return percent;
  }

  public static int GetOccurrances(string str, params string[] targets) {
        int count = 0;
        string substring;
        for (int i = 0; i <= str.Length; i++) {
            for (int j = 0; j < targets.Length; j++) {
                if (i + targets[j].Length <= str.Length) {
                    substring = str.Substring(i, targets[j].Length);
                    if (targets[j].Equals(substring)) {
                        count++;
                    }
                }
            }
        }

        return count;
    }

}