To build this mod, it needs references to the following dll files in `7 Days To Die/7DaysToDie_Data/Managed`:

- `0Harmony`
- `Assembly-CSharp`
- `Assembly-CSharp-firstpass`
- `LogLibrary`
- `mscorlib`
- `System`
- `System.Core`
- `System.Data`
- `System.Xml`
- `UnityEngine`
- `UnityEngine.CoreModule`

Copy these files to this folder.

Technically, you can go without the System modules as you will have those natively with .NET Framework 4.6.1, but
the game actually uses Unity's modified versions of those files with Mono extensions, so Your Mileage May Vary.