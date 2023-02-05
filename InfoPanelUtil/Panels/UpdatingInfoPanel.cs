using System.Collections.Generic;
using System.Linq;
using DebugMod.InfoPanels;

namespace InfoPanelUtil.Panels
{
    /// <summary>
    /// Class for an info panel that allows sending single-line messages to the panel
    /// </summary>
    public class UpdatingInfoPanel : CustomInfoPanel
    {
        private static readonly Dictionary<string, UpdatingInfoPanel> _registeredPanels = new();
        private static readonly Modding.ILogger _logger = new Modding.SimpleLogger("InfoPanelUtil.UpdatingInfoPanel");

        public static UpdatingInfoPanel Create(string name, bool showBackground)
        {
            UpdatingInfoPanel panel = new(name, showBackground);
            AddInfoPanel(name, panel);
            _registeredPanels.Add(name, panel);
            return panel;
        }

        public static void AddLineToPanel(string panelName, string text)
        {
            if (!_registeredPanels.TryGetValue(panelName, out UpdatingInfoPanel panel))
            {
                _logger.LogWarn($"No panel with name {panelName} registered");
            }

            panel.AddLine(text);
        }


        private string _text = "";
        private readonly Queue<string> _lines = new();

        public void AddLine(string line)
        {
            _lines.Enqueue(line);
            while (_lines.Count > 36)
            {
                _lines.Dequeue();
            }

            _text = string.Join("\n", _lines.Reverse());
        }
        public string GetText() => _text;

        private UpdatingInfoPanel(string Name, bool showBackground = true) : base(Name, showBackground)
        {
            this.AddInfo(10f, 10f, 20f, "", GetText);
        }
    }
}