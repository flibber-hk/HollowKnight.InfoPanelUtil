using InfoPanelUtil.Panels;
using Modding;
using MonoMod.ModInterop;
using System;

namespace InfoPanelUtil
{
    [ModExportName("InfoPanelUtil")]
    internal static class Export
    {
        private static readonly ILogger _logger = new SimpleLogger("InfoPanelUtil.Export");

        public static Action<string> CreateUpdatingInfoPanel(string name, bool showBackground)
        {
            _logger.LogDebug($"Received updating info panel {name}");
            UpdatingInfoPanel panel = UpdatingInfoPanel.Create(name, showBackground);
            return panel.AddLine;
        }

        public static void UpdateInfoPanel(string name, string message) 
            => UpdatingInfoPanel.AddLineToPanel(name, message);
    }
}
