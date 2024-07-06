

using ModLoader;
using ModLoader.Helpers;
using UnityEngine;
using HarmonyLib;
using MultiplayerMod.Socket;
using System.Collections.Generic;

namespace MultiplayerMod
{
    public class MultiplayerMod : Mod
    {
        public static MultiplayerMod Main;

        // this ModNameID can be whatever you want
        public override string ModNameID => "multiplayerMod";

        public override string DisplayName => "Miltiplayer Mod";

        public override string Author => "105Code";

        public override string MinimumGameVersionNecessary => "0.3.7";

        // I recommend use MAJOR.MINOR.PATCH Semantic versioning. 
        // Reference link: https://semver.org/ 
        public override string ModVersion => "1.0.0";

        public override string Description => "Multiplayer mod client";

        private GameObject _manager;

        // With this variable you can define if your mods needs the others mods to work
        public override Dictionary<string, string> Dependencies
        {
            get
            {
                return new Dictionary<string, string>() { };
            }
        }

        public override void Early_Load()
        {
            // This is for a singleton pattern. you can see more about singleton here https://www.c-sharpcorner.com/UploadFile/8911c4/singleton-design-pattern-in-C-Sharp/
            Main = this;

            // Make use to use Debug.log from UnityEngine
            Debug.Log("Running Early load code");

            this._manager = GameObject.Instantiate(new GameObject("MultiplayerMod"));
            this._manager.AddComponent<ConnectionComponent>();


            // Use early load to use Harmony and patch function
            Harmony harmony = new Harmony(ModNameID);
            // I use ModNameID in Harmony, because you need to pass string ID to create an instance of Harmony.

            // This function finds all the patches you have created and runs them
            harmony.PatchAll();

            // you can subscribe to scene changes
            SceneHelper.OnWorldSceneLoaded += this.OnWorld;
            SceneHelper.OnBuildSceneLoaded += this.OnBuild;

        }

        public override void Load()
        {
            Debug.Log("Running Load code");

            // init your keybindings
            Settings.Setup();

        }

        // When the world scene is loaded
        private void OnWorld()
        {
            Debug.Log("On World");
        }

        // When the Build scene is loaded
        private void OnBuild()
        {
            Debug.Log("On Build");
        }

    }
}