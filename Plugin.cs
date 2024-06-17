using BepInEx;
using System;
using System.IO;
using System.Reflection;
using UnityEngine;
using Utilla;

namespace bed
{
    [ModdedGamemode]
    [BepInDependency("org.legoandmars.gorillatag.utilla", "1.5.0")]
    [BepInPlugin(PluginInfo.GUID, PluginInfo.Name, PluginInfo.Version)]
    public class Plugin : BaseUnityPlugin
    {
        bool inRoom;
        public GameObject blanket;

        void Start()
        {
            Utilla.Events.GameInitialized += OnGameInitialized;
        }

        void OnGameInitialized(object sender, EventArgs e)
        {
            AssetBundle assetBundle = LoadAssetBundle("bed.Resources.bed");
            blanket = UnityEngine.Object.Instantiate(assetBundle.LoadAsset<GameObject>("blanket"));
            this.blanket.transform.position = new Vector3(-68.7728f, 11.512f, - 83.6137f);
            this.blanket.transform.eulerAngles += new Vector3(279.9834f, 242.955f, 177.8158f);
            //-68.7728 11.512 -83.6137
            //279.9834 242.955 177.8158
        }
        public AssetBundle LoadAssetBundle(string path)
        {
            Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(path);
            AssetBundle bundle = AssetBundle.LoadFromStream(stream);
            stream.Close();
            return bundle;
        }
    }
}
