using System;
using GTAG_NotificationLib;
using HarmonyLib;
using Photon.Pun;
using Photon.Realtime;

namespace ShibaGTTemplate.Backend
{
	// Token: 0x02000010 RID: 16
	[HarmonyPatch(typeof(GorillaNot))]
	[HarmonyPatch("OnPlayerLeftRoom", 0)]
	internal class OnLeave : HarmonyPatch
	{
		// Token: 0x0600003C RID: 60 RVA: 0x000090CC File Offset: 0x000072CC
		private static void Prefix(Player otherPlayer)
		{
			bool flag = otherPlayer != PhotonNetwork.LocalPlayer;
			if (flag)
			{
				NotifiLib.SendNotification("<color=blue>[ROOM]:</color> Player " + otherPlayer.NickName + " Left Lobby");
				bool isMasterClient = PhotonNetwork.IsMasterClient;
				if (isMasterClient)
				{
					NotifiLib.SendNotification("<color=yellow>[ROOM]: YOU ARE NOW MASTER CLIENT!</color>");
				}
			}
		}
	}
}
