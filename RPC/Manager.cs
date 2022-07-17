using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace RPC
{
    internal class Manager
    {
        internal struct EventHandlers
        {
            internal RPC.Manager.ReadyCallback readyCallback;
            internal RPC.Manager.DisconnectedCallback disconnectedCallback;
            internal RPC.Manager.ErrorCallback errorCallback;
            internal RPC.Manager.JoinCallback joinCallback;
            internal RPC.Manager.SpectateCallback spectateCallback;
            internal RPC.Manager.RequestCallback requestCallback;
        }

        [Serializable]
        internal struct RichPresence
        {
            internal string state;
            internal string details;
            internal long startTimestamp;
            internal long endTimestamp;
            internal string largeImageKey;
            internal string largeImageText;
            internal string smallImageKey;
            internal string smallImageText;
            internal string partyId;
            internal int partySize;
            internal int partyMax;
            internal string matchSecret;
            internal string joinSecret;
            internal string spectateSecret;
            internal bool instance;
            internal string buttons;

        }

        [Serializable]
        internal struct JoinRequest
        {
#pragma warning disable CS0649
            public string userId;
#pragma warning restore CS0649
#pragma warning disable CS0649
            public string username;
#pragma warning restore CS0649
#pragma warning disable CS0649
            public string discriminator;
#pragma warning restore CS0649
#pragma warning disable CS0649
            public string avatar;
#pragma warning restore CS0649
        }

        public enum Reply
        {
            No,
            Yes,
            Ignore
        }

        [DllImport("discord-rpc.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Initialize")]
        internal protected static extern void Initialize(string applicationId, ref RPC.Manager.EventHandlers handlers, bool autoRegister, string optionalSteamId);

        [DllImport("discord-rpc.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Shutdown")]
        internal protected static extern void Shutdown();

        [DllImport("discord-rpc.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_RunCallbacks")]
        internal protected static extern void RunCallbacks();

        [DllImport("discord-rpc.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_UpdatePresence")]
        internal protected static extern void UpdatePresence(ref RPC.Manager.RichPresence presence);

        [DllImport("discord-rpc.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_ClearPresence")]
        internal protected static extern void ClearPresence();

        [DllImport("discord-rpc.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Respond")]
        internal protected static extern void Respond(string userId, RPC.Manager.Reply reply);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal protected delegate void ReadyCallback();

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal protected delegate void DisconnectedCallback(int errorCode, string message);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal protected delegate void ErrorCallback(int errorCode, string message);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal protected delegate void JoinCallback(string secret);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal protected delegate void SpectateCallback(string secret);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal protected delegate void RequestCallback(ref RPC.Manager.JoinRequest request);
    }
}
