using System;
using HarmonyLib;
using UnityEngine;

namespace ShibaGTTemplate.Backend
{
	// Token: 0x0200000E RID: 14
	[HarmonyPatch(typeof(VRRig), "OnDisable")]
	internal class GhostPatch : MonoBehaviour
	{
		// Token: 0x06000038 RID: 56 RVA: 0x00009070 File Offset: 0x00007270
		public static bool Prefix(VRRig __instance)
		{
			bool flag = __instance == GorillaTagger.Instance.offlineVRRig;
			return !flag;
		}
	}
}
