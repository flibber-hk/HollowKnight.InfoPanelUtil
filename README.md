# HollowKnight.InfoPanelUtil

Debug addon that adds more options for creating info panels.

This mod requires Debug Mod, but all the panels defined here can be referenced safely
without DebugMod installed through MonoMod ModInterop, and will only be displayable if
both this and DebugMod are installed.

Usage as follows:
* Add the Debug Import file [here](https://github.com/TheMulhima/HollowKnight.DebugMod/blob/master/Example%20of%20Adding%20into%20Debug/DebugImport.cs) as usual.
* Modify the file as follows:

```cs
// Add the following as a nested class of DebugMod
[ModImportName("InfoPanelUtil")]
private static class InfoPanelImport
{
    public static Func<string, bool, Action<string>> CreateUpdatingInfoPanel = null;
    public static Action<string, string> UpdateInfoPanel = null;
}

// Call the following in the static constructor of DebugMod
typeof(InfoPanelImport).ModInterop();

// Add the following methods to the DebugMod class
public static Action<string> CreateUpdatingInfoPanel(string Name, bool showBackground)
    => InfoPanelImport.CreateUpdatingInfoPanel?.Invoke(Name, showBackground) ?? ((s) => { });
    
public static void UpdateInfoPanel(string name, string message)
    => InfoPanelImport.UpdateInfoPanel?.Invoke(name, message);
```

* Call `DebugMod.CreateUpdatingInfoPanel(name, showBackground) in the Initialize method of your mod.
* Messages can be sent to the info panel either by calling UpdateInfoPanel with the same name argument,
name, or by calling the action returned by CreateUpdatingInfoPanel.

To view the panel, click the Info Panel Switch button on the Mod UI page of debug mod's keybinds until the
intended panel is shown.
