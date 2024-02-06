using System;
using GTAG_NotificationLib;
using HarmonyLib;
using Photon.Realtime;

namespace ShibaGTTemplate.Backend
{
	// Token: 0x0200000F RID: 15
	[HarmonyPatch(typeof(GorillaNot))]
	[HarmonyPatch("OnPlayerEnteredRoom", 0)]
	internal class OnJoin : HarmonyPatch
	{
		// Token: 0x0600003A RID: 58 RVA: 0x000090A5 File Offset: 0x000072A5
		private static void Prefix(Player newPlayer)
		{
			NotifiLib.SendNotification("<color=blue>[ROOM]:</color> Player " + newPlayer.NickName + " Joined Lobby");
		}
	}
}
