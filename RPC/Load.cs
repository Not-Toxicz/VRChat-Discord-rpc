using MelonLoader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPC
{
    public class Load : MelonLoader.MelonMod
    {
        public override void OnSceneWasInitialized(int buildIndex, string sceneName)
        {
            RPC.Discord.Update();
            RPC.Discord.Enabled = true;
        }
        public override void OnSceneWasLoaded(int buildIndex, string sceneName)
        {
            RPC.Discord.Update();
            RPC.Discord.Enabled = true;
        }
        public override void OnFixedUpdate()
        {
            RPC.Discord.Update();
        }
        public override void OnApplicationStart()
        {
            RPC.Discord.Init();
        }
    }
}
