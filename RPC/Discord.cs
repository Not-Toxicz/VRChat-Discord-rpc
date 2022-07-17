using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using VRC;
using VRC.Core;

namespace RPC
{
    internal class Discord
    {
        internal static RPC.Manager.RichPresence presence;
        internal static RPC.Manager.EventHandlers eventHandlers;



		public static void Init()
		{
			Discord.eventHandlers = default(RPC.Manager.EventHandlers);
			Discord.eventHandlers.errorCallback = delegate (int code, string message)
			{
			};
			Discord.presence.state = "World: Loading...";
			Discord.presence.details = "Name: Starting up..";
			Discord.presence.largeImageKey = "animegirlgif";
			Discord.presence.partySize = 0;
			Discord.presence.partyMax = 0;
			Discord.presence.startTimestamp = (long)DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
			Discord.presence.partyId = "";
			Discord.presence.largeImageText = "Open Source RPC by Tox";
			try
			{
				RPC.Manager.Initialize("997626159665795175", ref Discord.eventHandlers, true, null);
				RPC.Manager.UpdatePresence(ref Discord.presence);
				Discord.Enabled = true;
			}
			catch
			{
			}
		}

		public static void Update()
		{
			try
			{
				bool isEndabled = Discord.Enabled;
				if (isEndabled)
				{
					bool isUserNull = APIUser.CurrentUser != null;
					if (isUserNull)
					{
						bool IsUserNotNull = !VRCPlayer.field_Internal_Static_VRCPlayer_0;
						if (IsUserNotNull)
						{
							Discord.presence.details = "Username: " + APIUser.CurrentUser.displayName;
							Discord.presence.state = "World: Loading...";
							RPC.Manager.UpdatePresence(ref Discord.presence);
						}
						else
						{
                            string type = "";
                            switch (RoomManager.field_Internal_Static_ApiWorldInstance_0.type.ToString())
                            {
                                case "Public":
                                    type = "Public";
                                    break;
                                case "FriendsOfGuests":
                                    type = "Friends+";
                                    break;
                                case "FriendsOnly":
                                    type = "Friends";
                                    break;
                                case "InviteOnly":
                                    type = "Invite";
                                    break;
                                case "InvitePlust":
                                    type = "Invite+";
                                    break;
                            }
                            Discord.presence.details = "Username: " + APIUser.CurrentUser.displayName + $" <3";
							Discord.presence.state = $"World: {RoomManager.field_Internal_Static_ApiWorld_0.name} [{PlayerManager.prop_PlayerManager_0.field_Private_List_1_Player_0.Count} / {RoomManager.field_Internal_Static_ApiWorld_0.capacity}] [{type}]";
							RPC.Manager.UpdatePresence(ref Discord.presence);
							Discord.Enabled = false;
						}
					}
					else
					{
						Discord.presence.details = "Username: Null";
						Discord.presence.state = $"World: {RoomManager.field_Internal_Static_ApiWorld_0.name} [{PlayerManager.prop_PlayerManager_0.field_Private_List_1_Player_0.Count} / {RoomManager.field_Internal_Static_ApiWorld_0.capacity}]";
						RPC.Manager.UpdatePresence(ref Discord.presence);
					}
				}
			}
			catch
			{
			}
		}

		public static void OnApplicationQuit()
		{
			RPC.Manager.Shutdown();
		}

		public static bool Enabled = false;
	}
}
