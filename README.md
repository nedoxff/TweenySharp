# TweenySharp
A C# binding for Tweeny - a modern C++ tweening library

# Pros
- No additional libraries needed
- No C++ dependencies or any P/Invoke methods
- Debatable but fast
- No confusing template gibberish
- It's in C#, c'mon! :D

# Cons
- Not finished
- No comments (yet)
- Buggy (for now)
- Does not support multiple points like original C++ library does
- Of course slower than the C++ variant
- Uses `dynamic` (slower)

# Usage
Here's a simple example how you can use TweenySharp:
```csharp
using System;
using TweenySharp;

namespace App
{
    class Program
    {
        static void Main(string[] args)
        {
            var tween = new Tween<int>()
                .From(0) //Start value
                .To(255) //End value
                .During(100) //Amount of steps (duration)
                .Forward() // Direction of the tween (increasing/decreasing)
                .Via(Easing.EaseType.CircularInOut) // Type of tween
                .SetOnStep(Console.WriteLine); // On step callback
            for (var i = 0; i < 100; i++)
                tween.Step(1, false); // Step by one step (0.01) and call the callback
        }
    }
}
```
### Output:
```
    ...
    16
    17
    19
    20
    22
    24
    25
    27
    29
    32
    34
    36
    39
    42
    44
    48
    51
    54
    58
    62
    67
    ...
```
