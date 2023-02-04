using System;
using System.Collections.Generic;
using System.Linq;
using Modding;
using MonoMod.ModInterop;
using UnityEngine;

namespace InfoPanelUtil
{
    public class InfoPanelUtil : Mod
    {
        internal static InfoPanelUtil instance;
        
        public InfoPanelUtil() : base(null)
        {
            instance = this;
            typeof(Export).ModInterop();
        }
        
        public override string GetVersion()
        {
            return GetType().Assembly.GetName().Version.ToString();
        }
        
        public override void Initialize()
        {
            Log("Initializing Mod...");
            
            
        }
    }
}