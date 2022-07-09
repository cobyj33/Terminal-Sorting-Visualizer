using System;
using System.Collections.Generic;

public static class Util {
  public static Type GetEnumeratedType<T>(this IEnumerable<T> _)
  {
      return typeof(T);
  }
  
}