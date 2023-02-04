using InfoPanelUtil.Panels;
using MonoMod.ModInterop;
using System;

namespace InfoPanelUtil
{
    [ModExportName("InfoPanelUtil")]
    internal static class Export
    {
        public static Action<string> CreateUpdatingInfoPanel(string name, bool showBackground)
        {
            UpdatingInfoPanel panel = new(name, showBackground);
            return panel.AddLine;
        }

        public static void UpdateInfoPanel(string name, string message) 
            => UpdatingInfoPanel.AddLineToPanel(name, message);
    }
}
