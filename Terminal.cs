using System;
using System.Text;
using static DataManipulation;

public static class Terminal {

  public static void WriteToCenter(string toWrite) {
    Console.WriteLine(GetCenteredString(toWrite));
  }

  public static int GetStringHeight(string toWrite) {
    int stringHeight = toWrite.Length / Console.BufferWidth;
    stringHeight += GetOccurrances(toWrite, "\n");
    return stringHeight;
  }

  public static string GetCenteredString(string toWrite) {
    StringBuilder builder = new StringBuilder();
    if (toWrite.Length <= Console.WindowWidth) {
      string padding = new String(' ', (Console.WindowWidth - toWrite.Length) / 2);
      builder.Append(padding + toWrite + padding);
    } else {
      for (int i = 0; i < toWrite.Length; i += Console.WindowWidth) {
        if (i + Console.WindowWidth >= toWrite.Length) {
          string padding = new String(' ', (Console.WindowWidth - (toWrite.Length - i)) / 2);
          builder.Append(padding + toWrite + padding);
        } else {
          builder.Append(toWrite.Substring(i, Console.WindowWidth));
        }
      }
    }
    return builder.ToString();
  }

  // public static string GetSpacedBetweenString(params string strings) {
  //   int length = TotalLength(strings);
  //   int paddingBetween = 
  // }

  // public static int TotalLength(params string strings) {
  //   int len = 0;
  //   foreach (string str in strings) {
  //     len += str.Length;
  //   }
  //   return len;
  // }

  public static void Clear() {
    Console.Write("\033[H\033[2J");
    Console.Clear();
  }
  
}