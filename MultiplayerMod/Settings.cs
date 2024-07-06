
using ModLoader;
using UnityEngine;
using System.Collections.Generic;

namespace MultiplayerMod
{
    public class Settings : ModKeybindings
    {
        public static Settings Main;

        public static void Setup()
        {
            // Again for the singleton pattern. To use keybindings values anywhere in your mod.
            Main = SetupKeybindings<Settings>(MultiplayerMod.Main);
        }

        public override void CreateUI()
        {
            // this sections load default keybindings
            Settings keySettings = new Settings();

            // this creates UI elements in the Settings menu
            base.CreateUI_Text("Multiplayer Mod");
        }

        // define your key bindings like this
    }

}