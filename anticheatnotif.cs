using System;
using GTAG_NotificationLib;
using HarmonyLib;
using Photon.Pun;
using UnityEngine;

namespace ShibaGTTemplate.Backend
{
	// Token: 0x0200000D RID: 13
	[HarmonyPatch(typeof(GorillaNot), "SendReport")]
	internal class anticheatnotif : MonoBehaviour
	{
		// Token: 0x06000036 RID: 54 RVA: 0x00009028 File Offset: 0x00007228
		private static bool Prefix(string susReason, string susId, string susNick)
		{
			bool flag = susId == PhotonNetwork.LocalPlayer.UserId;
			if (flag)
			{
				NotifiLib.SendNotification("<color=red>[ANTICHEAT] REPORTED FOR: " + susReason + "</color>");
			}
			return false;
		}
	}
}
