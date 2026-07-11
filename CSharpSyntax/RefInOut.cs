//* Unlike raw pointers, they are safe managed references that cannot perform pointer arithmetic or reference arbitrary memory
public class RefInOut
{
  public static void Main()
  {
    // Normal (by value)
    int normal = 10;
    ByValue(normal);
    Console.WriteLine($"ByValue: {normal}"); // 10

    // ref (must be initialized)
    int byRef = 10;
    ByRef(ref byRef);
    Console.WriteLine($"ref: {byRef}"); // 42

    // out (doesn't need initialization)
    ByOut(out var byOut);
    Console.WriteLine($"out: {byOut}"); // 42

    // in (must be initialized, read-only)
    int byIn = 10;
    ByIn(in byIn);
    Console.WriteLine($"in: {byIn}"); // 10
  }

  static void ByValue(int x)
  {
    x = 42;
  }

  static void ByRef(ref int x)
  {
    Console.WriteLine($"ref received: {x}");
  
    x = 42;
  }

  static void ByOut(out int x)
  {
    // Console.WriteLine($"out received: {x}"); //! Unassigned local variable 'x' used
    x = 42;
  }

  static void ByIn(in int x)
  {
    Console.WriteLine($"in received: {x}");
    // x = 42; //! Compile-time error (read-only)
  }
}