using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using dark.efijiPOIWikjek;
using ExitGames.Client.Photon;
using GorillaExtensions;
using GorillaLocomotion;
using GorillaLocomotion.Gameplay;
using GorillaNetworking;
using GorillaTag;
using GTAG_NotificationLib;
using HarmonyLib;
using Photon.Pun;
using Photon.Realtime;
using ShibaGTTemplate.UI;
using ShibaGTTemplate.Utilities;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace ShibaGTTemplate.Backend
{
	// Token: 0x02000011 RID: 17
	internal class Mods : MonoBehaviour
	{
		// Token: 0x0600003E RID: 62 RVA: 0x00009128 File Offset: 0x00007328
		public static void Settings()
		{
			WristMenu.settingsbuttons[0].enabled = new bool?(false);
			WristMenu.buttons[0].enabled = new bool?(false);
			Mods.inSettings = !Mods.inSettings;
			WristMenu.DestroyMenu();
			WristMenu.instance.Draw();
		}

		// Token: 0x0600003F RID: 63 RVA: 0x00009180 File Offset: 0x00007380
		public static void MoveMnets()
		{
			WristMenu.settingsbuttons[0].enabled = new bool?(false);
			WristMenu.buttons[0].enabled = new bool?(false);
			Mods.inSettings = !Mods.inSettings;
			WristMenu.DestroyMenu();
			WristMenu.instance.Draw();
		}

		// Token: 0x06000040 RID: 64 RVA: 0x000091D8 File Offset: 0x000073D8
		public static void Disconnect()
		{
			bool rightControllerSecondaryButton = ControllerInputPoller.instance.rightControllerSecondaryButton;
			if (rightControllerSecondaryButton)
			{
				PhotonNetwork.Disconnect();
			}
		}

		// Token: 0x06000041 RID: 65 RVA: 0x000091FE File Offset: 0x000073FE
		public static void Joinrandom()
		{
			PhotonNetwork.JoinRandomRoom();
		}

		// Token: 0x06000042 RID: 66 RVA: 0x00009207 File Offset: 0x00007407
		public static void QuitApp()
		{
			Application.Quit();
		}

		// Token: 0x06000043 RID: 67 RVA: 0x00009210 File Offset: 0x00007410
		private static void PlatformsThing(bool invis, bool sticky)
		{
			Mods.colorKeysPlatformMonke[0].color = Color.red;
			Mods.colorKeysPlatformMonke[0].time = 0f;
			Mods.colorKeysPlatformMonke[1].color = Color.green;
			Mods.colorKeysPlatformMonke[1].time = 0.3f;
			Mods.colorKeysPlatformMonke[2].color = Color.blue;
			Mods.colorKeysPlatformMonke[2].time = 0.6f;
			Mods.colorKeysPlatformMonke[3].color = Color.red;
			Mods.colorKeysPlatformMonke[3].time = 1f;
			bool gripDownR = WristMenu.gripDownR;
			bool gripDownL = WristMenu.gripDownL;
			bool flag = gripDownR;
			if (flag)
			{
				bool flag2 = !Mods.once_right && Mods.jump_right_local == null;
				if (flag2)
				{
					if (sticky)
					{
						Mods.jump_right_local = GameObject.CreatePrimitive(0);
					}
					else
					{
						Mods.jump_right_local = GameObject.CreatePrimitive(3);
					}
					Mods.jump_right_local.GetComponent<Renderer>().material.SetColor("_Color", Color.black);
					if (invis)
					{
						Object.Destroy(Mods.jump_right_local.GetComponent<Renderer>());
					}
					Mods.jump_right_local.transform.localScale = Mods.scale;
					Mods.jump_right_local.transform.position = new Vector3(0f, -0.01f, 0f) + Player.Instance.rightControllerTransform.position;
					Mods.jump_right_local.transform.rotation = Player.Instance.rightControllerTransform.rotation;
					object[] array = new object[]
					{
						new Vector3(0f, -0.01f, 0f) + Player.Instance.rightControllerTransform.position,
						Player.Instance.rightControllerTransform.rotation
					};
					RaiseEventOptions raiseEventOptions = new RaiseEventOptions
					{
						Receivers = 0
					};
					PhotonNetwork.RaiseEvent(70, array, raiseEventOptions, SendOptions.SendReliable);
					Mods.once_right = true;
					Mods.once_right_false = false;
					ColorChanger colorChanger = Mods.jump_right_local.AddComponent<ColorChanger>();
					colorChanger.colors = new Gradient
					{
						colorKeys = Mods.colorKeysPlatformMonke
					};
					colorChanger.Start();
				}
			}
			else
			{
				bool flag3 = !Mods.once_right_false && Mods.jump_right_local != null;
				if (flag3)
				{
					Object.Destroy(Mods.jump_right_local);
					Mods.jump_right_local = null;
					Mods.once_right = false;
					Mods.once_right_false = true;
					RaiseEventOptions raiseEventOptions2 = new RaiseEventOptions
					{
						Receivers = 0
					};
					PhotonNetwork.RaiseEvent(72, null, raiseEventOptions2, SendOptions.SendReliable);
				}
			}
			bool flag4 = gripDownL;
			if (flag4)
			{
				bool flag5 = !Mods.once_left && Mods.jump_left_local == null;
				if (flag5)
				{
					if (sticky)
					{
						Mods.jump_left_local = GameObject.CreatePrimitive(0);
					}
					else
					{
						Mods.jump_left_local = GameObject.CreatePrimitive(3);
					}
					Mods.jump_left_local.GetComponent<Renderer>().material.SetColor("_Color", Color.black);
					if (invis)
					{
						Object.Destroy(Mods.jump_left_local.GetComponent<Renderer>());
					}
					Mods.jump_left_local.transform.localScale = Mods.scale;
					Mods.jump_left_local.transform.position = new Vector3(0f, -0.01f, 0f) + Player.Instance.leftControllerTransform.position;
					Mods.jump_left_local.transform.rotation = Player.Instance.leftControllerTransform.rotation;
					object[] array2 = new object[]
					{
						new Vector3(0f, -0.01f, 0f) + Player.Instance.leftControllerTransform.position,
						Player.Instance.leftControllerTransform.rotation
					};
					RaiseEventOptions raiseEventOptions3 = new RaiseEventOptions
					{
						Receivers = 0
					};
					PhotonNetwork.RaiseEvent(69, array2, raiseEventOptions3, SendOptions.SendReliable);
					Mods.once_left = true;
					Mods.once_left_false = false;
					ColorChanger colorChanger2 = Mods.jump_left_local.AddComponent<ColorChanger>();
					colorChanger2.colors = new Gradient
					{
						colorKeys = Mods.colorKeysPlatformMonke
					};
					colorChanger2.Start();
				}
			}
			else
			{
				bool flag6 = !Mods.once_left_false && Mods.jump_left_local != null;
				if (flag6)
				{
					Object.Destroy(Mods.jump_left_local);
					Mods.jump_left_local = null;
					Mods.once_left = false;
					Mods.once_left_false = true;
					RaiseEventOptions raiseEventOptions4 = new RaiseEventOptions
					{
						Receivers = 0
					};
					PhotonNetwork.RaiseEvent(71, null, raiseEventOptions4, SendOptions.SendReliable);
				}
			}
			bool flag7 = !PhotonNetwork.InRoom;
			if (flag7)
			{
				for (int i = 0; i < Mods.jump_right_network.Length; i++)
				{
					Object.Destroy(Mods.jump_right_network[i]);
				}
				for (int j = 0; j < Mods.jump_left_network.Length; j++)
				{
					Object.Destroy(Mods.jump_left_network[j]);
				}
			}
		}

		// Token: 0x06000044 RID: 68 RVA: 0x00009728 File Offset: 0x00007928
		private static void PlatformsThing2(bool invis, bool sticky)
		{
			Mods.colorKeysPlatformMonke[0].color = Color.red;
			Mods.colorKeysPlatformMonke[0].time = 0f;
			Mods.colorKeysPlatformMonke[1].color = Color.green;
			Mods.colorKeysPlatformMonke[1].time = 0.3f;
			Mods.colorKeysPlatformMonke[2].color = Color.blue;
			Mods.colorKeysPlatformMonke[2].time = 0.6f;
			Mods.colorKeysPlatformMonke[3].color = Color.red;
			Mods.colorKeysPlatformMonke[3].time = 1f;
			bool gripDownR = WristMenu.gripDownR;
			bool gripDownL = WristMenu.gripDownL;
			bool flag = gripDownR;
			if (flag)
			{
				bool flag2 = !Mods.once_right && Mods.jump_right_local == null;
				if (flag2)
				{
					if (sticky)
					{
						Mods.jump_right_local = GameObject.CreatePrimitive(0);
					}
					else
					{
						Mods.jump_right_local = GameObject.CreatePrimitive(3);
					}
					Mods.jump_right_local.GetComponent<Renderer>().material.SetColor("_Color", Color.black);
					if (invis)
					{
						Object.Destroy(Mods.jump_right_local.GetComponent<Renderer>());
					}
					Mods.jump_right_local.transform.localScale = Mods.scale;
					Mods.jump_right_local.transform.position = new Vector3(0f, -0.01f, 0f) + Player.Instance.rightControllerTransform.position;
					Mods.jump_right_local.transform.rotation = Player.Instance.rightControllerTransform.rotation;
					object[] array = new object[]
					{
						new Vector3(0f, -0.01f, 0f) + Player.Instance.rightControllerTransform.position,
						Player.Instance.rightControllerTransform.rotation
					};
					RaiseEventOptions raiseEventOptions = new RaiseEventOptions
					{
						Receivers = 0
					};
					PhotonNetwork.RaiseEvent(70, array, raiseEventOptions, SendOptions.SendReliable);
					Mods.once_right = true;
					Mods.once_right_false = false;
					ColorChanger colorChanger = Mods.jump_right_local.AddComponent<ColorChanger>();
					colorChanger.colors = new Gradient
					{
						colorKeys = Mods.colorKeysPlatformMonke
					};
					colorChanger.Start();
				}
			}
			else
			{
				bool flag3 = !Mods.once_right_false && Mods.jump_right_local != null;
				if (flag3)
				{
					Object.Destroy(Mods.jump_right_local);
					Mods.jump_right_local = null;
					Mods.once_right = false;
					Mods.once_right_false = true;
					RaiseEventOptions raiseEventOptions2 = new RaiseEventOptions
					{
						Receivers = 0
					};
					PhotonNetwork.RaiseEvent(72, null, raiseEventOptions2, SendOptions.SendReliable);
				}
			}
			bool flag4 = gripDownL;
			if (flag4)
			{
				bool flag5 = !Mods.once_left && Mods.jump_left_local == null;
				if (flag5)
				{
					if (sticky)
					{
						Mods.jump_left_local = GameObject.CreatePrimitive(0);
					}
					else
					{
						Mods.jump_left_local = GameObject.CreatePrimitive(3);
					}
					Mods.jump_left_local.GetComponent<Renderer>().material.SetColor("_Color", Color.black);
					if (invis)
					{
						Object.Destroy(Mods.jump_left_local.GetComponent<Renderer>());
					}
					Mods.jump_left_local.transform.localScale = Mods.scale;
					Mods.jump_left_local.transform.position = new Vector3(0f, -0.01f, 0f) + Player.Instance.leftControllerTransform.position;
					Mods.jump_left_local.transform.rotation = Player.Instance.leftControllerTransform.rotation;
					object[] array2 = new object[]
					{
						new Vector3(0f, -0.01f, 0f) + Player.Instance.leftControllerTransform.position,
						Player.Instance.leftControllerTransform.rotation
					};
					RaiseEventOptions raiseEventOptions3 = new RaiseEventOptions
					{
						Receivers = 0
					};
					PhotonNetwork.RaiseEvent(69, array2, raiseEventOptions3, SendOptions.SendReliable);
					Mods.once_left = true;
					Mods.once_left_false = false;
					ColorChanger colorChanger2 = Mods.jump_left_local.AddComponent<ColorChanger>();
					colorChanger2.colors = new Gradient
					{
						colorKeys = Mods.colorKeysPlatformMonke
					};
					colorChanger2.Start();
				}
			}
			else
			{
				bool flag6 = !Mods.once_left_false && Mods.jump_left_local != null;
				if (flag6)
				{
					Object.Destroy(Mods.jump_left_local);
					Mods.jump_left_local = null;
					Mods.once_left = false;
					Mods.once_left_false = true;
					RaiseEventOptions raiseEventOptions4 = new RaiseEventOptions
					{
						Receivers = 0
					};
					PhotonNetwork.RaiseEvent(71, null, raiseEventOptions4, SendOptions.SendReliable);
				}
			}
			bool flag7 = !PhotonNetwork.InRoom;
			if (flag7)
			{
				for (int i = 0; i < Mods.jump_right_network.Length; i++)
				{
					Object.Destroy(Mods.jump_right_network[i]);
				}
				for (int j = 0; j < Mods.jump_left_network.Length; j++)
				{
					Object.Destroy(Mods.jump_left_network[j]);
				}
			}
		}

		// Token: 0x06000045 RID: 69 RVA: 0x00009C3E File Offset: 0x00007E3E
		public static void Platforms()
		{
			Mods.PlatformsThing(Mods.invisplat, Mods.stickyplatforms);
		}

		// Token: 0x06000046 RID: 70 RVA: 0x00009C51 File Offset: 0x00007E51
		public static void CirclePlatforms()
		{
			Mods.PlatformsThing2(Mods.invisplat, Mods.stickyplatforms);
		}

		// Token: 0x06000047 RID: 71 RVA: 0x00009C64 File Offset: 0x00007E64
		public static void HoldRocket()
		{
			bool rightGrab = ControllerInputPoller.instance.rightGrab;
			if (rightGrab)
			{
				GameObject.Find("RocketShip_Prefab").transform.localScale = new Vector3(0.05f, 0.05f, 0.05f);
				GameObject.Find("RocketShip_Prefab").transform.position = new Vector3(0f, -0.0075f, 0f);
				GameObject.Find("RocketShip_Prefab").transform.position = Player.Instance.rightControllerTransform.position;
			}
		}

		// Token: 0x06000048 RID: 72 RVA: 0x00009CFA File Offset: 0x00007EFA
		public static void BlackBug()
		{
			GameObject.Find("Floating Bug Holdable").GetComponent<Renderer>().material.color = Color.blue;
		}

		// Token: 0x06000049 RID: 73 RVA: 0x00009D1C File Offset: 0x00007F1C
		public static void BalloonToHand()
		{
			bool leftGrab = ControllerInputPoller.instance.leftGrab;
			if (leftGrab)
			{
				BalloonHoldable balloonHoldable = new BalloonHoldable();
				balloonHoldable.transform.position = Player.Instance.leftControllerTransform.position;
			}
		}

		// Token: 0x0600004A RID: 74 RVA: 0x00009D5D File Offset: 0x00007F5D
		public static void HeadSpiny()
		{
			VRMap head = RigShit.GetOwnVRRig().head;
			head.trackingRotationOffset.y = head.trackingRotationOffset.y + 15f;
		}

		// Token: 0x0600004B RID: 75 RVA: 0x00009D7D File Offset: 0x00007F7D
		public static void Badquilty()
		{
			QualitySettings.masterTextureLimit = 500000000;
		}

		// Token: 0x0600004C RID: 76 RVA: 0x00009D8C File Offset: 0x00007F8C
		public static void customstump()
		{
			GameObject gameObject = GameObject.Find("Environment Objects/LocalObjects_Prefab/Cave_Main_Prefab/Cave_Crystals_Prefab_V3/UpperCave/C_DarkCrystal_Big");
			GameObject.Find("Environment Objects/LocalObjects_Prefab/Cave_Main_Prefab/Cave_Crystals_Prefab_V3/UpperCave/C_DarkCrystal_Big").transform.localScale = new Vector3(0.45f, 0.45f, 0.45f);
			bool flag = gameObject != null;
			if (flag)
			{
				gameObject.SetActive(true);
				GameObject gameObject2 = GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/tree/TreeWood");
				Vector3 position = gameObject2.transform.position;
				Vector3 localScale = gameObject.transform.localScale;
				gameObject.transform.SetParent(gameObject2.transform);
				position.y += 15f;
				position.x += -1.5f;
				position.z += 0.6f;
				localScale..ctor(0.45f, 0.45f, 0.45f);
				gameObject.transform.position = position;
			}
		}

		// Token: 0x0600004D RID: 77 RVA: 0x00009E70 File Offset: 0x00008070
		public static void PhysicalTagAura()
		{
			foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
			{
				Vector3 position = vrrig.transform.position;
				Vector3 position2 = GorillaTagger.Instance.offlineVRRig.head.rigTarget.position;
				float num = Vector3.Distance(position, position2);
				bool flag = GorillaTagger.Instance.offlineVRRig.mainSkin.material.name.Contains("fected") && !vrrig.mainSkin.material.name.Contains("fected") && !Player.Instance.disableMovement && (double)num < 1.667;
				if (flag)
				{
					bool flag2 = Mods.rightHand;
					if (flag2)
					{
						Player.Instance.rightControllerTransform.position = position;
					}
					else
					{
						Player.Instance.leftControllerTransform.position = position;
					}
				}
			}
		}

		// Token: 0x0600004E RID: 78 RVA: 0x00009F98 File Offset: 0x00008198
		public static void SizeChangerByVortex()
		{
			bool rightControllerPrimaryButton = ControllerInputPoller.instance.rightControllerPrimaryButton;
			bool flag = rightControllerPrimaryButton;
			if (flag)
			{
				Player.Instance.scale = 1f;
			}
			bool rightGrab = ControllerInputPoller.instance.rightGrab;
			if (rightGrab)
			{
				Player.Instance.scale += 0.1f;
			}
			bool leftGrab = ControllerInputPoller.instance.leftGrab;
			if (leftGrab)
			{
				Player.Instance.scale -= 0.1f;
			}
		}

		// Token: 0x0600004F RID: 79 RVA: 0x0000A01C File Offset: 0x0000821C
		public static void HeadSizeChangerByVortex()
		{
			bool rightControllerPrimaryButton = ControllerInputPoller.instance.rightControllerPrimaryButton;
			bool flag = rightControllerPrimaryButton;
			if (flag)
			{
				Player.Instance.scale = 1f;
			}
			bool rightGrab = ControllerInputPoller.instance.rightGrab;
			if (rightGrab)
			{
				Player.Instance.scale += 0.1f;
			}
			bool leftGrab = ControllerInputPoller.instance.leftGrab;
			if (leftGrab)
			{
				Player.Instance.scale -= 0.1f;
			}
		}

		// Token: 0x06000050 RID: 80 RVA: 0x0000A09D File Offset: 0x0000829D
		public static void Fixquilty()
		{
			QualitySettings.masterTextureLimit = 0;
		}

		// Token: 0x06000051 RID: 81 RVA: 0x0000A0A7 File Offset: 0x000082A7
		public static void HeadSpinx()
		{
			VRMap head = RigShit.GetOwnVRRig().head;
			head.trackingRotationOffset.x = head.trackingRotationOffset.x + 15f;
		}

		// Token: 0x06000052 RID: 82 RVA: 0x0000A0C7 File Offset: 0x000082C7
		public static void HeadSpinz()
		{
			VRMap head = RigShit.GetOwnVRRig().head;
			head.trackingRotationOffset.z = head.trackingRotationOffset.z + 15f;
		}

		// Token: 0x06000053 RID: 83 RVA: 0x0000A0E7 File Offset: 0x000082E7
		public static void fixheady()
		{
			RigShit.GetOwnVRRig().head.trackingRotationOffset.y = 0f;
		}

		// Token: 0x06000054 RID: 84 RVA: 0x0000A104 File Offset: 0x00008304
		public static void FIXHEADULTAMENT()
		{
			RigShit.GetOwnVRRig().head.trackingRotationOffset.y = 0f;
			RigShit.GetOwnVRRig().head.trackingRotationOffset.x = 0f;
			RigShit.GetOwnVRRig().head.trackingRotationOffset.z = 0f;
		}

		// Token: 0x06000055 RID: 85 RVA: 0x0000A15D File Offset: 0x0000835D
		public static void fixheadx()
		{
			RigShit.GetOwnVRRig().head.trackingRotationOffset.x = 0f;
		}

		// Token: 0x06000056 RID: 86 RVA: 0x0000A179 File Offset: 0x00008379
		public static void fixheadz()
		{
			RigShit.GetOwnVRRig().head.trackingRotationOffset.z = 0f;
		}

		// Token: 0x06000057 RID: 87 RVA: 0x0000A198 File Offset: 0x00008398
		public static void UntagSelf()
		{
			foreach (GorillaTagManager gorillaTagManager in Object.FindObjectsOfType<GorillaTagManager>())
			{
				bool flag = gorillaTagManager.currentInfected.Contains(PhotonNetwork.LocalPlayer);
				if (flag)
				{
					gorillaTagManager.currentInfected.Remove(PhotonNetwork.LocalPlayer);
				}
			}
		}

		// Token: 0x06000058 RID: 88 RVA: 0x0000A1E8 File Offset: 0x000083E8
		public static void UntagAll()
		{
			foreach (GorillaTagManager gorillaTagManager in Object.FindObjectsOfType<GorillaTagManager>())
			{
				foreach (Player item in PhotonNetwork.PlayerList)
				{
					bool flag = gorillaTagManager.currentInfected.Contains(item);
					if (flag)
					{
						gorillaTagManager.currentInfected.Remove(item);
					}
				}
			}
		}

		// Token: 0x06000059 RID: 89 RVA: 0x0000A258 File Offset: 0x00008458
		public static void InvisV2()
		{
			bool flag = ControllerInputPoller.instance.rightControllerIndexFloat > 0f;
			if (flag)
			{
				GorillaTagger.Instance.offlineVRRig.headBodyOffset = new Vector3(999f, 999f, 999f);
				GameObject gameObject = GameObject.CreatePrimitive(0);
				Object.Destroy(gameObject.GetComponent<Rigidbody>());
				Object.Destroy(gameObject.GetComponent<SphereCollider>());
				gameObject.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
				gameObject.transform.position = GorillaTagger.Instance.rightHandTransform.position;
				gameObject.GetComponent<Renderer>().material.color = new Color32(209, 8, 8, 1);
				GameObject gameObject2 = GameObject.CreatePrimitive(0);
				Object.Destroy(gameObject2.GetComponent<Rigidbody>());
				Object.Destroy(gameObject2.GetComponent<SphereCollider>());
				gameObject2.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
				gameObject2.transform.position = GorillaTagger.Instance.leftHandTransform.position;
				gameObject2.GetComponent<Renderer>().material.color = new Color32(209, 8, 8, 1);
				Object.Destroy(gameObject, Time.deltaTime);
				Object.Destroy(gameObject2, Time.deltaTime);
			}
			else
			{
				GorillaTagger.Instance.offlineVRRig.headBodyOffset = Vector3.zero;
			}
		}

		// Token: 0x0600005A RID: 90 RVA: 0x0000A3D0 File Offset: 0x000085D0
		public static void Ghostmonke()
		{
			bool flag = ControllerInputPoller.instance.rightControllerIndexFloat > 0f;
			if (flag)
			{
				GorillaTagger.Instance.offlineVRRig.enabled = false;
				GameObject gameObject = GameObject.CreatePrimitive(0);
				Object.Destroy(gameObject.GetComponent<Rigidbody>());
				Object.Destroy(gameObject.GetComponent<SphereCollider>());
				gameObject.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
				gameObject.transform.position = GorillaTagger.Instance.rightHandTransform.position;
				gameObject.GetComponent<Renderer>().material.color = new Color32(209, 8, 8, 1);
				GameObject gameObject2 = GameObject.CreatePrimitive(0);
				Object.Destroy(gameObject2.GetComponent<Rigidbody>());
				Object.Destroy(gameObject2.GetComponent<SphereCollider>());
				gameObject2.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
				gameObject2.transform.position = GorillaTagger.Instance.leftHandTransform.position;
				gameObject2.GetComponent<Renderer>().material.color = new Color32(209, 8, 8, 1);
				Object.Destroy(gameObject, Time.deltaTime);
				Object.Destroy(gameObject2, Time.deltaTime);
			}
			else
			{
				GorillaTagger.Instance.offlineVRRig.enabled = true;
			}
		}

		// Token: 0x0600005B RID: 91 RVA: 0x0000A534 File Offset: 0x00008734
		public static void SinkSand()
		{
			bool rightControllerPrimaryButton = ControllerInputPoller.instance.rightControllerPrimaryButton;
			bool flag = rightControllerPrimaryButton;
			if (flag)
			{
				Player.Instance.transform.position += Player.Instance.headCollider.transform.forward * Time.deltaTime * 0f;
				Player.Instance.GetComponent<Rigidbody>().velocity = Vector3.zero;
				foreach (MeshCollider meshCollider in Resources.FindObjectsOfTypeAll<MeshCollider>())
				{
					meshCollider.enabled = false;
				}
			}
			else
			{
				foreach (MeshCollider meshCollider2 in Resources.FindObjectsOfTypeAll<MeshCollider>())
				{
					meshCollider2.enabled = true;
				}
			}
		}

		// Token: 0x0600005C RID: 92 RVA: 0x0000A608 File Offset: 0x00008808
		private static bool CalculateGrabState(float grabValue, float grabThreshold)
		{
			return grabValue >= grabThreshold;
		}

		// Token: 0x0600005D RID: 93 RVA: 0x0000A624 File Offset: 0x00008824
		public static void CasualBeacons()
		{
			foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
			{
				bool flag = vrrig != GorillaTagger.Instance.offlineVRRig;
				bool flag2 = flag;
				if (flag2)
				{
					GameObject gameObject = new GameObject("Line");
					LineRenderer lineRenderer = gameObject.AddComponent<LineRenderer>();
					Color playerColor = vrrig.playerColor;
					lineRenderer.startColor = playerColor;
					lineRenderer.endColor = playerColor;
					lineRenderer.startWidth = 0.025f;
					lineRenderer.endWidth = 0.025f;
					lineRenderer.positionCount = 2;
					lineRenderer.useWorldSpace = true;
					lineRenderer.SetPosition(0, vrrig.transform.position + new Vector3(0f, 9999f, 0f));
					lineRenderer.SetPosition(1, vrrig.transform.position - new Vector3(0f, 9999f, 0f));
					lineRenderer.material.shader = Shader.Find("GUI/Text Shader");
					Object.Destroy(gameObject, Time.deltaTime);
				}
			}
		}

		// Token: 0x0600005E RID: 94 RVA: 0x0000A784 File Offset: 0x00008984
		public static void NoTreeHouseFix()
		{
			bool leftGrab = ControllerInputPoller.instance.leftGrab;
			if (leftGrab)
			{
				GameObject.Find("Environment Objects/LocalObjects_Prefab/Forest/Environment/WeatherDayNight/snow/newTreehouse (1)").SetActive(false);
				GameObject.Find("Environment Objects/LocalObjects_Prefab/Forest/Environment/WeatherDayNight/snow/newTreehouse (1)").SetActive(false);
			}
			else
			{
				GameObject.Find("Environment Objects/LocalObjects_Prefab/Forest/Environment/WeatherDayNight/snow/newTreehouse (1)").SetActive(true);
				GameObject.Find("Environment Objects/LocalObjects_Prefab/Forest/Environment/WeatherDayNight/snow/newTreehouse (1)").SetActive(true);
			}
		}

		// Token: 0x0600005F RID: 95 RVA: 0x0000A7EC File Offset: 0x000089EC
		public static void NoTreeHouse()
		{
			bool leftGrab = ControllerInputPoller.instance.leftGrab;
			if (leftGrab)
			{
				GameObject.Find("Environment Objects/LocalObjects_Prefab/Forest/Terrain/newTreehouse/").SetActive(false);
				GameObject.Find("Environment Objects/LocalObjects_Prefab/Forest/Terrain/newTreehouse/").SetActive(false);
			}
			else
			{
				GameObject.Find("Environment Objects/LocalObjects_Prefab/Forest/Terrain/newTreehouse/").SetActive(true);
				GameObject.Find("Environment Objects/LocalObjects_Prefab/Forest/Terrain/newTreehouse/").SetActive(true);
			}
		}

		// Token: 0x06000060 RID: 96 RVA: 0x0000A854 File Offset: 0x00008A54
		public static void SpamFirstCosmeticSpot()
		{
			bool flag = Mods.ba < Time.time;
			if (flag)
			{
				Mods.ba = Time.time + 0.1f;
				GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/UI/Wardrobe/WardrobeItemButton").GetComponent<WardrobeItemButton>().ButtonActivationWithHand(false);
				Mods.flushmanually();
			}
		}

		// Token: 0x06000061 RID: 97 RVA: 0x0000A8A0 File Offset: 0x00008AA0
		public static void SpamSecondCosmeticSpot()
		{
			bool flag = Mods.ba2 < Time.time;
			if (flag)
			{
				Mods.ba2 = Time.time + 0.1f;
				GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/UI/Wardrobe/WardrobeItemButton (1)").GetComponent<WardrobeItemButton>().ButtonActivationWithHand(false);
				Mods.flushmanually();
			}
		}

		// Token: 0x06000062 RID: 98 RVA: 0x0000A8EC File Offset: 0x00008AEC
		public static void SpamThirdCosmeticSpot()
		{
			bool flag = Mods.ba3 < Time.time;
			if (flag)
			{
				Mods.ba3 = Time.time + 0.1f;
				GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/UI/Wardrobe/WardrobeItemButton (2)").GetComponent<WardrobeItemButton>().ButtonActivationWithHand(false);
				Mods.flushmanually();
			}
		}

		// Token: 0x06000063 RID: 99 RVA: 0x0000A938 File Offset: 0x00008B38
		public static void SpamAllCosmeticSpot()
		{
			GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/UI/Wardrobe/WardrobeItemButton").GetComponent<GorillaPressableButton>().ButtonActivationWithHand(false);
			GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/UI/Wardrobe/WardrobeItemButton (1)").GetComponent<GorillaPressableButton>().ButtonActivationWithHand(false);
			GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/UI/Wardrobe/WardrobeItemButton (2)").GetComponent<GorillaPressableButton>().ButtonActivationWithHand(false);
		}

		// Token: 0x06000064 RID: 100 RVA: 0x0000A988 File Offset: 0x00008B88
		public static void TpToStump()
		{
			Mods.input = GameObject.Find("Player Objects/Player VR Controller/GorillaPlayer").GetComponent<ControllerInputPoller>();
			bool activeSelf = GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom").activeSelf;
			if (activeSelf)
			{
				bool rightControllerPrimaryButton = ControllerInputPoller.instance.rightControllerPrimaryButton;
				if (rightControllerPrimaryButton)
				{
					foreach (MeshCollider meshCollider in Resources.FindObjectsOfTypeAll<MeshCollider>())
					{
						meshCollider.enabled = false;
					}
					Player.Instance.transform.position = new Vector3(-66.4848f, 11.8871f, -82.6619f);
				}
				else
				{
					foreach (MeshCollider meshCollider2 in Resources.FindObjectsOfTypeAll<MeshCollider>())
					{
						meshCollider2.enabled = true;
					}
				}
			}
		}

		// Token: 0x06000065 RID: 101 RVA: 0x0000AA50 File Offset: 0x00008C50
		public static void TpToCanonns()
		{
			Mods.input = GameObject.Find("Player Objects/Player VR Controller/GorillaPlayer").GetComponent<ControllerInputPoller>();
			bool activeSelf = GameObject.Find("Environment Objects/LocalObjects_Prefab/Canyon").activeSelf;
			if (activeSelf)
			{
				bool rightControllerPrimaryButton = ControllerInputPoller.instance.rightControllerPrimaryButton;
				if (rightControllerPrimaryButton)
				{
					foreach (MeshCollider meshCollider in Resources.FindObjectsOfTypeAll<MeshCollider>())
					{
						meshCollider.enabled = false;
					}
					Player.Instance.transform.position = new Vector3(-87.0265f, 10.2069f, -109.3344f);
				}
				else
				{
					foreach (MeshCollider meshCollider2 in Resources.FindObjectsOfTypeAll<MeshCollider>())
					{
						meshCollider2.enabled = true;
					}
				}
			}
		}

		// Token: 0x06000066 RID: 102 RVA: 0x0000AB16 File Offset: 0x00008D16
		public static void DisableQuitBox()
		{
			GameObject.Find("Environment Objects/TriggerZones_Prefab/ZoneTransitions_Prefab/QuitBox").SetActive(false);
		}

		// Token: 0x06000067 RID: 103 RVA: 0x0000AB2A File Offset: 0x00008D2A
		public static void FixDisableQuitBox()
		{
			GameObject.Find("Environment Objects/TriggerZones_Prefab/ZoneTransitions_Prefab/QuitBox").SetActive(false);
		}

		// Token: 0x06000068 RID: 104 RVA: 0x0000AB3E File Offset: 0x00008D3E
		public static void FixWalkwithanycosmetic()
		{
			GameObject.Find("Environment Objects/TriggerZones_Prefab/ZoneTransitions_Prefab/Cosmetics Room Triggers").SetActive(true);
		}

		// Token: 0x06000069 RID: 105 RVA: 0x0000AB52 File Offset: 0x00008D52
		public static void Walkwithanycosmetic()
		{
			GameObject.Find("Environment Objects/TriggerZones_Prefab/ZoneTransitions_Prefab/Cosmetics Room Triggers").SetActive(false);
		}

		// Token: 0x0600006A RID: 106 RVA: 0x0000AB66 File Offset: 0x00008D66
		public static void DisableNetworkTriggers()
		{
			GameObject.Find("Environment Objects/TriggerZones_Prefab/JoinRoomTriggers_Prefab").SetActive(false);
		}

		// Token: 0x0600006B RID: 107 RVA: 0x0000AB7A File Offset: 0x00008D7A
		public static void FixDisableNetworkTriggers()
		{
			GameObject.Find("Environment Objects/TriggerZones_Prefab/JoinRoomTriggers_Prefab").SetActive(true);
		}

		// Token: 0x0600006C RID: 108 RVA: 0x0000AB90 File Offset: 0x00008D90
		public static void upandsown()
		{
			bool flag = (double)ControllerInputPoller.instance.rightControllerIndexFloat > 0.9;
			if (flag)
			{
				Player.Instance.transform.position += Player.Instance.bodyCollider.transform.up * Time.deltaTime * 15f;
				Player.Instance.GetComponent<Rigidbody>().velocity = Vector3.zero;
			}
			bool flag2 = (double)ControllerInputPoller.instance.leftControllerIndexFloat > 0.9;
			if (flag2)
			{
				Player.Instance.transform.position -= Player.Instance.bodyCollider.transform.up * Time.deltaTime * 15f;
				Player.Instance.GetComponent<Rigidbody>().velocity = Vector3.zero;
			}
		}

		// Token: 0x0600006D RID: 109 RVA: 0x0000AC8C File Offset: 0x00008E8C
		public static void CarMonke()
		{
			bool flag = ControllerInputPoller.instance.rightControllerIndexFloat >= 0.3f;
			if (flag)
			{
				Player.Instance.transform.position += Player.Instance.headCollider.transform.forward * Time.deltaTime * 15f;
				bool rightGrab = ControllerInputPoller.instance.rightGrab;
				if (rightGrab)
				{
					Player.Instance.transform.position -= Player.Instance.headCollider.transform.forward * Time.deltaTime * 20f;
				}
			}
		}

		// Token: 0x0600006E RID: 110 RVA: 0x0000AD51 File Offset: 0x00008F51
		public static void Makedrawbig()
		{
			Mods.drawsize += 0.1f;
		}

		// Token: 0x0600006F RID: 111 RVA: 0x0000AD64 File Offset: 0x00008F64
		public static void TPGun()
		{
			bool rightGrab = ControllerInputPoller.instance.rightGrab;
			if (rightGrab)
			{
				RaycastHit raycastHit;
				bool flag = Physics.Raycast(Player.Instance.rightControllerTransform.position - Player.Instance.rightControllerTransform.up, -Player.Instance.rightControllerTransform.up, ref raycastHit) && Mods.pointer == null;
				if (flag)
				{
					Mods.pointer = GameObject.CreatePrimitive(0);
					Object.Destroy(Mods.pointer.GetComponent<Rigidbody>());
					Object.Destroy(Mods.pointer.GetComponent<SphereCollider>());
					Mods.pointer.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
				}
				Mods.pointer.transform.position = raycastHit.point;
				bool flag2 = ControllerInputPoller.instance.rightControllerIndexFloat > 0f;
				if (flag2)
				{
					Mods.pointer.GetComponent<Renderer>().material.color = new Color32(byte.MaxValue, 0, 0, 1);
					Player.Instance.GetComponent<Rigidbody>().transform.position = Mods.pointer.transform.position;
					Player.Instance.headCollider.transform.position = Mods.pointer.transform.position;
				}
				Mods.pointer.GetComponent<Renderer>().material.color = new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, 1);
			}
			else
			{
				Object.Destroy(Mods.pointer);
			}
		}

		// Token: 0x06000070 RID: 112 RVA: 0x0000AF08 File Offset: 0x00009108
		public static void ChangeColor3()
		{
			WristMenu.FirstColor = Color.red;
			WristMenu.SecondColor = Color.black;
			WristMenu.ButtonColorDisable = Color.black;
			WristMenu.ButtonColorEnabled = Color.red;
			WristMenu.ButtonTextColor = Color.white;
			WristMenu.settingsbuttons[6].enabled = new bool?(false);
			WristMenu.DestroyMenu();
			WristMenu.instance.Draw();
		}

		// Token: 0x06000071 RID: 113 RVA: 0x0000AF70 File Offset: 0x00009170
		public static void ChangeColor2()
		{
			WristMenu.FirstColor = Color.yellow;
			WristMenu.SecondColor = Color.black;
			WristMenu.ButtonColorDisable = Color.black;
			WristMenu.ButtonColorEnabled = Color.red;
			WristMenu.ButtonTextColor = Color.white;
			WristMenu.settingsbuttons[8].enabled = new bool?(false);
			WristMenu.DestroyMenu();
			WristMenu.instance.Draw();
		}

		// Token: 0x06000072 RID: 114 RVA: 0x0000AFD8 File Offset: 0x000091D8
		public static void ChangeColor1()
		{
			WristMenu.FirstColor = Color.green;
			WristMenu.SecondColor = Color.black;
			WristMenu.ButtonColorDisable = Color.black;
			WristMenu.ButtonColorEnabled = Color.red;
			WristMenu.ButtonTextColor = Color.white;
			WristMenu.settingsbuttons[7].enabled = new bool?(false);
			WristMenu.DestroyMenu();
			WristMenu.instance.Draw();
		}

		// Token: 0x06000073 RID: 115 RVA: 0x0000B040 File Offset: 0x00009240
		public static void ChangeColor4()
		{
			WristMenu.FirstColor = Color.blue;
			WristMenu.SecondColor = Color.black;
			WristMenu.ButtonColorDisable = Color.black;
			WristMenu.ButtonColorEnabled = Color.red;
			WristMenu.ButtonTextColor = Color.white;
			WristMenu.settingsbuttons[9].enabled = new bool?(false);
			WristMenu.DestroyMenu();
			WristMenu.instance.Draw();
		}

		// Token: 0x06000074 RID: 116 RVA: 0x0000B0A8 File Offset: 0x000092A8
		public static void ProcessHandSpinner()
		{
			VRMap vrmap = GorillaTagger.Instance.offlineVRRig.rightHand;
			VRMap leftHand = GorillaTagger.Instance.offlineVRRig.leftHand;
			vrmap.trackingRotationOffset.y = vrmap.trackingRotationOffset.y + 10f;
			leftHand.trackingRotationOffset.y = leftHand.trackingRotationOffset.y + 10f;
		}

		// Token: 0x06000075 RID: 117 RVA: 0x0000B110 File Offset: 0x00009310
		public static void FixProcessHandSpinner()
		{
			VRMap vrmap = GorillaTagger.Instance.offlineVRRig.rightHand;
			VRMap leftHand = GorillaTagger.Instance.offlineVRRig.leftHand;
			vrmap.trackingRotationOffset.y = vrmap.trackingRotationOffset.y + 0f;
			leftHand.trackingRotationOffset.y = leftHand.trackingRotationOffset.y + 0f;
		}

		// Token: 0x06000076 RID: 118 RVA: 0x0000B178 File Offset: 0x00009378
		public static void Boingmod()
		{
			bool rightControllerSecondaryButton = ControllerInputPoller.instance.rightControllerSecondaryButton;
			if (rightControllerSecondaryButton)
			{
				Player.Instance.GetComponent<Rigidbody>().transform.position += Player.Instance.headCollider.transform.forward / 3f;
				Player.Instance.GetComponent<Rigidbody>().transform.position += Player.Instance.headCollider.transform.up / 6f;
			}
		}

		// Token: 0x06000077 RID: 119 RVA: 0x0000B214 File Offset: 0x00009414
		public static void NoTrees()
		{
			bool leftGrab = ControllerInputPoller.instance.leftGrab;
			if (leftGrab)
			{
				GameObject.Find("Environment Objects/LocalObjects_Prefab/Forest/Terrain/SmallTrees/").SetActive(false);
			}
			else
			{
				GameObject.Find("Environment Objects/LocalObjects_Prefab/Forest/Terrain/SmallTrees/").SetActive(true);
			}
		}

		// Token: 0x06000078 RID: 120 RVA: 0x0000B25C File Offset: 0x0000945C
		public static void NoStump()
		{
			bool leftGrab = ControllerInputPoller.instance.leftGrab;
			if (leftGrab)
			{
				GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/tree/").SetActive(false);
				GameObject.Find("Environment Objects/LocalObjects_Prefab/Forest/Terrain/longbranch/").SetActive(false);
				GameObject.Find("Environment Objects/LocalObjects_Prefab/ForestToCanyon/").SetActive(false);
			}
			else
			{
				GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/tree/").SetActive(true);
				GameObject.Find("Environment Objects/LocalObjects_Prefab/Forest/Terrain/longbranch/").SetActive(true);
				GameObject.Find("Environment Objects/LocalObjects_Prefab/ForestToCanyon/").SetActive(true);
			}
		}

		// Token: 0x06000079 RID: 121 RVA: 0x0000B2E8 File Offset: 0x000094E8
		public static void NoLeeveevw()
		{
			foreach (GameObject gameObject in Object.FindObjectsOfType(typeof(GameObject)) as GameObject[])
			{
				bool flag = gameObject.name == "smallleaves (1)";
				bool flag2 = flag;
				if (flag2)
				{
					gameObject.SetActive(false);
				}
			}
			foreach (GameObject gameObject2 in Object.FindObjectsOfType(typeof(GameObject)) as GameObject[])
			{
				bool flag3 = gameObject2.name == "smallleaves.001";
				bool flag4 = flag3;
				if (flag4)
				{
					gameObject2.SetActive(false);
				}
			}
			foreach (GameObject gameObject3 in Object.FindObjectsOfType(typeof(GameObject)) as GameObject[])
			{
				bool flag5 = gameObject3.name == "smallleaves.002";
				bool flag6 = flag5;
				if (flag6)
				{
					gameObject3.SetActive(false);
				}
			}
			foreach (GameObject gameObject4 in Object.FindObjectsOfType(typeof(GameObject)) as GameObject[])
			{
				bool flag7 = gameObject4.name == "smallleaves.003";
				bool flag8 = flag7;
				if (flag8)
				{
					gameObject4.SetActive(false);
				}
			}
		}

		// Token: 0x0600007A RID: 122 RVA: 0x0000B450 File Offset: 0x00009650
		public static void YesLeeveevw()
		{
			foreach (GameObject gameObject in Object.FindObjectsOfType(typeof(GameObject)) as GameObject[])
			{
				bool flag = gameObject.name == "smallleaves (1)";
				bool flag2 = flag;
				if (flag2)
				{
					gameObject.SetActive(true);
				}
			}
			foreach (GameObject gameObject2 in Object.FindObjectsOfType(typeof(GameObject)) as GameObject[])
			{
				bool flag3 = gameObject2.name == "smallleaves.001";
				bool flag4 = flag3;
				if (flag4)
				{
					gameObject2.SetActive(true);
				}
			}
			foreach (GameObject gameObject3 in Object.FindObjectsOfType(typeof(GameObject)) as GameObject[])
			{
				bool flag5 = gameObject3.name == "smallleaves.002";
				bool flag6 = flag5;
				if (flag6)
				{
					gameObject3.SetActive(true);
				}
			}
			foreach (GameObject gameObject4 in Object.FindObjectsOfType(typeof(GameObject)) as GameObject[])
			{
				bool flag7 = gameObject4.name == "smallleaves.003";
				bool flag8 = flag7;
				if (flag8)
				{
					gameObject4.SetActive(true);
				}
			}
		}

		// Token: 0x0600007B RID: 123 RVA: 0x0000B5B8 File Offset: 0x000097B8
		public static void ESP()
		{
			foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
			{
				bool flag = !vrrig.isOfflineVRRig && !vrrig.isMyPlayer && vrrig.mainSkin.material.name.Contains("fected");
				if (flag)
				{
					vrrig.mainSkin.material.shader = Shader.Find("GUI/Text Shader");
					bool flag2 = Mods.espcolor == 0;
					if (flag2)
					{
						vrrig.mainSkin.material.color = new Color(9f, 0f, 0f, 0.5f);
					}
					else
					{
						vrrig.playerColor.a = 0.5f;
						vrrig.mainSkin.material.color = vrrig.playerColor;
						vrrig.playerColor.a = 1f;
					}
				}
				else
				{
					bool flag3 = !vrrig.isOfflineVRRig && !vrrig.isMyPlayer;
					if (flag3)
					{
						vrrig.mainSkin.material.shader = Shader.Find("GUI/Text Shader");
						vrrig.mainSkin.material.shader = Shader.Find("GUI/Text Shader");
						bool flag4 = Mods.espcolor == 0;
						if (flag4)
						{
							vrrig.mainSkin.material.color = new Color(0f, 9f, 0f, 0.5f);
						}
						else
						{
							vrrig.playerColor.a = 0.5f;
							vrrig.mainSkin.material.color = vrrig.playerColor;
							vrrig.playerColor.a = 1f;
						}
					}
				}
			}
			Mods.widhcnkesdj = true;
		}

		// Token: 0x0600007C RID: 124 RVA: 0x0000B7BC File Offset: 0x000099BC
		public static void demonichands()
		{
			bool gripDownL = WristMenu.gripDownL;
			if (gripDownL)
			{
				Mods.BetaFireImpact(GorillaTagger.Instance.offlineVRRig.leftHandTransform.position, Color.red, false);
			}
			bool gripDownR = WristMenu.gripDownR;
			if (gripDownR)
			{
				Mods.BetaFireImpact(GorillaTagger.Instance.offlineVRRig.rightHandTransform.position, Color.red, false);
			}
		}

		// Token: 0x0600007D RID: 125 RVA: 0x0000B820 File Offset: 0x00009A20
		public static void BetaFireImpact(Vector3 position, Color color, bool noDelay = false)
		{
			bool flag = Time.time > Mods.projDebounce;
			if (flag)
			{
				object[] array = new object[]
				{
					position,
					color.r,
					color.g,
					color.b,
					color.a,
					1
				};
				object[] array2 = new object[]
				{
					PhotonNetwork.ServerTimestamp,
					1,
					array
				};
				PhotonNetwork.RaiseEvent(3, array2, new RaiseEventOptions
				{
					Receivers = 1
				}, SendOptions.SendUnreliable);
				try
				{
					Mods.flushmanually();
				}
				catch
				{
				}
				bool flag2 = Mods.projDebounceType > 0f && !noDelay;
				if (flag2)
				{
					Mods.projDebounce = Time.time + Mods.projDebounceType;
				}
			}
		}

		// Token: 0x0600007E RID: 126 RVA: 0x0000B918 File Offset: 0x00009B18
		public static void GrabBugR()
		{
			bool rightGrab = ControllerInputPoller.instance.rightGrab;
			if (rightGrab)
			{
				GameObject.Find("Floating Bug Holdable").transform.position = GorillaTagger.Instance.rightHandTransform.position;
			}
		}

		// Token: 0x0600007F RID: 127 RVA: 0x0000B95C File Offset: 0x00009B5C
		public static void FlyNoclip()
		{
			bool rightControllerPrimaryButton = ControllerInputPoller.instance.rightControllerPrimaryButton;
			if (rightControllerPrimaryButton)
			{
				Player.Instance.transform.position += Player.Instance.headCollider.transform.forward * Time.deltaTime * 10f;
				Player.Instance.GetComponent<Rigidbody>().velocity = Vector3.zero;
				foreach (MeshCollider meshCollider in Resources.FindObjectsOfTypeAll<MeshCollider>())
				{
					meshCollider.enabled = false;
				}
			}
			else
			{
				foreach (MeshCollider meshCollider2 in Resources.FindObjectsOfTypeAll<MeshCollider>())
				{
					meshCollider2.enabled = true;
				}
			}
		}

		// Token: 0x06000080 RID: 128 RVA: 0x0000BA28 File Offset: 0x00009C28
		public static void WallWalk()
		{
			RaycastHit raycastHit;
			Physics.Raycast(Player.Instance.rightControllerTransform.position, -Player.Instance.rightControllerTransform.right, ref raycastHit, 100f, int.MaxValue);
			RaycastHit raycastHit2;
			Physics.Raycast(Player.Instance.leftControllerTransform.position, Player.Instance.rightControllerTransform.right, ref raycastHit2, 100f, int.MaxValue);
			bool rightGrab = ControllerInputPoller.instance.rightGrab;
			if (rightGrab)
			{
				bool flag = raycastHit.distance < raycastHit2.distance;
				if (flag)
				{
					bool flag2 = raycastHit.distance < 1f;
					if (flag2)
					{
						Vector3 normalized = (raycastHit.point - Player.Instance.rightControllerTransform.position).normalized;
						Physics.gravity = normalized * 9.81f;
					}
					else
					{
						Physics.gravity = new Vector3(0f, -9.81f, 0f);
					}
				}
				bool flag3 = raycastHit.distance == raycastHit2.distance;
				if (flag3)
				{
					Physics.gravity = new Vector3(0f, -9.81f, 0f);
				}
			}
			else
			{
				Physics.gravity = new Vector3(0f, -9.81f, 0f);
			}
			bool leftGrab = ControllerInputPoller.instance.leftGrab;
			if (leftGrab)
			{
				bool flag4 = raycastHit.distance > raycastHit2.distance;
				if (flag4)
				{
					bool flag5 = raycastHit2.distance < 1f;
					if (flag5)
					{
						Vector3 normalized2 = (raycastHit2.point - Player.Instance.leftControllerTransform.position).normalized;
						Physics.gravity = normalized2 * 9.81f;
					}
					else
					{
						Physics.gravity = new Vector3(0f, -9.81f, 0f);
					}
				}
				bool flag6 = raycastHit.distance == raycastHit2.distance;
				if (flag6)
				{
					Physics.gravity = new Vector3(0f, -9.81f, 0f);
				}
			}
			else
			{
				Physics.gravity = new Vector3(0f, -9.81f, 0f);
			}
		}

		// Token: 0x06000081 RID: 129 RVA: 0x0000BC6D File Offset: 0x00009E6D
		public static void Disablewater()
		{
			Mods.disablewater = true;
			Mods.walkonwater = false;
			Mods.fixwater = false;
			Mods.swimeverywhere = false;
			Mods.waterchecker();
		}

		// Token: 0x06000082 RID: 130 RVA: 0x0000BC8E File Offset: 0x00009E8E
		public static void FIXwater()
		{
			Mods.disablewater = false;
			Mods.walkonwater = false;
			Mods.fixwater = true;
			Mods.swimeverywhere = false;
			Mods.waterchecker();
		}

		// Token: 0x06000083 RID: 131 RVA: 0x0000BCB0 File Offset: 0x00009EB0
		public static void waterchecker()
		{
			bool flag = Mods.disablewater;
			if (flag)
			{
				int layer = LayerMask.NameToLayer("TransparentFX");
				GameObject.Find("Environment Objects/LocalObjects_Prefab").transform.Find("Beach/B_WaterVolumes/OceanWater").gameObject.layer = layer;
			}
			bool flag2 = Mods.walkonwater;
			if (flag2)
			{
				int layer2 = LayerMask.NameToLayer("Default");
				GameObject.Find("Environment Objects/LocalObjects_Prefab/").transform.Find("Beach/B_WaterVolumes/OceanWater").gameObject.layer = layer2;
			}
			bool flag3 = Mods.fixwater;
			if (flag3)
			{
				int layer3 = LayerMask.NameToLayer("Water");
				GameObject.Find("Environment Objects/LocalObjects_Prefab/").transform.Find("Beach/B_WaterVolumes/OceanWater").gameObject.layer = layer3;
			}
		}

		// Token: 0x06000084 RID: 132 RVA: 0x0000BD74 File Offset: 0x00009F74
		public static void nograv()
		{
			bool rightGrab = ControllerInputPoller.instance.rightGrab;
			if (rightGrab)
			{
				Physics.gravity = new Vector3(0f, 0f, 0f);
			}
			else
			{
				Physics.gravity = new Vector3(0f, -10f, 0f);
			}
		}

		// Token: 0x06000085 RID: 133 RVA: 0x0000BDCC File Offset: 0x00009FCC
		public static void LockOnGun()
		{
			foreach (Player player in PhotonNetwork.PlayerList)
			{
				Mods.pointer.transform.position = GorillaTagger.Instance.offlineVRRig.transform.position;
				Mods.pointer.transform.rotation = GorillaTagger.Instance.offlineVRRig.transform.rotation;
			}
		}

		// Token: 0x06000086 RID: 134 RVA: 0x0000BE40 File Offset: 0x0000A040
		public static void NoColiider()
		{
			bool rightGrab = ControllerInputPoller.instance.rightGrab;
			if (rightGrab)
			{
				GorillaTagger.Instance.bodyCollider.enabled = false;
				GorillaTagger.Instance.headCollider.enabled = false;
			}
		}

		// Token: 0x06000087 RID: 135 RVA: 0x0000BE84 File Offset: 0x0000A084
		public static void grabrig()
		{
			bool rightGrab = ControllerInputPoller.instance.rightGrab;
			if (rightGrab)
			{
				GorillaTagger.Instance.offlineVRRig.enabled = false;
				GorillaTagger.Instance.offlineVRRig.transform.position = GorillaTagger.Instance.rightHandTransform.position;
			}
			else
			{
				GorillaTagger.Instance.offlineVRRig.enabled = true;
			}
		}

		// Token: 0x06000088 RID: 136 RVA: 0x0000BEEE File Offset: 0x0000A0EE
		public static void UnreleasedSweater()
		{
			GameObject.Find("Player Objects/Local VRRig/Local Gorilla Player/rig/body/WinterJan2023 Body/LBACP.").SetActive(true);
		}

		// Token: 0x06000089 RID: 137 RVA: 0x0000BF02 File Offset: 0x0000A102
		public static void DisableUnreleasedSweater()
		{
			GameObject.Find("Player Objects/Local VRRig/Local Gorilla Player/rig/body/WinterJan2023 Body/LBACP.").SetActive(false);
		}

		// Token: 0x0600008A RID: 138 RVA: 0x0000BF16 File Offset: 0x0000A116
		public static void NOTAPVIBATIONS()
		{
			GorillaTagger.Instance.tapHapticStrength = 0f;
			Mods.stuiejrf3 = false;
		}

		// Token: 0x0600008B RID: 139 RVA: 0x0000BF2E File Offset: 0x0000A12E
		public static void FixNOTAPVIBATIONS()
		{
			Mods.stuiejrf3 = true;
			GorillaTagger.Instance.tapHapticStrength = 0.5f;
		}

		// Token: 0x0600008C RID: 140 RVA: 0x0000BF48 File Offset: 0x0000A148
		public static void ScareGun()
		{
			bool flag = ControllerInputPoller.instance.rightControllerGripFloat == 1f;
			if (flag)
			{
				RaycastHit raycastHit;
				bool flag2 = Physics.Raycast(Player.Instance.rightControllerTransform.position - Player.Instance.rightControllerTransform.up, -Player.Instance.rightControllerTransform.up, ref raycastHit) && Mods.pointer == null;
				if (flag2)
				{
					Mods.pointer = GameObject.CreatePrimitive(0);
					Object.Destroy(Mods.pointer.GetComponent<Rigidbody>());
					Object.Destroy(Mods.pointer.GetComponent<SphereCollider>());
					Mods.pointer.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
				}
				Mods.pointer.transform.position = raycastHit.point;
				bool flag3 = ControllerInputPoller.instance.rightControllerIndexFloat == 1f;
				if (flag3)
				{
					RigShit.GetOwnVRRig().enabled = false;
					RigShit.GetOwnVRRig().transform.position = Mods.pointer.transform.position;
				}
				else
				{
					RigShit.GetOwnVRRig().enabled = true;
				}
			}
			else
			{
				RigShit.GetOwnVRRig().enabled = true;
				Object.Destroy(Mods.pointer);
			}
		}

		// Token: 0x0600008D RID: 141 RVA: 0x0000C09C File Offset: 0x0000A29C
		public static void HitTargetGun()
		{
			bool flag = ControllerInputPoller.instance.rightControllerGripFloat == 1f;
			if (flag)
			{
				RaycastHit raycastHit;
				bool flag2 = Physics.Raycast(Player.Instance.rightControllerTransform.position - Player.Instance.rightControllerTransform.up, -Player.Instance.rightControllerTransform.up, ref raycastHit) && Mods.pointer == null;
				if (flag2)
				{
					Mods.pointer = GameObject.CreatePrimitive(0);
					Object.Destroy(Mods.pointer.GetComponent<Rigidbody>());
					Object.Destroy(Mods.pointer.GetComponent<SphereCollider>());
					Mods.pointer.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
				}
				Mods.pointer.transform.position = raycastHit.point;
				HitTargetWithScoreCounter componentInParent = raycastHit.collider.GetComponentInParent<HitTargetWithScoreCounter>();
				bool flag3 = ControllerInputPoller.instance.rightControllerIndexFloat == 1f;
				if (flag3)
				{
					componentInParent.TargetHit();
				}
			}
			else
			{
				Object.Destroy(Mods.pointer);
			}
		}

		// Token: 0x0600008E RID: 142 RVA: 0x0000C1C0 File Offset: 0x0000A3C0
		public static void ModderTracers()
		{
			foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
			{
				bool flag = RigShit.GetPlayerFromRig(vrrig).CustomProperties.ContainsKey("mods");
				if (flag)
				{
					bool flag2 = !vrrig.isMyPlayer;
					if (flag2)
					{
						bool flag3 = !vrrig.head.rigTarget.gameObject.GetComponent<LineRenderer>();
						if (flag3)
						{
							vrrig.head.rigTarget.gameObject.AddComponent<LineRenderer>();
						}
						vrrig.head.rigTarget.gameObject.GetComponent<LineRenderer>().startWidth = 0.025f;
						vrrig.head.rigTarget.gameObject.GetComponent<LineRenderer>().material.shader = Shader.Find("GorillaTag/UberShader");
						vrrig.head.rigTarget.gameObject.GetComponent<LineRenderer>().material.color = vrrig.playerColor;
					}
					vrrig.head.rigTarget.gameObject.GetComponent<LineRenderer>().SetPosition(0, vrrig.head.rigTarget.gameObject.transform.position);
					vrrig.head.rigTarget.gameObject.GetComponent<LineRenderer>().SetPosition(1, GorillaTagger.Instance.offlineVRRig.rightHandTransform.position);
				}
			}
			Mods.weufewfjdfjn = true;
		}

		// Token: 0x0600008F RID: 143 RVA: 0x0000C370 File Offset: 0x0000A570
		public static void balloonhitgun()
		{
			bool flag = ControllerInputPoller.instance.rightControllerGripFloat == 1f;
			if (flag)
			{
				RaycastHit raycastHit;
				bool flag2 = Physics.Raycast(Player.Instance.rightControllerTransform.position - Player.Instance.rightControllerTransform.up, -Player.Instance.rightControllerTransform.up, ref raycastHit) && Mods.pointer == null;
				if (flag2)
				{
					Mods.pointer = GameObject.CreatePrimitive(0);
					Object.Destroy(Mods.pointer.GetComponent<Rigidbody>());
					Object.Destroy(Mods.pointer.GetComponent<SphereCollider>());
					Mods.pointer.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
				}
				Mods.pointer.transform.position = raycastHit.point;
				bool flag3 = ControllerInputPoller.instance.rightControllerIndexFloat == 1f;
				if (flag3)
				{
					bool flag4 = raycastHit.collider.GetComponentInParent<BalloonHoldable>();
					if (flag4)
					{
						GorillaTagger.Instance.leftHandTriggerCollider.transform.position = raycastHit.point;
					}
				}
			}
			else
			{
				Object.Destroy(Mods.pointer);
			}
		}

		// Token: 0x06000090 RID: 144 RVA: 0x0000C4B4 File Offset: 0x0000A6B4
		public static void RemovePlats()
		{
			bool rightGrab = ControllerInputPoller.instance.rightGrab;
			if (rightGrab)
			{
				for (int i = 1; i > 0; i++)
				{
					GameObject.Find("plat").SetActive(false);
					GameObject.Find("plat").SetActive(false);
					GameObject.Find("plat").SetActive(false);
					GameObject.Find("plat").SetActive(false);
					GameObject.Find("plat").SetActive(false);
					GameObject.Find("plat").SetActive(false);
				}
				for (int j = 1; j > 0; j++)
				{
					GameObject.Find("plat").SetActive(false);
					GameObject.Find("plat").SetActive(false);
					GameObject.Find("plat").SetActive(false);
					GameObject.Find("plat").SetActive(false);
					GameObject.Find("plat").SetActive(false);
					GameObject.Find("plat").SetActive(false);
				}
				for (int k = 1; k > 0; k++)
				{
					GameObject.Find("plat").SetActive(false);
					GameObject.Find("plat").SetActive(false);
					GameObject.Find("plat").SetActive(false);
					GameObject.Find("plat").SetActive(false);
					GameObject.Find("plat").SetActive(false);
					GameObject.Find("plat").SetActive(false);
				}
				for (int l = 1; l > 0; l++)
				{
					GameObject.Find("plat").SetActive(false);
					GameObject.Find("plat").SetActive(false);
					GameObject.Find("plat").SetActive(false);
					GameObject.Find("plat").SetActive(false);
					GameObject.Find("plat").SetActive(false);
					GameObject.Find("plat").SetActive(false);
				}
				for (int m = 1; m > 0; m++)
				{
					GameObject.Find("plat").SetActive(false);
					GameObject.Find("plat").SetActive(false);
					GameObject.Find("plat").SetActive(false);
					GameObject.Find("plat").SetActive(false);
					GameObject.Find("plat").SetActive(false);
					GameObject.Find("plat").SetActive(false);
				}
				for (int n = 1; n > 0; n++)
				{
					GameObject.Find("plat").SetActive(false);
					GameObject.Find("plat").SetActive(false);
					GameObject.Find("plat").SetActive(false);
					GameObject.Find("plat").SetActive(false);
					GameObject.Find("plat").SetActive(false);
					GameObject.Find("plat").SetActive(false);
				}
				for (int num = 1; num > 0; num++)
				{
					GameObject.Find("plat").SetActive(false);
					GameObject.Find("plat").SetActive(false);
					GameObject.Find("plat").SetActive(false);
					GameObject.Find("plat").SetActive(false);
					GameObject.Find("plat").SetActive(false);
					GameObject.Find("plat").SetActive(false);
				}
				for (int num2 = 1; num2 > 0; num2++)
				{
					GameObject.Find("plat").SetActive(false);
					GameObject.Find("plat").SetActive(false);
					GameObject.Find("plat").SetActive(false);
					GameObject.Find("plat").SetActive(false);
					GameObject.Find("plat").SetActive(false);
					GameObject.Find("plat").SetActive(false);
				}
			}
		}

		// Token: 0x06000091 RID: 145 RVA: 0x0000C8C0 File Offset: 0x0000AAC0
		public static void RandomSoundSpam()
		{
			bool flag = ControllerInputPoller.instance.leftControllerIndexFloat == 1f && Mods.balll < Time.time;
			if (flag)
			{
				Mods.balll = Time.time + 0.01f;
				int num = Random.Range(0, 215);
				GorillaTagger.Instance.myVRRig.RPC("PlayHandTap", 0, new object[]
				{
					num,
					true,
					999f
				});
				Mods.flushmanually();
			}
		}

		// Token: 0x06000092 RID: 146 RVA: 0x0000C954 File Offset: 0x0000AB54
		public static void HugeCristalSpam()
		{
			bool flag = ControllerInputPoller.instance.leftControllerIndexFloat == 1f && Mods.balll < Time.time;
			if (flag)
			{
				Mods.balll = Time.time + 0.01f;
				GorillaTagger.Instance.myVRRig.RPC("PlayHandTap", 0, new object[]
				{
					213,
					true,
					999f
				});
				Mods.flushmanually();
			}
		}

		// Token: 0x06000093 RID: 147 RVA: 0x0000C9E0 File Offset: 0x0000ABE0
		public static void MedalSpam()
		{
			bool flag = ControllerInputPoller.instance.leftControllerIndexFloat == 1f && Mods.balll < Time.time;
			if (flag)
			{
				Mods.balll = Time.time + 0.01f;
				GorillaTagger.Instance.myVRRig.RPC("PlayHandTap", 0, new object[]
				{
					18,
					true,
					999f
				});
				Mods.flushmanually();
			}
		}

		// Token: 0x06000094 RID: 148 RVA: 0x0000CA68 File Offset: 0x0000AC68
		public static void AKSPAM()
		{
			bool flag = ControllerInputPoller.instance.leftControllerIndexFloat == 1f && Mods.balll < Time.time;
			if (flag)
			{
				Mods.balll = Time.time + 0.01f;
				GorillaTagger.Instance.myVRRig.RPC("PlayHandTap", 0, new object[]
				{
					203,
					true,
					999f
				});
				Mods.flushmanually();
			}
		}

		// Token: 0x06000095 RID: 149 RVA: 0x0000CAF4 File Offset: 0x0000ACF4
		public static void platgun()
		{
			bool flag = ControllerInputPoller.instance.rightControllerGripFloat == 1f;
			bool flag2 = !flag;
			if (flag2)
			{
				Object.Destroy(Mods.pointer);
				Mods.pointer = null;
				Mods.antiRepeat = false;
			}
			else
			{
				RaycastHit raycastHit;
				Physics.Raycast(Player.Instance.rightControllerTransform.position - Player.Instance.rightControllerTransform.up, -Player.Instance.rightControllerTransform.up, ref raycastHit);
				bool flag3 = Mods.pointer == null;
				if (flag3)
				{
					Mods.pointer = GameObject.CreatePrimitive(0);
					Object.Destroy(Mods.pointer.GetComponent<Rigidbody>());
					Object.Destroy(Mods.pointer.GetComponent<SphereCollider>());
					Mods.pointer.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
				}
				Mods.pointer.transform.position = raycastHit.point;
				Mods.pointer.GetComponent<Renderer>().material.SetColor("_Color", Color.white);
				bool flag4 = ControllerInputPoller.instance.rightControllerIndexFloat == 1f;
				bool flag5 = !flag4;
				if (flag5)
				{
					Mods.antiRepeat = false;
				}
				else
				{
					GameObject gameObject = GameObject.CreatePrimitive(3);
					gameObject.name = "plat";
					gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.black);
					gameObject.transform.localScale = new Vector3(0.025f, 0.3f, 0.4f);
					gameObject.transform.position = raycastHit.point;
					gameObject.transform.LookAt(Player.Instance.headCollider.transform);
					object[] array = new object[]
					{
						gameObject.transform.position,
						gameObject.transform.rotation
					};
					RaiseEventOptions raiseEventOptions = new RaiseEventOptions
					{
						Receivers = 0
					};
					PhotonNetwork.RaiseEvent(69, array, raiseEventOptions, SendOptions.SendReliable);
					ColorChanger colorChanger = gameObject.AddComponent<ColorChanger>();
					colorChanger.colors = new Gradient
					{
						colorKeys = Mods.colorKeysPlatformMonke
					};
					colorChanger.Start();
				}
			}
		}

		// Token: 0x06000096 RID: 150 RVA: 0x0000CD30 File Offset: 0x0000AF30
		public static void ControlBalloonGun()
		{
			bool flag = ControllerInputPoller.instance.rightControllerGripFloat == 1f;
			if (flag)
			{
				RaycastHit raycastHit;
				bool flag2 = Physics.Raycast(Player.Instance.rightControllerTransform.position - Player.Instance.rightControllerTransform.up, -Player.Instance.rightControllerTransform.up, ref raycastHit) && Mods.pointer == null;
				if (flag2)
				{
					Mods.pointer = GameObject.CreatePrimitive(0);
					Object.Destroy(Mods.pointer.GetComponent<Rigidbody>());
					Object.Destroy(Mods.pointer.GetComponent<SphereCollider>());
					Mods.pointer.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
				}
				Mods.pointer.transform.position = raycastHit.point;
				bool flag3 = ControllerInputPoller.instance.rightControllerIndexFloat == 1f;
				if (flag3)
				{
					foreach (BalloonHoldable balloonHoldable in Object.FindObjectsOfType<BalloonHoldable>())
					{
						balloonHoldable.transform.position = raycastHit.point;
					}
				}
			}
			else
			{
				Object.Destroy(Mods.pointer);
			}
		}

		// Token: 0x06000097 RID: 151 RVA: 0x0000CE74 File Offset: 0x0000B074
		public static void WaterBalloonBlockGun()
		{
			bool flag = ControllerInputPoller.instance.rightControllerGripFloat == 1f;
			if (flag)
			{
				RaycastHit raycastHit;
				Physics.Raycast(Player.Instance.rightControllerTransform.position - Player.Instance.rightControllerTransform.up, -Player.Instance.rightControllerTransform.up, ref raycastHit);
				bool flag2 = Mods.pointer == null;
				if (flag2)
				{
					Mods.pointer = GameObject.CreatePrimitive(0);
					Object.Destroy(Mods.pointer.GetComponent<Rigidbody>());
					Object.Destroy(Mods.pointer.GetComponent<SphereCollider>());
					Mods.pointer.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
				}
				Mods.pointer.transform.position = raycastHit.point;
				bool flag3 = ControllerInputPoller.instance.rightControllerIndexFloat == 1f;
				if (flag3)
				{
					bool flag4 = !Mods.teleportGunAntiRepeat;
					if (flag4)
					{
						GameObject gameObject = GameObject.CreatePrimitive(3);
						gameObject.name = "waterballonsdsw:D";
						gameObject.transform.position = Mods.pointer.transform.position;
						gameObject.transform.rotation = Mods.pointer.transform.rotation;
						gameObject.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
						gameObject.AddComponent<GorillaSurfaceOverride>();
						gameObject.GetComponent<GorillaSurfaceOverride>().overrideIndex = 204;
						gameObject.GetComponent<GorillaSurfaceOverride>().extraVelMultiplier = 1f;
						gameObject.GetComponent<GorillaSurfaceOverride>().extraVelMaxMultiplier = 1f;
						gameObject.GetComponent<Renderer>().material.color = Color.blue;
						Mods.teleportGunAntiRepeat = true;
					}
				}
				else
				{
					Mods.teleportGunAntiRepeat = false;
				}
			}
			else
			{
				Object.Destroy(Mods.pointer);
				Mods.pointer = null;
				Mods.teleportGunAntiRepeat = false;
			}
		}

		// Token: 0x06000098 RID: 152 RVA: 0x0000D070 File Offset: 0x0000B270
		public static void RockFloor()
		{
			GameObject.Find("pit ground").GetComponent<GorillaSurfaceOverride>().extraVelMultiplier = 1f;
			GameObject.Find("pit ground").GetComponent<GorillaSurfaceOverride>().extraVelMaxMultiplier = 1f;
			GameObject.Find("pit ground").GetComponent<GorillaSurfaceOverride>().overrideIndex = 231;
		}

		// Token: 0x06000099 RID: 153 RVA: 0x0000D0CC File Offset: 0x0000B2CC
		public static void SlipFloor()
		{
			GameObject.Find("pit ground").GetComponent<GorillaSurfaceOverride>().extraVelMultiplier = 1f;
			GameObject.Find("pit ground").GetComponent<GorillaSurfaceOverride>().extraVelMaxMultiplier = 1f;
			GameObject.Find("pit ground").GetComponent<GorillaSurfaceOverride>().overrideIndex = 59;
		}

		// Token: 0x0600009A RID: 154 RVA: 0x0000D124 File Offset: 0x0000B324
		public static void PreasentFloor()
		{
			GameObject.Find("pit ground").GetComponent<GorillaSurfaceOverride>().extraVelMultiplier = 1f;
			GameObject.Find("pit ground").GetComponent<GorillaSurfaceOverride>().extraVelMaxMultiplier = 1f;
			GameObject.Find("pit ground").GetComponent<GorillaSurfaceOverride>().overrideIndex = 240;
		}

		// Token: 0x0600009B RID: 155 RVA: 0x0000D180 File Offset: 0x0000B380
		public static void MentosFloor()
		{
			GameObject.Find("pit ground").GetComponent<GorillaSurfaceOverride>().extraVelMultiplier = 1f;
			GameObject.Find("pit ground").GetComponent<GorillaSurfaceOverride>().extraVelMaxMultiplier = 1f;
			GameObject.Find("pit ground").GetComponent<GorillaSurfaceOverride>().overrideIndex = 249;
		}

		// Token: 0x0600009C RID: 156 RVA: 0x0000D1DC File Offset: 0x0000B3DC
		public static void BreakeDoor()
		{
			bool flag = Mods.smth46 < Time.time;
			if (flag)
			{
				Mods.smth46 = Time.time + 0.05f;
				foreach (GTDoor gtdoor in Object.FindObjectsOfType<GTDoor>())
				{
					gtdoor.photonView.RPC("ChangeDoorState", 5, new object[]
					{
						5
					});
					gtdoor.photonView.RPC("ChangeDoorState", 5, new object[]
					{
						2
					});
					Mods.flushmanually();
				}
			}
		}

		// Token: 0x0600009D RID: 157 RVA: 0x0000D270 File Offset: 0x0000B470
		public static void OpenDoor()
		{
			bool flag = ControllerInputPoller.instance.rightControllerIndexFloat == 1f;
			if (flag)
			{
				foreach (GTDoor gtdoor in Object.FindObjectsOfType<GTDoor>())
				{
					gtdoor.photonView.RPC("ChangeDoorState", 5, new object[]
					{
						5
					});
					Mods.flushmanually();
				}
			}
		}

		// Token: 0x0600009E RID: 158 RVA: 0x0000D2DC File Offset: 0x0000B4DC
		public static void CloseDoor()
		{
			bool flag = ControllerInputPoller.instance.rightControllerIndexFloat == 1f;
			if (flag)
			{
				foreach (GTDoor gtdoor in Object.FindObjectsOfType<GTDoor>())
				{
					gtdoor.photonView.RPC("ChangeDoorState", 5, new object[]
					{
						2
					});
					Mods.flushmanually();
				}
			}
		}

		// Token: 0x0600009F RID: 159 RVA: 0x0000D348 File Offset: 0x0000B548
		public static void IceBlockGun()
		{
			bool flag = ControllerInputPoller.instance.rightControllerGripFloat == 1f;
			if (flag)
			{
				RaycastHit raycastHit;
				Physics.Raycast(Player.Instance.rightControllerTransform.position - Player.Instance.rightControllerTransform.up, -Player.Instance.rightControllerTransform.up, ref raycastHit);
				bool flag2 = Mods.pointer == null;
				if (flag2)
				{
					Mods.pointer = GameObject.CreatePrimitive(0);
					Object.Destroy(Mods.pointer.GetComponent<Rigidbody>());
					Object.Destroy(Mods.pointer.GetComponent<SphereCollider>());
					Mods.pointer.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
				}
				Mods.pointer.transform.position = raycastHit.point;
				bool flag3 = ControllerInputPoller.instance.rightControllerIndexFloat == 1f;
				if (flag3)
				{
					bool flag4 = !Mods.teleportGunAntiRepeat;
					if (flag4)
					{
						GameObject gameObject = GameObject.CreatePrimitive(3);
						gameObject.name = "waterballonsdsw:D";
						gameObject.transform.position = Mods.pointer.transform.position;
						gameObject.transform.rotation = Mods.pointer.transform.rotation;
						gameObject.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
						gameObject.AddComponent<GorillaSurfaceOverride>();
						gameObject.GetComponent<GorillaSurfaceOverride>().overrideIndex = 59;
						gameObject.GetComponent<GorillaSurfaceOverride>().extraVelMultiplier = 1f;
						gameObject.GetComponent<GorillaSurfaceOverride>().extraVelMaxMultiplier = 1f;
						gameObject.GetComponent<Renderer>().material.color = Color.cyan;
						Mods.teleportGunAntiRepeat = true;
					}
				}
				else
				{
					Mods.teleportGunAntiRepeat = false;
				}
			}
			else
			{
				Object.Destroy(Mods.pointer);
				Mods.pointer = null;
				Mods.teleportGunAntiRepeat = false;
			}
		}

		// Token: 0x060000A0 RID: 160 RVA: 0x0000D540 File Offset: 0x0000B740
		public static void RockBlockGun()
		{
			bool flag = ControllerInputPoller.instance.rightControllerGripFloat == 1f;
			if (flag)
			{
				RaycastHit raycastHit;
				Physics.Raycast(Player.Instance.rightControllerTransform.position - Player.Instance.rightControllerTransform.up, -Player.Instance.rightControllerTransform.up, ref raycastHit);
				bool flag2 = Mods.pointer == null;
				if (flag2)
				{
					Mods.pointer = GameObject.CreatePrimitive(0);
					Object.Destroy(Mods.pointer.GetComponent<Rigidbody>());
					Object.Destroy(Mods.pointer.GetComponent<SphereCollider>());
					Mods.pointer.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
				}
				Mods.pointer.transform.position = raycastHit.point;
				bool flag3 = ControllerInputPoller.instance.rightControllerIndexFloat == 1f;
				if (flag3)
				{
					bool flag4 = !Mods.teleportGunAntiRepeat;
					if (flag4)
					{
						GameObject gameObject = GameObject.CreatePrimitive(3);
						gameObject.name = "waterballonsdsw:D";
						gameObject.transform.position = Mods.pointer.transform.position;
						gameObject.transform.rotation = Mods.pointer.transform.rotation;
						gameObject.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
						gameObject.AddComponent<GorillaSurfaceOverride>();
						gameObject.GetComponent<GorillaSurfaceOverride>().overrideIndex = 231;
						gameObject.GetComponent<GorillaSurfaceOverride>().extraVelMultiplier = 1f;
						gameObject.GetComponent<GorillaSurfaceOverride>().extraVelMaxMultiplier = 1f;
						gameObject.GetComponent<Renderer>().material.color = Color.black;
						Mods.teleportGunAntiRepeat = true;
					}
				}
				else
				{
					Mods.teleportGunAntiRepeat = false;
				}
			}
			else
			{
				Object.Destroy(Mods.pointer);
				Mods.pointer = null;
				Mods.teleportGunAntiRepeat = false;
			}
		}

		// Token: 0x060000A1 RID: 161 RVA: 0x0000D73C File Offset: 0x0000B93C
		public static void MentsoBlockGun()
		{
			bool flag = ControllerInputPoller.instance.rightControllerGripFloat == 1f;
			if (flag)
			{
				RaycastHit raycastHit;
				Physics.Raycast(Player.Instance.rightControllerTransform.position - Player.Instance.rightControllerTransform.up, -Player.Instance.rightControllerTransform.up, ref raycastHit);
				bool flag2 = Mods.pointer == null;
				if (flag2)
				{
					Mods.pointer = GameObject.CreatePrimitive(0);
					Object.Destroy(Mods.pointer.GetComponent<Rigidbody>());
					Object.Destroy(Mods.pointer.GetComponent<SphereCollider>());
					Mods.pointer.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
				}
				Mods.pointer.transform.position = raycastHit.point;
				bool flag3 = ControllerInputPoller.instance.rightControllerIndexFloat == 1f;
				if (flag3)
				{
					bool flag4 = !Mods.teleportGunAntiRepeat;
					if (flag4)
					{
						GameObject gameObject = GameObject.CreatePrimitive(3);
						gameObject.name = "waterballonsdsw:D";
						gameObject.transform.position = Mods.pointer.transform.position;
						gameObject.transform.rotation = Mods.pointer.transform.rotation;
						gameObject.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
						gameObject.AddComponent<GorillaSurfaceOverride>();
						gameObject.GetComponent<GorillaSurfaceOverride>().overrideIndex = 249;
						gameObject.GetComponent<GorillaSurfaceOverride>().extraVelMultiplier = 1f;
						gameObject.GetComponent<GorillaSurfaceOverride>().extraVelMaxMultiplier = 1f;
						gameObject.GetComponent<Renderer>().material.color = Color.white;
						Mods.teleportGunAntiRepeat = true;
					}
				}
				else
				{
					Mods.teleportGunAntiRepeat = false;
				}
			}
			else
			{
				Object.Destroy(Mods.pointer);
				Mods.pointer = null;
				Mods.teleportGunAntiRepeat = false;
			}
		}

		// Token: 0x060000A2 RID: 162 RVA: 0x0000D938 File Offset: 0x0000BB38
		public static void PresentBlockGun()
		{
			bool flag = ControllerInputPoller.instance.rightControllerGripFloat == 1f;
			if (flag)
			{
				RaycastHit raycastHit;
				Physics.Raycast(Player.Instance.rightControllerTransform.position - Player.Instance.rightControllerTransform.up, -Player.Instance.rightControllerTransform.up, ref raycastHit);
				bool flag2 = Mods.pointer == null;
				if (flag2)
				{
					Mods.pointer = GameObject.CreatePrimitive(0);
					Object.Destroy(Mods.pointer.GetComponent<Rigidbody>());
					Object.Destroy(Mods.pointer.GetComponent<SphereCollider>());
					Mods.pointer.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
				}
				Mods.pointer.transform.position = raycastHit.point;
				bool flag3 = ControllerInputPoller.instance.rightControllerIndexFloat == 1f;
				if (flag3)
				{
					bool flag4 = !Mods.teleportGunAntiRepeat;
					if (flag4)
					{
						GameObject gameObject = GameObject.CreatePrimitive(3);
						gameObject.name = "waterballonsdsw:D";
						gameObject.transform.position = Mods.pointer.transform.position;
						gameObject.transform.rotation = Mods.pointer.transform.rotation;
						gameObject.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
						gameObject.AddComponent<GorillaSurfaceOverride>();
						gameObject.GetComponent<GorillaSurfaceOverride>().overrideIndex = 240;
						gameObject.GetComponent<GorillaSurfaceOverride>().extraVelMultiplier = 1f;
						gameObject.GetComponent<GorillaSurfaceOverride>().extraVelMaxMultiplier = 1f;
						gameObject.GetComponent<Renderer>().material.color = Color.yellow;
						Mods.teleportGunAntiRepeat = true;
					}
				}
				else
				{
					Mods.teleportGunAntiRepeat = false;
				}
			}
			else
			{
				Object.Destroy(Mods.pointer);
				Mods.pointer = null;
				Mods.teleportGunAntiRepeat = false;
			}
		}

		// Token: 0x060000A3 RID: 163 RVA: 0x0000DB34 File Offset: 0x0000BD34
		public static void TrampolineGun()
		{
			bool flag = ControllerInputPoller.instance.rightControllerGripFloat == 1f;
			if (flag)
			{
				RaycastHit raycastHit;
				Physics.Raycast(Player.Instance.rightControllerTransform.position - Player.Instance.rightControllerTransform.up, -Player.Instance.rightControllerTransform.up, ref raycastHit);
				bool flag2 = Mods.pointer == null;
				if (flag2)
				{
					Mods.pointer = GameObject.CreatePrimitive(0);
					Object.Destroy(Mods.pointer.GetComponent<Rigidbody>());
					Object.Destroy(Mods.pointer.GetComponent<SphereCollider>());
					Mods.pointer.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
				}
				Mods.pointer.transform.position = raycastHit.point;
				bool flag3 = ControllerInputPoller.instance.rightControllerIndexFloat == 1f;
				if (flag3)
				{
					bool flag4 = !Mods.teleportGunAntiRepeat;
					if (flag4)
					{
						GameObject gameObject = GameObject.CreatePrimitive(3);
						gameObject.name = "trmapol:D";
						gameObject.transform.position = Mods.pointer.transform.position;
						gameObject.transform.rotation = Mods.pointer.transform.rotation;
						gameObject.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
						gameObject.AddComponent<GorillaSurfaceOverride>();
						gameObject.GetComponent<GorillaSurfaceOverride>().overrideIndex = 202;
						gameObject.GetComponent<GorillaSurfaceOverride>().extraVelMultiplier = 1.4f;
						gameObject.GetComponent<GorillaSurfaceOverride>().extraVelMaxMultiplier = 1.7f;
						gameObject.GetComponent<Renderer>().material.color = Color.grey;
						Mods.teleportGunAntiRepeat = true;
					}
				}
				else
				{
					Mods.teleportGunAntiRepeat = false;
				}
			}
			else
			{
				Object.Destroy(Mods.pointer);
				Mods.pointer = null;
				Mods.teleportGunAntiRepeat = false;
			}
		}

		// Token: 0x060000A4 RID: 164 RVA: 0x0000DD30 File Offset: 0x0000BF30
		public static void SnowBlockGun()
		{
			bool flag = ControllerInputPoller.instance.rightControllerGripFloat == 1f;
			if (flag)
			{
				RaycastHit raycastHit;
				Physics.Raycast(Player.Instance.rightControllerTransform.position - Player.Instance.rightControllerTransform.up, -Player.Instance.rightControllerTransform.up, ref raycastHit);
				bool flag2 = Mods.pointer == null;
				if (flag2)
				{
					Mods.pointer = GameObject.CreatePrimitive(0);
					Object.Destroy(Mods.pointer.GetComponent<Rigidbody>());
					Object.Destroy(Mods.pointer.GetComponent<SphereCollider>());
					Mods.pointer.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
				}
				Mods.pointer.transform.position = raycastHit.point;
				bool flag3 = ControllerInputPoller.instance.rightControllerIndexFloat == 1f;
				if (flag3)
				{
					bool flag4 = !Mods.teleportGunAntiRepeat;
					if (flag4)
					{
						GameObject gameObject = GameObject.CreatePrimitive(3);
						gameObject.name = "waterballonsdsw:D";
						gameObject.transform.position = Mods.pointer.transform.position;
						gameObject.transform.rotation = Mods.pointer.transform.rotation;
						gameObject.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
						gameObject.AddComponent<GorillaSurfaceOverride>();
						gameObject.GetComponent<GorillaSurfaceOverride>().overrideIndex = 32;
						gameObject.GetComponent<GorillaSurfaceOverride>().extraVelMultiplier = 1f;
						gameObject.GetComponent<GorillaSurfaceOverride>().extraVelMaxMultiplier = 1f;
						gameObject.GetComponent<Renderer>().material.color = Color.white;
						Mods.teleportGunAntiRepeat = true;
					}
				}
				else
				{
					Mods.teleportGunAntiRepeat = false;
				}
			}
			else
			{
				Object.Destroy(Mods.pointer);
				Mods.pointer = null;
				Mods.teleportGunAntiRepeat = false;
			}
		}

		// Token: 0x060000A5 RID: 165 RVA: 0x0000DF28 File Offset: 0x0000C128
		public static void PunchMod()
		{
			int num = -1;
			foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
			{
				bool flag = vrrig != GorillaTagger.Instance.offlineVRRig;
				if (flag)
				{
					num++;
					Vector3 position = vrrig.rightHandTransform.position;
					Vector3 position2 = GorillaTagger.Instance.offlineVRRig.head.rigTarget.position;
					float num2 = Vector3.Distance(position, position2);
					bool flag2 = (double)num2 < 0.25;
					if (flag2)
					{
						Player.Instance.GetComponent<Rigidbody>().velocity += Vector3.Normalize(vrrig.rightHandTransform.position - Mods.lastRight[num]) * 10f;
					}
					Mods.lastRight[num] = vrrig.rightHandTransform.position;
					position = vrrig.leftHandTransform.position;
					num2 = Vector3.Distance(position, position2);
					bool flag3 = (double)num2 < 0.25;
					if (flag3)
					{
						Player.Instance.GetComponent<Rigidbody>().velocity += Vector3.Normalize(vrrig.leftHandTransform.position - Mods.lastLeft[num]) * 10f;
					}
					Mods.lastLeft[num] = vrrig.leftHandTransform.position;
				}
			}
		}

		// Token: 0x060000A6 RID: 166 RVA: 0x0000E0E0 File Offset: 0x0000C2E0
		public static void goust()
		{
			Player.Instance.rightControllerTransform.transform.position += new Vector3(0f, 10f, 0f);
			Player.Instance.leftControllerTransform.transform.position += new Vector3(0f, 10f, 0f);
		}

		// Token: 0x060000A7 RID: 167 RVA: 0x0000E158 File Offset: 0x0000C358
		public static void goust2()
		{
			Player.Instance.rightControllerTransform.transform.position += new Vector3(0f, 0f, 0f);
			Player.Instance.leftControllerTransform.transform.position += new Vector3(0f, 0f, 0f);
		}

		// Token: 0x060000A8 RID: 168 RVA: 0x0000E1D0 File Offset: 0x0000C3D0
		public static void Draw()
		{
			bool rightGrab = ControllerInputPoller.instance.rightGrab;
			if (rightGrab)
			{
				Mods.drawcube = GameObject.CreatePrimitive(0);
				Object.Destroy(Mods.drawcube.GetComponent<SphereCollider>());
				Object.Destroy(Mods.drawcube.GetComponent<Rigidbody>());
				Mods.drawcube.GetComponent<Renderer>().material.SetColor("_Color", Color.black);
				Mods.drawcube.transform.position = Player.Instance.rightControllerTransform.position;
				Mods.drawcube.transform.localScale = new Vector3(Mods.drawsize, Mods.drawsize, Mods.drawsize);
			}
		}

		// Token: 0x060000A9 RID: 169 RVA: 0x0000E280 File Offset: 0x0000C480
		public static void drawbig()
		{
			Mods.drawsize += 0.1f;
			WristMenu.buttons[127].enabled = new bool?(false);
			WristMenu.DestroyMenu();
			WristMenu.instance.Draw();
		}

		// Token: 0x060000AA RID: 170 RVA: 0x0000E2BC File Offset: 0x0000C4BC
		public static void drawSmall()
		{
			bool flag = (double)Mods.drawsize > 0.0;
			if (flag)
			{
				Mods.drawsize -= 0.1f;
			}
			WristMenu.buttons[128].enabled = new bool?(false);
			WristMenu.DestroyMenu();
			WristMenu.instance.Draw();
		}

		// Token: 0x060000AB RID: 171 RVA: 0x0000E31C File Offset: 0x0000C51C
		public static void cleardraw()
		{
			bool rightGrab = ControllerInputPoller.instance.rightGrab;
			if (rightGrab)
			{
				for (int i = 1; i > 0; i++)
				{
					GameObject.Find("Sphere").SetActive(false);
					GameObject.Find("Sphere").SetActive(false);
					GameObject.Find("Sphere").SetActive(false);
					GameObject.Find("Sphere").SetActive(false);
					GameObject.Find("Sphere").SetActive(false);
					GameObject.Find("Sphere").SetActive(false);
				}
				for (int j = 1; j > 0; j++)
				{
					GameObject.Find("Sphere").SetActive(false);
					GameObject.Find("Sphere").SetActive(false);
					GameObject.Find("Sphere").SetActive(false);
					GameObject.Find("Sphere").SetActive(false);
					GameObject.Find("Sphere").SetActive(false);
					GameObject.Find("Sphere").SetActive(false);
				}
				for (int k = 1; k > 0; k++)
				{
					GameObject.Find("Sphere").SetActive(false);
					GameObject.Find("Sphere").SetActive(false);
					GameObject.Find("Sphere").SetActive(false);
					GameObject.Find("Sphere").SetActive(false);
					GameObject.Find("Sphere").SetActive(false);
					GameObject.Find("Sphere").SetActive(false);
				}
				for (int l = 1; l > 0; l++)
				{
					GameObject.Find("Sphere").SetActive(false);
					GameObject.Find("Sphere").SetActive(false);
					GameObject.Find("Sphere").SetActive(false);
					GameObject.Find("Sphere").SetActive(false);
					GameObject.Find("Sphere").SetActive(false);
					GameObject.Find("Sphere").SetActive(false);
				}
				for (int m = 1; m > 0; m++)
				{
					GameObject.Find("Sphere").SetActive(false);
					GameObject.Find("Sphere").SetActive(false);
					GameObject.Find("Sphere").SetActive(false);
					GameObject.Find("Sphere").SetActive(false);
					GameObject.Find("Sphere").SetActive(false);
					GameObject.Find("Sphere").SetActive(false);
				}
				for (int n = 1; n > 0; n++)
				{
					GameObject.Find("Sphere").SetActive(false);
					GameObject.Find("Sphere").SetActive(false);
					GameObject.Find("Sphere").SetActive(false);
					GameObject.Find("Sphere").SetActive(false);
					GameObject.Find("Sphere").SetActive(false);
					GameObject.Find("Sphere").SetActive(false);
				}
				for (int num = 1; num > 0; num++)
				{
					GameObject.Find("Sphere").SetActive(false);
					GameObject.Find("Sphere").SetActive(false);
					GameObject.Find("Sphere").SetActive(false);
					GameObject.Find("Sphere").SetActive(false);
					GameObject.Find("Sphere").SetActive(false);
					GameObject.Find("Sphere").SetActive(false);
				}
				for (int num2 = 1; num2 > 0; num2++)
				{
					GameObject.Find("Sphere").SetActive(false);
					GameObject.Find("Sphere").SetActive(false);
					GameObject.Find("Sphere").SetActive(false);
					GameObject.Find("Sphere").SetActive(false);
					GameObject.Find("Sphere").SetActive(false);
					GameObject.Find("Sphere").SetActive(false);
				}
				for (int num3 = 1; num3 > 0; num3++)
				{
					GameObject.Find("Sphere").SetActive(false);
					GameObject.Find("Sphere").SetActive(false);
					GameObject.Find("Sphere").SetActive(false);
					GameObject.Find("Sphere").SetActive(false);
					GameObject.Find("Sphere").SetActive(false);
					GameObject.Find("Sphere").SetActive(false);
				}
				for (int num4 = 1; num4 > 0; num4++)
				{
					GameObject.Find("Sphere").SetActive(false);
					GameObject.Find("Sphere").SetActive(false);
					GameObject.Find("Sphere").SetActive(false);
					GameObject.Find("Sphere").SetActive(false);
					GameObject.Find("Sphere").SetActive(false);
					GameObject.Find("Sphere").SetActive(false);
				}
			}
		}

		// Token: 0x060000AC RID: 172 RVA: 0x0000E824 File Offset: 0x0000CA24
		public static void MuteAll()
		{
			bool flag = ControllerInputPoller.instance.rightControllerIndexFloat == 1f;
			if (flag)
			{
				Player[] playerList = PhotonNetwork.PlayerList;
				for (int i = 0; i < playerList.Length; i++)
				{
					Player player = playerList[i];
					GorillaPlayerScoreboardLine[] array = (from x in Object.FindObjectsOfType<GorillaPlayerScoreboardLine>()
					where x.linePlayer == GorillaGameManager.instance.FindVRRigForPlayer(player).Owner
					select x).ToArray<GorillaPlayerScoreboardLine>();
					array[0].PressButton(true, 3);
					foreach (GorillaPlayerScoreboardLine gorillaPlayerScoreboardLine in array)
					{
						gorillaPlayerScoreboardLine.muteButton.isOn = true;
						gorillaPlayerScoreboardLine.muteButton.UpdateColor();
					}
				}
			}
		}

		// Token: 0x060000AD RID: 173 RVA: 0x0000E8E0 File Offset: 0x0000CAE0
		public static void GripFly()
		{
			bool rightGrab = ControllerInputPoller.instance.rightGrab;
			if (rightGrab)
			{
				Player.Instance.transform.position += Player.Instance.headCollider.transform.forward * Time.deltaTime * 15f;
				Player.Instance.GetComponent<Rigidbody>().velocity = Vector3.zero;
			}
		}

		// Token: 0x060000AE RID: 174 RVA: 0x0000E958 File Offset: 0x0000CB58
		public static void Fly()
		{
			bool rightControllerPrimaryButton = ControllerInputPoller.instance.rightControllerPrimaryButton;
			if (rightControllerPrimaryButton)
			{
				Player.Instance.transform.position += Player.Instance.headCollider.transform.forward * Time.deltaTime * 15f;
				Player.Instance.GetComponent<Rigidbody>().velocity = Vector3.zero;
			}
		}

		// Token: 0x060000AF RID: 175 RVA: 0x0000E9D0 File Offset: 0x0000CBD0
		public static void TriggerFly()
		{
			bool flag = ControllerInputPoller.instance.rightControllerIndexFloat == 1f;
			if (flag)
			{
				Player.Instance.transform.position += Player.Instance.headCollider.transform.forward * Time.deltaTime * 15f;
				Player.Instance.GetComponent<Rigidbody>().velocity = Vector3.zero;
			}
		}

		// Token: 0x060000B0 RID: 176 RVA: 0x0000EA50 File Offset: 0x0000CC50
		public static void joystickfly()
		{
			Mods.ljoy = ControllerInputPoller.instance.rightControllerPrimary2DAxis;
			bool flag = Mods.ljoy.y > 0.4f;
			if (flag)
			{
				Player.Instance.transform.position += Player.Instance.headCollider.transform.forward * Time.deltaTime * 14f;
				Player.Instance.GetComponent<Rigidbody>().velocity = Vector3.zero;
			}
			bool flag2 = Mods.ljoy.y < -0.4f;
			if (flag2)
			{
				Player.Instance.transform.position -= Player.Instance.headCollider.transform.forward * Time.deltaTime * 14f;
				Player.Instance.GetComponent<Rigidbody>().velocity = Vector3.zero;
			}
			bool flag3 = Mods.ljoy.x > 0.4f;
			if (flag3)
			{
				Player.Instance.transform.position += Player.Instance.headCollider.transform.right * Time.deltaTime * 14f;
				Player.Instance.GetComponent<Rigidbody>().velocity = Vector3.zero;
			}
			bool flag4 = Mods.ljoy.x < -0.4f;
			if (flag4)
			{
				Player.Instance.transform.position -= Player.Instance.headCollider.transform.right * Time.deltaTime * 14f;
				Player.Instance.GetComponent<Rigidbody>().velocity = Vector3.zero;
			}
			Player.Instance.GetComponent<Rigidbody>().velocity = Vector3.zero;
		}

		// Token: 0x060000B1 RID: 177 RVA: 0x0000EC40 File Offset: 0x0000CE40
		public static void BigBalloon()
		{
			bool inRoom = PhotonNetwork.InRoom;
			if (inRoom)
			{
				foreach (BalloonHoldable balloonHoldable in Object.FindObjectsOfType<BalloonHoldable>())
				{
					balloonHoldable.transform.localScale = new Vector3(5f, 5f, 5f);
				}
			}
			else
			{
				foreach (BalloonHoldable balloonHoldable2 in Object.FindObjectsOfType<BalloonHoldable>())
				{
					balloonHoldable2.transform.localScale = new Vector3(1f, 1f, 1f);
				}
			}
		}

		// Token: 0x060000B2 RID: 178 RVA: 0x0000ECE0 File Offset: 0x0000CEE0
		public static void Reportgun()
		{
			bool flag = ControllerInputPoller.instance.rightControllerGripFloat == 1f;
			if (flag)
			{
				RaycastHit raycastHit;
				bool flag2 = Physics.Raycast(Player.Instance.rightControllerTransform.position - Player.Instance.rightControllerTransform.up, -Player.Instance.rightControllerTransform.up, ref raycastHit) && Mods.pointer == null;
				if (flag2)
				{
					Mods.pointer = GameObject.CreatePrimitive(0);
					Object.Destroy(Mods.pointer.GetComponent<Rigidbody>());
					Object.Destroy(Mods.pointer.GetComponent<SphereCollider>());
					Mods.pointer.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
				}
				Mods.pointer.transform.position = raycastHit.point;
				Player owner = Mods.rig2view(raycastHit.collider.GetComponentInParent<VRRig>()).Owner;
				bool flag3 = ControllerInputPoller.instance.rightControllerIndexFloat == 1f;
				if (flag3)
				{
					GorillaPlayerScoreboardLine[] array = (from x in Object.FindObjectsOfType<GorillaPlayerScoreboardLine>()
					where x.linePlayer == owner
					select x).ToArray<GorillaPlayerScoreboardLine>();
					array[0].PressButton(true, 1);
					array[0].PressButton(true, 2);
					array[0].PressButton(true, 0);
					foreach (GorillaPlayerScoreboardLine gorillaPlayerScoreboardLine in array)
					{
						gorillaPlayerScoreboardLine.reportButton.isOn = true;
						gorillaPlayerScoreboardLine.reportButton.UpdateColor();
					}
				}
			}
			else
			{
				Object.Destroy(Mods.pointer);
			}
		}

		// Token: 0x060000B3 RID: 179 RVA: 0x0000EE8C File Offset: 0x0000D08C
		public static PhotonView rig2view(VRRig p)
		{
			return (PhotonView)Traverse.Create(p).Field("photonView").GetValue();
		}

		// Token: 0x060000B4 RID: 180 RVA: 0x0000EEB8 File Offset: 0x0000D0B8
		public static void Mutegun()
		{
			bool flag = ControllerInputPoller.instance.rightControllerGripFloat == 1f;
			if (flag)
			{
				RaycastHit raycastHit;
				bool flag2 = Physics.Raycast(Player.Instance.rightControllerTransform.position - Player.Instance.rightControllerTransform.up, -Player.Instance.rightControllerTransform.up, ref raycastHit) && Mods.pointer == null;
				if (flag2)
				{
					Mods.pointer = GameObject.CreatePrimitive(0);
					Object.Destroy(Mods.pointer.GetComponent<Rigidbody>());
					Object.Destroy(Mods.pointer.GetComponent<SphereCollider>());
					Mods.pointer.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
				}
				Mods.pointer.transform.position = raycastHit.point;
				Player owner = Mods.rig2view(raycastHit.collider.GetComponentInParent<VRRig>()).Owner;
				bool flag3 = ControllerInputPoller.instance.rightControllerIndexFloat == 1f;
				if (flag3)
				{
					GorillaPlayerScoreboardLine[] array = (from x in Object.FindObjectsOfType<GorillaPlayerScoreboardLine>()
					where x.linePlayer == owner
					select x).ToArray<GorillaPlayerScoreboardLine>();
					array[0].PressButton(true, 3);
					foreach (GorillaPlayerScoreboardLine gorillaPlayerScoreboardLine in array)
					{
						gorillaPlayerScoreboardLine.muteButton.isOn = true;
						gorillaPlayerScoreboardLine.muteButton.UpdateColor();
					}
				}
			}
			else
			{
				Object.Destroy(Mods.pointer);
			}
		}

		// Token: 0x060000B5 RID: 181 RVA: 0x0000F04C File Offset: 0x0000D24C
		public static void TimeDay()
		{
			BetterDayNightManager.instance.SetTimeOfDay(3);
			WristMenu.settingsbuttons[10].enabled = new bool?(false);
			WristMenu.DestroyMenu();
			WristMenu.instance.Draw();
		}

		// Token: 0x060000B6 RID: 182 RVA: 0x0000F085 File Offset: 0x0000D285
		public static void TimeDawn()
		{
			BetterDayNightManager.instance.SetTimeOfDay(1);
			WristMenu.settingsbuttons[11].enabled = new bool?(false);
			WristMenu.DestroyMenu();
			WristMenu.instance.Draw();
		}

		// Token: 0x060000B7 RID: 183 RVA: 0x0000F0BE File Offset: 0x0000D2BE
		public static void TimeNight()
		{
			BetterDayNightManager.instance.SetTimeOfDay(0);
			WristMenu.settingsbuttons[12].enabled = new bool?(false);
			WristMenu.DestroyMenu();
			WristMenu.instance.Draw();
		}

		// Token: 0x060000B8 RID: 184 RVA: 0x0000F0F8 File Offset: 0x0000D2F8
		public static void GrabMonstersR()
		{
			bool rightGrab = ControllerInputPoller.instance.rightGrab;
			if (rightGrab)
			{
				GameObject.Find("Monkeye_Prefab_1").transform.position = GorillaTagger.Instance.rightHandTransform.position;
				GameObject.Find("Monkeye_Prefab_2").transform.position = GorillaTagger.Instance.rightHandTransform.position;
			}
		}

		// Token: 0x060000B9 RID: 185 RVA: 0x0000F160 File Offset: 0x0000D360
		public static void GunLock()
		{
			Mods.gunLock = true;
		}

		// Token: 0x060000BA RID: 186 RVA: 0x0000F169 File Offset: 0x0000D369
		public static void UNGodModLock()
		{
			Mods.gunLock = false;
		}

		// Token: 0x060000BB RID: 187 RVA: 0x0000F174 File Offset: 0x0000D374
		public static void MonstersGun()
		{
			bool rightGrab = ControllerInputPoller.instance.rightGrab;
			if (rightGrab)
			{
				RaycastHit raycastHit;
				bool flag = Physics.Raycast(Player.Instance.rightControllerTransform.position - Player.Instance.rightControllerTransform.up, -Player.Instance.rightControllerTransform.up, ref raycastHit) && Mods.pointer == null;
				bool flag2 = flag;
				if (flag2)
				{
					Mods.pointer = GameObject.CreatePrimitive(0);
					Object.Destroy(Mods.pointer.GetComponent<Rigidbody>());
					Object.Destroy(Mods.pointer.GetComponent<SphereCollider>());
					Mods.pointer.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
				}
				Mods.pointer.transform.position = raycastHit.point;
				bool flag3 = ControllerInputPoller.instance.rightControllerIndexFloat > 0f;
				bool flag4 = flag3;
				if (flag4)
				{
					Mods.pointer.GetComponent<Renderer>().material.color = new Color32(byte.MaxValue, 0, 0, 1);
					GameObject.Find("Monkeye_Prefab_1").transform.position = Mods.pointer.transform.position;
					GameObject.Find("Monkeye_Prefab_2").transform.position = Mods.pointer.transform.position;
				}
				Mods.pointer.GetComponent<Renderer>().material.color = new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, 1);
			}
			else
			{
				Object.Destroy(Mods.pointer);
			}
		}

		// Token: 0x060000BC RID: 188 RVA: 0x0000F320 File Offset: 0x0000D520
		public static void FastSwim()
		{
			bool inWater = Player.Instance.InWater;
			bool flag = inWater;
			if (flag)
			{
				Player.Instance.gameObject.GetComponent<Rigidbody>().velocity *= 1.069f;
			}
		}

		// Token: 0x060000BD RID: 189 RVA: 0x0000F368 File Offset: 0x0000D568
		public static void GripToWallWalkMadeByArms()
		{
			bool rightGrab = ControllerInputPoller.instance.rightGrab;
			if (rightGrab)
			{
				RaycastHit raycastHit;
				Physics.Raycast(Player.Instance.rightControllerTransform.position, Player.Instance.rightControllerTransform.right, ref raycastHit, 100f, 512);
				bool flag = raycastHit.distance < 4f;
				bool flag2 = flag;
				if (flag2)
				{
					Player.Instance.bodyCollider.attachedRigidbody.useGravity = false;
					Player.Instance.bodyCollider.attachedRigidbody.velocity -= raycastHit.normal * (9.8f * Time.deltaTime);
				}
				Player.Instance.bodyCollider.attachedRigidbody.useGravity = true;
			}
		}

		// Token: 0x060000BE RID: 190 RVA: 0x0000F434 File Offset: 0x0000D634
		private static void SetCustomRoomProperties(Hashtable PropertiesToSet)
		{
			PhotonNetwork.CurrentRoom.SetCustomProperties(PropertiesToSet, null, null);
			PhotonNetwork.CurrentRoom.LoadBalancingClient.OpSetCustomPropertiesOfRoom(PropertiesToSet, null, null);
			PhotonNetwork.CurrentRoom.LoadBalancingClient.LoadBalancingPeer.OpSetCustomPropertiesOfRoom(PropertiesToSet);
			PhotonNetwork.NetworkingClient.CurrentRoom.LoadBalancingClient.LoadBalancingPeer.OpSetCustomPropertiesOfRoom(PropertiesToSet);
			PhotonNetwork.NetworkingClient.CurrentRoom.SetCustomProperties(PropertiesToSet, null, null);
			PhotonNetwork.NetworkingClient.CurrentRoom.LoadBalancingClient.OpSetCustomPropertiesOfRoom(PropertiesToSet, null, null);
		}

		// Token: 0x060000BF RID: 191 RVA: 0x0000F4C0 File Offset: 0x0000D6C0
		public static void ChangeGamemodeHunt()
		{
			Hashtable hashtable = new Hashtable();
			hashtable.Add("gameMode", Mods.NewGamemodeType);
			Mods.SetCustomRoomProperties(hashtable);
			Hashtable hashtable2 = new Hashtable();
			hashtable2.Add("gameMode", Mods.NewGamemodeType);
			Hashtable customRoomProperties = hashtable2;
			Mods.SetCustomRoomProperties(customRoomProperties);
			PhotonNetwork.CurrentRoom.CustomProperties["HUNT"] = Mods.NewGamemodeType;
		}

		// Token: 0x060000C0 RID: 192 RVA: 0x0000F528 File Offset: 0x0000D728
		public static void ChangeGamemodeBATTLE()
		{
			Hashtable hashtable = new Hashtable();
			hashtable.Add("gameMode", Mods.NewGamemodeType);
			Mods.SetCustomRoomProperties(hashtable);
			Hashtable hashtable2 = new Hashtable();
			hashtable2.Add("gameMode", Mods.NewGamemodeType);
			Hashtable customRoomProperties = hashtable2;
			Mods.SetCustomRoomProperties(customRoomProperties);
			PhotonNetwork.CurrentRoom.CustomProperties["BATTLE"] = Mods.NewGamemodeType;
		}

		// Token: 0x060000C1 RID: 193 RVA: 0x0000F590 File Offset: 0x0000D790
		public static void ChangeGamemodeINFECTION()
		{
			Hashtable hashtable = new Hashtable();
			hashtable.Add("gameMode", Mods.NewGamemodeType);
			Mods.SetCustomRoomProperties(hashtable);
			Hashtable hashtable2 = new Hashtable();
			hashtable2.Add("gameMode", Mods.NewGamemodeType);
			Hashtable customRoomProperties = hashtable2;
			Mods.SetCustomRoomProperties(customRoomProperties);
			PhotonNetwork.CurrentRoom.CustomProperties["INFECTION"] = Mods.NewGamemodeType;
		}

		// Token: 0x060000C2 RID: 194 RVA: 0x0000F5F8 File Offset: 0x0000D7F8
		public static void GrabForest()
		{
			bool rightGrab = ControllerInputPoller.instance.rightGrab;
			if (rightGrab)
			{
				GameObject.Find("Uncover ForestCombined").transform.position = Player.Instance.rightHandFollower.transform.position;
				GameObject.Find("Uncover ForestCombined").transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
			}
			else
			{
				GameObject.Find("Uncover ForestCombined").transform.localScale = new Vector3(1f, 1f, 1f);
				GameObject.Find("Uncover ForestCombined").transform.position = new Vector3(-55.2344f, 2.0516f, -56.9323f);
			}
		}

		// Token: 0x060000C3 RID: 195 RVA: 0x0000F6C0 File Offset: 0x0000D8C0
		public static void RainbowSnowballs()
		{
			bool flag = Mods.cooldown2 < Time.time;
			bool flag2 = flag;
			if (flag2)
			{
				foreach (SnowballThrowable snowballThrowable in Object.FindObjectsOfType<SnowballThrowable>())
				{
					bool flag3 = !snowballThrowable.randomizeColor;
					bool flag4 = flag3;
					if (flag4)
					{
						snowballThrowable.randomizeColor = true;
					}
				}
				Mods.cooldown2 = Time.time + 0.1f;
			}
		}

		// Token: 0x060000C4 RID: 196 RVA: 0x0000F72C File Offset: 0x0000D92C
		public static void Timewierd()
		{
			GameObject.Find("Environment Objects/LocalObjects_Prefab/Standard Sky").SetActive(false);
			WristMenu.settingsbuttons[13].enabled = new bool?(false);
			WristMenu.DestroyMenu();
			WristMenu.instance.Draw();
		}

		// Token: 0x060000C5 RID: 197 RVA: 0x0000F768 File Offset: 0x0000D968
		public static void BugGun()
		{
			bool rightGrab = ControllerInputPoller.instance.rightGrab;
			if (rightGrab)
			{
				RaycastHit raycastHit;
				bool flag = Physics.Raycast(Player.Instance.rightControllerTransform.position - Player.Instance.rightControllerTransform.up, -Player.Instance.rightControllerTransform.up, ref raycastHit) && Mods.pointer == null;
				bool flag2 = flag;
				if (flag2)
				{
					Mods.pointer = GameObject.CreatePrimitive(0);
					Object.Destroy(Mods.pointer.GetComponent<Rigidbody>());
					Object.Destroy(Mods.pointer.GetComponent<SphereCollider>());
					Mods.pointer.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
				}
				Mods.pointer.transform.position = raycastHit.point;
				bool flag3 = ControllerInputPoller.instance.rightControllerIndexFloat > 0f;
				bool flag4 = flag3;
				if (flag4)
				{
					Mods.pointer.GetComponent<Renderer>().material.color = new Color32(byte.MaxValue, 0, 0, 1);
					GameObject.Find("Floating Bug Holdable").transform.position = Mods.pointer.transform.position;
				}
				Mods.pointer.GetComponent<Renderer>().material.color = new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, 1);
			}
			else
			{
				Object.Destroy(Mods.pointer);
			}
		}

		// Token: 0x060000C6 RID: 198 RVA: 0x0000F8EF File Offset: 0x0000DAEF
		public static void norpc()
		{
			GorillaNot.instance.rpcCallLimit = 999999999;
			PhotonNetwork.RemoveRPCs(PhotonNetwork.LocalPlayer);
		}

		// Token: 0x060000C7 RID: 199 RVA: 0x0000F90E File Offset: 0x0000DB0E
		public static void redandblack()
		{
		}

		// Token: 0x060000C8 RID: 200 RVA: 0x0000F914 File Offset: 0x0000DB14
		public static void RopeSpaz()
		{
			bool flag = ControllerInputPoller.instance.rightControllerGripFloat > 0f;
			bool flag2 = flag;
			if (flag2)
			{
				bool flag3 = Time.time > Mods.cooldown;
				bool flag4 = flag3;
				bool flag5 = flag4;
				if (flag5)
				{
					Mods.cooldown = Time.time + 0.1f;
					GorillaRopeSwing[] array = Object.FindObjectsOfType<GorillaRopeSwing>();
					for (int i = 0; i < array.Length; i++)
					{
						PhotonView photonView = array[i].photonView;
						string text = "SetVelocity";
						RpcTarget rpcTarget = 0;
						object[] array2 = new object[4];
						array2[0] = 1;
						array2[1] = new Vector3((float)Random.Range(0, 300), 0f, (float)Random.Range(-300, 300));
						array2[2] = true;
						photonView.RPC(text, rpcTarget, array2);
						Mods.norpc();
					}
				}
			}
		}

		// Token: 0x060000C9 RID: 201 RVA: 0x0000FA08 File Offset: 0x0000DC08
		public static void RopeUp()
		{
			bool rightGrab = ControllerInputPoller.instance.rightGrab;
			if (rightGrab)
			{
				bool flag = Time.time > Mods.ropetimeout + 0.5f;
				if (flag)
				{
					Mods.ropetimeout = Time.time;
					foreach (GorillaRopeSwing gorillaRopeSwing in Object.FindObjectsOfType<GorillaRopeSwing>())
					{
						PhotonView photonView = gorillaRopeSwing.photonView;
						string text = "SetVelocity";
						RpcTarget rpcTarget = 0;
						object[] array2 = new object[4];
						array2[0] = 4;
						array2[1] = new Vector3(0f, 100f, 0f);
						array2[2] = true;
						photonView.RPC(text, rpcTarget, array2);
					}
				}
			}
		}

		// Token: 0x060000CA RID: 202 RVA: 0x0000FAB0 File Offset: 0x0000DCB0
		public static void Strobe()
		{
			bool flag = Mods.balll2 < Time.time;
			if (flag)
			{
				Mods.balll2 = Time.time + 0.08f;
				Color color = Color.white;
				int num = Random.Range(0, 11);
				bool flag2 = num == 0;
				if (flag2)
				{
					color = Color.black;
				}
				bool flag3 = num == 1;
				if (flag3)
				{
					color = Color.white;
				}
				bool flag4 = num == 2;
				if (flag4)
				{
					color = Color.yellow;
				}
				bool flag5 = num == 3;
				if (flag5)
				{
					color = Color.red;
				}
				bool flag6 = num == 4;
				if (flag6)
				{
					color = Color.green;
				}
				bool flag7 = num == 5;
				if (flag7)
				{
					color = Color.magenta;
				}
				bool flag8 = num == 6;
				if (flag8)
				{
					color = Color.cyan;
				}
				bool flag9 = num == 7;
				if (flag9)
				{
					color = Color.grey;
				}
				bool flag10 = num == 8;
				if (flag10)
				{
					color = Color.clear;
				}
				bool flag11 = num == 9;
				if (flag11)
				{
					color = Color.blue;
				}
				bool flag12 = num == 10;
				if (flag12)
				{
					color = Color.black;
				}
				Mods.ChangeMonkColor(color);
				Mods.flushmanually();
			}
		}

		// Token: 0x060000CB RID: 203 RVA: 0x0000FBC8 File Offset: 0x0000DDC8
		public static void ChangeMonkColor(Color color)
		{
			bool flag = GorillaComputer.instance.friendJoinCollider.playerIDsCurrentlyTouching.Contains(PhotonNetwork.LocalPlayer.UserId);
			if (flag)
			{
				GorillaTagger.Instance.myVRRig.RPC("InitializeNoobMaterial", 0, new object[]
				{
					color.r,
					color.g,
					color.b,
					false
				});
			}
		}

		// Token: 0x060000CC RID: 204 RVA: 0x0000FC4C File Offset: 0x0000DE4C
		public static void Freeze()
		{
			bool flag = Mods.ropedelay < Time.time && WristMenu.gripDownR;
			if (flag)
			{
				Mods.ropedelay = Time.time + 0.1f;
				Object[] array = Object.FindObjectsOfType(typeof(GorillaRopeSwing));
				for (int i = 0; i < array.Length; i++)
				{
					PhotonView photonView = ((GorillaRopeSwing)array[i]).photonView;
					string text = "SetVelocity";
					RpcTarget rpcTarget = 0;
					object[] array2 = new object[4];
					array2[0] = 10;
					array2[1] = Player.Instance.bodyCollider.center;
					array2[2] = true;
					photonView.RPC(text, rpcTarget, array2);
					Mods.flushmanually();
				}
			}
		}

		// Token: 0x060000CD RID: 205 RVA: 0x0000FD10 File Offset: 0x0000DF10
		public static void Ropedown()
		{
			bool rightGrab = ControllerInputPoller.instance.rightGrab;
			if (rightGrab)
			{
				bool flag = Time.time > Mods.ropetimeout + 0.5f;
				if (flag)
				{
					Mods.ropetimeout = Time.time;
					foreach (GorillaRopeSwing gorillaRopeSwing in Object.FindObjectsOfType<GorillaRopeSwing>())
					{
						PhotonView photonView = gorillaRopeSwing.photonView;
						string text = "SetVelocity";
						RpcTarget rpcTarget = 0;
						object[] array2 = new object[4];
						array2[0] = 4;
						array2[1] = new Vector3(0f, -100f, 0f);
						array2[2] = true;
						photonView.RPC(text, rpcTarget, array2);
					}
				}
			}
		}

		// Token: 0x060000CE RID: 206 RVA: 0x0000FDB8 File Offset: 0x0000DFB8
		public static void SpazAll()
		{
			foreach (Player player in PhotonNetwork.PlayerList)
			{
				GorillaTagger.Instance.offlineVRRig.head.rigTarget.eulerAngles = new Vector3((float)Random.Range(0, 360), (float)Random.Range(0, 360), (float)Random.Range(0, 360));
				GorillaTagger.Instance.offlineVRRig.leftHand.rigTarget.eulerAngles = new Vector3((float)Random.Range(0, 360), (float)Random.Range(0, 360), (float)Random.Range(0, 360));
				GorillaTagger.Instance.offlineVRRig.rightHand.rigTarget.eulerAngles = new Vector3((float)Random.Range(0, 360), (float)Random.Range(0, 360), (float)Random.Range(0, 360));
				GorillaTagger.Instance.offlineVRRig.head.rigTarget.eulerAngles = new Vector3((float)Random.Range(0, 360), (float)Random.Range(0, 180), (float)Random.Range(0, 180));
				GorillaTagger.Instance.offlineVRRig.leftHand.rigTarget.eulerAngles = new Vector3((float)Random.Range(0, 360), (float)Random.Range(0, 180), (float)Random.Range(0, 180));
				GorillaTagger.Instance.offlineVRRig.rightHand.rigTarget.eulerAngles = new Vector3((float)Random.Range(0, 360), (float)Random.Range(0, 180), (float)Random.Range(0, 180));
			}
		}

		// Token: 0x060000CF RID: 207 RVA: 0x0000FF7C File Offset: 0x0000E17C
		public static void TagAll()
		{
			bool flag = !GorillaTagger.Instance.offlineVRRig.mainSkin.material.name.Contains("fected");
			bool flag2 = flag;
			if (flag2)
			{
				NotifiLib.SendNotification("<color=grey>[</color><color=red>ERROR</color><color=grey>]</color> <color=white>You must be tagged.</color>");
			}
			else
			{
				bool flag3 = false;
				foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
				{
					bool flag4 = !vrrig.mainSkin.material.name.Contains("fected");
					bool flag5 = flag4;
					if (flag5)
					{
						flag3 = true;
						break;
					}
				}
				bool flag6 = flag3;
				bool flag7 = flag6;
				if (flag7)
				{
					foreach (VRRig vrrig2 in GorillaParent.instance.vrrigs)
					{
						bool flag8 = !vrrig2.mainSkin.material.name.Contains("fected");
						bool flag9 = flag8;
						if (flag9)
						{
							bool enabled = GorillaTagger.Instance.offlineVRRig.enabled;
							bool flag10 = enabled;
							if (flag10)
							{
								GorillaTagger.Instance.offlineVRRig.enabled = false;
							}
							GorillaTagger.Instance.offlineVRRig.transform.position = vrrig2.transform.position;
							GorillaTagger.Instance.myVRRig.transform.position = vrrig2.transform.position;
							Vector3 position = vrrig2.transform.position;
							Vector3 position2 = GorillaTagger.Instance.offlineVRRig.head.rigTarget.position;
							float num = Vector3.Distance(position, position2);
							bool flag11 = GorillaTagger.Instance.offlineVRRig.mainSkin.material.name.Contains("fected") && !vrrig2.mainSkin.material.name.Contains("fected") && (double)num < 1.667;
							bool flag12 = flag11;
							if (flag12)
							{
								bool flag13 = Mods.rightHand;
								bool flag14 = flag13;
								if (flag14)
								{
									Player.Instance.rightControllerTransform.position = position;
								}
								else
								{
									Player.Instance.leftControllerTransform.position = position;
								}
							}
						}
					}
				}
				else
				{
					NotifiLib.SendNotification("<color=grey>[</color><color=green>SUCCESS</color><color=grey>]</color> <color=white>Everyone is tagged!</color>");
					GorillaTagger.Instance.offlineVRRig.enabled = true;
				}
			}
		}

		// Token: 0x060000D0 RID: 208 RVA: 0x00010240 File Offset: 0x0000E440
		public static void OFFTagAll()
		{
			bool flag = !Mods.baweiofjwf;
			if (flag)
			{
				GorillaTagger.Instance.offlineVRRig.enabled = true;
				Mods.baweiofjwf = true;
			}
		}

		// Token: 0x060000D1 RID: 209 RVA: 0x00010273 File Offset: 0x0000E473
		public static void SetTimer(int index, int value)
		{
			Mods.timers[index] = value;
		}

		// Token: 0x060000D2 RID: 210 RVA: 0x00010280 File Offset: 0x0000E480
		public static int GetTimer(int index)
		{
			return Mods.timers[index];
		}

		// Token: 0x060000D3 RID: 211 RVA: 0x0001029C File Offset: 0x0000E49C
		public static int IncrementTimer(int index)
		{
			Mods.timers[index]++;
			return Mods.timers[index];
		}

		// Token: 0x060000D4 RID: 212 RVA: 0x000102C8 File Offset: 0x0000E4C8
		public static void SlingShotSelf()
		{
			CosmeticsController instance = CosmeticsController.instance;
			CosmeticsController.CosmeticItem itemFromDict = instance.GetItemFromDict("Slingshot");
			instance.ApplyCosmeticItemToSet(GorillaTagger.Instance.offlineVRRig.cosmeticSet, itemFromDict, true, false);
		}

		// Token: 0x060000D5 RID: 213 RVA: 0x00010304 File Offset: 0x0000E504
		public static void AntiTag()
		{
			bool flag = GorillaTagger.Instance.offlineVRRig.mainSkin.material.name.Contains("fected");
			if (!flag)
			{
				foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
				{
					bool flag2 = vrrig.mainSkin.material.name.Contains("fected") && Vector3.Distance(vrrig.transform.position, GorillaTagger.Instance.offlineVRRig.transform.position) <= 7f;
					if (flag2)
					{
						GorillaTagger.Instance.offlineVRRig.enabled = false;
						GorillaTagger.Instance.offlineVRRig.transform.position = Player.Instance.transform.position - new Vector3(0f, 7f, 0f);
					}
				}
				GorillaTagger.Instance.offlineVRRig.enabled = true;
			}
		}

		// Token: 0x060000D6 RID: 214 RVA: 0x00010440 File Offset: 0x0000E640
		public static void TrainGun()
		{
			bool rightGrab = ControllerInputPoller.instance.rightGrab;
			if (rightGrab)
			{
				RaycastHit raycastHit;
				bool flag = Physics.Raycast(Player.Instance.rightControllerTransform.position - Player.Instance.rightControllerTransform.up, -Player.Instance.rightControllerTransform.up, ref raycastHit) && Mods.pointer == null;
				bool flag2 = flag;
				if (flag2)
				{
					Mods.pointer = GameObject.CreatePrimitive(0);
					Object.Destroy(Mods.pointer.GetComponent<Rigidbody>());
					Object.Destroy(Mods.pointer.GetComponent<SphereCollider>());
					Mods.pointer.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
				}
				Mods.pointer.transform.position = raycastHit.point;
				bool flag3 = ControllerInputPoller.instance.rightControllerIndexFloat > 0f;
				bool flag4 = flag3;
				if (flag4)
				{
					Mods.pointer.GetComponent<Renderer>().material.color = new Color32(byte.MaxValue, 0, 0, 1);
					GameObject.Find("Environment Objects/LocalObjects_Prefab/Forest/Holiday2023Forest/Holiday2023Forest_Gameplay/NCTrain_Kit_Prefab").transform.position = Mods.pointer.transform.position;
				}
				Mods.pointer.GetComponent<Renderer>().material.color = new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, 1);
			}
			else
			{
				Object.Destroy(Mods.pointer);
			}
		}

		// Token: 0x060000D7 RID: 215 RVA: 0x000105C7 File Offset: 0x0000E7C7
		public static void Spam()
		{
		}

		// Token: 0x060000D8 RID: 216 RVA: 0x000105CC File Offset: 0x0000E7CC
		public static void Vomit()
		{
			bool rightGrab = ControllerInputPoller.instance.rightGrab;
			if (rightGrab)
			{
				Vector3 position = GorillaTagger.Instance.headCollider.transform.position + GorillaTagger.Instance.headCollider.transform.forward * 0.1f + GorillaTagger.Instance.headCollider.transform.up * -0.15f;
				Vector3 velocity = GorillaTagger.Instance.headCollider.transform.forward * 8.33f;
				Mods.BetaFireProjectile("SnowballProjectile", position, velocity, new Color32(78, 219, 9, byte.MaxValue), false);
			}
		}

		// Token: 0x060000D9 RID: 217 RVA: 0x00010690 File Offset: 0x0000E890
		public static void Pee()
		{
			bool rightGrab = ControllerInputPoller.instance.rightGrab;
			if (rightGrab)
			{
				Vector3 position = Player.Instance.bodyCollider.transform.position + new Vector3(0f, -0.1f, 0f);
				Vector3 velocity = Player.Instance.bodyCollider.transform.forward * Time.deltaTime * 145f;
				Mods.BetaFireProjectile("SlingshotProjectile", position, velocity, new Color32(219, 214, 9, byte.MaxValue), false);
			}
		}

		// Token: 0x060000DA RID: 218 RVA: 0x00010734 File Offset: 0x0000E934
		public static void ClosePee()
		{
			bool rightGrab = ControllerInputPoller.instance.rightGrab;
			if (rightGrab)
			{
				Vector3 position = Player.Instance.bodyCollider.transform.position + new Vector3(0f, -0.1f, 0f);
				Vector3 velocity = Player.Instance.bodyCollider.transform.forward * Time.deltaTime * 45f;
				Mods.BetaFireProjectile("SlingshotProjectile", position, velocity, new Color32(219, 214, 9, byte.MaxValue), false);
			}
		}

		// Token: 0x060000DB RID: 219 RVA: 0x000107D7 File Offset: 0x0000E9D7
		public static void HeadUpside()
		{
			RigShit.GetOwnVRRig().head.trackingRotationOffset.x = 180f;
		}

		// Token: 0x060000DC RID: 220 RVA: 0x000107F3 File Offset: 0x0000E9F3
		public static void HeadBack()
		{
			GorillaTagger.Instance.offlineVRRig.head.trackingRotationOffset.y = 180f;
		}

		// Token: 0x060000DD RID: 221 RVA: 0x00010814 File Offset: 0x0000EA14
		public static void Fixheadback()
		{
			bool flag = Mods.back;
			if (flag)
			{
				Mods.back = false;
				RigShit.GetOwnVRRig().head.trackingRotationOffset.y = 0f;
			}
		}

		// Token: 0x060000DE RID: 222 RVA: 0x0001084C File Offset: 0x0000EA4C
		public static void Fixheadupside()
		{
			bool flag = Mods.upside;
			if (flag)
			{
				Mods.upside = false;
				RigShit.GetOwnVRRig().head.trackingRotationOffset.x = 0f;
			}
		}

		// Token: 0x060000DF RID: 223 RVA: 0x00010884 File Offset: 0x0000EA84
		public static void LaserPee()
		{
			bool rightGrab = ControllerInputPoller.instance.rightGrab;
			if (rightGrab)
			{
				Vector3 position = Player.Instance.bodyCollider.transform.position + new Vector3(0f, -0.1f, 0f);
				Vector3 velocity = Player.Instance.bodyCollider.transform.forward * Time.deltaTime * 1000f;
				Mods.BetaFireProjectile("SlingshotProjectile", position, velocity, new Color32(219, 214, 9, byte.MaxValue), false);
			}
		}

		// Token: 0x060000E0 RID: 224 RVA: 0x00010928 File Offset: 0x0000EB28
		public static void Cum()
		{
			bool rightGrab = ControllerInputPoller.instance.rightGrab;
			if (rightGrab)
			{
				Vector3 position = Player.Instance.bodyCollider.transform.position + new Vector3(0f, -0.1f, 0f);
				Vector3 velocity = Player.Instance.bodyCollider.transform.forward * Time.deltaTime * 145f;
				Mods.BetaFireProjectile("SlingshotProjectile", position, velocity, new Color32(250, 250, 250, byte.MaxValue), false);
			}
		}

		// Token: 0x060000E1 RID: 225 RVA: 0x000109D0 File Offset: 0x0000EBD0
		public static void CloseCum()
		{
			bool rightGrab = ControllerInputPoller.instance.rightGrab;
			if (rightGrab)
			{
				Vector3 position = Player.Instance.bodyCollider.transform.position + new Vector3(0f, -0.1f, 0f);
				Vector3 velocity = Player.Instance.bodyCollider.transform.forward * Time.deltaTime * 45f;
				Mods.BetaFireProjectile("SlingshotProjectile", position, velocity, new Color32(250, 250, 250, byte.MaxValue), false);
			}
		}

		// Token: 0x060000E2 RID: 226 RVA: 0x00010A78 File Offset: 0x0000EC78
		public static void LaserCum()
		{
			bool rightGrab = ControllerInputPoller.instance.rightGrab;
			if (rightGrab)
			{
				Vector3 position = Player.Instance.bodyCollider.transform.position + new Vector3(0f, -0.1f, 0f);
				Vector3 velocity = Player.Instance.bodyCollider.transform.forward * Time.deltaTime * 1000f;
				Mods.BetaFireProjectile("SlingshotProjectile", position, velocity, new Color32(250, 250, 250, byte.MaxValue), false);
			}
		}

		// Token: 0x060000E3 RID: 227 RVA: 0x00010B20 File Offset: 0x0000ED20
		public static void SnowBallSpam()
		{
			bool rightGrab = ControllerInputPoller.instance.rightGrab;
			if (rightGrab)
			{
				Vector3 position = Player.Instance.rightControllerTransform.transform.position;
				Vector3 currentVelocity = Player.Instance.currentVelocity;
				Vector3 velocity = Vector3.up + Player.Instance.rightControllerTransform.transform.forward;
				Mods.BetaFireProjectile("SnowballProjectile", position, velocity, new Color32(250, 250, 250, byte.MaxValue), false);
			}
			bool leftGrab = ControllerInputPoller.instance.leftGrab;
			if (leftGrab)
			{
				Vector3 position2 = Player.Instance.leftControllerTransform.transform.position;
				Vector3 currentVelocity2 = Player.Instance.currentVelocity;
				Vector3 velocity2 = Vector3.up + Player.Instance.leftControllerTransform.transform.forward;
				Mods.BetaFireProjectile("SnowballProjectile", position2, velocity2, new Color32(250, 250, 250, byte.MaxValue), false);
			}
		}

		// Token: 0x060000E4 RID: 228 RVA: 0x00010C30 File Offset: 0x0000EE30
		public static void SnowBallGun()
		{
			bool rightGrab = ControllerInputPoller.instance.rightGrab;
			if (rightGrab)
			{
				Vector3 position = Player.Instance.rightControllerTransform.transform.position;
				Vector3 velocity = -Player.Instance.rightControllerTransform.up * Time.deltaTime * 1000f;
				Mods.BetaFireProjectile("SnowballProjectile", position, velocity, new Color32(250, 250, 250, byte.MaxValue), false);
			}
			bool leftGrab = ControllerInputPoller.instance.leftGrab;
			if (leftGrab)
			{
				Vector3 position2 = Player.Instance.leftControllerTransform.transform.position;
				Vector3 velocity2 = -Player.Instance.leftControllerTransform.up * Time.deltaTime * 1000f;
				Mods.BetaFireProjectile("SnowballProjectile", position2, velocity2, new Color32(250, 250, 250, byte.MaxValue), false);
			}
		}

		// Token: 0x060000E5 RID: 229 RVA: 0x00010D3C File Offset: 0x0000EF3C
		public static void WaterBallonSpam()
		{
			bool rightGrab = ControllerInputPoller.instance.rightGrab;
			if (rightGrab)
			{
				Vector3 position = Player.Instance.rightControllerTransform.transform.position;
				Vector3 currentVelocity = Player.Instance.currentVelocity;
				Vector3 velocity = Vector3.up + Player.Instance.rightControllerTransform.transform.forward;
				Mods.BetaFireProjectile("WaterBalloonProjectile", position, velocity, new Color32(18, 19, byte.MaxValue, byte.MaxValue), false);
			}
			bool leftGrab = ControllerInputPoller.instance.leftGrab;
			if (leftGrab)
			{
				Vector3 position2 = Player.Instance.leftControllerTransform.transform.position;
				Vector3 currentVelocity2 = Player.Instance.currentVelocity;
				Vector3 velocity2 = Vector3.up + Player.Instance.leftControllerTransform.transform.forward;
				Mods.BetaFireProjectile("WaterBalloonProjectile", position2, velocity2, new Color32(18, 19, byte.MaxValue, byte.MaxValue), false);
			}
		}

		// Token: 0x060000E6 RID: 230 RVA: 0x00010E40 File Offset: 0x0000F040
		public static void WaterBallonGun()
		{
			bool rightGrab = ControllerInputPoller.instance.rightGrab;
			if (rightGrab)
			{
				Vector3 position = Player.Instance.rightControllerTransform.transform.position;
				Vector3 velocity = -Player.Instance.rightControllerTransform.up * Time.deltaTime * 1000f;
				Mods.BetaFireProjectile("WaterBalloonProjectile", position, velocity, new Color32(18, 19, byte.MaxValue, byte.MaxValue), false);
			}
			bool leftGrab = ControllerInputPoller.instance.leftGrab;
			if (leftGrab)
			{
				Vector3 position2 = Player.Instance.leftControllerTransform.transform.position;
				Vector3 velocity2 = -Player.Instance.leftControllerTransform.up * Time.deltaTime * 1000f;
				Mods.BetaFireProjectile("WaterBalloonProjectile", position2, velocity2, new Color32(18, 19, byte.MaxValue, byte.MaxValue), false);
			}
		}

		// Token: 0x060000E7 RID: 231 RVA: 0x00010F40 File Offset: 0x0000F140
		public static void DeadShotSpam()
		{
			bool rightGrab = ControllerInputPoller.instance.rightGrab;
			if (rightGrab)
			{
				Vector3 position = Player.Instance.rightControllerTransform.transform.position;
				Vector3 currentVelocity = Player.Instance.currentVelocity;
				Vector3 velocity = Vector3.up + Player.Instance.rightControllerTransform.transform.forward;
				Mods.BetaFireProjectile("HornsSlingshotProjectile", position, velocity, new Color32(8, byte.MaxValue, 21, byte.MaxValue), false);
			}
			bool leftGrab = ControllerInputPoller.instance.leftGrab;
			if (leftGrab)
			{
				Vector3 position2 = Player.Instance.leftControllerTransform.transform.position;
				Vector3 currentVelocity2 = Player.Instance.currentVelocity;
				Vector3 velocity2 = Vector3.up + Player.Instance.leftControllerTransform.transform.forward;
				Mods.BetaFireProjectile("HornsSlingshotProjectile", position2, velocity2, new Color32(8, byte.MaxValue, 21, byte.MaxValue), false);
			}
		}

		// Token: 0x060000E8 RID: 232 RVA: 0x00011044 File Offset: 0x0000F244
		public static void DeadShotGun()
		{
			bool rightGrab = ControllerInputPoller.instance.rightGrab;
			if (rightGrab)
			{
				Vector3 position = Player.Instance.rightControllerTransform.transform.position;
				Vector3 velocity = -Player.Instance.rightControllerTransform.up * Time.deltaTime * 1000f;
				Mods.BetaFireProjectile("HornsSlingshotProjectile", position, velocity, new Color32(8, byte.MaxValue, 21, byte.MaxValue), false);
			}
			bool leftGrab = ControllerInputPoller.instance.leftGrab;
			if (leftGrab)
			{
				Vector3 position2 = Player.Instance.leftControllerTransform.transform.position;
				Vector3 velocity2 = -Player.Instance.leftControllerTransform.up * Time.deltaTime * 1000f;
				Mods.BetaFireProjectile("HornsSlingshotProjectile", position2, velocity2, new Color32(8, byte.MaxValue, 21, byte.MaxValue), false);
			}
		}

		// Token: 0x060000E9 RID: 233 RVA: 0x00011140 File Offset: 0x0000F340
		public static void LeafSpam()
		{
			bool rightGrab = ControllerInputPoller.instance.rightGrab;
			if (rightGrab)
			{
				Vector3 position = Player.Instance.rightControllerTransform.transform.position;
				Vector3 currentVelocity = Player.Instance.currentVelocity;
				Vector3 velocity = Vector3.up + Player.Instance.rightControllerTransform.transform.forward;
				Mods.BetaFireProjectile("ElfBow_Projectile", position, velocity, new Color32(8, byte.MaxValue, 21, byte.MaxValue), false);
			}
			bool leftGrab = ControllerInputPoller.instance.leftGrab;
			if (leftGrab)
			{
				Vector3 position2 = Player.Instance.leftControllerTransform.transform.position;
				Vector3 currentVelocity2 = Player.Instance.currentVelocity;
				Vector3 velocity2 = Vector3.up + Player.Instance.leftControllerTransform.transform.forward;
				Mods.BetaFireProjectile("ElfBow_Projectile", position2, velocity2, new Color32(8, byte.MaxValue, 21, byte.MaxValue), false);
			}
		}

		// Token: 0x060000EA RID: 234 RVA: 0x00011244 File Offset: 0x0000F444
		public static void LeafGun()
		{
			bool rightGrab = ControllerInputPoller.instance.rightGrab;
			if (rightGrab)
			{
				Vector3 position = Player.Instance.rightControllerTransform.transform.position;
				Vector3 velocity = -Player.Instance.rightControllerTransform.up * Time.deltaTime * 1000f;
				Mods.BetaFireProjectile("ElfBow_Projectile", position, velocity, new Color32(8, byte.MaxValue, 21, byte.MaxValue), false);
			}
			bool leftGrab = ControllerInputPoller.instance.leftGrab;
			if (leftGrab)
			{
				Vector3 position2 = Player.Instance.leftControllerTransform.transform.position;
				Vector3 velocity2 = -Player.Instance.leftControllerTransform.up * Time.deltaTime * 1000f;
				Mods.BetaFireProjectile("ElfBow_Projectile", position2, velocity2, new Color32(8, byte.MaxValue, 21, byte.MaxValue), false);
			}
		}

		// Token: 0x060000EB RID: 235 RVA: 0x00011340 File Offset: 0x0000F540
		public static void CloudSpam()
		{
			bool rightGrab = ControllerInputPoller.instance.rightGrab;
			if (rightGrab)
			{
				Vector3 position = Player.Instance.rightControllerTransform.transform.position;
				Vector3 currentVelocity = Player.Instance.currentVelocity;
				Vector3 velocity = Vector3.up + Player.Instance.rightControllerTransform.transform.forward;
				Mods.BetaFireProjectile("CloudSlingshot_Projectile", position, velocity, new Color32(250, 250, 250, byte.MaxValue), false);
			}
			bool leftGrab = ControllerInputPoller.instance.leftGrab;
			if (leftGrab)
			{
				Vector3 position2 = Player.Instance.leftControllerTransform.transform.position;
				Vector3 currentVelocity2 = Player.Instance.currentVelocity;
				Vector3 velocity2 = Vector3.up + Player.Instance.leftControllerTransform.transform.forward;
				Mods.BetaFireProjectile("CloudSlingshot_Projectile", position2, velocity2, new Color32(250, 250, 250, byte.MaxValue), false);
			}
		}

		// Token: 0x060000EC RID: 236 RVA: 0x00011450 File Offset: 0x0000F650
		public static void CloudGun()
		{
			bool rightGrab = ControllerInputPoller.instance.rightGrab;
			if (rightGrab)
			{
				Vector3 position = Player.Instance.rightControllerTransform.transform.position;
				Vector3 velocity = -Player.Instance.rightControllerTransform.up * Time.deltaTime * 1000f;
				Mods.BetaFireProjectile("CloudSlingshot_Projectile", position, velocity, new Color32(250, 250, 250, byte.MaxValue), false);
			}
			bool leftGrab = ControllerInputPoller.instance.leftGrab;
			if (leftGrab)
			{
				Vector3 position2 = Player.Instance.leftControllerTransform.transform.position;
				Vector3 velocity2 = -Player.Instance.leftControllerTransform.up * Time.deltaTime * 1000f;
				Mods.BetaFireProjectile("CloudSlingshot_Projectile", position2, velocity2, new Color32(250, 250, 250, byte.MaxValue), false);
			}
		}

		// Token: 0x060000ED RID: 237 RVA: 0x0001155C File Offset: 0x0000F75C
		public static void IceSpam()
		{
			bool rightGrab = ControllerInputPoller.instance.rightGrab;
			if (rightGrab)
			{
				Vector3 position = Player.Instance.rightControllerTransform.transform.position;
				Vector3 currentVelocity = Player.Instance.currentVelocity;
				Vector3 velocity = Vector3.up + Player.Instance.rightControllerTransform.transform.forward;
				Mods.BetaFireProjectile("IceSlingshot_Projectile", position, velocity, new Color32(129, 236, 253, byte.MaxValue), false);
			}
			bool leftGrab = ControllerInputPoller.instance.leftGrab;
			if (leftGrab)
			{
				Vector3 position2 = Player.Instance.leftControllerTransform.transform.position;
				Vector3 currentVelocity2 = Player.Instance.currentVelocity;
				Vector3 velocity2 = Vector3.up + Player.Instance.leftControllerTransform.transform.forward;
				Mods.BetaFireProjectile("IceSlingshot_Projectile", position2, velocity2, new Color32(129, 236, 253, byte.MaxValue), false);
			}
		}

		// Token: 0x060000EE RID: 238 RVA: 0x0001166C File Offset: 0x0000F86C
		public static void IceGun()
		{
			bool rightGrab = ControllerInputPoller.instance.rightGrab;
			if (rightGrab)
			{
				Vector3 position = Player.Instance.rightControllerTransform.transform.position;
				Vector3 velocity = -Player.Instance.rightControllerTransform.up * Time.deltaTime * 1000f;
				Mods.BetaFireProjectile("IceSlingshot_Projectile", position, velocity, new Color32(129, 236, 253, byte.MaxValue), false);
			}
			bool leftGrab = ControllerInputPoller.instance.leftGrab;
			if (leftGrab)
			{
				Vector3 position2 = Player.Instance.leftControllerTransform.transform.position;
				Vector3 velocity2 = -Player.Instance.leftControllerTransform.up * Time.deltaTime * 1000f;
				Mods.BetaFireProjectile("IceSlingshot_Projectile", position2, velocity2, new Color32(129, 236, 253, byte.MaxValue), false);
			}
		}

		// Token: 0x060000EF RID: 239 RVA: 0x00011778 File Offset: 0x0000F978
		public static void RockSpam()
		{
			bool rightGrab = ControllerInputPoller.instance.rightGrab;
			if (rightGrab)
			{
				Vector3 position = Player.Instance.rightControllerTransform.transform.position;
				Vector3 currentVelocity = Player.Instance.currentVelocity;
				Vector3 velocity = Vector3.up + Player.Instance.rightControllerTransform.transform.forward;
				Mods.BetaFireProjectile("LavaRockProjectile", position, velocity, new Color32(250, 250, 250, byte.MaxValue), false);
			}
			bool leftGrab = ControllerInputPoller.instance.leftGrab;
			if (leftGrab)
			{
				Vector3 position2 = Player.Instance.leftControllerTransform.transform.position;
				Vector3 currentVelocity2 = Player.Instance.currentVelocity;
				Vector3 velocity2 = Vector3.up + Player.Instance.leftControllerTransform.transform.forward;
				Mods.BetaFireProjectile("LavaRockProjectile", position2, velocity2, new Color32(250, 250, 250, byte.MaxValue), false);
			}
		}

		// Token: 0x060000F0 RID: 240 RVA: 0x00011888 File Offset: 0x0000FA88
		public static void RockGun()
		{
			bool rightGrab = ControllerInputPoller.instance.rightGrab;
			if (rightGrab)
			{
				Vector3 position = Player.Instance.rightControllerTransform.transform.position;
				Vector3 velocity = -Player.Instance.rightControllerTransform.up * Time.deltaTime * 1000f;
				Mods.BetaFireProjectile("LavaRockProjectile", position, velocity, new Color32(250, 250, 250, byte.MaxValue), false);
			}
			bool leftGrab = ControllerInputPoller.instance.leftGrab;
			if (leftGrab)
			{
				Vector3 position2 = Player.Instance.leftControllerTransform.transform.position;
				Vector3 velocity2 = -Player.Instance.leftControllerTransform.up * Time.deltaTime * 1000f;
				Mods.BetaFireProjectile("LavaRockProjectile", position2, velocity2, new Color32(250, 250, 250, byte.MaxValue), false);
			}
		}

		// Token: 0x060000F1 RID: 241 RVA: 0x00011994 File Offset: 0x0000FB94
		public static void MoltRockSpam()
		{
			bool rightGrab = ControllerInputPoller.instance.rightGrab;
			if (rightGrab)
			{
				Vector3 position = Player.Instance.rightControllerTransform.transform.position;
				Vector3 currentVelocity = Player.Instance.currentVelocity;
				Vector3 velocity = Vector3.up + Player.Instance.rightControllerTransform.transform.forward;
				Mods.BetaFireProjectile("MoltenSlingshot_Projectile", position, velocity, new Color32(231, 0, 0, byte.MaxValue), false);
			}
			bool leftGrab = ControllerInputPoller.instance.leftGrab;
			if (leftGrab)
			{
				Vector3 position2 = Player.Instance.leftControllerTransform.transform.position;
				Vector3 currentVelocity2 = Player.Instance.currentVelocity;
				Vector3 velocity2 = Vector3.up + Player.Instance.leftControllerTransform.transform.forward;
				Mods.BetaFireProjectile("MoltenSlingshot_Projectile", position2, velocity2, new Color32(231, 0, 0, byte.MaxValue), false);
			}
		}

		// Token: 0x060000F2 RID: 242 RVA: 0x00011A94 File Offset: 0x0000FC94
		public static void MoltRockGun()
		{
			bool rightGrab = ControllerInputPoller.instance.rightGrab;
			if (rightGrab)
			{
				Vector3 position = Player.Instance.rightControllerTransform.transform.position;
				Vector3 velocity = -Player.Instance.rightControllerTransform.up * Time.deltaTime * 1000f;
				Mods.BetaFireProjectile("MoltenSlingshot_Projectile", position, velocity, new Color32(231, 0, 0, byte.MaxValue), false);
			}
			bool leftGrab = ControllerInputPoller.instance.leftGrab;
			if (leftGrab)
			{
				Vector3 position2 = Player.Instance.leftControllerTransform.transform.position;
				Vector3 velocity2 = -Player.Instance.leftControllerTransform.up * Time.deltaTime * 1000f;
				Mods.BetaFireProjectile("MoltenSlingshot_Projectile", position2, velocity2, new Color32(231, 0, 0, byte.MaxValue), false);
			}
		}

		// Token: 0x060000F3 RID: 243 RVA: 0x00011B90 File Offset: 0x0000FD90
		public static void SlingShotSpam()
		{
			bool rightGrab = ControllerInputPoller.instance.rightGrab;
			if (rightGrab)
			{
				Vector3 position = Player.Instance.rightControllerTransform.transform.position;
				Vector3 currentVelocity = Player.Instance.currentVelocity;
				Vector3 velocity = Vector3.up + Player.Instance.rightControllerTransform.transform.forward;
				Mods.BetaFireProjectile("SlingshotProjectile", position, velocity, new Color32(6, 0, 187, byte.MaxValue), false);
			}
			bool leftGrab = ControllerInputPoller.instance.leftGrab;
			if (leftGrab)
			{
				Vector3 position2 = Player.Instance.leftControllerTransform.transform.position;
				Vector3 currentVelocity2 = Player.Instance.currentVelocity;
				Vector3 velocity2 = Vector3.up + Player.Instance.leftControllerTransform.transform.forward;
				Mods.BetaFireProjectile("SlingshotProjectile", position2, velocity2, new Color32(6, 0, 187, byte.MaxValue), false);
			}
		}

		// Token: 0x060000F4 RID: 244 RVA: 0x00011C90 File Offset: 0x0000FE90
		public static void SlingShotGun()
		{
			bool rightGrab = ControllerInputPoller.instance.rightGrab;
			if (rightGrab)
			{
				Vector3 position = Player.Instance.rightControllerTransform.transform.position;
				Vector3 velocity = -Player.Instance.rightControllerTransform.up * Time.deltaTime * 1000f;
				Mods.BetaFireProjectile("SlingshotProjectile", position, velocity, new Color32(6, 0, 187, byte.MaxValue), false);
			}
			bool leftGrab = ControllerInputPoller.instance.leftGrab;
			if (leftGrab)
			{
				Vector3 position2 = Player.Instance.leftControllerTransform.transform.position;
				Vector3 velocity2 = -Player.Instance.leftControllerTransform.up * Time.deltaTime * 1000f;
				Mods.BetaFireProjectile("SlingshotProjectile", position2, velocity2, new Color32(6, 0, 187, byte.MaxValue), false);
			}
		}

		// Token: 0x060000F5 RID: 245 RVA: 0x00011D8C File Offset: 0x0000FF8C
		public static void SpiderSpam()
		{
			bool rightGrab = ControllerInputPoller.instance.rightGrab;
			if (rightGrab)
			{
				Vector3 position = Player.Instance.rightControllerTransform.transform.position;
				Vector3 currentVelocity = Player.Instance.currentVelocity;
				Vector3 velocity = Vector3.up + Player.Instance.rightControllerTransform.transform.forward;
				Mods.BetaFireProjectile("SpiderBow_Projectile", position, velocity, new Color32(250, 250, 250, byte.MaxValue), false);
			}
			bool leftGrab = ControllerInputPoller.instance.leftGrab;
			if (leftGrab)
			{
				Vector3 position2 = Player.Instance.leftControllerTransform.transform.position;
				Vector3 currentVelocity2 = Player.Instance.currentVelocity;
				Vector3 velocity2 = Vector3.up + Player.Instance.leftControllerTransform.transform.forward;
				Mods.BetaFireProjectile("SpiderBow_Projectile", position2, velocity2, new Color32(250, 250, 250, byte.MaxValue), false);
			}
		}

		// Token: 0x060000F6 RID: 246 RVA: 0x00011E9C File Offset: 0x0001009C
		public static void SpiderGun()
		{
			bool rightGrab = ControllerInputPoller.instance.rightGrab;
			if (rightGrab)
			{
				Vector3 position = Player.Instance.rightControllerTransform.transform.position;
				Vector3 velocity = -Player.Instance.rightControllerTransform.up * Time.deltaTime * 1000f;
				Mods.BetaFireProjectile("SpiderBow_Projectile", position, velocity, new Color32(250, 250, 250, byte.MaxValue), false);
			}
			bool leftGrab = ControllerInputPoller.instance.leftGrab;
			if (leftGrab)
			{
				Vector3 position2 = Player.Instance.leftControllerTransform.transform.position;
				Vector3 velocity2 = -Player.Instance.leftControllerTransform.up * Time.deltaTime * 1000f;
				Mods.BetaFireProjectile("SpiderBow_Projectile", position2, velocity2, new Color32(250, 250, 250, byte.MaxValue), false);
			}
		}

		// Token: 0x060000F7 RID: 247 RVA: 0x00011FA8 File Offset: 0x000101A8
		public static void CupidSpam()
		{
			bool rightGrab = ControllerInputPoller.instance.rightGrab;
			if (rightGrab)
			{
				Vector3 position = Player.Instance.rightControllerTransform.transform.position;
				Vector3 currentVelocity = Player.Instance.currentVelocity;
				Vector3 velocity = Vector3.up + Player.Instance.rightControllerTransform.transform.forward;
				Mods.BetaFireProjectile("CupidBow_Projectile", position, velocity, new Color32(249, 0, 0, byte.MaxValue), false);
			}
			bool leftGrab = ControllerInputPoller.instance.leftGrab;
			if (leftGrab)
			{
				Vector3 position2 = Player.Instance.leftControllerTransform.transform.position;
				Vector3 currentVelocity2 = Player.Instance.currentVelocity;
				Vector3 velocity2 = Vector3.up + Player.Instance.leftControllerTransform.transform.forward;
				Mods.BetaFireProjectile("CupidBow_Projectile", position2, velocity2, new Color32(249, 0, 0, byte.MaxValue), false);
			}
		}

		// Token: 0x060000F8 RID: 248 RVA: 0x000120A8 File Offset: 0x000102A8
		public static void CupidGun()
		{
			bool rightGrab = ControllerInputPoller.instance.rightGrab;
			if (rightGrab)
			{
				Vector3 position = Player.Instance.rightControllerTransform.transform.position;
				Vector3 velocity = -Player.Instance.rightControllerTransform.up * Time.deltaTime * 1000f;
				Mods.BetaFireProjectile("CupidBow_Projectile", position, velocity, new Color32(249, 0, 0, byte.MaxValue), false);
			}
			bool leftGrab = ControllerInputPoller.instance.leftGrab;
			if (leftGrab)
			{
				Vector3 position2 = Player.Instance.leftControllerTransform.transform.position;
				Vector3 velocity2 = -Player.Instance.leftControllerTransform.up * Time.deltaTime * 1000f;
				Mods.BetaFireProjectile("CupidBow_Projectile", position2, velocity2, new Color32(249, 0, 0, byte.MaxValue), false);
			}
		}

		// Token: 0x060000F9 RID: 249 RVA: 0x000121A4 File Offset: 0x000103A4
		public static void CoalSpam()
		{
			bool rightGrab = ControllerInputPoller.instance.rightGrab;
			if (rightGrab)
			{
				Vector3 position = Player.Instance.rightControllerTransform.transform.position;
				Vector3 currentVelocity = Player.Instance.currentVelocity;
				Vector3 velocity = Vector3.up + Player.Instance.rightControllerTransform.transform.forward;
				Mods.BetaFireProjectile("BucketGiftCoal", position, velocity, new Color32(24, 24, 22, byte.MaxValue), false);
			}
			bool leftGrab = ControllerInputPoller.instance.leftGrab;
			if (leftGrab)
			{
				Vector3 position2 = Player.Instance.leftControllerTransform.transform.position;
				Vector3 currentVelocity2 = Player.Instance.currentVelocity;
				Vector3 velocity2 = Vector3.up + Player.Instance.leftControllerTransform.transform.forward;
				Mods.BetaFireProjectile("BucketGiftCoal", position2, velocity2, new Color32(24, 24, 22, byte.MaxValue), false);
			}
		}

		// Token: 0x060000FA RID: 250 RVA: 0x000122A4 File Offset: 0x000104A4
		public static void CoalGun()
		{
			bool rightGrab = ControllerInputPoller.instance.rightGrab;
			if (rightGrab)
			{
				Vector3 position = Player.Instance.rightControllerTransform.transform.position;
				Vector3 velocity = -Player.Instance.rightControllerTransform.up * Time.deltaTime * 1000f;
				Mods.BetaFireProjectile("BucketGiftCoal", position, velocity, new Color32(24, 24, 22, byte.MaxValue), false);
			}
			bool leftGrab = ControllerInputPoller.instance.leftGrab;
			if (leftGrab)
			{
				Vector3 position2 = Player.Instance.leftControllerTransform.transform.position;
				Vector3 velocity2 = -Player.Instance.leftControllerTransform.up * Time.deltaTime * 1000f;
				Mods.BetaFireProjectile("BucketGiftCoal", position2, velocity2, new Color32(24, 24, 22, byte.MaxValue), false);
			}
		}

		// Token: 0x060000FB RID: 251 RVA: 0x0001239C File Offset: 0x0001059C
		public static void CaneSpam()
		{
			bool rightGrab = ControllerInputPoller.instance.rightGrab;
			if (rightGrab)
			{
				Vector3 position = Player.Instance.rightControllerTransform.transform.position;
				Vector3 currentVelocity = Player.Instance.currentVelocity;
				Vector3 velocity = Vector3.up + Player.Instance.rightControllerTransform.transform.forward;
				Mods.BetaFireProjectile("BucketGiftCane", position, velocity, new Color32(250, 250, 250, byte.MaxValue), false);
			}
			bool leftGrab = ControllerInputPoller.instance.leftGrab;
			if (leftGrab)
			{
				Vector3 position2 = Player.Instance.leftControllerTransform.transform.position;
				Vector3 currentVelocity2 = Player.Instance.currentVelocity;
				Vector3 velocity2 = Vector3.up + Player.Instance.leftControllerTransform.transform.forward;
				Mods.BetaFireProjectile("BucketGiftCane", position2, velocity2, new Color32(250, 250, 250, byte.MaxValue), false);
			}
		}

		// Token: 0x060000FC RID: 252 RVA: 0x000124AC File Offset: 0x000106AC
		public static void CaneGun()
		{
			bool rightGrab = ControllerInputPoller.instance.rightGrab;
			if (rightGrab)
			{
				Vector3 position = Player.Instance.rightControllerTransform.transform.position;
				Vector3 velocity = -Player.Instance.rightControllerTransform.up * Time.deltaTime * 1000f;
				Mods.BetaFireProjectile("BucketGiftCane", position, velocity, new Color32(250, 250, 250, byte.MaxValue), false);
			}
			bool leftGrab = ControllerInputPoller.instance.leftGrab;
			if (leftGrab)
			{
				Vector3 position2 = Player.Instance.leftControllerTransform.transform.position;
				Vector3 velocity2 = -Player.Instance.leftControllerTransform.up * Time.deltaTime * 1000f;
				Mods.BetaFireProjectile("BucketGiftCane", position2, velocity2, new Color32(250, 250, 250, byte.MaxValue), false);
			}
		}

		// Token: 0x060000FD RID: 253 RVA: 0x000125B8 File Offset: 0x000107B8
		public static void RollSpam()
		{
			bool rightGrab = ControllerInputPoller.instance.rightGrab;
			if (rightGrab)
			{
				Vector3 position = Player.Instance.rightControllerTransform.transform.position;
				Vector3 currentVelocity = Player.Instance.currentVelocity;
				Vector3 velocity = Vector3.up + Player.Instance.rightControllerTransform.transform.forward;
				Mods.BetaFireProjectile("BucketGiftRoll", position, velocity, new Color32(250, 250, 250, byte.MaxValue), false);
			}
			bool leftGrab = ControllerInputPoller.instance.leftGrab;
			if (leftGrab)
			{
				Vector3 position2 = Player.Instance.leftControllerTransform.transform.position;
				Vector3 currentVelocity2 = Player.Instance.currentVelocity;
				Vector3 velocity2 = Vector3.up + Player.Instance.leftControllerTransform.transform.forward;
				Mods.BetaFireProjectile("BucketGiftRoll", position2, velocity2, new Color32(250, 250, 250, byte.MaxValue), false);
			}
		}

		// Token: 0x060000FE RID: 254 RVA: 0x000126C8 File Offset: 0x000108C8
		public static void RollGun()
		{
			bool rightGrab = ControllerInputPoller.instance.rightGrab;
			if (rightGrab)
			{
				Vector3 position = Player.Instance.rightControllerTransform.transform.position;
				Vector3 velocity = -Player.Instance.rightControllerTransform.up * Time.deltaTime * 1000f;
				Mods.BetaFireProjectile("BucketGiftRoll", position, velocity, new Color32(250, 250, 250, byte.MaxValue), false);
			}
			bool leftGrab = ControllerInputPoller.instance.leftGrab;
			if (leftGrab)
			{
				Vector3 position2 = Player.Instance.leftControllerTransform.transform.position;
				Vector3 velocity2 = -Player.Instance.leftControllerTransform.up * Time.deltaTime * 1000f;
				Mods.BetaFireProjectile("BucketGiftRoll", position2, velocity2, new Color32(250, 250, 250, byte.MaxValue), false);
			}
		}

		// Token: 0x060000FF RID: 255 RVA: 0x000127D4 File Offset: 0x000109D4
		public static void SquareSpam()
		{
			bool rightGrab = ControllerInputPoller.instance.rightGrab;
			if (rightGrab)
			{
				Vector3 position = Player.Instance.rightControllerTransform.transform.position;
				Vector3 currentVelocity = Player.Instance.currentVelocity;
				Vector3 velocity = Vector3.up + Player.Instance.rightControllerTransform.transform.forward;
				Mods.BetaFireProjectile("BucketGiftSquare", position, velocity, new Color32(250, 250, 250, byte.MaxValue), false);
			}
			bool leftGrab = ControllerInputPoller.instance.leftGrab;
			if (leftGrab)
			{
				Vector3 position2 = Player.Instance.leftControllerTransform.transform.position;
				Vector3 currentVelocity2 = Player.Instance.currentVelocity;
				Vector3 velocity2 = Vector3.up + Player.Instance.leftControllerTransform.transform.forward;
				Mods.BetaFireProjectile("BucketGiftSquare", position2, velocity2, new Color32(250, 250, 250, byte.MaxValue), false);
			}
		}

		// Token: 0x06000100 RID: 256 RVA: 0x000128E4 File Offset: 0x00010AE4
		public static void SquareGun()
		{
			bool rightGrab = ControllerInputPoller.instance.rightGrab;
			if (rightGrab)
			{
				Vector3 position = Player.Instance.rightControllerTransform.transform.position;
				Vector3 velocity = -Player.Instance.rightControllerTransform.up * Time.deltaTime * 1000f;
				Mods.BetaFireProjectile("BucketGiftSquare", position, velocity, new Color32(250, 250, 250, byte.MaxValue), false);
			}
			bool leftGrab = ControllerInputPoller.instance.leftGrab;
			if (leftGrab)
			{
				Vector3 position2 = Player.Instance.leftControllerTransform.transform.position;
				Vector3 velocity2 = -Player.Instance.leftControllerTransform.up * Time.deltaTime * 1000f;
				Mods.BetaFireProjectile("BucketGiftSquare", position2, velocity2, new Color32(250, 250, 250, byte.MaxValue), false);
			}
		}

		// Token: 0x06000101 RID: 257 RVA: 0x000129F0 File Offset: 0x00010BF0
		public static void RoundSpam()
		{
			bool rightGrab = ControllerInputPoller.instance.rightGrab;
			if (rightGrab)
			{
				Vector3 position = Player.Instance.rightControllerTransform.transform.position;
				Vector3 currentVelocity = Player.Instance.currentVelocity;
				Vector3 velocity = Vector3.up + Player.Instance.rightControllerTransform.transform.forward;
				Mods.BetaFireProjectile("BucketGiftRound", position, velocity, new Color32(250, 250, 250, byte.MaxValue), false);
			}
			bool leftGrab = ControllerInputPoller.instance.leftGrab;
			if (leftGrab)
			{
				Vector3 position2 = Player.Instance.leftControllerTransform.transform.position;
				Vector3 currentVelocity2 = Player.Instance.currentVelocity;
				Vector3 velocity2 = Vector3.up + Player.Instance.leftControllerTransform.transform.forward;
				Mods.BetaFireProjectile("BucketGiftRound", position2, velocity2, new Color32(250, 250, 250, byte.MaxValue), false);
			}
		}

		// Token: 0x06000102 RID: 258 RVA: 0x00012B00 File Offset: 0x00010D00
		public static void RoundGun()
		{
			bool rightGrab = ControllerInputPoller.instance.rightGrab;
			if (rightGrab)
			{
				Vector3 position = Player.Instance.rightControllerTransform.transform.position;
				Vector3 velocity = -Player.Instance.rightControllerTransform.up * Time.deltaTime * 1000f;
				Mods.BetaFireProjectile("BucketGiftRound", position, velocity, new Color32(250, 250, 250, byte.MaxValue), false);
			}
			bool leftGrab = ControllerInputPoller.instance.leftGrab;
			if (leftGrab)
			{
				Vector3 position2 = Player.Instance.leftControllerTransform.transform.position;
				Vector3 velocity2 = -Player.Instance.leftControllerTransform.up * Time.deltaTime * 1000f;
				Mods.BetaFireProjectile("BucketGiftRound", position2, velocity2, new Color32(250, 250, 250, byte.MaxValue), false);
			}
		}

		// Token: 0x06000103 RID: 259 RVA: 0x00012C0C File Offset: 0x00010E0C
		public static void Feces()
		{
			bool rightGrab = ControllerInputPoller.instance.rightGrab;
			if (rightGrab)
			{
				Vector3 position = GorillaTagger.Instance.bodyCollider.transform.position + new Vector3(0f, -0.2f, 0f);
				Vector3 zero = Vector3.zero;
				Mods.BetaFireProjectile("SnowballProjectile", position, zero, new Color32(99, 43, 0, byte.MaxValue), false);
			}
		}

		// Token: 0x06000104 RID: 260 RVA: 0x00012C84 File Offset: 0x00010E84
		public static void HaveAPeriod()
		{
			bool rightGrab = ControllerInputPoller.instance.rightGrab;
			if (rightGrab)
			{
				Vector3 position = GorillaTagger.Instance.bodyCollider.transform.position + new Vector3(0f, -0.2f, 0f);
				Vector3 zero = Vector3.zero;
				Mods.BetaFireProjectile("SlingshotProjectile", position, zero, new Color32(198, 9, 15, byte.MaxValue), false);
			}
		}

		// Token: 0x06000105 RID: 261 RVA: 0x00012D00 File Offset: 0x00010F00
		public static void ThrowPoop()
		{
			bool rightGrab = ControllerInputPoller.instance.rightGrab;
			if (rightGrab)
			{
				Vector3 position = Player.Instance.rightControllerTransform.transform.position;
				Vector3 velocity = -Player.Instance.rightControllerTransform.up * Time.deltaTime * 600f;
				Mods.BetaFireProjectile("SnowballProjectile", position, velocity, new Color32(99, 43, 0, byte.MaxValue), false);
			}
		}

		// Token: 0x06000106 RID: 262 RVA: 0x00012D80 File Offset: 0x00010F80
		public static void PeriodLanucher()
		{
			bool rightGrab = ControllerInputPoller.instance.rightGrab;
			if (rightGrab)
			{
				Vector3 position = Player.Instance.rightControllerTransform.transform.position;
				Vector3 velocity = -Player.Instance.rightControllerTransform.up * Time.deltaTime * 600f;
				Mods.BetaFireProjectile("SlingshotProjectile", position, velocity, new Color32(198, 9, 15, byte.MaxValue), false);
			}
		}

		// Token: 0x06000107 RID: 263 RVA: 0x00012E04 File Offset: 0x00011004
		public static void WaterHose()
		{
			bool rightGrab = ControllerInputPoller.instance.rightGrab;
			if (rightGrab)
			{
				Vector3 position = Player.Instance.rightControllerTransform.transform.position;
				Vector3 velocity = -Player.Instance.rightControllerTransform.up * Time.deltaTime * 600f;
				Mods.BetaFireProjectile("SlingshotProjectile", position, velocity, new Color32(0, 221, 249, byte.MaxValue), false);
			}
		}

		// Token: 0x06000108 RID: 264 RVA: 0x00012E8C File Offset: 0x0001108C
		public static void BetaFireProjectile(string projectileName, Vector3 position, Vector3 velocity, Color color, bool noDelay = false)
		{
			bool flag = Time.time > Mods.projDebounce;
			if (flag)
			{
				Vector3 velocity2 = GorillaTagger.Instance.GetComponent<Rigidbody>().velocity;
				GorillaTagger.Instance.GetComponent<Rigidbody>().velocity = velocity;
				SnowballThrowable component = GameObject.Find("Player Objects/Local VRRig/Local Gorilla Player/rig/body/shoulder.R/upper_arm.R/forearm.R/hand.R/palm.01.R/TransferrableItemRightHand/SnowballRightAnchor").transform.Find("LMACF.").GetComponent<SnowballThrowable>();
				Vector3 position2 = component.transform.position;
				component.randomizeColor = true;
				GorillaTagger.Instance.offlineVRRig.SetThrowableProjectileColor(false, color);
				component.transform.position = position;
				component.projectilePrefab.tag = projectileName;
				component.OnRelease(null, null);
				try
				{
					Mods.flushmanually();
				}
				catch
				{
				}
				GorillaTagger.Instance.GetComponent<Rigidbody>().velocity = velocity2;
				component.transform.position = position2;
				component.randomizeColor = false;
				component.projectilePrefab.tag = "SnowballProjectile";
				bool flag2 = Mods.projDebounceType > 0f && !noDelay;
				if (flag2)
				{
					Mods.projDebounce = Time.time + Mods.projDebounceType;
				}
			}
		}

		// Token: 0x06000109 RID: 265 RVA: 0x00012FC8 File Offset: 0x000111C8
		public static void GayBalls()
		{
			GameObject.Find("pit ground").GetComponent<SlingshotProjectile>().tag = "CloudSlingshot_Projectile";
		}

		// Token: 0x0600010A RID: 266 RVA: 0x00012FE8 File Offset: 0x000111E8
		public static void Fastbug()
		{
			foreach (ThrowableBug throwableBug in Object.FindObjectsOfType(typeof(ThrowableBug)))
			{
				throwableBug.bobingSpeed = 50f;
				throwableBug.maxNaturalSpeed = 50f;
				throwableBug.startingSpeed = 50f;
			}
		}

		// Token: 0x0600010B RID: 267 RVA: 0x00013044 File Offset: 0x00011244
		public static void ESPOnHuntTarget()
		{
			foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
			{
				bool flag = RigShit.GetRigFromPlayer(GameObject.Find("Gorilla Hunt Manager(Clone)").GetComponent<GorillaHuntManager>().GetTargetOf(PhotonNetwork.LocalPlayer)) == vrrig;
				if (flag)
				{
					vrrig.mainSkin.material.shader = Shader.Find("GUI/Text Shader");
					vrrig.mainSkin.material.color = Color.cyan;
				}
			}
			Mods.widhcnkesdj1 = true;
		}

		// Token: 0x0600010C RID: 268 RVA: 0x000130FC File Offset: 0x000112FC
		public static void TPBehindTarget()
		{
			bool triggerDownR = WristMenu.triggerDownR;
			if (triggerDownR)
			{
				GorillaHuntManager component = GameObject.Find("Gorilla Hunt Manager(Clone)").GetComponent<GorillaHuntManager>();
				foreach (Player player in PhotonNetwork.PlayerListOthers)
				{
					bool flag = player == component.GetTargetOf(PhotonNetwork.LocalPlayer);
					if (flag)
					{
						VRRig rigFromPlayer = RigShit.GetRigFromPlayer(player);
						Player.Instance.transform.position = rigFromPlayer.transform.position + rigFromPlayer.transform.forward * -1f * Time.deltaTime;
						GorillaTagger.Instance.offlineVRRig.transform.position = Player.Instance.transform.position;
					}
				}
			}
		}

		// Token: 0x0600010D RID: 269 RVA: 0x000131D0 File Offset: 0x000113D0
		public static void RightArmGun()
		{
			bool rightGrab = ControllerInputPoller.instance.rightGrab;
			if (rightGrab)
			{
				RaycastHit raycastHit;
				Physics.Raycast(Player.Instance.rightControllerTransform.position - Player.Instance.rightControllerTransform.up, -Player.Instance.rightControllerTransform.up, ref raycastHit);
				bool flag = Mods.pointer == null;
				if (flag)
				{
					Mods.pointer = GameObject.CreatePrimitive(0);
					Object.Destroy(Mods.pointer.GetComponent<Rigidbody>());
					Object.Destroy(Mods.pointer.GetComponent<SphereCollider>());
					Mods.pointer.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
				}
				Mods.pointer.transform.position = raycastHit.point;
				bool flag2 = ControllerInputPoller.instance.rightControllerIndexFloat == 1f;
				if (flag2)
				{
					Player.Instance.rightControllerTransform.position = raycastHit.point;
				}
			}
			else
			{
				Object.Destroy(Mods.pointer);
				Mods.pointer = null;
			}
		}

		// Token: 0x0600010E RID: 270 RVA: 0x000132F0 File Offset: 0x000114F0
		public static void LeftArmGun()
		{
			bool leftGrab = ControllerInputPoller.instance.leftGrab;
			if (leftGrab)
			{
				RaycastHit raycastHit;
				Physics.Raycast(Player.Instance.leftControllerTransform.position - Player.Instance.leftControllerTransform.up, -Player.Instance.leftControllerTransform.up, ref raycastHit);
				bool flag = Mods.pointer == null;
				if (flag)
				{
					Mods.pointer = GameObject.CreatePrimitive(0);
					Object.Destroy(Mods.pointer.GetComponent<Rigidbody>());
					Object.Destroy(Mods.pointer.GetComponent<SphereCollider>());
					Mods.pointer.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
				}
				Mods.pointer.transform.position = raycastHit.point;
				bool flag2 = ControllerInputPoller.instance.leftControllerIndexFloat == 1f;
				if (flag2)
				{
					Player.Instance.leftControllerTransform.position = raycastHit.point;
				}
			}
			else
			{
				Object.Destroy(Mods.pointer);
				Mods.pointer = null;
			}
		}

		// Token: 0x0600010F RID: 271 RVA: 0x00013410 File Offset: 0x00011610
		public static void GrabTrainR()
		{
			bool rightGrab = ControllerInputPoller.instance.rightGrab;
			if (rightGrab)
			{
				GameObject.Find("Environment Objects/LocalObjects_Prefab/Forest/Holiday2023Forest/Holiday2023Forest_Gameplay/NCTrain_Kit_Prefab").transform.position = GorillaTagger.Instance.rightHandTransform.position;
			}
		}

		// Token: 0x06000110 RID: 272 RVA: 0x00013454 File Offset: 0x00011654
		public static void LightUpCristal()
		{
			bool rightGrab = ControllerInputPoller.instance.rightGrab;
			if (rightGrab)
			{
				GameObject.Find("Environment Objects/LocalObjects_Prefab/Cave_Main_Prefab/Cave_Crystals_Prefab_V3/C_Crystal_Cluster/C_Crystal_Chunk (49)\r\n").GetComponent<GorillaPressableButton>().ButtonActivationWithHand(false);
			}
		}

		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000111 RID: 273 RVA: 0x0001348C File Offset: 0x0001168C
		public static Color black
		{
			get
			{
				return new Color32(0, 0, 0, 1);
			}
		}

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000112 RID: 274 RVA: 0x000134AC File Offset: 0x000116AC
		public static Color purple
		{
			get
			{
				return new Color(0.7f, 0f, 0.9f, 1f);
			}
		}

		// Token: 0x06000113 RID: 275 RVA: 0x000134D8 File Offset: 0x000116D8
		public static void ThemeChanger()
		{
			Mods.thememnumber++;
			bool flag = Mods.thememnumber == 6;
			if (flag)
			{
				Mods.thememnumber = 0;
				Mods.maincolor = Mods.black;
				Mods.buttoncolor = Mods.black;
				Mods.activatedcolor = Color.blue;
				Mods.shibaimage = false;
				Mods.binaryimage = false;
				Mods.animated = true;
				File.WriteAllText("shibagttheme.txt", "main");
			}
			bool flag2 = Mods.thememnumber == 0;
			if (flag2)
			{
				Mods.maincolor = Color.black;
				Mods.buttoncolor = Color.black;
				Mods.activatedcolor = Color.blue;
				Mods.shibaimage = false;
				Mods.binaryimage = false;
				Mods.animated = false;
				File.WriteAllText("shibagttheme.txt", "dark");
			}
			bool flag3 = Mods.thememnumber == 1;
			if (flag3)
			{
				Mods.maincolor = Mods.purple;
				Mods.buttoncolor = Color.black;
				Mods.activatedcolor = Mods.purple;
				Mods.shibaimage = false;
				Mods.binaryimage = false;
				Mods.animated = false;
				File.WriteAllText("shibagttheme.txt", "og");
			}
			bool flag4 = Mods.thememnumber == 2;
			if (flag4)
			{
				Mods.maincolor = Color.white;
				Mods.buttoncolor = Color.grey;
				Mods.activatedcolor = Color.black;
				Mods.shibaimage = false;
				Mods.binaryimage = false;
				Mods.animated = false;
				File.WriteAllText("shibagttheme.txt", "light");
			}
			bool flag5 = Mods.thememnumber == 3;
			if (flag5)
			{
				Mods.maincolor = Color.black;
				Mods.buttoncolor = Color.black;
				Mods.activatedcolor = Mods.purple;
				Mods.shibaimage = true;
				Mods.binaryimage = false;
				Mods.animated = false;
				File.WriteAllText("shibagttheme.txt", "shiba");
			}
			bool flag6 = Mods.thememnumber == 4;
			if (flag6)
			{
				Mods.maincolor = Color.black;
				Mods.buttoncolor = Color.black;
				Mods.activatedcolor = Color.green;
				Mods.shibaimage = false;
				Mods.binaryimage = true;
				Mods.animated = false;
				File.WriteAllText("shibagttheme.txt", "binary");
			}
			bool flag7 = Mods.thememnumber == 5;
			if (flag7)
			{
				Mods.maincolor = Color.black;
				Mods.buttoncolor = Color.black;
				Mods.activatedcolor = Color.blue;
				Mods.shibaimage = false;
				Mods.binaryimage = false;
				Mods.animated = true;
				File.WriteAllText("shibagttheme.txt", "main");
			}
			WristMenu.settingsbuttons[0] = new bool?(false);
			WristMenu.DestroyMenu();
			WristMenu.instance.Draw();
		}

		// Token: 0x06000114 RID: 276 RVA: 0x00013748 File Offset: 0x00011948
		public static void GrabBatR()
		{
			bool rightGrab = ControllerInputPoller.instance.rightGrab;
			if (rightGrab)
			{
				GameObject.Find("Cave Bat Holdable").transform.position = GorillaTagger.Instance.rightHandTransform.position;
			}
		}

		// Token: 0x06000115 RID: 277 RVA: 0x0001378C File Offset: 0x0001198C
		public static void ThemeChanger2()
		{
			Mods.thememnumber++;
			bool flag = Mods.thememnumber == 6;
			if (flag)
			{
				Mods.thememnumber = 0;
				Mods.maincolor = Mods.black;
				Mods.buttoncolor = Mods.black;
				Mods.activatedcolor = Color.blue;
				Mods.shibaimage = false;
				Mods.binaryimage = false;
				Mods.animated = true;
				File.WriteAllText("shibagttheme.txt", "main");
			}
			bool flag2 = Mods.thememnumber == 0;
			if (flag2)
			{
				Mods.maincolor = Color.black;
				Mods.buttoncolor = Color.black;
				Mods.activatedcolor = Color.blue;
				Mods.shibaimage = false;
				Mods.binaryimage = false;
				Mods.animated = false;
				File.WriteAllText("shibagttheme.txt", "dark");
			}
			bool flag3 = Mods.thememnumber == 1;
			if (flag3)
			{
				Mods.maincolor = Mods.purple;
				Mods.buttoncolor = Color.black;
				Mods.activatedcolor = Mods.purple;
				Mods.shibaimage = false;
				Mods.binaryimage = false;
				Mods.animated = false;
				File.WriteAllText("shibagttheme.txt", "og");
			}
			bool flag4 = Mods.thememnumber == 2;
			if (flag4)
			{
				Mods.maincolor = Color.white;
				Mods.buttoncolor = Color.grey;
				Mods.activatedcolor = Color.black;
				Mods.shibaimage = false;
				Mods.binaryimage = false;
				Mods.animated = false;
				File.WriteAllText("shibagttheme.txt", "light");
			}
			bool flag5 = Mods.thememnumber == 3;
			if (flag5)
			{
				Mods.maincolor = Color.black;
				Mods.buttoncolor = Color.black;
				Mods.activatedcolor = Mods.purple;
				Mods.shibaimage = true;
				Mods.binaryimage = false;
				Mods.animated = false;
				File.WriteAllText("shibagttheme.txt", "shiba");
			}
			bool flag6 = Mods.thememnumber == 4;
			if (flag6)
			{
				Mods.maincolor = Color.black;
				Mods.buttoncolor = Color.black;
				Mods.activatedcolor = Color.green;
				Mods.shibaimage = false;
				Mods.binaryimage = true;
				Mods.animated = false;
				File.WriteAllText("shibagttheme.txt", "binary");
			}
			bool flag7 = Mods.thememnumber == 5;
			if (flag7)
			{
				Mods.maincolor = Color.black;
				Mods.buttoncolor = Color.black;
				Mods.activatedcolor = Color.blue;
				Mods.shibaimage = false;
				Mods.binaryimage = false;
				Mods.animated = true;
				File.WriteAllText("shibagttheme.txt", "main");
			}
			WristMenu.settingsbuttons[4] = new bool?(false);
			Object.Destroy(Mods.menu);
			Mods.menu = null;
			WristMenu.instance.Draw();
		}

		// Token: 0x06000116 RID: 278 RVA: 0x00013A08 File Offset: 0x00011C08
		public static void SlingShotHeart()
		{
			Slingshot[] array = Object.FindObjectsOfType<Slingshot>();
			for (int i = 0; i < array.Length; i++)
			{
				array[i].projectilePrefab = GameObject.Find("Environment Objects/PersistentObjects_Prefab/GlobalObjectPools/CupidArrow_Projectile(Clone)");
			}
		}

		// Token: 0x06000117 RID: 279 RVA: 0x00013A44 File Offset: 0x00011C44
		public static void SplachSElf()
		{
			bool flag = ControllerInputPoller.instance.rightControllerIndexFloat == 1f && Mods.balll < Time.time;
			if (flag)
			{
				Mods.balll = Time.time + 0.5f;
				GorillaTagger.Instance.myVRRig.RPC("PlaySplashEffect", 0, new object[]
				{
					RigShit.GetOwnVRRig().transform.position,
					Random.rotation,
					4f,
					100f,
					true,
					false
				});
			}
		}

		// Token: 0x06000118 RID: 280 RVA: 0x00013AF8 File Offset: 0x00011CF8
		public static void lowgrav()
		{
			bool rightGrab = ControllerInputPoller.instance.rightGrab;
			if (rightGrab)
			{
				Physics.gravity = new Vector3(0f, -2.5f, 0f);
			}
			else
			{
				Physics.gravity = new Vector3(0f, -10f, 0f);
			}
		}

		// Token: 0x06000119 RID: 281 RVA: 0x00013B50 File Offset: 0x00011D50
		public static void ConnectToEuServer()
		{
			PhotonNetwork.ConnectToRegion("eu");
		}

		// Token: 0x0600011A RID: 282 RVA: 0x00013B60 File Offset: 0x00011D60
		public static void highgrav()
		{
			bool rightGrab = ControllerInputPoller.instance.rightGrab;
			if (rightGrab)
			{
				Physics.gravity = new Vector3(0f, -16f, 0f);
			}
			else
			{
				Physics.gravity = new Vector3(0f, -10f, 0f);
			}
		}

		// Token: 0x0600011B RID: 283 RVA: 0x00013BB8 File Offset: 0x00011DB8
		public static void HitAllTargets()
		{
			bool flag = ControllerInputPoller.instance.rightControllerIndexFloat == 1f;
			if (flag)
			{
				GameObject[] array = Object.FindObjectsOfType<GameObject>();
				foreach (GameObject gameObject in array)
				{
					HitTargetWithScoreCounter hitTargetWithScoreCounter;
					bool flag2 = gameObject.TryGetComponent<HitTargetWithScoreCounter>(ref hitTargetWithScoreCounter);
					if (flag2)
					{
						hitTargetWithScoreCounter.TargetHit();
					}
				}
			}
		}

		// Token: 0x0600011C RID: 284 RVA: 0x00013C1C File Offset: 0x00011E1C
		public static void TagGun()
		{
			bool rightGrab = ControllerInputPoller.instance.rightGrab;
			if (rightGrab)
			{
				RaycastHit raycastHit;
				Physics.Raycast(GorillaTagger.Instance.rightHandTransform.position, GorillaTagger.Instance.rightHandTransform.forward, ref raycastHit);
				bool flag = Mods.shouldBePC;
				bool flag2 = flag;
				if (flag2)
				{
					Ray ray = Mods.TPC.ScreenPointToRay(Mouse.current.position.ReadValue());
					Physics.Raycast(ray, ref raycastHit, 100f);
				}
				GameObject gameObject = GameObject.CreatePrimitive(0);
				gameObject.GetComponent<Renderer>().material.color = Color.red;
				gameObject.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
				gameObject.transform.position = raycastHit.point;
				Object.Destroy(gameObject.GetComponent<BoxCollider>());
				Object.Destroy(gameObject.GetComponent<Rigidbody>());
				Object.Destroy(gameObject.GetComponent<Collider>());
				Object.Destroy(gameObject, Time.deltaTime);
				bool flag3 = Mods.isCopying && Mods.whoCopy != null;
				bool flag4 = flag3;
				if (flag4)
				{
					bool flag5 = !Mods.whoCopy.mainSkin.material.name.Contains("fected");
					bool flag6 = flag5;
					if (flag6)
					{
						GorillaTagger.Instance.offlineVRRig.enabled = false;
						GorillaTagger.Instance.offlineVRRig.transform.position = Mods.whoCopy.transform.position;
						GorillaTagger.Instance.myVRRig.transform.position = Mods.whoCopy.transform.position;
						Vector3 position = Mods.whoCopy.transform.position;
						Vector3 position2 = GorillaTagger.Instance.offlineVRRig.head.rigTarget.position;
						float num = Vector3.Distance(position, position2);
						bool flag7 = GorillaTagger.Instance.offlineVRRig.mainSkin.material.name.Contains("fected") && !Mods.whoCopy.mainSkin.material.name.Contains("fected") && (double)num < 1.667;
						bool flag8 = flag7;
						if (flag8)
						{
							bool rightGrab2 = ControllerInputPoller.instance.rightGrab;
							if (rightGrab2)
							{
								Player.Instance.rightControllerTransform.position = position;
							}
							else
							{
								Player.Instance.leftControllerTransform.position = position;
							}
						}
						GameObject gameObject2 = GameObject.CreatePrimitive(0);
						Object.Destroy(gameObject2.GetComponent<Rigidbody>());
						Object.Destroy(gameObject2.GetComponent<SphereCollider>());
						gameObject2.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
						gameObject2.transform.position = GorillaTagger.Instance.leftHandTransform.position;
						GameObject gameObject3 = GameObject.CreatePrimitive(0);
						Object.Destroy(gameObject3.GetComponent<Rigidbody>());
						Object.Destroy(gameObject3.GetComponent<SphereCollider>());
						gameObject3.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
						gameObject3.transform.position = GorillaTagger.Instance.rightHandTransform.position;
						gameObject2.GetComponent<Renderer>().material.color = Color.red;
						gameObject3.GetComponent<Renderer>().material.color = Color.red;
						Object.Destroy(gameObject2, Time.deltaTime);
						Object.Destroy(gameObject3, Time.deltaTime);
					}
				}
				bool flag9 = ControllerInputPoller.instance.rightControllerIndexFloat == 1f;
				if (flag9)
				{
					VRRig componentInParent = raycastHit.collider.GetComponentInParent<VRRig>();
					bool flag10 = componentInParent && componentInParent != GorillaTagger.Instance.offlineVRRig && !componentInParent.mainSkin.material.name.Contains("fected");
					bool flag11 = flag10;
					if (flag11)
					{
						Mods.isCopying = true;
						Mods.whoCopy = componentInParent;
					}
				}
			}
			else
			{
				bool flag12 = Mods.isCopying;
				bool flag13 = flag12;
				if (flag13)
				{
					Mods.isCopying = false;
					GorillaTagger.Instance.offlineVRRig.enabled = true;
				}
			}
		}

		// Token: 0x0600011D RID: 285 RVA: 0x00014058 File Offset: 0x00012258
		public static void setmaster()
		{
			bool flag = GorillaComputer.instance.currentGameMode.Contains("MOD");
			if (flag)
			{
				PhotonNetwork.SetMasterClient(PhotonNetwork.LocalPlayer);
			}
			WristMenu.settingsbuttons[17].enabled = new bool?(false);
			WristMenu.DestroyMenu();
			WristMenu.instance.Draw();
		}

		// Token: 0x0600011E RID: 286 RVA: 0x000140B5 File Offset: 0x000122B5
		public static void LaunchRocket()
		{
			GameObject.Find("Environment Objects/PersistentObjects_Prefab/RocketShip_Prefab").GetComponent<ScheduledTimelinePlayer>().timeline.Stop();
			GameObject.Find("Environment Objects/PersistentObjects_Prefab/RocketShip_Prefab").GetComponent<ScheduledTimelinePlayer>().timeline.Play();
		}

		// Token: 0x0600011F RID: 287 RVA: 0x000140EC File Offset: 0x000122EC
		public static void DisableAirSwim()
		{
			bool flag = Mods.airSwimPart != null;
			bool flag2 = flag;
			if (flag2)
			{
				Object.Destroy(Mods.airSwimPart);
				Player.Instance.audioManager.UnsetMixerSnapshot(0.1f);
			}
		}

		// Token: 0x06000120 RID: 288 RVA: 0x00014130 File Offset: 0x00012330
		public static void AirSwim()
		{
			bool flag = Mods.airSwimPart == null;
			bool flag2 = flag;
			if (flag2)
			{
				Mods.airSwimPart = Object.Instantiate<GameObject>(GameObject.Find("Environment Objects/LocalObjects_Prefab/Beach/B_WaterVolumes/OceanWater"));
				Mods.airSwimPart.transform.localScale = new Vector3(5f, 5f, 5f);
				Mods.airSwimPart.GetComponent<Renderer>().enabled = false;
			}
			else
			{
				Mods.airSwimPart.transform.position = GorillaTagger.Instance.headCollider.transform.position;
			}
		}

		// Token: 0x06000121 RID: 289 RVA: 0x000141C4 File Offset: 0x000123C4
		public static void StickLongArms()
		{
			Player.Instance.leftControllerTransform.transform.position = GorillaTagger.Instance.leftHandTransform.position + GorillaTagger.Instance.leftHandTransform.forward * 0.333f;
			Player.Instance.rightControllerTransform.transform.position = GorillaTagger.Instance.rightHandTransform.position + GorillaTagger.Instance.rightHandTransform.forward * 0.333f;
		}

		// Token: 0x06000122 RID: 290 RVA: 0x00014258 File Offset: 0x00012458
		public static void LaggyRig()
		{
			bool flag = Time.time > Mods.laggyRigDelay;
			bool flag2 = flag;
			if (flag2)
			{
				GorillaTagger.Instance.offlineVRRig.enabled = true;
				Mods.idiotfixthingy = true;
				Mods.laggyRigDelay = Time.time + 0.5f;
			}
			else
			{
				bool flag3 = Mods.idiotfixthingy;
				bool flag4 = flag3;
				if (flag4)
				{
					Mods.idiotfixthingy = false;
				}
				else
				{
					GorillaTagger.Instance.offlineVRRig.enabled = false;
				}
			}
		}

		// Token: 0x06000123 RID: 291 RVA: 0x000142D0 File Offset: 0x000124D0
		public static void walkonwater2()
		{
			int layer = LayerMask.NameToLayer("Default");
			GameObject.Find("UpperWater1").layer = layer;
			GameObject.Find("UpperWater2").layer = layer;
			GameObject.Find("UpperWater3").layer = layer;
			GameObject.Find("UpperWater4").layer = layer;
			GameObject.Find("UpperWater5").layer = layer;
			GameObject.Find("UpperWater6").layer = layer;
			GameObject.Find("UpperWater7").layer = layer;
			GameObject.Find("UpperWater8").layer = layer;
			GameObject.Find("UpperWater9").layer = layer;
			GameObject.Find("UpperWater10").layer = layer;
			GameObject.Find("OceanWater").layer = layer;
			GameObject.Find("WaterfallsStreams").layer = layer;
		}

		// Token: 0x06000124 RID: 292 RVA: 0x000143B8 File Offset: 0x000125B8
		public static void SlingShotIce()
		{
			Slingshot[] array = Object.FindObjectsOfType<Slingshot>();
			for (int i = 0; i < array.Length; i++)
			{
				array[i].projectilePrefab = GameObject.Find("Environment Objects/PersistentObjects_Prefab/GlobalObjectPools/IceSlingshotProjectile_PrefabV Variant(Clone)");
			}
		}

		// Token: 0x06000125 RID: 293 RVA: 0x000143F4 File Offset: 0x000125F4
		public static void SnowFloor()
		{
			GameObject.Find("pit ground").GetComponent<GorillaSurfaceOverride>().extraVelMultiplier = 1f;
			GameObject.Find("pit ground").GetComponent<GorillaSurfaceOverride>().extraVelMaxMultiplier = 1f;
			GameObject.Find("pit ground").GetComponent<GorillaSurfaceOverride>().overrideIndex = 32;
		}

		// Token: 0x06000126 RID: 294 RVA: 0x0001444A File Offset: 0x0001264A
		public static void bouncyfloor()
		{
			GameObject.Find("pit ground").GetComponent<GorillaSurfaceOverride>().extraVelMultiplier = 7f;
			GameObject.Find("pit ground").GetComponent<GorillaSurfaceOverride>().overrideIndex = 7;
		}

		// Token: 0x06000127 RID: 295 RVA: 0x0001447C File Offset: 0x0001267C
		public static void waterballonfloor()
		{
			GameObject.Find("pit ground").GetComponent<GorillaSurfaceOverride>().extraVelMultiplier = 1f;
			GameObject.Find("pit ground").GetComponent<GorillaSurfaceOverride>().extraVelMaxMultiplier = 1f;
			GameObject.Find("pit ground").GetComponent<GorillaSurfaceOverride>().overrideIndex = 204;
		}

		// Token: 0x06000128 RID: 296 RVA: 0x000144D5 File Offset: 0x000126D5
		public static void RightHandMEnu()
		{
			Mods.dontdestroymenu = true;
			Mods.destroymenu = false;
		}

		// Token: 0x06000129 RID: 297 RVA: 0x000144E4 File Offset: 0x000126E4
		public static void Dontdesty2()
		{
			Mods.dontdestroymenu = false;
			Mods.destroymenu = true;
		}

		// Token: 0x0600012A RID: 298 RVA: 0x000144F4 File Offset: 0x000126F4
		public static void Slowall()
		{
			bool flag = ControllerInputPoller.instance.rightControllerIndexFloat == 1f;
			if (flag)
			{
				bool flag2 = PhotonNetwork.LocalPlayer == PhotonNetwork.MasterClient;
				if (flag2)
				{
					GorillaTagger.Instance.myVRRig.RPC("SetTaggedTime", 1, null);
					Mods.flushmanually();
				}
			}
		}

		// Token: 0x0600012B RID: 299 RVA: 0x0001454C File Offset: 0x0001274C
		public static void vibrateall()
		{
			bool flag = PhotonNetwork.LocalPlayer == PhotonNetwork.MasterClient;
			if (flag)
			{
				GorillaTagger.Instance.myVRRig.RPC("SetJoinTaggedTime", 1, null);
				Mods.flushmanually();
			}
		}

		// Token: 0x0600012C RID: 300 RVA: 0x0001458C File Offset: 0x0001278C
		public static void vibrategun()
		{
			bool flag = ControllerInputPoller.instance.rightControllerGripFloat == 1f;
			if (flag)
			{
				RaycastHit raycastHit;
				bool flag2 = Physics.Raycast(Player.Instance.rightControllerTransform.position - Player.Instance.rightControllerTransform.up, -Player.Instance.rightControllerTransform.up, ref raycastHit) && Mods.pointer == null;
				if (flag2)
				{
					Mods.pointer = GameObject.CreatePrimitive(0);
					Object.Destroy(Mods.pointer.GetComponent<Rigidbody>());
					Object.Destroy(Mods.pointer.GetComponent<SphereCollider>());
					Mods.pointer.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
				}
				Mods.pointer.transform.position = raycastHit.point;
				bool flag3 = ControllerInputPoller.instance.rightControllerIndexFloat == 1f;
				if (flag3)
				{
					Player owner = Mods.rig2view(raycastHit.collider.GetComponentInParent<VRRig>()).Owner;
					GorillaTagger.Instance.myVRRig.RPC("SetJoinTaggedTime", owner, null);
					Mods.flushmanually();
				}
			}
			else
			{
				RigShit.GetOwnVRRig().enabled = true;
				Object.Destroy(Mods.pointer);
			}
		}

		// Token: 0x0600012D RID: 301 RVA: 0x000146DC File Offset: 0x000128DC
		public static void RandomColorSnowballs()
		{
			GameObject.Find("Player Objects/Local VRRig/Local Gorilla Player/rig/body/shoulder.R/upper_arm.R/forearm.R/hand.R/palm.01.R/TransferrableItemRightHand/SnowballRightAnchor").transform.Find("LMACF.").GetComponent<SnowballThrowable>().randomizeColor = true;
			GameObject.Find("Player Objects/Local VRRig/Local Gorilla Player/rig/body/shoulder.R/upper_arm.R/forearm.R/hand.R/palm.01.R/TransferrableItemRightHand/SnowballLeftAnchor").transform.Find("LMACE.").GetComponent<SnowballThrowable>().randomizeColor = true;
		}

		// Token: 0x0600012E RID: 302 RVA: 0x00014734 File Offset: 0x00012934
		public static void CreatePublic()
		{
			bool flag = PhotonNetworkController.Instance.currentJoinTrigger.gameModeName != "city" && PhotonNetworkController.Instance.currentJoinTrigger.gameModeName != "basement";
			bool flag2 = flag;
			Hashtable customRoomProperties;
			if (flag2)
			{
				Hashtable hashtable = new Hashtable();
				hashtable.Add("gameMode", PhotonNetworkController.Instance.currentJoinTrigger.gameModeName + GorillaComputer.instance.currentQueue + GorillaComputer.instance.currentGameMode);
				customRoomProperties = hashtable;
			}
			else
			{
				Hashtable hashtable2 = new Hashtable();
				hashtable2.Add("gameMode", PhotonNetworkController.Instance.currentJoinTrigger.gameModeName + GorillaComputer.instance.currentQueue + "INFECTION");
				customRoomProperties = hashtable2;
			}
			RoomOptions roomOptions = new RoomOptions();
			roomOptions.IsVisible = true;
			roomOptions.IsOpen = true;
			roomOptions.MaxPlayers = PhotonNetworkController.Instance.GetRoomSize(PhotonNetworkController.Instance.currentJoinTrigger.gameModeName);
			roomOptions.CustomRoomProperties = customRoomProperties;
			roomOptions.PublishUserId = true;
			roomOptions.CustomRoomPropertiesForLobby = new string[]
			{
				"gameMode"
			};
			PhotonNetwork.CreateRoom(Mods.RandomRoomName(), roomOptions, null, null);
			WristMenu.buttons[12].enabled = new bool?(false);
			WristMenu.DestroyMenu();
			WristMenu.instance.Draw();
		}

		// Token: 0x0600012F RID: 303 RVA: 0x000148A0 File Offset: 0x00012AA0
		public static string RandomRoomName()
		{
			string text = "";
			for (int i = 0; i < 4; i++)
			{
				text += PhotonNetworkController.Instance.roomCharacters.Substring(Random.Range(0, PhotonNetworkController.Instance.roomCharacters.Length), 1);
			}
			bool flag = GorillaComputer.instance.CheckAutoBanListForName(text);
			bool flag2 = flag;
			string result;
			if (flag2)
			{
				result = text;
			}
			else
			{
				result = Mods.RandomRoomName();
			}
			return result;
		}

		// Token: 0x06000130 RID: 304 RVA: 0x00014924 File Offset: 0x00012B24
		public static void AutoJoinRoomSPIDERONTOP()
		{
			Mods.Reconnect.rejRoom = "SPIDERONTOP";
			Mods.Reconnect.rejDebounce = Time.time + 2f;
			WristMenu.buttons[11].enabled = new bool?(false);
			WristMenu.DestroyMenu();
			WristMenu.instance.Draw();
		}

		// Token: 0x06000131 RID: 305 RVA: 0x00014974 File Offset: 0x00012B74
		public static void AutoJoinRoomCYPEE()
		{
			Mods.Reconnect.rejRoom = "CYPEE";
			Mods.Reconnect.rejDebounce = Time.time + 2f;
			WristMenu.buttons[12].enabled = new bool?(false);
			WristMenu.DestroyMenu();
			WristMenu.instance.Draw();
		}

		// Token: 0x06000132 RID: 306 RVA: 0x000149C4 File Offset: 0x00012BC4
		public static void fixfloor()
		{
			GameObject.Find("pit ground").GetComponent<GorillaSurfaceOverride>().overrideIndex = 7;
			GameObject.Find("pit ground").GetComponent<GorillaSurfaceOverride>().extraVelMultiplier = 1f;
			GameObject.Find("pit ground").GetComponent<GorillaSurfaceOverride>().extraVelMaxMultiplier = 1f;
		}

		// Token: 0x06000133 RID: 307 RVA: 0x00014A1C File Offset: 0x00012C1C
		public static void SlingShotBalloon()
		{
			Slingshot[] array = Object.FindObjectsOfType<Slingshot>();
			for (int i = 0; i < array.Length; i++)
			{
				array[i].projectilePrefab = GameObject.Find("Environment Objects/PersistentObjects_Prefab/GlobalObjectPools/WaterBalloonProjectile(Clone)");
			}
		}

		// Token: 0x06000134 RID: 308 RVA: 0x00014A58 File Offset: 0x00012C58
		public PhotonView GetPhotonViewFromRig(VRRig rig)
		{
			PhotonView value = Traverse.Create(rig).Field("photonView").GetValue<PhotonView>();
			bool flag = value != null;
			PhotonView result;
			if (flag)
			{
				result = value;
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x06000135 RID: 309 RVA: 0x00014A94 File Offset: 0x00012C94
		public static void offleaves()
		{
			bool flag = !Mods.erihu;
			if (flag)
			{
				Mods.erihu = true;
				foreach (GameObject gameObject in Resources.FindObjectsOfTypeAll<GameObject>())
				{
					bool flag2 = gameObject.activeSelf && gameObject.name.Contains("smallleaves");
					if (flag2)
					{
						gameObject.SetActive(false);
						Mods.leaves.Add(gameObject);
					}
				}
			}
		}

		// Token: 0x06000136 RID: 310 RVA: 0x00014B08 File Offset: 0x00012D08
		public static void onleaves()
		{
			bool flag = !Mods.erihu;
			if (flag)
			{
				Mods.erihu = true;
				foreach (GameObject gameObject in Resources.FindObjectsOfTypeAll<GameObject>())
				{
					bool flag2 = gameObject.activeSelf && gameObject.name.Contains("smallleaves");
					if (flag2)
					{
						gameObject.SetActive(true);
						Mods.leaves.Add(gameObject);
					}
				}
			}
		}

		// Token: 0x06000137 RID: 311 RVA: 0x00014B7C File Offset: 0x00012D7C
		public static void offanticrash()
		{
			GameObject.Find("Environment Objects/PersistentObjects_Prefab/GlobalObjectPools").SetActive(true);
		}

		// Token: 0x06000138 RID: 312 RVA: 0x00014B90 File Offset: 0x00012D90
		public static void antimoderator()
		{
			foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
			{
				bool flag = !vrrig.isOfflineVRRig && vrrig.concatStringOfCosmeticsAllowed.Contains("LBAAK");
				if (flag)
				{
					PhotonNetwork.Disconnect();
					NotifiLib.SendNotification("<color=red>[ANTI-MODERATOR]</color> Someone with a STICK joined, disconnected.");
				}
			}
		}

		// Token: 0x06000139 RID: 313 RVA: 0x00014C1C File Offset: 0x00012E1C
		public static void anticrash()
		{
			GameObject.Find("Environment Objects/PersistentObjects_Prefab/GlobalObjectPools").SetActive(false);
		}

		// Token: 0x0600013A RID: 314 RVA: 0x00014C30 File Offset: 0x00012E30
		public static void ChangeColor(Color color)
		{
			bool inRoom = PhotonNetwork.InRoom;
			bool flag = inRoom;
			if (flag)
			{
				bool flag2 = GorillaComputer.instance.friendJoinCollider.playerIDsCurrentlyTouching.Contains(PhotonNetwork.LocalPlayer.UserId);
				bool flag3 = flag2;
				if (flag3)
				{
					PlayerPrefs.SetFloat("redValue", Mathf.Clamp(color.r, 0f, 1f));
					PlayerPrefs.SetFloat("greenValue", Mathf.Clamp(color.g, 0f, 1f));
					PlayerPrefs.SetFloat("blueValue", Mathf.Clamp(color.b, 0f, 1f));
					GorillaTagger.Instance.offlineVRRig.mainSkin.material.color = color;
					GorillaTagger.Instance.UpdateColor(color.r, color.g, color.b);
					PlayerPrefs.Save();
					GorillaTagger.Instance.myVRRig.RPC("InitializeNoobMaterial", 0, new object[]
					{
						color.r,
						color.g,
						color.b,
						false
					});
					Mods.flushmanually();
				}
				else
				{
					Mods.isUpdatingValues = true;
					Mods.valueChangeDelay = Time.time + 0.8f;
					Mods.changingColor = true;
					Mods.colorChange = color;
				}
			}
			else
			{
				PlayerPrefs.SetFloat("redValue", Mathf.Clamp(color.r, 0f, 1f));
				PlayerPrefs.SetFloat("greenValue", Mathf.Clamp(color.g, 0f, 1f));
				PlayerPrefs.SetFloat("blueValue", Mathf.Clamp(color.b, 0f, 1f));
				GorillaTagger.Instance.offlineVRRig.mainSkin.material.color = color;
				GorillaTagger.Instance.UpdateColor(color.r, color.g, color.b);
				PlayerPrefs.Save();
				GorillaTagger.Instance.myVRRig.RPC("InitializeNoobMaterial", 0, new object[]
				{
					color.r,
					color.g,
					color.b,
					false
				});
				Mods.flushmanually();
			}
		}

		// Token: 0x0600013B RID: 315 RVA: 0x00014E8C File Offset: 0x0001308C
		public static void Joystickplats()
		{
			bool joystickR = WristMenu.joystickR;
			if (joystickR)
			{
				Mods.Platforms();
				bool joystickL = WristMenu.joystickL;
				if (joystickL)
				{
					Mods.Platforms();
				}
			}
		}

		// Token: 0x0600013C RID: 316 RVA: 0x00014EBC File Offset: 0x000130BC
		public static void RGBMonke()
		{
			bool flag = GorillaComputer.instance.friendJoinCollider.playerIDsCurrentlyTouching.Contains(PhotonNetwork.LocalPlayer.UserId) && Time.time > Mods.balll2111 + 0.08f && PhotonNetwork.InRoom;
			if (flag)
			{
				Mods.balll2111 = Time.time;
				Mods.updateTimer += Time.deltaTime;
				bool randomColor = Mods.RandomColor;
				if (randomColor)
				{
					bool flag2 = (double)Time.time > (double)Mods.timer;
					if (flag2)
					{
						Mods.color = Random.ColorHSV(0f, 1f, Mods.GlowAmount, Mods.GlowAmount, Mods.GlowAmount, Mods.GlowAmount);
						Mods.timer = Time.time + Mods.CycleSpeed;
					}
				}
				else
				{
					bool flag3 = (double)Mods.hue >= 1.0;
					if (flag3)
					{
						Mods.hue = 0f;
					}
					Mods.hue += Mods.CycleSpeed;
					Mods.color = Color.HSVToRGB(Mods.hue, 1f * Mods.GlowAmount, 1f * Mods.GlowAmount);
				}
				bool flag4 = (double)Mods.updateTimer > (double)Mods.updateRate;
				if (flag4)
				{
					Mods.updateTimer = 999f;
					GorillaTagger.Instance.UpdateColor(Mods.color.r, Mods.color.g, Mods.color.b);
					GorillaTagger.Instance.myVRRig.RPC("InitializeNoobMaterial", 1, new object[]
					{
						Mods.color.r,
						Mods.color.g,
						Mods.color.b,
						false
					});
					Mods.RpcPatcher(GorillaTagger.Instance.offlineVRRig);
					Mods.flushmanually();
				}
			}
		}

		// Token: 0x0600013D RID: 317 RVA: 0x0001509C File Offset: 0x0001329C
		public static void CursedGrabHead()
		{
			bool rightGrab = ControllerInputPoller.instance.rightGrab;
			if (rightGrab)
			{
				GorillaTagger.Instance.offlineVRRig.headMesh.transform.position = Player.Instance.rightControllerTransform.position;
			}
			bool leftGrab = ControllerInputPoller.instance.leftGrab;
			if (leftGrab)
			{
				GorillaTagger.Instance.offlineVRRig.headMesh.transform.rotation = Player.Instance.leftControllerTransform.rotation;
			}
		}

		// Token: 0x0600013E RID: 318 RVA: 0x00015120 File Offset: 0x00013320
		public static void UpsideHead()
		{
			GorillaTagger.Instance.offlineVRRig.head.trackingRotationOffset.z = 180f;
		}

		// Token: 0x0600013F RID: 319 RVA: 0x00015141 File Offset: 0x00013341
		public static void FixUpsideHead()
		{
			GorillaTagger.Instance.offlineVRRig.head.trackingRotationOffset.z = 0f;
		}

		// Token: 0x06000140 RID: 320 RVA: 0x00015164 File Offset: 0x00013364
		public static void ProjectileDelay()
		{
			Mods.projDebounceType += 0.1f;
			bool flag = Mods.projDebounceType > 1.05f;
			bool flag2 = flag;
			if (flag2)
			{
				Mods.projDebounceType = 0f;
			}
			WristMenu.settingsbuttons[19].enabled = new bool?(false);
			WristMenu.DestroyMenu();
			WristMenu.instance.Draw();
		}

		// Token: 0x06000141 RID: 321 RVA: 0x000151C8 File Offset: 0x000133C8
		public static void ChangeIdentity()
		{
			string text = "GORILLA";
			for (int i = 0; i < 4; i++)
			{
				text += Random.Range(0, 9).ToString();
			}
			Mods.ChangeName(text);
			byte b = (byte)Random.Range(0, 255);
			byte b2 = (byte)Random.Range(0, 255);
			byte b3 = (byte)Random.Range(0, 255);
			Mods.ChangeColor(new Color32(b, b2, b3, byte.MaxValue));
		}

		// Token: 0x06000142 RID: 322 RVA: 0x00015254 File Offset: 0x00013454
		public static void espoff()
		{
			bool flag = Mods.widhcnkesdj;
			if (flag)
			{
				foreach (VRRig vrrig in (VRRig[])Object.FindObjectsOfType(typeof(VRRig)))
				{
					bool flag2 = !vrrig.isOfflineVRRig && !vrrig.isMyPlayer;
					if (flag2)
					{
						vrrig.ChangeMaterialLocal(vrrig.currentMatIndex);
					}
				}
				Mods.widhcnkesdj = false;
			}
		}

		// Token: 0x06000143 RID: 323 RVA: 0x000152C6 File Offset: 0x000134C6
		public static void lefthand()
		{
			Mods.lefthandd = true;
		}

		// Token: 0x06000144 RID: 324 RVA: 0x000152D0 File Offset: 0x000134D0
		public static void FixNoSlip()
		{
			bool flag = Mods.esiuhkfdjmcsl;
			if (flag)
			{
				bool flag2 = GameObject.Find("Environment Objects/LocalObjects_Prefab/Forest");
				if (flag2)
				{
					Mods.esiuhkfdjmcsl = false;
					GameObject.Find("Environment Objects/LocalObjects_Prefab/Forest/Terrain/pitgeo/pit lower slippery wall").GetComponent<GorillaSurfaceOverride>().overrideIndex = 1;
				}
				bool flag3 = GameObject.Find("Environment Objects/LocalObjects_Prefab/Mountain");
				if (flag3)
				{
					Mods.esiuhkfdjmcsl = false;
					GameObject.Find("Environment Objects/LocalObjects_Prefab/w/Geometry/V2_mountainsideice").GetComponent<GorillaSurfaceOverride>().overrideIndex = 59;
				}
			}
		}

		// Token: 0x06000145 RID: 325 RVA: 0x0001534C File Offset: 0x0001354C
		public static void NoSlip()
		{
			bool flag = !Mods.esiuhkfdjmcsl;
			if (flag)
			{
				bool flag2 = GameObject.Find("Environment Objects/LocalObjects_Prefab/Forest");
				if (flag2)
				{
					Mods.esiuhkfdjmcsl = true;
					GameObject.Find("Environment Objects/LocalObjects_Prefab/Forest/Terrain/pitgeo/pit lower slippery wall").GetComponent<GorillaSurfaceOverride>().overrideIndex = 0;
				}
				else
				{
					bool flag3 = GameObject.Find("Environment Objects/LocalObjects_Prefab/Mountain");
					if (flag3)
					{
						Mods.esiuhkfdjmcsl = true;
						GameObject.Find("Environment Objects/LocalObjects_Prefab/Mountain/Geometry/V2_mountainsideice").GetComponent<GorillaSurfaceOverride>().overrideIndex = 0;
					}
				}
			}
		}

		// Token: 0x06000146 RID: 326 RVA: 0x000153CC File Offset: 0x000135CC
		public static void c4()
		{
			bool rightGrab = ControllerInputPoller.instance.rightGrab;
			if (rightGrab)
			{
				bool flag = Mods.C4 == null;
				bool flag2 = flag;
				if (flag2)
				{
					GradientColorKey[] array = new GradientColorKey[5];
					array[0].color = new Color32(0, 0, byte.MaxValue, 1);
					array[0].time = 0f;
					array[1].color = new Color32(0, 0, 128, 1);
					array[1].time = 0.3f;
					array[2].color = new Color32(0, 0, 64, 1);
					array[2].time = 0.6f;
					array[3].color = new Color32(0, 0, 32, 1);
					array[3].time = 0.9f;
					array[4].color = new Color32(0, 0, 0, 1);
					array[4].time = 1f;
					Mods.C4 = GameObject.CreatePrimitive(3);
					Object.Destroy(Mods.C4.GetComponent<Collider>());
					Object.Destroy(Mods.C4.GetComponent<Rigidbody>());
					Mods.C4.transform.localScale = new Vector3(0.2f, 0.2f, 0.4f);
					ColorChanger colorChanger = Mods.C4.AddComponent<ColorChanger>();
					colorChanger.colors = new Gradient
					{
						colorKeys = array
					};
					colorChanger.Start();
				}
				Mods.C4.transform.position = Player.Instance.rightControllerTransform.transform.position;
			}
			bool flag3 = ControllerInputPoller.instance.rightControllerIndexFloat >= 0.3f;
			bool flag4 = flag3;
			if (flag4)
			{
				Object.Destroy(Mods.C4);
				Player.Instance.GetComponent<Rigidbody>().AddExplosionForce(40000f, Mods.C4.transform.position, 5f);
			}
		}

		// Token: 0x06000147 RID: 327 RVA: 0x000155E8 File Offset: 0x000137E8
		public static void SlideControll()
		{
			Player.Instance.slideControl = 1f;
		}

		// Token: 0x06000148 RID: 328 RVA: 0x000155FA File Offset: 0x000137FA
		public static void FixSlideControll()
		{
			Player.Instance.slideControl = 0f;
		}

		// Token: 0x06000149 RID: 329 RVA: 0x0001560C File Offset: 0x0001380C
		public static void IronMonke()
		{
			bool rightGrab = ControllerInputPoller.instance.rightGrab;
			if (rightGrab)
			{
				GorillaTagger.Instance.offlineVRRig.PlayHandTapLocal(75, false, 0.1f);
				GorillaTagger.Instance.StartVibration(false, GorillaTagger.Instance.tapHapticStrength / 10f, GorillaTagger.Instance.tapHapticDuration);
				Player.Instance.GetComponent<Rigidbody>().AddForce(new Vector3(15f * Player.Instance.rightControllerTransform.right.x, 15f * Player.Instance.rightControllerTransform.right.y, 15f * Player.Instance.rightControllerTransform.right.z), 5);
			}
			bool leftGrab = ControllerInputPoller.instance.leftGrab;
			if (leftGrab)
			{
				GorillaTagger.Instance.offlineVRRig.PlayHandTapLocal(75, true, 0.1f);
				GorillaTagger.Instance.StartVibration(true, GorillaTagger.Instance.tapHapticStrength / 10f, GorillaTagger.Instance.tapHapticDuration);
				Player.Instance.GetComponent<Rigidbody>().AddForce(new Vector3(15f * Player.Instance.leftControllerTransform.right.x * -1f, 15f * Player.Instance.leftControllerTransform.right.y * -1f, 15f * Player.Instance.leftControllerTransform.right.z * -1f), 5);
			}
		}

		// Token: 0x0600014A RID: 330 RVA: 0x0001579A File Offset: 0x0001399A
		public static void bothhanded()
		{
			Mods.bothhands = true;
		}

		// Token: 0x0600014B RID: 331 RVA: 0x000157A3 File Offset: 0x000139A3
		public static void offbothhanded()
		{
			Mods.bothhands = false;
		}

		// Token: 0x0600014C RID: 332 RVA: 0x000157AC File Offset: 0x000139AC
		public static void PopAllBalloons()
		{
			foreach (BalloonHoldable balloonHoldable in Object.FindObjectsOfType<BalloonHoldable>())
			{
				Vector3 position = balloonHoldable.gameObject.transform.position;
				Vector3 zero = Vector3.zero;
				Mods.BetaFireProjectile("SlingshotProjectile", position, zero, Color.white, true);
			}
		}

		// Token: 0x0600014D RID: 333 RVA: 0x00015801 File Offset: 0x00013A01
		public static void NoTapCooldown()
		{
			GorillaTagger.Instance.tapCoolDown = 0f;
			Mods.stuiejrf2 = true;
		}

		// Token: 0x0600014E RID: 334 RVA: 0x0001581C File Offset: 0x00013A1C
		public static void OFFNoTapCooldown()
		{
			bool flag = Mods.stuiejrf2;
			if (flag)
			{
				Mods.stuiejrf2 = false;
				GorillaTagger.Instance.tapCoolDown = 0.1f;
			}
		}

		// Token: 0x0600014F RID: 335 RVA: 0x0001584C File Offset: 0x00013A4C
		public static void NoTagJoin()
		{
			PlayerPrefs.SetString("tutorial", "false");
			Hashtable hashtable = new Hashtable();
			hashtable.Add("didTutorial", true);
			PhotonNetwork.LocalPlayer.SetCustomProperties(hashtable, null, null);
			PlayerPrefs.Save();
			Mods.stuiejrf99 = false;
		}

		// Token: 0x06000150 RID: 336 RVA: 0x0001589C File Offset: 0x00013A9C
		public static void TagJoin()
		{
			PlayerPrefs.SetString("tutorial", "false");
			Hashtable hashtable = new Hashtable();
			hashtable.Add("didTutorial", true);
			PhotonNetwork.LocalPlayer.SetCustomProperties(hashtable, null, null);
			PlayerPrefs.Save();
			Mods.stuiejrf99 = false;
		}

		// Token: 0x06000151 RID: 337 RVA: 0x000158EC File Offset: 0x00013AEC
		public static void NoTagOnroomJoinFalse()
		{
			bool flag = !Mods.stuiejrf99;
			if (flag)
			{
				Mods.stuiejrf99 = true;
				PlayerPrefs.SetString("tutorial", "true");
				Hashtable hashtable = new Hashtable();
				hashtable.Add("didTutorial", true);
				PhotonNetwork.LocalPlayer.SetCustomProperties(hashtable, null, null);
				PlayerPrefs.Save();
			}
		}

		// Token: 0x06000152 RID: 338 RVA: 0x0001594A File Offset: 0x00013B4A
		public static void RpcPatcher(VRRig rig)
		{
			Mods.CleanActorAndRPCBuffers(GorillaTagger.Instance.myVRRig);
		}

		// Token: 0x06000153 RID: 339 RVA: 0x0001595D File Offset: 0x00013B5D
		public static void offrainbow()
		{
			Mods.rainboww = false;
		}

		// Token: 0x06000154 RID: 340 RVA: 0x00015966 File Offset: 0x00013B66
		public static void CleanActorAndRPCBuffers(PhotonView photonView)
		{
			PhotonNetwork.OpCleanActorRpcBuffer(photonView.Owner.ActorNumber);
			PhotonNetwork.OpCleanRpcBuffer(photonView);
		}

		// Token: 0x06000155 RID: 341 RVA: 0x00015984 File Offset: 0x00013B84
		public static List<VRRig> GetValidChoosableRigs()
		{
			Mods.validRigs.Clear();
			foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
			{
				bool flag = !vrrig.isOfflineVRRig && (PhotonNetwork.InRoom || vrrig.isOfflineVRRig) && !(vrrig == null);
				if (flag)
				{
					Mods.validRigs.Add(vrrig);
				}
			}
			return Mods.validRigs;
		}

		// Token: 0x06000156 RID: 342 RVA: 0x00015A28 File Offset: 0x00013C28
		public static void HeadInRightAndLeftHand()
		{
			bool flag = ControllerInputPoller.instance.rightControllerIndexTouch > 1f;
			if (flag)
			{
				GorillaTagger.Instance.headCollider.transform.position = GorillaTagger.Instance.rightHandTransform.position;
			}
			bool flag2 = ControllerInputPoller.instance.leftControllerIndexTouch > 1f;
			if (flag2)
			{
				GorillaTagger.Instance.headCollider.transform.position = GorillaTagger.Instance.leftHandTransform.position;
			}
		}

		// Token: 0x06000157 RID: 343 RVA: 0x00015AB0 File Offset: 0x00013CB0
		public static void RopeGun()
		{
			bool rightGrab = ControllerInputPoller.instance.rightGrab;
			if (rightGrab)
			{
				RaycastHit raycastHit;
				bool flag = Physics.Raycast(Player.Instance.rightControllerTransform.position - Player.Instance.rightControllerTransform.up, -Player.Instance.rightControllerTransform.up, ref raycastHit) && Mods.pointer == null;
				if (flag)
				{
					Mods.pointer = GameObject.CreatePrimitive(0);
					Object.Destroy(Mods.pointer.GetComponent<Rigidbody>());
					Object.Destroy(Mods.pointer.GetComponent<SphereCollider>());
					Mods.pointer.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
				}
				Mods.pointer.transform.position = raycastHit.point;
				bool flag2 = ControllerInputPoller.instance.rightControllerIndexFloat > 0f;
				if (flag2)
				{
					GorillaRopeSwing componentInParent = raycastHit.collider.GetComponentInParent<GorillaRopeSwing>();
					Mods.pointer.GetComponent<Renderer>().material.color = new Color32(byte.MaxValue, 0, 0, 1);
					Mods.norpc();
					Mods.RopeSpecific(new Vector3((float)Random.Range(0, 999), (float)Random.Range(0, 999), (float)Random.Range(0, 999)), componentInParent);
				}
				Mods.pointer.GetComponent<Renderer>().material.color = new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, 1);
			}
			else
			{
				Object.Destroy(Mods.pointer);
			}
		}

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x06000158 RID: 344 RVA: 0x00015C50 File Offset: 0x00013E50
		// (set) Token: 0x06000159 RID: 345 RVA: 0x00015C57 File Offset: 0x00013E57
		public static float BoardSelectCooldown { get; private set; }

		// Token: 0x0600015A RID: 346 RVA: 0x00015C60 File Offset: 0x00013E60
		private static void RopeSpecific(Vector3 Pos, GorillaRopeSwing gorillaRopeSwing)
		{
			PhotonView photonView = gorillaRopeSwing.photonView;
			string text = "SetVelocity";
			RpcTarget rpcTarget = 0;
			object[] array = new object[4];
			array[0] = 1;
			array[1] = Pos;
			array[2] = true;
			photonView.RPC(text, rpcTarget, array);
		}

		// Token: 0x0600015B RID: 347 RVA: 0x00015CAC File Offset: 0x00013EAC
		public static void OrbitBug()
		{
			float num = 1f;
			Mods.angle += Mods.orbitSpeed * Time.deltaTime;
			float num2 = RigShit.GetOwnVRRig().transform.position.x + num * Mathf.Cos(Mods.angle);
			float num3 = RigShit.GetOwnVRRig().transform.position.y + num * Mathf.Sin(Mods.angle);
			float num4 = RigShit.GetOwnVRRig().transform.position.z + num * Mathf.Sin(Mods.angle);
			GameObject.Find("Floating Bug Holdable").transform.position = new Vector3(num2, num3, num4);
		}

		// Token: 0x0600015C RID: 348 RVA: 0x00015D5C File Offset: 0x00013F5C
		public static void OrbitBat()
		{
			float num = 1f;
			Mods.angle += Mods.orbitSpeed * Time.deltaTime;
			float num2 = RigShit.GetOwnVRRig().transform.position.x + num * Mathf.Cos(Mods.angle);
			float num3 = RigShit.GetOwnVRRig().transform.position.y + num * Mathf.Sin(Mods.angle);
			float num4 = RigShit.GetOwnVRRig().transform.position.z + num * Mathf.Sin(Mods.angle);
			GameObject.Find("Cave Bat Holdable").transform.position = new Vector3(num2, num3, num4);
		}

		// Token: 0x0600015D RID: 349 RVA: 0x00015E0C File Offset: 0x0001400C
		public static void OrbitBall()
		{
			float num = 1f;
			Mods.angle += Mods.orbitSpeed * Time.deltaTime;
			float num2 = RigShit.GetOwnVRRig().transform.position.x + num * Mathf.Cos(Mods.angle);
			float num3 = RigShit.GetOwnVRRig().transform.position.y + num * Mathf.Sin(Mods.angle);
			float num4 = RigShit.GetOwnVRRig().transform.position.z + num * Mathf.Sin(Mods.angle);
			foreach (TransferrableBall transferrableBall in Object.FindObjectsOfType<TransferrableBall>())
			{
				transferrableBall.transform.position = new Vector3(num2, num3, num4);
			}
		}

		// Token: 0x0600015E RID: 350 RVA: 0x00015ED8 File Offset: 0x000140D8
		public static void OrbitMonsters()
		{
			float num = 1f;
			Mods.angle += Mods.orbitSpeed * Time.deltaTime;
			float num2 = RigShit.GetOwnVRRig().transform.position.x + num * Mathf.Cos(Mods.angle);
			float num3 = RigShit.GetOwnVRRig().transform.position.y + num * Mathf.Sin(Mods.angle);
			float num4 = RigShit.GetOwnVRRig().transform.position.z + num * Mathf.Sin(Mods.angle);
			GameObject.Find("Monkeye_Prefab_1").transform.position = new Vector3(num2, num3, num4);
			GameObject.Find("Monkeye_Prefab_2").transform.position = new Vector3(num2, num3, num4);
		}

		// Token: 0x0600015F RID: 351 RVA: 0x00015FA4 File Offset: 0x000141A4
		public static void OrbitTrain()
		{
			float num = 1f;
			Mods.angle += Mods.orbitSpeed * Time.deltaTime;
			float num2 = RigShit.GetOwnVRRig().transform.position.x + num * Mathf.Cos(Mods.angle);
			float num3 = RigShit.GetOwnVRRig().transform.position.y + num * Mathf.Sin(Mods.angle);
			float num4 = RigShit.GetOwnVRRig().transform.position.z + num * Mathf.Sin(Mods.angle);
			GameObject.Find("Environment Objects/LocalObjects_Prefab/Forest/Holiday2023Forest/Holiday2023Forest_Gameplay/NCTrain_Kit_Prefab/NCTrainEngine_Prefab/TrainHoliday_FBX").transform.position = new Vector3(num2, num3, num4);
		}

		// Token: 0x06000160 RID: 352 RVA: 0x00016054 File Offset: 0x00014254
		public static void HaloBug()
		{
			Mods.angle += Mods.orbitSpeed * Time.deltaTime;
			float num = RigShit.GetOwnVRRig().headConstraint.transform.position.x + 0.5f * Mathf.Cos(Mods.angle);
			float num2 = RigShit.GetOwnVRRig().headConstraint.transform.position.y + 0.5f;
			float num3 = RigShit.GetOwnVRRig().headConstraint.transform.position.z + 0.5f * Mathf.Sin(Mods.angle);
			GameObject.Find("Floating Bug Holdable").transform.position = new Vector3(num, num2, num3);
		}

		// Token: 0x06000161 RID: 353 RVA: 0x0001610C File Offset: 0x0001430C
		public static void HaloBat()
		{
			Mods.angle += Mods.orbitSpeed * Time.deltaTime;
			float num = RigShit.GetOwnVRRig().headConstraint.transform.position.x + 0.5f * Mathf.Cos(Mods.angle);
			float num2 = RigShit.GetOwnVRRig().headConstraint.transform.position.y + 0.5f;
			float num3 = RigShit.GetOwnVRRig().headConstraint.transform.position.z + 0.5f * Mathf.Sin(Mods.angle);
			GameObject.Find("Cave Bat Holdable").transform.position = new Vector3(num, num2, num3);
		}

		// Token: 0x06000162 RID: 354 RVA: 0x000161C4 File Offset: 0x000143C4
		public static void HaloBall()
		{
			Mods.angle += Mods.orbitSpeed * Time.deltaTime;
			float num = RigShit.GetOwnVRRig().headConstraint.transform.position.x + 0.5f * Mathf.Cos(Mods.angle);
			float num2 = RigShit.GetOwnVRRig().headConstraint.transform.position.y + 0.5f;
			float num3 = RigShit.GetOwnVRRig().headConstraint.transform.position.z + 0.5f * Mathf.Sin(Mods.angle);
			GameObject.Find("Ball").transform.position = new Vector3(num, num2, num3);
		}

		// Token: 0x06000163 RID: 355 RVA: 0x0001627C File Offset: 0x0001447C
		public static void HaloMonsters()
		{
			Mods.angle += Mods.orbitSpeed * Time.deltaTime;
			float num = RigShit.GetOwnVRRig().headConstraint.transform.position.x + 0.5f * Mathf.Cos(Mods.angle);
			float num2 = RigShit.GetOwnVRRig().headConstraint.transform.position.y + 0.5f;
			float num3 = RigShit.GetOwnVRRig().headConstraint.transform.position.z + 0.5f * Mathf.Sin(Mods.angle);
			GameObject.Find("Monkeye_Prefab_1").transform.position = new Vector3(num, num2, num3);
			GameObject.Find("Monkeye_Prefab_2").transform.position = new Vector3(num, num2, num3);
		}

		// Token: 0x06000164 RID: 356 RVA: 0x00016350 File Offset: 0x00014550
		public static void HaloTrain()
		{
			Mods.angle += Mods.orbitSpeed * Time.deltaTime;
			float num = RigShit.GetOwnVRRig().headConstraint.transform.position.x + 0.5f * Mathf.Cos(Mods.angle);
			float num2 = RigShit.GetOwnVRRig().headConstraint.transform.position.y + 0.5f;
			float num3 = RigShit.GetOwnVRRig().headConstraint.transform.position.z + 0.5f * Mathf.Sin(Mods.angle);
			GameObject.Find("Environment Objects/LocalObjects_Prefab/Forest/Holiday2023Forest/Holiday2023Forest_Gameplay/NCTrain_Kit_Prefab/NCTrainEngine_Prefab/TrainHoliday_FBX").transform.position = new Vector3(num, num2, num3);
		}

		// Token: 0x06000165 RID: 357 RVA: 0x00016407 File Offset: 0x00014607
		public static void SetNameToSpiderOnTop()
		{
			Mods.ChangeName("SpiderOnTop");
		}

		// Token: 0x06000166 RID: 358 RVA: 0x00016415 File Offset: 0x00014615
		public static void SetNameToPBBV()
		{
			Mods.ChangeName("PBBV");
		}

		// Token: 0x06000167 RID: 359 RVA: 0x00016424 File Offset: 0x00014624
		public static void ReportAll()
		{
			bool flag = ControllerInputPoller.instance.rightControllerIndexFloat == 1f;
			if (flag)
			{
				Player[] playerList = PhotonNetwork.PlayerList;
				for (int i = 0; i < playerList.Length; i++)
				{
					Player player = playerList[i];
					bool flag2 = player.NickName != PhotonNetwork.LocalPlayer.NickName;
					bool flag3 = flag2;
					if (flag3)
					{
						GorillaPlayerScoreboardLine[] array = (from x in Object.FindObjectsOfType<GorillaPlayerScoreboardLine>()
						where x.linePlayer == GorillaGameManager.instance.FindVRRigForPlayer(player).Owner
						select x).ToArray<GorillaPlayerScoreboardLine>();
						array[0].PressButton(true, 4);
						array[0].PressButton(true, 0);
						array[0].PressButton(true, 2);
						array[0].PressButton(true, 1);
						array[0].PressButton(true, 4);
						foreach (GorillaPlayerScoreboardLine gorillaPlayerScoreboardLine in array)
						{
							gorillaPlayerScoreboardLine.reportButton.isOn = true;
							gorillaPlayerScoreboardLine.reportButton.UpdateColor();
						}
					}
				}
			}
		}

		// Token: 0x06000168 RID: 360 RVA: 0x0001653C File Offset: 0x0001473C
		public static void BatGun()
		{
			bool rightGrab = ControllerInputPoller.instance.rightGrab;
			if (rightGrab)
			{
				RaycastHit raycastHit;
				bool flag = Physics.Raycast(Player.Instance.rightControllerTransform.position - Player.Instance.rightControllerTransform.up, -Player.Instance.rightControllerTransform.up, ref raycastHit) && Mods.pointer == null;
				bool flag2 = flag;
				if (flag2)
				{
					Mods.pointer = GameObject.CreatePrimitive(0);
					Object.Destroy(Mods.pointer.GetComponent<Rigidbody>());
					Object.Destroy(Mods.pointer.GetComponent<SphereCollider>());
					Mods.pointer.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
				}
				Mods.pointer.transform.position = raycastHit.point;
				bool flag3 = ControllerInputPoller.instance.rightControllerIndexFloat > 0f;
				bool flag4 = flag3;
				if (flag4)
				{
					Mods.pointer.GetComponent<Renderer>().material.color = new Color32(byte.MaxValue, 0, 0, 1);
					GameObject.Find("Cave Bat Holdable").transform.position = Mods.pointer.transform.position;
				}
				Mods.pointer.GetComponent<Renderer>().material.color = new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, 1);
			}
			else
			{
				Object.Destroy(Mods.pointer);
			}
		}

		// Token: 0x06000169 RID: 361 RVA: 0x000166C4 File Offset: 0x000148C4
		public static void FixGoound()
		{
			foreach (GorillaSurfaceOverride gorillaSurfaceOverride in Resources.FindObjectsOfTypeAll<GorillaSurfaceOverride>())
			{
				gorillaSurfaceOverride.extraVelMaxMultiplier = 1f;
				gorillaSurfaceOverride.extraVelMultiplier = 1f;
			}
			bool activeSelf = GameObject.Find("Environment Objects/LocalObjects_Prefab").transform.Find("Mountain").gameObject.activeSelf;
			if (activeSelf)
			{
				GameObject.Find("Environment Objects/LocalObjects_Prefab/Mountain/Geometry/V2_mountainsidesnow").GetComponent<GorillaSurfaceOverride>().overrideIndex = 32;
			}
			else
			{
				bool activeSelf2 = GameObject.Find("Environment Objects/LocalObjects_Prefab").transform.Find("Forest").gameObject.activeSelf;
				if (activeSelf2)
				{
					GameObject.Find("Environment Objects/LocalObjects_Prefab/Forest/Terrain/pitgeo/pit ground").GetComponent<GorillaSurfaceOverride>().overrideIndex = 7;
				}
				else
				{
					bool activeSelf3 = GameObject.Find("Environment Objects/LocalObjects_Prefab").transform.Find("Beach").gameObject.activeSelf;
					if (activeSelf3)
					{
						GameObject.Find("Environment Objects/LocalObjects_Prefab/ForestToBeach/ForestToBeach_Prefab_V4/ForestToBeach_Geo/B_CaveGrassV2").GetComponent<GorillaSurfaceOverride>().overrideIndex = 7;
						GameObject.Find("Environment Objects/LocalObjects_Prefab/Beach/Beach_Main_Geo/B_Terrain_prefab/B_GrassGround").GetComponent<GorillaSurfaceOverride>().overrideIndex = 7;
						GameObject.Find("Environment Objects/LocalObjects_Prefab/Beach/Beach_Main_Geo/B_Terrain_prefab/B_SandGround").GetComponent<GorillaSurfaceOverride>().overrideIndex = 197;
						GameObject.Find("Environment Objects/LocalObjects_Prefab/Beach/Beach_Main_Geo/B_DocksPier_1/B_Dock_Main1").GetComponent<GorillaSurfaceOverride>().overrideIndex = 145;
					}
					else
					{
						bool activeSelf4 = GameObject.Find("Environment Objects/LocalObjects_Prefab").transform.Find("Canyon").gameObject.activeSelf;
						if (activeSelf4)
						{
							GameObject.Find("Environment Objects/LocalObjects_Prefab/Canyon/Canyon/CanyonV5_Prefab/Canyon4_6_GroundA").GetComponent<GorillaSurfaceOverride>().overrideIndex = 0;
						}
					}
				}
			}
		}

		// Token: 0x0600016A RID: 362 RVA: 0x00016858 File Offset: 0x00014A58
		public static void GrabBallR()
		{
			bool rightGrab = ControllerInputPoller.instance.rightGrab;
			if (rightGrab)
			{
				GameObject.Find("Ball").transform.position = GorillaTagger.Instance.rightHandTransform.position;
			}
		}

		// Token: 0x0600016B RID: 363 RVA: 0x0001689C File Offset: 0x00014A9C
		public static void FrogGround()
		{
			bool activeSelf = GameObject.Find("Environment Objects/LocalObjects_Prefab").transform.Find("Mountain").gameObject.activeSelf;
			if (activeSelf)
			{
				GameObject.Find("Environment Objects/LocalObjects_Prefab/Mountain/Geometry/V2_mountainsidesnow").GetComponent<GorillaSurfaceOverride>().overrideIndex = 91;
			}
			else
			{
				bool activeSelf2 = GameObject.Find("Environment Objects/LocalObjects_Prefab").transform.Find("Forest").gameObject.activeSelf;
				if (activeSelf2)
				{
					GameObject.Find("Environment Objects/LocalObjects_Prefab/Forest/Terrain/pitgeo/pit ground").GetComponent<GorillaSurfaceOverride>().overrideIndex = 91;
				}
				else
				{
					bool activeSelf3 = GameObject.Find("Environment Objects/LocalObjects_Prefab").transform.Find("Beach").gameObject.activeSelf;
					if (activeSelf3)
					{
						GameObject.Find("Environment Objects/LocalObjects_Prefab/ForestToBeach/ForestToBeach_Prefab_V4/ForestToBeach_Geo/B_CaveGrassV2").GetComponent<GorillaSurfaceOverride>().overrideIndex = 91;
						GameObject.Find("Environment Objects/LocalObjects_Prefab/Beach/Beach_Main_Geo/B_Terrain_prefab/B_GrassGround").GetComponent<GorillaSurfaceOverride>().overrideIndex = 91;
						GameObject.Find("Environment Objects/LocalObjects_Prefab/Beach/Beach_Main_Geo/B_Terrain_prefab/B_SandGround").GetComponent<GorillaSurfaceOverride>().overrideIndex = 91;
						GameObject.Find("Environment Objects/LocalObjects_Prefab/Beach/Beach_Main_Geo/B_DocksPier_1/B_Dock_Main1").GetComponent<GorillaSurfaceOverride>().overrideIndex = 91;
					}
					else
					{
						bool activeSelf4 = GameObject.Find("Environment Objects/LocalObjects_Prefab").transform.Find("Canyon").gameObject.activeSelf;
						if (activeSelf4)
						{
							GameObject.Find("Environment Objects/LocalObjects_Prefab/Canyon/Canyon/CanyonV5_Prefab/Canyon4_6_GroundA").GetComponent<GorillaSurfaceOverride>().overrideIndex = 91;
						}
					}
				}
			}
		}

		// Token: 0x0600016C RID: 364 RVA: 0x000169F4 File Offset: 0x00014BF4
		public static void ornamentGround()
		{
			bool activeSelf = GameObject.Find("Environment Objects/LocalObjects_Prefab").transform.Find("Mountain").gameObject.activeSelf;
			if (activeSelf)
			{
				GameObject.Find("Environment Objects/LocalObjects_Prefab/Mountain/Geometry/V2_mountainsidesnow").GetComponent<GorillaSurfaceOverride>().overrideIndex = 128;
			}
			else
			{
				bool activeSelf2 = GameObject.Find("Environment Objects/LocalObjects_Prefab").transform.Find("Forest").gameObject.activeSelf;
				if (activeSelf2)
				{
					GameObject.Find("Environment Objects/LocalObjects_Prefab/Forest/Terrain/pitgeo/pit ground").GetComponent<GorillaSurfaceOverride>().overrideIndex = 128;
				}
				else
				{
					bool activeSelf3 = GameObject.Find("Environment Objects/LocalObjects_Prefab").transform.Find("Beach").gameObject.activeSelf;
					if (activeSelf3)
					{
						GameObject.Find("Environment Objects/LocalObjects_Prefab/ForestToBeach/ForestToBeach_Prefab_V4/ForestToBeach_Geo/B_CaveGrassV2").GetComponent<GorillaSurfaceOverride>().overrideIndex = 128;
						GameObject.Find("Environment Objects/LocalObjects_Prefab/Beach/Beach_Main_Geo/B_Terrain_prefab/B_GrassGround").GetComponent<GorillaSurfaceOverride>().overrideIndex = 128;
						GameObject.Find("Environment Objects/LocalObjects_Prefab/Beach/Beach_Main_Geo/B_Terrain_prefab/B_SandGround").GetComponent<GorillaSurfaceOverride>().overrideIndex = 128;
						GameObject.Find("Environment Objects/LocalObjects_Prefab/Beach/Beach_Main_Geo/B_DocksPier_1/B_Dock_Main1").GetComponent<GorillaSurfaceOverride>().overrideIndex = 128;
					}
					else
					{
						bool activeSelf4 = GameObject.Find("Environment Objects/LocalObjects_Prefab").transform.Find("Canyon").gameObject.activeSelf;
						if (activeSelf4)
						{
							GameObject.Find("Environment Objects/LocalObjects_Prefab/Canyon/Canyon/CanyonV5_Prefab/Canyon4_6_GroundA").GetComponent<GorillaSurfaceOverride>().overrideIndex = 128;
						}
					}
				}
			}
		}

		// Token: 0x0600016D RID: 365 RVA: 0x00016B64 File Offset: 0x00014D64
		public static void ButtonGround()
		{
			bool activeSelf = GameObject.Find("Environment Objects/LocalObjects_Prefab").transform.Find("Mountain").gameObject.activeSelf;
			if (activeSelf)
			{
				GameObject.Find("Environment Objects/LocalObjects_Prefab/Mountain/Geometry/V2_mountainsidesnow").GetComponent<GorillaSurfaceOverride>().overrideIndex = 67;
			}
			else
			{
				bool activeSelf2 = GameObject.Find("Environment Objects/LocalObjects_Prefab").transform.Find("Forest").gameObject.activeSelf;
				if (activeSelf2)
				{
					GameObject.Find("Environment Objects/LocalObjects_Prefab/Forest/Terrain/pitgeo/pit ground").GetComponent<GorillaSurfaceOverride>().overrideIndex = 67;
				}
				else
				{
					bool activeSelf3 = GameObject.Find("Environment Objects/LocalObjects_Prefab").transform.Find("Beach").gameObject.activeSelf;
					if (activeSelf3)
					{
						GameObject.Find("Environment Objects/LocalObjects_Prefab/ForestToBeach/ForestToBeach_Prefab_V4/ForestToBeach_Geo/B_CaveGrassV2").GetComponent<GorillaSurfaceOverride>().overrideIndex = 67;
						GameObject.Find("Environment Objects/LocalObjects_Prefab/Beach/Beach_Main_Geo/B_Terrain_prefab/B_GrassGround").GetComponent<GorillaSurfaceOverride>().overrideIndex = 67;
						GameObject.Find("Environment Objects/LocalObjects_Prefab/Beach/Beach_Main_Geo/B_Terrain_prefab/B_SandGround").GetComponent<GorillaSurfaceOverride>().overrideIndex = 67;
						GameObject.Find("Environment Objects/LocalObjects_Prefab/Beach/Beach_Main_Geo/B_DocksPier_1/B_Dock_Main1").GetComponent<GorillaSurfaceOverride>().overrideIndex = 67;
					}
					else
					{
						bool activeSelf4 = GameObject.Find("Environment Objects/LocalObjects_Prefab").transform.Find("Canyon").gameObject.activeSelf;
						if (activeSelf4)
						{
							GameObject.Find("Environment Objects/LocalObjects_Prefab/Canyon/Canyon/CanyonV5_Prefab/Canyon4_6_GroundA").GetComponent<GorillaSurfaceOverride>().overrideIndex = 67;
						}
					}
				}
			}
		}

		// Token: 0x0600016E RID: 366 RVA: 0x00016CBC File Offset: 0x00014EBC
		public static void COLORALL()
		{
			foreach (VRRig vrrig in (VRRig[])Object.FindObjectsOfType(typeof(VRRig)))
			{
				vrrig.mainSkin.material.color = Color.clear;
			}
		}

		// Token: 0x0600016F RID: 367 RVA: 0x00016D0C File Offset: 0x00014F0C
		public static void DrumGround()
		{
			bool activeSelf = GameObject.Find("Environment Objects/LocalObjects_Prefab").transform.Find("Mountain").gameObject.activeSelf;
			if (activeSelf)
			{
				GameObject.Find("Environment Objects/LocalObjects_Prefab/Mountain/Geometry/V2_mountainsidesnow").GetComponent<GorillaSurfaceOverride>().overrideIndex = 73;
			}
			else
			{
				bool activeSelf2 = GameObject.Find("Environment Objects/LocalObjects_Prefab").transform.Find("Forest").gameObject.activeSelf;
				if (activeSelf2)
				{
					GameObject.Find("Environment Objects/LocalObjects_Prefab/Forest/Terrain/pitgeo/pit ground").GetComponent<GorillaSurfaceOverride>().overrideIndex = 73;
				}
				else
				{
					bool activeSelf3 = GameObject.Find("Environment Objects/LocalObjects_Prefab").transform.Find("Beach").gameObject.activeSelf;
					if (activeSelf3)
					{
						GameObject.Find("Environment Objects/LocalObjects_Prefab/ForestToBeach/ForestToBeach_Prefab_V4/ForestToBeach_Geo/B_CaveGrassV2").GetComponent<GorillaSurfaceOverride>().overrideIndex = 73;
						GameObject.Find("Environment Objects/LocalObjects_Prefab/Beach/Beach_Main_Geo/B_Terrain_prefab/B_GrassGround").GetComponent<GorillaSurfaceOverride>().overrideIndex = 73;
						GameObject.Find("Environment Objects/LocalObjects_Prefab/Beach/Beach_Main_Geo/B_Terrain_prefab/B_SandGround").GetComponent<GorillaSurfaceOverride>().overrideIndex = 73;
						GameObject.Find("Environment Objects/LocalObjects_Prefab/Beach/Beach_Main_Geo/B_DocksPier_1/B_Dock_Main1").GetComponent<GorillaSurfaceOverride>().overrideIndex = 73;
					}
					else
					{
						bool activeSelf4 = GameObject.Find("Environment Objects/LocalObjects_Prefab").transform.Find("Canyon").gameObject.activeSelf;
						if (activeSelf4)
						{
							GameObject.Find("Environment Objects/LocalObjects_Prefab/Canyon/Canyon/CanyonV5_Prefab/Canyon4_6_GroundA").GetComponent<GorillaSurfaceOverride>().overrideIndex = 73;
						}
					}
				}
			}
		}

		// Token: 0x06000170 RID: 368 RVA: 0x00016E64 File Offset: 0x00015064
		public static void esphuntoff()
		{
			bool flag = Mods.widhcnkesdj1;
			if (flag)
			{
				foreach (VRRig vrrig in (VRRig[])Object.FindObjectsOfType(typeof(VRRig)))
				{
					bool flag2 = !vrrig.isOfflineVRRig && !vrrig.isMyPlayer;
					if (flag2)
					{
						vrrig.ChangeMaterialLocal(vrrig.currentMatIndex);
					}
				}
				Mods.widhcnkesdj1 = false;
			}
		}

		// Token: 0x06000171 RID: 369 RVA: 0x00016ED6 File Offset: 0x000150D6
		public static void DisableForestGroundSnow()
		{
			GameObject.Find("pit ground").GetComponent<GorillaSurfaceOverride>().overrideIndex = 31;
		}

		// Token: 0x06000172 RID: 370 RVA: 0x00016EF0 File Offset: 0x000150F0
		public static void ProcessCheckPoint()
		{
			bool flag = Mods.CalculateGrabState(ControllerInputPoller.instance.rightControllerGripFloat, 0.75f);
			bool flag2 = flag;
			if (flag2)
			{
				bool flag3 = Mods.pointer == null;
				bool flag4 = flag3;
				if (flag4)
				{
					Mods.pointer = GameObject.CreatePrimitive(0);
					Object.Destroy(Mods.pointer.GetComponent<Rigidbody>());
					Object.Destroy(Mods.pointer.GetComponent<SphereCollider>());
					Mods.pointer.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
				}
				Mods.pointer.transform.position = Player.Instance.rightControllerTransform.position;
			}
			bool flag5 = !Mods.CalculateGrabState(ControllerInputPoller.instance.rightControllerGripFloat, 0.75f) && Mods.CalculateGrabState(ControllerInputPoller.instance.rightControllerIndexFloat, 0.75f);
			bool flag6 = flag5;
			if (flag6)
			{
				Mods.pointer.GetComponent<Renderer>().material.color = Color.green;
				Player.Instance.GetComponent<Rigidbody>().isKinematic = true;
				GameObject.Find("GorillaPlayer").transform.position = Mods.pointer.transform.position;
				Player.Instance.GetComponent<Rigidbody>().velocity = new Vector3(0f, 0f, 0f);
				Player.Instance.GetComponent<Rigidbody>().isKinematic = false;
			}
			else
			{
				Mods.pointer.GetComponent<Renderer>().material.color = Color.red;
			}
		}

		// Token: 0x06000173 RID: 371 RVA: 0x00017084 File Offset: 0x00015284
		public static void BallGun()
		{
			bool rightGrab = ControllerInputPoller.instance.rightGrab;
			if (rightGrab)
			{
				RaycastHit raycastHit;
				bool flag = Physics.Raycast(Player.Instance.rightControllerTransform.position - Player.Instance.rightControllerTransform.up, -Player.Instance.rightControllerTransform.up, ref raycastHit) && Mods.pointer == null;
				bool flag2 = flag;
				if (flag2)
				{
					Mods.pointer = GameObject.CreatePrimitive(0);
					Object.Destroy(Mods.pointer.GetComponent<Rigidbody>());
					Object.Destroy(Mods.pointer.GetComponent<SphereCollider>());
					Mods.pointer.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
				}
				Mods.pointer.transform.position = raycastHit.point;
				bool flag3 = ControllerInputPoller.instance.rightControllerIndexFloat > 0f;
				bool flag4 = flag3;
				if (flag4)
				{
					Mods.pointer.GetComponent<Renderer>().material.color = new Color32(byte.MaxValue, 0, 0, 1);
					GameObject.Find("Ball").transform.position = Mods.pointer.transform.position;
				}
				Mods.pointer.GetComponent<Renderer>().material.color = new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, 1);
			}
			else
			{
				Object.Destroy(Mods.pointer);
			}
		}

		// Token: 0x06000174 RID: 372 RVA: 0x0001720C File Offset: 0x0001540C
		public static void ProcessCustomPlatformMonke()
		{
			bool leftControllerPrimaryButton = ControllerInputPoller.instance.leftControllerPrimaryButton;
			if (leftControllerPrimaryButton)
			{
				Mods.platnum++;
				bool flag = Mods.platnum == 8;
				if (flag)
				{
					Mods.platnum = 0;
					Mods.platcolor = Color.black;
				}
				bool flag2 = Mods.platnum == 0;
				if (flag2)
				{
					Mods.platcolor = Color.magenta;
				}
				bool flag3 = Mods.platnum == 1;
				if (flag3)
				{
					Mods.platcolor = Color.green;
				}
				bool flag4 = Mods.platnum == 2;
				if (flag4)
				{
					Mods.platcolor = Color.white;
				}
				bool flag5 = Mods.platnum == 3;
				if (flag5)
				{
					Mods.platcolor = Color.gray;
				}
				bool flag6 = Mods.platnum == 4;
				if (flag6)
				{
					Mods.platcolor = Color.red;
				}
				bool flag7 = Mods.platnum == 5;
				if (flag7)
				{
					Mods.platcolor = Color.yellow;
				}
				bool flag8 = Mods.platnum == 6;
				if (flag8)
				{
					Mods.platcolor = Color.blue;
				}
				bool flag9 = Mods.platnum == 7;
				if (flag9)
				{
					Mods.platcolor = Color.cyan;
				}
			}
			bool flag10 = !Mods.once_networking;
			if (flag10)
			{
				PhotonNetwork.NetworkingClient.EventReceived += Mods.PlatformNetwork;
				Mods.once_networking = true;
			}
			bool rightGrab = ControllerInputPoller.instance.rightGrab;
			if (rightGrab)
			{
				bool flag11 = !Mods.once_right && Mods.jump_right_local == null;
				if (flag11)
				{
					Mods.jump_right_local = GameObject.CreatePrimitive(3);
					Mods.jump_right_local.GetComponent<Renderer>().material.color = Mods.platcolor;
					Mods.jump_right_local.transform.localScale = Mods.scale;
					Mods.jump_right_local.transform.position = new Vector3(0f, -0.01f, 0f) + Player.Instance.rightControllerTransform.position;
					Mods.jump_right_local.transform.rotation = Player.Instance.rightControllerTransform.rotation;
					object[] array = new object[]
					{
						new Vector3(0f, -0.01f, 0f) + Player.Instance.rightControllerTransform.position,
						Player.Instance.rightControllerTransform.rotation
					};
					RaiseEventOptions raiseEventOptions = new RaiseEventOptions
					{
						Receivers = 0
					};
					PhotonNetwork.RaiseEvent(70, array, raiseEventOptions, SendOptions.SendReliable);
					Mods.once_right = true;
					Mods.once_right_false = false;
				}
			}
			else
			{
				bool flag12 = !Mods.once_right_false && Mods.jump_right_local != null;
				if (flag12)
				{
					Object.Destroy(Mods.jump_right_local);
					Mods.jump_right_local = null;
					Mods.once_right = false;
					Mods.once_right_false = true;
					RaiseEventOptions raiseEventOptions2 = new RaiseEventOptions
					{
						Receivers = 0
					};
					PhotonNetwork.RaiseEvent(72, null, raiseEventOptions2, SendOptions.SendReliable);
				}
			}
			bool leftGrab = ControllerInputPoller.instance.leftGrab;
			if (leftGrab)
			{
				bool flag13 = !Mods.once_left && Mods.jump_left_local == null;
				if (flag13)
				{
					Mods.jump_left_local = GameObject.CreatePrimitive(3);
					Mods.jump_left_local.GetComponent<Renderer>().material.SetColor("_Color", Mods.platcolor);
					Mods.jump_left_local.transform.localScale = Mods.scale;
					Mods.jump_left_local.transform.position = new Vector3(0f, -0.01f, 0f) + Player.Instance.leftControllerTransform.position;
					Mods.jump_left_local.transform.rotation = Player.Instance.leftControllerTransform.rotation;
					object[] array2 = new object[]
					{
						new Vector3(0f, -0.01f, 0f) + Player.Instance.leftControllerTransform.position,
						Player.Instance.leftControllerTransform.rotation
					};
					RaiseEventOptions raiseEventOptions3 = new RaiseEventOptions
					{
						Receivers = 0
					};
					PhotonNetwork.RaiseEvent(69, array2, raiseEventOptions3, SendOptions.SendReliable);
					Mods.once_left = true;
					Mods.once_left_false = false;
				}
			}
			else
			{
				bool flag14 = !Mods.once_left_false && Mods.jump_left_local != null;
				if (flag14)
				{
					Object.Destroy(Mods.jump_left_local);
					Mods.jump_left_local = null;
					Mods.once_left = false;
					Mods.once_left_false = true;
					RaiseEventOptions raiseEventOptions4 = new RaiseEventOptions
					{
						Receivers = 0
					};
					PhotonNetwork.RaiseEvent(71, null, raiseEventOptions4, SendOptions.SendReliable);
				}
			}
			bool flag15 = !PhotonNetwork.InRoom;
			if (flag15)
			{
				for (int i = 0; i < Mods.jump_right_network.Length; i++)
				{
					Object.Destroy(Mods.jump_right_network[i]);
				}
				for (int j = 0; j < Mods.jump_left_network.Length; j++)
				{
					Object.Destroy(Mods.jump_left_network[j]);
				}
			}
		}

		// Token: 0x06000175 RID: 373 RVA: 0x000176F7 File Offset: 0x000158F7
		private static void PlatformNetwork(EventData eventData)
		{
		}

		// Token: 0x06000176 RID: 374 RVA: 0x000176FC File Offset: 0x000158FC
		public static void triggerplats()
		{
			Mods.colorKeysPlatformMonke[0].color = Color.red;
			Mods.colorKeysPlatformMonke[0].time = 0f;
			Mods.colorKeysPlatformMonke[1].color = Color.green;
			Mods.colorKeysPlatformMonke[1].time = 0.3f;
			Mods.colorKeysPlatformMonke[2].color = Color.blue;
			Mods.colorKeysPlatformMonke[2].time = 0.6f;
			Mods.colorKeysPlatformMonke[3].color = Color.red;
			Mods.colorKeysPlatformMonke[3].time = 1f;
			bool flag = !Mods.once_networking;
			if (flag)
			{
				PhotonNetwork.NetworkingClient.EventReceived += Mods.PlatformNetwork;
				Mods.once_networking = true;
			}
			bool flag2 = ControllerInputPoller.instance.rightControllerIndexFloat == 1f;
			if (flag2)
			{
				bool flag3 = !Mods.once_right && Mods.jump_right_local == null;
				if (flag3)
				{
					Mods.jump_right_local = GameObject.CreatePrimitive(3);
					Mods.jump_right_local.GetComponent<Renderer>().material.SetColor("_Color", Color.black);
					Mods.jump_right_local.transform.localScale = Mods.scale;
					Mods.jump_right_local.transform.position = new Vector3(0f, -0.01f, 0f) + Player.Instance.rightControllerTransform.position;
					Mods.jump_right_local.transform.rotation = Player.Instance.rightControllerTransform.rotation;
					object[] array = new object[]
					{
						new Vector3(0f, -0.01f, 0f) + Player.Instance.rightControllerTransform.position,
						Player.Instance.rightControllerTransform.rotation
					};
					RaiseEventOptions raiseEventOptions = new RaiseEventOptions
					{
						Receivers = 0
					};
					PhotonNetwork.RaiseEvent(70, array, raiseEventOptions, SendOptions.SendReliable);
					Mods.once_right = true;
					Mods.once_right_false = false;
					ColorChanger colorChanger = Mods.jump_right_local.AddComponent<ColorChanger>();
					colorChanger.colors = new Gradient
					{
						colorKeys = Mods.colorKeysPlatformMonke
					};
					colorChanger.Start();
				}
			}
			else
			{
				bool flag4 = !Mods.once_right_false && Mods.jump_right_local != null;
				if (flag4)
				{
					Object.Destroy(Mods.jump_right_local);
					Mods.jump_right_local = null;
					Mods.once_right = false;
					Mods.once_right_false = true;
					RaiseEventOptions raiseEventOptions2 = new RaiseEventOptions
					{
						Receivers = 0
					};
					PhotonNetwork.RaiseEvent(72, null, raiseEventOptions2, SendOptions.SendReliable);
				}
			}
			bool flag5 = ControllerInputPoller.instance.leftControllerIndexFloat == 1f;
			if (flag5)
			{
				bool flag6 = !Mods.once_left && Mods.jump_left_local == null;
				if (flag6)
				{
					Mods.jump_left_local = GameObject.CreatePrimitive(3);
					Mods.jump_left_local.GetComponent<Renderer>().material.SetColor("_Color", Color.black);
					Mods.jump_left_local.transform.localScale = Mods.scale;
					Mods.jump_left_local.transform.position = new Vector3(0f, -0.01f, 0f) + Player.Instance.leftControllerTransform.position;
					Mods.jump_left_local.transform.rotation = Player.Instance.leftControllerTransform.rotation;
					object[] array2 = new object[]
					{
						new Vector3(0f, -0.01f, 0f) + Player.Instance.leftControllerTransform.position,
						Player.Instance.leftControllerTransform.rotation
					};
					RaiseEventOptions raiseEventOptions3 = new RaiseEventOptions
					{
						Receivers = 0
					};
					PhotonNetwork.RaiseEvent(69, array2, raiseEventOptions3, SendOptions.SendReliable);
					Mods.once_left = true;
					Mods.once_left_false = false;
					ColorChanger colorChanger2 = Mods.jump_left_local.AddComponent<ColorChanger>();
					colorChanger2.colors = new Gradient
					{
						colorKeys = Mods.colorKeysPlatformMonke
					};
					colorChanger2.Start();
				}
			}
			else
			{
				bool flag7 = !Mods.once_left_false && Mods.jump_left_local != null;
				if (flag7)
				{
					Object.Destroy(Mods.jump_left_local);
					Mods.jump_left_local = null;
					Mods.once_left = false;
					Mods.once_left_false = true;
					RaiseEventOptions raiseEventOptions4 = new RaiseEventOptions
					{
						Receivers = 0
					};
					PhotonNetwork.RaiseEvent(71, null, raiseEventOptions4, SendOptions.SendReliable);
				}
			}
			bool flag8 = !PhotonNetwork.InRoom;
			if (flag8)
			{
				for (int i = 0; i < Mods.jump_right_network.Length; i++)
				{
					Object.Destroy(Mods.jump_right_network[i]);
				}
				for (int j = 0; j < Mods.jump_left_network.Length; j++)
				{
					Object.Destroy(Mods.jump_left_network[j]);
				}
			}
		}

		// Token: 0x06000177 RID: 375 RVA: 0x00017BF4 File Offset: 0x00015DF4
		public static void Tracers()
		{
			bool flag = PhotonNetwork.CurrentRoom != null;
			if (flag)
			{
				foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
				{
					bool flag2 = !vrrig.isOfflineVRRig && !vrrig.isMyPlayer;
					if (flag2)
					{
						GameObject gameObject = new GameObject("Line");
						LineRenderer lineRenderer = gameObject.AddComponent<LineRenderer>();
						Color color = Color.Lerp(new Color(0f, 1f, 0f, 0.5f), new Color(0f, 1f, 1f, 0.5f), Mathf.PingPong(Time.time, 1f));
						lineRenderer.startColor = color;
						lineRenderer.endColor = color;
						lineRenderer.startWidth = 0.03f;
						lineRenderer.endWidth = 0.03f;
						lineRenderer.positionCount = 2;
						lineRenderer.useWorldSpace = true;
						lineRenderer.SetPosition(0, Player.Instance.rightControllerTransform.position);
						lineRenderer.SetPosition(1, vrrig.transform.position);
						lineRenderer.material.shader = Shader.Find("GUI/Text Shader");
						Object.Destroy(lineRenderer, Time.deltaTime);
						Object.Destroy(gameObject, Time.deltaTime);
					}
				}
			}
		}

		// Token: 0x06000178 RID: 376 RVA: 0x00017D88 File Offset: 0x00015F88
		public static void BetterLongArms()
		{
			bool flag = Mods.CalculateGrabState(ControllerInputPoller.instance.rightControllerIndexFloat, 0.1f);
			bool flag2 = flag;
			if (flag2)
			{
				Player.Instance.transform.localScale += new Vector3(0.02f, 0.02f, 0.02f);
				bool flag3 = Player.Instance.transform.localScale.x > 2f;
				bool flag4 = flag3;
				if (flag4)
				{
					Player.Instance.transform.localScale = new Vector3(2f, 2f, 2f);
				}
			}
			bool flag5 = Mods.CalculateGrabState(ControllerInputPoller.instance.leftControllerIndexFloat, 0.1f);
			bool flag6 = flag5;
			if (flag6)
			{
				Player.Instance.transform.localScale -= new Vector3(0.02f, 0.02f, 0.02f);
				bool flag7 = Player.Instance.transform.localScale.x < 0.2f;
				bool flag8 = flag7;
				if (flag8)
				{
					Player.Instance.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
				}
			}
		}

		// Token: 0x06000179 RID: 377 RVA: 0x00017EC6 File Offset: 0x000160C6
		public static void MosaBoost()
		{
			Player.Instance.maxJumpSpeed = 7.75f;
		}

		// Token: 0x0600017A RID: 378 RVA: 0x00017ED8 File Offset: 0x000160D8
		public static void speedboost()
		{
			Player.Instance.maxJumpSpeed = 9f;
		}

		// Token: 0x0600017B RID: 379 RVA: 0x00017EEC File Offset: 0x000160EC
		public static void ProcessNoClip()
		{
			bool flag = Mods.CalculateGrabState(ControllerInputPoller.instance.rightControllerIndexFloat, 0.1f);
			if (flag)
			{
				bool flag2 = !Mods.flag2;
				if (flag2)
				{
					MeshCollider[] array = Resources.FindObjectsOfTypeAll<MeshCollider>();
					foreach (MeshCollider meshCollider in array)
					{
						meshCollider.enabled = false;
					}
					Mods.flag2 = true;
					Mods.flag1 = false;
				}
			}
			else
			{
				bool flag3 = !Mods.flag1;
				if (flag3)
				{
					MeshCollider[] array3 = Resources.FindObjectsOfTypeAll<MeshCollider>();
					foreach (MeshCollider meshCollider2 in array3)
					{
						meshCollider2.enabled = true;
					}
					Mods.flag1 = true;
					Mods.flag2 = false;
				}
			}
		}

		// Token: 0x0600017C RID: 380 RVA: 0x00017FB0 File Offset: 0x000161B0
		public static void copygun()
		{
			bool gripDownR = WristMenu.gripDownR;
			if (gripDownR)
			{
				bool flag = !MenusGUI.emulators && Physics.Raycast(Player.Instance.rightControllerTransform.position - Player.Instance.rightControllerTransform.up, -Player.Instance.rightControllerTransform.up, ref Mods.raycastHit) && Mods.pointer == null;
				if (flag)
				{
					Mods.pointer = GameObject.CreatePrimitive(0);
					Object.Destroy(Mods.pointer.GetComponent<Rigidbody>());
					Object.Destroy(Mods.pointer.GetComponent<SphereCollider>());
					Mods.pointer.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
				}
				bool triggerDownR = WristMenu.triggerDownR;
				if (triggerDownR)
				{
					bool flag2 = Mods.gunLock;
					if (flag2)
					{
						bool flag3 = Mods.raycastHit.collider.GetComponentInParent<VRRig>() != null;
						if (flag3)
						{
							Mods.lockedrig = Mods.raycastHit.collider.GetComponentInParent<VRRig>();
						}
						bool flag4 = Mods.lockedrig != null;
						if (flag4)
						{
							Mods.pointer.transform.position = Mods.lockedrig.transform.position;
						}
						else
						{
							Mods.pointer.transform.position = Mods.raycastHit.point;
						}
						RigShit.GetPlayerFromRig(Mods.lockedrig);
					}
					else
					{
						Mods.pointer.transform.position = Mods.raycastHit.point;
					}
				}
				bool flag5 = Mods.lockedrig == null;
				if (flag5)
				{
					Mods.pointer.transform.position = Mods.raycastHit.point;
				}
				bool triggerDownR2 = WristMenu.triggerDownR;
				if (triggerDownR2)
				{
					bool flag6 = Mods.lockedrig != GorillaTagger.Instance.offlineVRRig || Mods.lockedrig == null;
					if (flag6)
					{
						bool flag7 = Mods.lockedrig != null;
						if (flag7)
						{
							Mods.chosenplayer = Mods.lockedrig;
						}
						else
						{
							Mods.chosenplayer = Mods.raycastHit.collider.GetComponentInParent<VRRig>();
						}
					}
					bool flag8 = !(Mods.chosenplayer != null);
					if (flag8)
					{
						GorillaTagger.Instance.offlineVRRig.enabled = true;
						GorillaTagger.Instance.offlineVRRig.headConstraint.rotation = Player.Instance.headCollider.transform.rotation;
					}
					else
					{
						bool flag9 = !Mods.chosenplayer.isOfflineVRRig;
						if (flag9)
						{
							VRRig vrrig = Mods.chosenplayer;
							RigShit.GetOwnVRRig().enabled = false;
							RigShit.GetOwnVRRig().transform.position = vrrig.transform.position;
							RigShit.GetOwnVRRig().transform.rotation = vrrig.transform.rotation;
							RigShit.GetOwnVRRig().rightHandPlayer.transform.position = vrrig.rightHandPlayer.transform.position;
							RigShit.GetOwnVRRig().rightHandPlayer.transform.rotation = vrrig.rightHandPlayer.transform.rotation;
							RigShit.GetOwnVRRig().leftHandPlayer.transform.position = vrrig.leftHandPlayer.transform.position;
							RigShit.GetOwnVRRig().leftHandPlayer.transform.rotation = vrrig.leftHandPlayer.transform.rotation;
							RigShit.GetOwnVRRig().head.headTransform.transform.rotation = vrrig.head.headTransform.transform.rotation;
							RigShit.GetOwnVRRig().head.headTransform.transform.position = vrrig.head.headTransform.transform.position;
							GorillaTagger.Instance.offlineVRRig.headConstraint.rotation = vrrig.headConstraint.rotation;
						}
					}
				}
			}
			else
			{
				GorillaTagger.Instance.offlineVRRig.enabled = true;
				Mods.lockedrig = null;
			}
		}

		// Token: 0x0600017D RID: 381 RVA: 0x000183CC File Offset: 0x000165CC
		public static void StartSkeleEsp()
		{
			foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
			{
				bool flag = vrrig != null && !vrrig.isOfflineVRRig;
				if (flag)
				{
					GTExt.GetOrAddComponent<Mods.RGBSkeletonESPClass>(vrrig.gameObject);
				}
			}
			Mods.eirsukdjyfj = true;
		}

		// Token: 0x0600017E RID: 382 RVA: 0x00018450 File Offset: 0x00016650
		public static void EndSkeleEsp()
		{
			bool flag = Mods.eirsukdjyfj;
			if (flag)
			{
				foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
				{
					bool flag2 = vrrig != null && !vrrig.isOfflineVRRig;
					if (flag2)
					{
						Object.Destroy(vrrig.gameObject.GetComponent<Mods.RGBSkeletonESPClass>());
					}
				}
			}
			Mods.eirsukdjyfj = false;
		}

		// Token: 0x0600017F RID: 383 RVA: 0x000184E4 File Offset: 0x000166E4
		public static void GripToToggleTriggerToTogglePlats()
		{
			bool rightGrab = ControllerInputPoller.instance.rightGrab;
			if (rightGrab)
			{
				Mods.TriggerToTogglePlats();
			}
			bool leftGrab = ControllerInputPoller.instance.leftGrab;
			if (leftGrab)
			{
				Mods.TriggerToTogglePlats();
			}
		}

		// Token: 0x06000180 RID: 384 RVA: 0x00018522 File Offset: 0x00016722
		public static void StickyPlatforms()
		{
			Mods.PlatformsThing(false, true);
		}

		// Token: 0x06000181 RID: 385 RVA: 0x0001852D File Offset: 0x0001672D
		public static void InvisStickyPlatforms()
		{
			Mods.PlatformsThing(true, true);
		}

		// Token: 0x06000182 RID: 386 RVA: 0x00018538 File Offset: 0x00016738
		public static void InvisPlatforms()
		{
			Mods.PlatformsThing(true, false);
		}

		// Token: 0x06000183 RID: 387 RVA: 0x00018543 File Offset: 0x00016743
		public static void NoTagFreeze()
		{
			Player.Instance.disableMovement = false;
		}

		// Token: 0x06000184 RID: 388 RVA: 0x00018551 File Offset: 0x00016751
		public static void themechange()
		{
			Player.Instance.disableMovement = false;
		}

		// Token: 0x06000185 RID: 389 RVA: 0x00018560 File Offset: 0x00016760
		public static void PBBVWalk()
		{
			bool rightGrab = ControllerInputPoller.instance.rightGrab;
			if (rightGrab)
			{
				Player.Instance.disableMovement = true;
			}
			else
			{
				Player.Instance.disableMovement = false;
			}
		}

		// Token: 0x06000186 RID: 390 RVA: 0x0001859C File Offset: 0x0001679C
		public static void HandsInHeadByVortex()
		{
			Player.Instance.rightControllerTransform.position = Player.Instance.headCollider.transform.position;
			Player.Instance.leftControllerTransform.position = Player.Instance.headCollider.transform.position;
		}

		// Token: 0x06000187 RID: 391 RVA: 0x000185F4 File Offset: 0x000167F4
		public static void ProcessTagAura()
		{
			bool rightGrab = ControllerInputPoller.instance.rightGrab;
			if (rightGrab)
			{
				foreach (Player player in PhotonNetwork.PlayerList)
				{
					bool flag = !GorillaGameManager.instance.FindPlayerVRRig(player).isMyPlayer;
					if (flag)
					{
						float num = Vector3.Distance(GorillaTagger.Instance.offlineVRRig.transform.position, GorillaGameManager.instance.FindPlayerVRRig(player).transform.position);
						bool flag2 = num < GorillaGameManager.instance.tagDistanceThreshold;
						if (flag2)
						{
							bool flag3 = !GorillaGameManager.instance.FindPlayerVRRig(player).mainSkin.material.name.Contains("fected");
							if (flag3)
							{
								PhotonView.Get(GorillaGameManager.instance.GetComponent<GorillaGameManager>()).RPC("ReportTagRPC", 2, new object[]
								{
									GorillaGameManager.instance.FindVRRigForPlayer(player).Owner
								});
								Mods.FlushRPCS();
							}
						}
					}
				}
			}
		}

		// Token: 0x06000188 RID: 392 RVA: 0x00018708 File Offset: 0x00016908
		public static void TagSelf()
		{
			bool rightGrab = ControllerInputPoller.instance.rightGrab;
			if (rightGrab)
			{
				Mods.FlushRPCS();
				Mods.FlushRPCS();
				Mods.FlushRPCS();
				Mods.FlushRPCS();
				GorillaGameManager[] array = Object.FindObjectsOfType<GorillaGameManager>();
				for (int i = 0; i < array.Length; i++)
				{
					PhotonView.Get(array[i]).RPC("ReportContactWithLavaRPC", 2, Array.Empty<object>());
				}
				Mods.FlushRPCS();
				Mods.FlushRPCS();
				Mods.FlushRPCS();
				Mods.FlushRPCS();
			}
		}

		// Token: 0x06000189 RID: 393 RVA: 0x0001878B File Offset: 0x0001698B
		public static void FlushRPCS()
		{
			GorillaNot.instance.rpcCallLimit = 9999;
			PhotonNetwork.RemoveRPCs(PhotonNetwork.LocalPlayer);
		}

		// Token: 0x0600018A RID: 394 RVA: 0x000187AC File Offset: 0x000169AC
		public static void flushmanually()
		{
			GorillaNot.instance.rpcCallLimit = int.MaxValue;
			PhotonNetwork.RemoveRPCs(PhotonNetwork.LocalPlayer);
			PhotonNetwork.OpCleanActorRpcBuffer(PhotonNetwork.LocalPlayer.ActorNumber);
			PhotonNetwork.OpCleanRpcBuffer(GorillaTagger.Instance.myVRRig);
			PhotonNetwork.RemoveBufferedRPCs(GorillaTagger.Instance.myVRRig.ViewID, null, null);
		}

		// Token: 0x0600018B RID: 395 RVA: 0x00018810 File Offset: 0x00016A10
		public static void ProcessWaterBender()
		{
			bool flag = ControllerInputPoller.instance.rightGrab && ControllerInputPoller.instance.leftGrab;
			if (flag)
			{
				Mods.FlushRPCS();
				Vector3 position = Player.Instance.rightControllerTransform.transform.position;
				Vector3 position2 = Player.Instance.leftControllerTransform.transform.position;
				Quaternion rotation = Player.Instance.rightControllerTransform.transform.rotation;
				Quaternion rotation2 = Player.Instance.leftControllerTransform.transform.rotation;
				Vector3 vector = (position + position2) / 2f;
				Quaternion quaternion = Quaternion.Lerp(rotation, rotation2, 0.5f);
				float num = Vector3.Distance(position, position2);
				PhotonView.Get(GorillaTagger.Instance.myVRRig).RPC("PlaySplashEffect", 0, new object[]
				{
					vector,
					quaternion,
					num,
					num,
					false,
					true
				});
			}
			else
			{
				bool rightGrab = ControllerInputPoller.instance.rightGrab;
				if (rightGrab)
				{
					Mods.FlushRPCS();
					PhotonView.Get(GorillaTagger.Instance.myVRRig).RPC("PlaySplashEffect", 0, new object[]
					{
						Player.Instance.rightControllerTransform.transform.position,
						GorillaTagger.Instance.offlineVRRig.transform.rotation,
						0.3f,
						0.3f,
						false,
						true
					});
				}
				bool leftGrab = ControllerInputPoller.instance.leftGrab;
				if (leftGrab)
				{
					Mods.FlushRPCS();
					PhotonView.Get(GorillaTagger.Instance.myVRRig).RPC("PlaySplashEffect", 0, new object[]
					{
						Player.Instance.leftControllerTransform.transform.position,
						GorillaTagger.Instance.offlineVRRig.transform.rotation,
						0.3f,
						0.3f,
						false,
						true
					});
				}
			}
			bool rightControllerSecondaryButton = ControllerInputPoller.instance.rightControllerSecondaryButton;
			if (rightControllerSecondaryButton)
			{
				Vector3 position3 = GorillaTagger.Instance.offlineVRRig.headMesh.transform.position;
				Quaternion quaternion2 = Quaternion.Euler(90f, 0f, 0f);
				PhotonView.Get(GorillaTagger.Instance.myVRRig).RPC("PlaySplashEffect", 0, new object[]
				{
					position3 + new Vector3(0f, 0.5f, 0f),
					quaternion2,
					0.3f,
					0.3f,
					false,
					false
				});
			}
		}

		// Token: 0x0600018C RID: 396 RVA: 0x00018B34 File Offset: 0x00016D34
		public static void splashgun()
		{
			bool flag = ControllerInputPoller.instance.rightControllerGripFloat == 1f;
			bool flag2 = flag;
			if (flag2)
			{
				RaycastHit raycastHit;
				bool flag3 = Physics.Raycast(Player.Instance.rightControllerTransform.position - Player.Instance.rightControllerTransform.up, -Player.Instance.rightControllerTransform.up, ref raycastHit) && Mods.pointer == null;
				if (flag3)
				{
					Mods.pointer = GameObject.CreatePrimitive(0);
					Object.Destroy(Mods.pointer.GetComponent<Rigidbody>());
					Object.Destroy(Mods.pointer.GetComponent<SphereCollider>());
					Mods.pointer.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
				}
				Mods.pointer.transform.position = raycastHit.point;
				bool flag4 = ControllerInputPoller.instance.rightControllerIndexFloat == 1f;
				if (flag4)
				{
					RigShit.GetOwnVRRig().enabled = false;
					RigShit.GetOwnVRRig().transform.position = Mods.pointer.transform.position;
					GorillaTagger.Instance.myVRRig.RPC("PlaySplashEffect", 0, new object[]
					{
						RigShit.GetOwnVRRig().transform.position,
						Random.rotation,
						4f,
						100f,
						true,
						false
					});
					Mods.flushmanually();
					RigShit.GetOwnVRRig().enabled = true;
				}
			}
			else
			{
				RigShit.GetOwnVRRig().enabled = true;
				Object.Destroy(Mods.pointer);
			}
		}

		// Token: 0x0600018D RID: 397 RVA: 0x00018CFC File Offset: 0x00016EFC
		public static void SilentHandTaps()
		{
			GorillaTagger.Instance.handTapVolume = 0f;
		}

		// Token: 0x0600018E RID: 398 RVA: 0x00018D0E File Offset: 0x00016F0E
		public static void NormalHandTaps()
		{
			GorillaTagger.Instance.handTapVolume = 0.1f;
		}

		// Token: 0x0600018F RID: 399 RVA: 0x00018D20 File Offset: 0x00016F20
		public static void AirStrike()
		{
			bool rightGrab = ControllerInputPoller.instance.rightGrab;
			if (rightGrab)
			{
				RaycastHit raycastHit;
				Physics.Raycast(Player.Instance.rightControllerTransform.position, -Player.Instance.rightControllerTransform.up, ref raycastHit);
				Mods.pointer = GameObject.CreatePrimitive(0);
				Mods.pointer.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
				Mods.pointer.GetComponent<Renderer>().material.color = new Color32(0, 0, byte.MaxValue, 1);
				Mods.pointer.transform.position = raycastHit.point;
				Object.Destroy(Mods.pointer.GetComponent<BoxCollider>());
				Object.Destroy(Mods.pointer.GetComponent<Rigidbody>());
				Object.Destroy(Mods.pointer.GetComponent<Collider>());
				bool flag = ControllerInputPoller.instance.rightControllerIndexFloat >= 0.3f;
				if (flag)
				{
					Player.Instance.GetComponent<Rigidbody>().velocity = new Vector3(0f, 15f, 0f);
				}
				bool flag2 = Mods.pointer != null;
				if (flag2)
				{
					Object.Destroy(Mods.pointer, Time.deltaTime);
				}
			}
		}

		// Token: 0x06000190 RID: 400 RVA: 0x00018E6C File Offset: 0x0001706C
		public static void CoustomCoC()
		{
			GameObject.Find("motdtext").GetComponent<Text>().text = "<color=red> Thanks For Using Spider Client V5. If You Have The Time Please Make A Vid On It. </color>";
			GameObject.Find("COC Text").GetComponent<Text>().text = "<color=black> Shortcut Meanings: \n(LG) Left Grip \n(RG) Right Grip \n(O) Ownership \n(M) Master \n(LM) Legit Master/Room Master \n(LT) Left Trigger \n(RT) Right Trigger \n(W) Working \n(NW) Not Working \n(UND) Undetected \n(A) A Button \n(X) X Button</color>";
			GameObject.Find("CodeOfConduct").GetComponent<Text>().text = "<color=black> Spider Client V5 </color>";
			GameObject.Find("motd").GetComponent<Text>().text = "<color=black> Welcome to Spider Client V5 </color>";
		}

		// Token: 0x06000191 RID: 401 RVA: 0x00018EE2 File Offset: 0x000170E2
		public static void LoudHandTaps()
		{
			GorillaTagger.Instance.handTapVolume = 5f;
		}

		// Token: 0x06000192 RID: 402 RVA: 0x00018EF4 File Offset: 0x000170F4
		private static void UpdateScaleForBeacons(GameObject startObj, GameObject endObj, GameObject beaconObj)
		{
			float num = Vector3.Distance(startObj.transform.position, endObj.transform.position);
			beaconObj.transform.localScale = new Vector3(beaconObj.transform.localScale.x, num / 2f, beaconObj.transform.localScale.z);
			Vector3 position = (startObj.transform.position + endObj.transform.position) / 2f;
			beaconObj.transform.position = position;
			Vector3 up = endObj.transform.position - startObj.transform.position;
			beaconObj.transform.up = up;
		}

		// Token: 0x06000193 RID: 403 RVA: 0x00018FB4 File Offset: 0x000171B4
		public static void BugTraces()
		{
			GameObject gameObject = GameObject.Find("Floating Bug Holdable");
			GameObject gameObject2 = GameObject.CreatePrimitive(2);
			Object.Destroy(gameObject2.GetComponent<BoxCollider>());
			Object.Destroy(gameObject2.GetComponent<Rigidbody>());
			Object.Destroy(gameObject2.GetComponent<Collider>());
			Object.Destroy(gameObject2.GetComponent<MeshCollider>());
			gameObject2.transform.rotation = Quaternion.identity;
			gameObject2.transform.localScale = new Vector3(0.02f, 0.02f, 0.02f);
			gameObject2.transform.position = gameObject.transform.position;
			Mods.UpdateScaleForBeacons(GorillaTagger.Instance.rightHandTransform.gameObject, gameObject.gameObject, gameObject2);
			Renderer component = gameObject2.GetComponent<Renderer>();
			component.material.color = Color.Lerp(new Color(0f, 1f, 0f, 0.5f), new Color(0f, 1f, 1f, 0.5f), Mathf.PingPong(Time.time, 1f));
			Object.Destroy(gameObject2, Time.deltaTime);
		}

		// Token: 0x06000194 RID: 404 RVA: 0x000190D0 File Offset: 0x000172D0
		public static void BugSizeChangerByVortex()
		{
			bool rightControllerPrimaryButton = ControllerInputPoller.instance.rightControllerPrimaryButton;
			bool flag = rightControllerPrimaryButton;
			if (flag)
			{
				GameObject.Find("Floating Bug Holdable").transform.localScale += new Vector3(0.1f, 0.1f, 0.1f);
			}
			bool rightGrab = ControllerInputPoller.instance.rightGrab;
			if (rightGrab)
			{
				GameObject.Find("Floating Bug Holdable").transform.localScale += new Vector3(0.1f, 0.1f, 0.1f);
			}
			bool leftGrab = ControllerInputPoller.instance.leftGrab;
			if (leftGrab)
			{
				GameObject.Find("Floating Bug Holdable").transform.localScale -= new Vector3(0.1f, 0.1f, 0.1f);
			}
		}

		// Token: 0x06000195 RID: 405 RVA: 0x000191B4 File Offset: 0x000173B4
		public static void BallTraces()
		{
			GameObject gameObject = GameObject.Find("Ball");
			GameObject gameObject2 = GameObject.CreatePrimitive(2);
			Object.Destroy(gameObject2.GetComponent<BoxCollider>());
			Object.Destroy(gameObject2.GetComponent<Rigidbody>());
			Object.Destroy(gameObject2.GetComponent<Collider>());
			Object.Destroy(gameObject2.GetComponent<MeshCollider>());
			gameObject2.transform.rotation = Quaternion.identity;
			gameObject2.transform.localScale = new Vector3(0.02f, 0.02f, 0.02f);
			gameObject2.transform.position = gameObject.transform.position;
			Mods.UpdateScaleForBeacons(GorillaTagger.Instance.rightHandTransform.gameObject, gameObject.gameObject, gameObject2);
			Renderer component = gameObject2.GetComponent<Renderer>();
			component.material.color = Color.Lerp(new Color(0f, 1f, 0f, 0.5f), new Color(0f, 1f, 1f, 0.5f), Mathf.PingPong(Time.time, 1f));
			Object.Destroy(gameObject2, Time.deltaTime);
		}

		// Token: 0x06000196 RID: 406 RVA: 0x000192D0 File Offset: 0x000174D0
		public static void BallSizeChangerByVortex()
		{
			bool rightControllerPrimaryButton = ControllerInputPoller.instance.rightControllerPrimaryButton;
			bool flag = rightControllerPrimaryButton;
			if (flag)
			{
				GameObject.Find("Ball").transform.localScale += new Vector3(0.1f, 0.1f, 0.1f);
			}
			bool rightGrab = ControllerInputPoller.instance.rightGrab;
			if (rightGrab)
			{
				GameObject.Find("Ball").transform.localScale += new Vector3(0.1f, 0.1f, 0.1f);
			}
			bool leftGrab = ControllerInputPoller.instance.leftGrab;
			if (leftGrab)
			{
				GameObject.Find("Ball").transform.localScale -= new Vector3(0.1f, 0.1f, 0.1f);
			}
		}

		// Token: 0x06000197 RID: 407 RVA: 0x000193B4 File Offset: 0x000175B4
		public static void RightHAndmenu()
		{
			bool rightControllerSecondaryButton = ControllerInputPoller.instance.rightControllerSecondaryButton;
			if (rightControllerSecondaryButton)
			{
				WristMenu.menu.transform.position = GorillaTagger.Instance.leftHandTransform.position;
				WristMenu.menu.transform.rotation = GorillaTagger.Instance.leftHandTransform.rotation;
			}
		}

		// Token: 0x06000198 RID: 408 RVA: 0x00019414 File Offset: 0x00017614
		public static void GrabBallons()
		{
			bool rightGrab = ControllerInputPoller.instance.rightGrab;
			if (rightGrab)
			{
				foreach (BalloonHoldable balloonHoldable in Object.FindObjectsOfType<BalloonHoldable>())
				{
					balloonHoldable.gameObject.transform.position = GorillaTagger.Instance.rightHandTransform.position;
				}
			}
		}

		// Token: 0x06000199 RID: 409 RVA: 0x00019470 File Offset: 0x00017670
		public static void PopBalloons()
		{
			bool leftGrab = ControllerInputPoller.instance.leftGrab;
			if (leftGrab)
			{
				foreach (BalloonHoldable balloonHoldable in Object.FindObjectsOfType<BalloonHoldable>())
				{
					balloonHoldable.PopBalloonRemote();
					balloonHoldable.PopBalloonRemote();
					balloonHoldable.PopBalloonRemote();
					balloonHoldable.PopBalloonRemote();
				}
			}
		}

		// Token: 0x0600019A RID: 410 RVA: 0x000194C8 File Offset: 0x000176C8
		public static void FlickJump()
		{
			bool rightControllerPrimaryButton = ControllerInputPoller.instance.rightControllerPrimaryButton;
			if (rightControllerPrimaryButton)
			{
				Player.Instance.rightControllerTransform.transform.position = GorillaTagger.Instance.rightHandTransform.position + new Vector3(0f, -1.5f, 0f);
			}
		}

		// Token: 0x0600019B RID: 411 RVA: 0x00019525 File Offset: 0x00017725
		public static void ConnectEU()
		{
			PhotonNetwork.ConnectToRegion("eu");
		}

		// Token: 0x0600019C RID: 412 RVA: 0x00019533 File Offset: 0x00017733
		public static void ConnectUSA()
		{
			PhotonNetwork.ConnectToRegion("usw");
		}

		// Token: 0x0600019D RID: 413 RVA: 0x00019541 File Offset: 0x00017741
		public static void ConnectUSW()
		{
			PhotonNetwork.ConnectToRegion("eu");
		}

		// Token: 0x0600019E RID: 414 RVA: 0x00019550 File Offset: 0x00017750
		public static void FreezeLimbs()
		{
			bool flag = ControllerInputPoller.instance.rightControllerIndexFloat == 1f;
			if (flag)
			{
				GorillaTagger.Instance.offlineVRRig.enabled = false;
				GorillaTagger.Instance.offlineVRRig.transform.position = GorillaTagger.Instance.bodyCollider.transform.position + new Vector3(0f, 0.15f, 0f);
				GorillaTagger.Instance.myVRRig.transform.position = GorillaTagger.Instance.bodyCollider.transform.position + new Vector3(0f, 0.15f, 0f);
				GorillaTagger.Instance.offlineVRRig.transform.rotation = GorillaTagger.Instance.bodyCollider.transform.rotation;
				GorillaTagger.Instance.myVRRig.transform.rotation = GorillaTagger.Instance.bodyCollider.transform.rotation;
				GameObject gameObject = GameObject.CreatePrimitive(0);
				Object.Destroy(gameObject.GetComponent<Rigidbody>());
				Object.Destroy(gameObject.GetComponent<SphereCollider>());
				gameObject.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
				gameObject.transform.position = GorillaTagger.Instance.leftHandTransform.position;
				GameObject gameObject2 = GameObject.CreatePrimitive(0);
				Object.Destroy(gameObject2.GetComponent<Rigidbody>());
				Object.Destroy(gameObject2.GetComponent<SphereCollider>());
				gameObject2.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
				gameObject2.transform.position = GorillaTagger.Instance.rightHandTransform.position;
				gameObject.GetComponent<Renderer>().material.color = Color.red;
				gameObject2.GetComponent<Renderer>().material.color = Color.red;
				Object.Destroy(gameObject, Time.deltaTime);
				Object.Destroy(gameObject2, Time.deltaTime);
			}
			else
			{
				GorillaTagger.Instance.offlineVRRig.enabled = true;
			}
		}

		// Token: 0x0600019F RID: 415 RVA: 0x00019770 File Offset: 0x00017970
		public static void TrainTraces()
		{
			GameObject gameObject = GameObject.Find("Environment Objects/LocalObjects_Prefab/Forest/Holiday2023Forest/Holiday2023Forest_Gameplay/NCTrain_Kit_Prefab");
			GameObject gameObject2 = GameObject.CreatePrimitive(2);
			Object.Destroy(gameObject2.GetComponent<BoxCollider>());
			Object.Destroy(gameObject2.GetComponent<Rigidbody>());
			Object.Destroy(gameObject2.GetComponent<Collider>());
			Object.Destroy(gameObject2.GetComponent<MeshCollider>());
			gameObject2.transform.rotation = Quaternion.identity;
			gameObject2.transform.localScale = new Vector3(0.02f, 0.02f, 0.02f);
			gameObject2.transform.position = gameObject.transform.position;
			Mods.UpdateScaleForBeacons(GorillaTagger.Instance.rightHandTransform.gameObject, gameObject.gameObject, gameObject2);
			Renderer component = gameObject2.GetComponent<Renderer>();
			component.material.color = Color.Lerp(new Color(0f, 1f, 0f, 0.5f), new Color(0f, 1f, 1f, 0.5f), Mathf.PingPong(Time.time, 1f));
			Object.Destroy(gameObject2, Time.deltaTime);
		}

		// Token: 0x060001A0 RID: 416 RVA: 0x0001988C File Offset: 0x00017A8C
		public static void TrainSizeChangerByVortex()
		{
			bool rightControllerPrimaryButton = ControllerInputPoller.instance.rightControllerPrimaryButton;
			bool flag = rightControllerPrimaryButton;
			if (flag)
			{
				GameObject.Find("Environment Objects/LocalObjects_Prefab/Forest/Holiday2023Forest/Holiday2023Forest_Gameplay/NCTrain_Kit_Prefab").transform.localScale += new Vector3(0.1f, 0.1f, 0.1f);
			}
			bool rightGrab = ControllerInputPoller.instance.rightGrab;
			if (rightGrab)
			{
				GameObject.Find("Environment Objects/LocalObjects_Prefab/Forest/Holiday2023Forest/Holiday2023Forest_Gameplay/NCTrain_Kit_Prefab").transform.localScale += new Vector3(0.1f, 0.1f, 0.1f);
			}
			bool leftGrab = ControllerInputPoller.instance.leftGrab;
			if (leftGrab)
			{
				GameObject.Find("Environment Objects/LocalObjects_Prefab/Forest/Holiday2023Forest/Holiday2023Forest_Gameplay/NCTrain_Kit_Prefab").transform.localScale -= new Vector3(0.1f, 0.1f, 0.1f);
			}
		}

		// Token: 0x060001A1 RID: 417 RVA: 0x00019970 File Offset: 0x00017B70
		public static void AutoFunnyRun()
		{
			bool rightGrab = ControllerInputPoller.instance.rightGrab;
			if (rightGrab)
			{
				float num = (float)Time.frameCount;
				GorillaTagger.Instance.rightHandTransform.position = GorillaTagger.Instance.headCollider.transform.position + GorillaTagger.Instance.headCollider.transform.forward * Mathf.Cos(num) / 10f + new Vector3(0f, -0.5f - Mathf.Sin(num) / 7f, 0f) + GorillaTagger.Instance.headCollider.transform.right * -0.05f;
				GorillaTagger.Instance.leftHandTransform.position = GorillaTagger.Instance.headCollider.transform.position + GorillaTagger.Instance.headCollider.transform.forward * Mathf.Cos(num + 180f) / 10f + new Vector3(0f, -0.5f - Mathf.Sin(num + 180f) / 7f, 0f) + GorillaTagger.Instance.headCollider.transform.right * 0.05f;
			}
			else
			{
				float num2 = (float)Time.frameCount;
				GorillaTagger.Instance.rightHandTransform.position = GorillaTagger.Instance.headCollider.transform.position + GorillaTagger.Instance.headCollider.transform.forward * Mathf.Cos(num2) / 10f + new Vector3(0f, -0.5f - Mathf.Sin(num2) / 7f, 0f);
			}
		}

		// Token: 0x060001A2 RID: 418 RVA: 0x00019B64 File Offset: 0x00017D64
		public static void BatTraces()
		{
			GameObject gameObject = GameObject.Find("Cave Bat Holdable");
			GameObject gameObject2 = GameObject.CreatePrimitive(2);
			Object.Destroy(gameObject2.GetComponent<BoxCollider>());
			Object.Destroy(gameObject2.GetComponent<Rigidbody>());
			Object.Destroy(gameObject2.GetComponent<Collider>());
			Object.Destroy(gameObject2.GetComponent<MeshCollider>());
			gameObject2.transform.rotation = Quaternion.identity;
			gameObject2.transform.localScale = new Vector3(0.02f, 0.02f, 0.02f);
			gameObject2.transform.position = gameObject.transform.position;
			Mods.UpdateScaleForBeacons(GorillaTagger.Instance.rightHandTransform.gameObject, gameObject.gameObject, gameObject2);
			Renderer component = gameObject2.GetComponent<Renderer>();
			component.material.color = Color.Lerp(new Color(0f, 1f, 0f, 0.5f), new Color(0f, 1f, 1f, 0.5f), Mathf.PingPong(Time.time, 1f));
			Object.Destroy(gameObject2, Time.deltaTime);
		}

		// Token: 0x060001A3 RID: 419 RVA: 0x00019C80 File Offset: 0x00017E80
		public static void BatSizeChangerByVortex()
		{
			bool rightControllerPrimaryButton = ControllerInputPoller.instance.rightControllerPrimaryButton;
			bool flag = rightControllerPrimaryButton;
			if (flag)
			{
				GameObject.Find("Cave Bat Holdable").transform.localScale += new Vector3(0.1f, 0.1f, 0.1f);
			}
			bool rightGrab = ControllerInputPoller.instance.rightGrab;
			if (rightGrab)
			{
				GameObject.Find("Cave Bat Holdable").transform.localScale += new Vector3(0.1f, 0.1f, 0.1f);
			}
			bool leftGrab = ControllerInputPoller.instance.leftGrab;
			if (leftGrab)
			{
				GameObject.Find("Cave Bat Holdable").transform.localScale -= new Vector3(0.1f, 0.1f, 0.1f);
			}
		}

		// Token: 0x060001A4 RID: 420 RVA: 0x00019D64 File Offset: 0x00017F64
		public static void MonstersTraces()
		{
			GameObject gameObject = GameObject.Find("Monkeye_Prefab_1");
			GameObject gameObject2 = GameObject.CreatePrimitive(2);
			Object.Destroy(gameObject2.GetComponent<BoxCollider>());
			Object.Destroy(gameObject2.GetComponent<Rigidbody>());
			Object.Destroy(gameObject2.GetComponent<Collider>());
			Object.Destroy(gameObject2.GetComponent<MeshCollider>());
			gameObject2.transform.rotation = Quaternion.identity;
			gameObject2.transform.localScale = new Vector3(0.02f, 0.02f, 0.02f);
			gameObject2.transform.position = gameObject.transform.position;
			Mods.UpdateScaleForBeacons(GorillaTagger.Instance.rightHandTransform.gameObject, gameObject.gameObject, gameObject2);
			Renderer component = gameObject2.GetComponent<Renderer>();
			component.material.color = Color.Lerp(new Color(0f, 1f, 0f, 0.5f), new Color(0f, 1f, 1f, 0.5f), Mathf.PingPong(Time.time, 1f));
			Object.Destroy(gameObject2, Time.deltaTime);
		}

		// Token: 0x060001A5 RID: 421 RVA: 0x00019E80 File Offset: 0x00018080
		public static void MonstersSizeChangerByVortex()
		{
			bool rightControllerPrimaryButton = ControllerInputPoller.instance.rightControllerPrimaryButton;
			bool flag = rightControllerPrimaryButton;
			if (flag)
			{
				GameObject.Find("Monkeye_Prefab_1").transform.localScale += new Vector3(0.1f, 0.1f, 0.1f);
				GameObject.Find("Monkeye_Prefab_2").transform.localScale += new Vector3(0.1f, 0.1f, 0.1f);
			}
			bool rightGrab = ControllerInputPoller.instance.rightGrab;
			if (rightGrab)
			{
				GameObject.Find("Monkeye_Prefab_1").transform.localScale += new Vector3(0.1f, 0.1f, 0.1f);
				GameObject.Find("Monkeye_Prefab_2").transform.localScale += new Vector3(0.1f, 0.1f, 0.1f);
			}
			bool leftGrab = ControllerInputPoller.instance.leftGrab;
			if (leftGrab)
			{
				GameObject.Find("Monkeye_Prefab_1").transform.localScale -= new Vector3(0.1f, 0.1f, 0.1f);
				GameObject.Find("Monkeye_Prefab_2").transform.localScale -= new Vector3(0.1f, 0.1f, 0.1f);
			}
		}

		// Token: 0x060001A6 RID: 422 RVA: 0x0001A000 File Offset: 0x00018200
		public static void TriggerToTogglePlats()
		{
			bool flag = ControllerInputPoller.instance.rightControllerIndexFloat == 1f && ControllerInputPoller.instance.leftControllerIndexFloat == 1f;
			if (flag)
			{
				Mods.Platforms();
			}
		}

		// Token: 0x060001A7 RID: 423 RVA: 0x0001A044 File Offset: 0x00018244
		public static void ProcessPlatformPlankMonke()
		{
			float rightControllerGripFloat = ControllerInputPoller.instance.rightControllerGripFloat;
			float leftControllerGripFloat = ControllerInputPoller.instance.leftControllerGripFloat;
			bool flag = rightControllerGripFloat == 1f && Mods.RightToggle;
			if (flag)
			{
				Mods.rPlat = GameObject.CreatePrimitive(3);
				Mods.PlatColor.color = Color.black;
				Mods.rPlat.GetComponent<Renderer>().material = Mods.PlatColor;
				Mods.rPlat.transform.localScale = new Vector3(0.0125f, 0.28f, 0.7f);
				Mods.rPlat.transform.position = new Vector3(0f, -0.0075f, 0f) + Player.Instance.rightControllerTransform.position;
				Mods.rPlat.transform.rotation = Player.Instance.rightControllerTransform.rotation;
				Mods.RightToggle = false;
			}
			bool flag2 = rightControllerGripFloat != 1f;
			if (flag2)
			{
				Object.Destroy(Mods.rPlat);
				Mods.RightToggle = true;
			}
			bool flag3 = leftControllerGripFloat == 1f && Mods.LeftToggle;
			if (flag3)
			{
				Mods.lPlat = GameObject.CreatePrimitive(3);
				Mods.PlatColor.color = Color.black;
				Mods.lPlat.GetComponent<Renderer>().material = Mods.PlatColor;
				Mods.lPlat.transform.localScale = new Vector3(0.0125f, 0.28f, 0.7f);
				Mods.lPlat.transform.position = new Vector3(0f, -0.0075f, 0f) + Player.Instance.leftControllerTransform.position;
				Mods.lPlat.transform.rotation = Player.Instance.leftControllerTransform.rotation;
				Mods.LeftToggle = false;
			}
			bool flag4 = leftControllerGripFloat != 1f;
			if (flag4)
			{
				Object.Destroy(Mods.lPlat);
				Mods.LeftToggle = true;
			}
		}

		// Token: 0x060001A8 RID: 424 RVA: 0x0001A248 File Offset: 0x00018448
		public static void AntiReportDisconnectForest()
		{
			try
			{
				GameObject gameObject = GameObject.Find("Environment Objects/PersistentObjects_Prefab/GorillaUI");
				Transform transform = gameObject.transform;
				for (int i = 0; i < transform.childCount; i++)
				{
					Transform transform2 = transform.GetChild(i);
					bool flag = transform2.gameObject.name.Contains("Anchor") && transform2.gameObject.activeSelf;
					bool flag2 = flag;
					if (flag2)
					{
						string name = transform2.gameObject.name;
						transform2 = transform2.Find("GorillaScoreBoard/LineParent");
						for (int j = 0; j < transform2.childCount; j++)
						{
							Transform child = transform2.GetChild(j);
							bool flag3 = child.name.Contains("GorillaPlayerScoreboardLine");
							bool flag4 = flag3;
							if (flag4)
							{
								Text component = child.Find("Player Name").GetComponent<Text>();
								Transform transform3 = child.Find("ReportButton");
								bool flag5 = component != null;
								bool flag6 = flag5;
								if (flag6)
								{
									bool flag7 = component.text == PhotonNetwork.LocalPlayer.NickName.ToUpper();
									bool flag8 = flag7;
									if (flag8)
									{
										foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
										{
											bool flag9 = vrrig != GorillaTagger.Instance.offlineVRRig;
											bool flag10 = flag9;
											if (flag10)
											{
												float num = Vector3.Distance(vrrig.rightHandTransform.position, transform3.position);
												float num2 = Vector3.Distance(vrrig.leftHandTransform.position, transform3.position);
												float num3 = 0.35f;
												bool flag11 = !name.Contains("Forest");
												bool flag12 = flag11;
												if (flag12)
												{
													num3 = 0.3f;
												}
												bool flag13 = num < num3 || num2 < num3;
												bool flag14 = flag13;
												if (flag14)
												{
													PhotonNetwork.Disconnect();
													Mods.flushmanually();
													NotifiLib.SendNotification("<color=grey>[</color><color=purple>ANTI-REPORT</color><color=grey>]</color> <color=white>Someone attempted to report you, you have been disconnected.</color>");
												}
											}
										}
									}
								}
								else
								{
									Debug.LogError("Odd error, no name");
								}
							}
						}
					}
				}
			}
			catch
			{
			}
		}

		// Token: 0x060001A9 RID: 425 RVA: 0x0001A4C8 File Offset: 0x000186C8
		public static void Disguise()
		{
			Color color = Random.ColorHSV();
			Mods.namelist.Add("MONKEYMAN");
			Mods.namelist.Add("GOOBER");
			Mods.namelist.Add("REALONE");
			Mods.namelist.Add("LAMPGT");
			Mods.namelist.Add("DISGUISEDMAN");
			Mods.namelist.Add("GOOFYGOOBER");
			Mods.namelist.Add("JIKOMAN");
			Mods.namelist.Add("BAGUETTE");
			Mods.namelist.Add("POOKIE");
			Mods.namelist.Add("HMMM");
			Mods.namelist.Add("WHATIS");
			Mods.namelist.Add("FORTNITE");
			Mods.namelist.Add("MOUSE");
			Mods.namelist.Add("SPESZ");
			GorillaTagger.Instance.offlineVRRig.enabled = false;
			GorillaTagger.Instance.offlineVRRig.transform.position = new Vector3(-66.7989f, 12.5422f, -82.6815f);
			bool flag = GorillaComputer.instance.friendJoinCollider.playerIDsCurrentlyTouching.Contains(PhotonNetwork.LocalPlayer.UserId);
			if (flag)
			{
				string text = Mods.namelist[Random.Range(0, Mods.namelist.ToArray().Length)];
				GorillaComputer.instance.offlineVRRigNametagText.text = text;
				PhotonNetwork.NickName = text;
				GorillaComputer.instance.savedName = text;
				PlayerPrefs.SetString("playerName", text);
				PlayerPrefs.Save();
				GorillaTagger.Instance.UpdateColor(color.r, color.g, color.b);
				GorillaTagger.Instance.myVRRig.RPC("InitializeNoobMaterial", 0, new object[]
				{
					color.r,
					color.g,
					color.b,
					false
				});
				GorillaTagger.Instance.offlineVRRig.enabled = true;
				foreach (ButtonInfo buttonInfo in WristMenu.buttons)
				{
					bool flag2 = buttonInfo.buttonText.Contains("Disguise");
					if (flag2)
					{
						buttonInfo.enabled = new bool?(false);
					}
				}
				Mods.namelist.Clear();
				WristMenu.DestroyMenu();
				WristMenu.instance.Draw();
			}
		}

		// Token: 0x060001AA RID: 426 RVA: 0x0001A778 File Offset: 0x00018978
		public static void flipmenu()
		{
			Mods.menu.transform.RotateAround(Mods.menu.transform.position, Mods.menu.transform.forward, 150f);
		}

		// Token: 0x060001AB RID: 427 RVA: 0x0001A7B0 File Offset: 0x000189B0
		public static void CircleMonkeys()
		{
			bool flag = PhotonNetwork.CurrentRoom != null;
			bool flag2 = flag;
			if (flag2)
			{
				foreach (Player player in PhotonNetwork.PlayerListOthers)
				{
					PhotonView photonView = GorillaGameManager.instance.FindVRRigForPlayer(player);
					VRRig vrrig = GorillaGameManager.instance.FindPlayerVRRig(player);
					bool flag3 = !vrrig.isOfflineVRRig && !vrrig.isMyPlayer && !photonView.IsMine;
					bool flag4 = flag3;
					if (flag4)
					{
						GameObject gameObject = GameObject.CreatePrimitive(0);
						Object.Destroy(gameObject.GetComponent<BoxCollider>());
						Object.Destroy(gameObject.GetComponent<Rigidbody>());
						Object.Destroy(gameObject.GetComponent<Collider>());
						gameObject.GetComponent<MeshRenderer>().material.SetColor("_Color", Color.magenta);
						gameObject.transform.rotation = Quaternion.identity;
						gameObject.transform.localScale = new Vector3(2f, 2f, 2f);
						gameObject.transform.position = vrrig.transform.position;
						gameObject.GetComponent<MeshRenderer>().material = vrrig.mainSkin.material;
						Object.Destroy(gameObject, Time.deltaTime);
					}
				}
			}
		}

		// Token: 0x060001AC RID: 428 RVA: 0x0001A8FC File Offset: 0x00018AFC
		public static void freezetrainoff()
		{
			bool flag = Mods.freezetrainbool;
			if (flag)
			{
				Mods.freezetrainbool = false;
				GameObject gameObject = GameObject.Find("Environment Objects/LocalObjects_Prefab/Forest/Holiday2023Forest/Holiday2023Forest_Gameplay/NCTrain_Kit_Prefab/NCTrainEngine_Prefab");
				PhotonView component = gameObject.GetComponent<PhotonView>();
				TraverseSpline component2 = gameObject.GetComponent<TraverseSpline>();
				component.ControllerActorNr = PhotonNetwork.LocalPlayer.ActorNumber;
				component.OwnerActorNr = PhotonNetwork.LocalPlayer.ActorNumber;
				component2.duration = 30f;
			}
		}

		// Token: 0x060001AD RID: 429 RVA: 0x0001A964 File Offset: 0x00018B64
		public static void freezetrain()
		{
			Mods.freezetrainbool = true;
			GameObject gameObject = GameObject.Find("Environment Objects/LocalObjects_Prefab/Forest/Holiday2023Forest/Holiday2023Forest_Gameplay/NCTrain_Kit_Prefab/NCTrainEngine_Prefab");
			PhotonView component = gameObject.GetComponent<PhotonView>();
			TraverseSpline component2 = gameObject.GetComponent<TraverseSpline>();
			component.ControllerActorNr = PhotonNetwork.LocalPlayer.ActorNumber;
			component.OwnerActorNr = PhotonNetwork.LocalPlayer.ActorNumber;
			component2.duration = float.MaxValue;
		}

		// Token: 0x060001AE RID: 430 RVA: 0x0001A9BE File Offset: 0x00018BBE
		public static void aaaaaA()
		{
			PhotonNetwork.CurrentRoom.IsOpen = true;
		}

		// Token: 0x060001AF RID: 431 RVA: 0x0001A9CD File Offset: 0x00018BCD
		public static void aaaaaA2()
		{
			PhotonNetwork.CurrentRoom.IsOpen = false;
		}

		// Token: 0x060001B0 RID: 432 RVA: 0x0001A9DC File Offset: 0x00018BDC
		public static void refectionTEST()
		{
			foreach (Player player in PhotonNetwork.PlayerListOthers)
			{
				MethodInfo method = typeof(PhotonNetwork).GetMethod("OpRemoveFromServerInstantiationsOfPlayer", BindingFlags.Instance | BindingFlags.NonPublic);
				bool flag = method != null;
				if (flag)
				{
					object[] parameters = new object[]
					{
						player.ActorNumber
					};
					method.Invoke(null, parameters);
				}
			}
		}

		// Token: 0x060001B1 RID: 433 RVA: 0x0001AA4C File Offset: 0x00018C4C
		public static void AntiReportDisconnectCity()
		{
			try
			{
				GameObject gameObject = GameObject.Find("Environment Objects/PersistentObjects_Prefab/GorillaUI");
				Transform transform = gameObject.transform;
				for (int i = 0; i < transform.childCount; i++)
				{
					Transform transform2 = transform.GetChild(i);
					bool flag = transform2.gameObject.name.Contains("Anchor") && transform2.gameObject.activeSelf;
					bool flag2 = flag;
					if (flag2)
					{
						string name = transform2.gameObject.name;
						transform2 = transform2.Find("GorillaScoreBoard/LineParent");
						for (int j = 0; j < transform2.childCount; j++)
						{
							Transform child = transform2.GetChild(j);
							bool flag3 = child.name.Contains("GorillaPlayerScoreboardLine");
							bool flag4 = flag3;
							if (flag4)
							{
								Text component = child.Find("Player Name").GetComponent<Text>();
								Transform transform3 = child.Find("ReportButton");
								bool flag5 = component != null;
								bool flag6 = flag5;
								if (flag6)
								{
									bool flag7 = component.text == PhotonNetwork.LocalPlayer.NickName.ToUpper();
									bool flag8 = flag7;
									if (flag8)
									{
										foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
										{
											bool flag9 = vrrig != GorillaTagger.Instance.offlineVRRig;
											bool flag10 = flag9;
											if (flag10)
											{
												float num = Vector3.Distance(vrrig.rightHandTransform.position, transform3.position);
												float num2 = Vector3.Distance(vrrig.leftHandTransform.position, transform3.position);
												float num3 = 0.45f;
												bool flag11 = !name.Contains("City");
												bool flag12 = flag11;
												if (flag12)
												{
													num3 = 0.2f;
												}
												bool flag13 = num < num3 || num2 < num3;
												bool flag14 = flag13;
												if (flag14)
												{
													PhotonNetwork.Disconnect();
													Mods.flushmanually();
													NotifiLib.SendNotification("<color=grey>[</color><color=purple>ANTI-REPORT</color><color=grey>]</color> <color=white>Someone attempted to report you, you have been disconnected.</color>");
												}
											}
										}
									}
								}
								else
								{
									Debug.LogError("Odd error, no name");
								}
							}
						}
					}
				}
			}
			catch
			{
			}
		}

		// Token: 0x060001B2 RID: 434 RVA: 0x0001ACCC File Offset: 0x00018ECC
		public static void AntiReportDisconnectCanyons()
		{
			try
			{
				GameObject gameObject = GameObject.Find("Environment Objects/PersistentObjects_Prefab/GorillaUI");
				Transform transform = gameObject.transform;
				for (int i = 0; i < transform.childCount; i++)
				{
					Transform transform2 = transform.GetChild(i);
					bool flag = transform2.gameObject.name.Contains("CanyonScoreboardAnchor") && transform2.gameObject.activeSelf;
					bool flag2 = flag;
					if (flag2)
					{
						string name = transform2.gameObject.name;
						transform2 = transform2.Find("GorillaScoreBoard/LineParent");
						for (int j = 0; j < transform2.childCount; j++)
						{
							Transform child = transform2.GetChild(j);
							bool flag3 = child.name.Contains("GorillaPlayerScoreboardLine");
							bool flag4 = flag3;
							if (flag4)
							{
								Text component = child.Find("Player Name").GetComponent<Text>();
								Transform transform3 = child.Find("ReportButton");
								bool flag5 = component != null;
								bool flag6 = flag5;
								if (flag6)
								{
									bool flag7 = component.text == PhotonNetwork.LocalPlayer.NickName.ToUpper();
									bool flag8 = flag7;
									if (flag8)
									{
										foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
										{
											bool flag9 = vrrig != GorillaTagger.Instance.offlineVRRig;
											bool flag10 = flag9;
											if (flag10)
											{
												float num = Vector3.Distance(vrrig.rightHandTransform.position, transform3.position);
												float num2 = Vector3.Distance(vrrig.leftHandTransform.position, transform3.position);
												float num3 = 0.45f;
												bool flag11 = !name.Contains("Canyons");
												bool flag12 = flag11;
												if (flag12)
												{
													num3 = 0.2f;
												}
												bool flag13 = num < num3 || num2 < num3;
												bool flag14 = flag13;
												if (flag14)
												{
													PhotonNetwork.Disconnect();
													Mods.flushmanually();
													NotifiLib.SendNotification("<color=grey>[</color><color=purple>ANTI-REPORT</color><color=grey>]</color> <color=white>Someone attempted to report you, you have been disconnected.</color>");
												}
											}
										}
									}
								}
								else
								{
									Debug.LogError("Odd error, no name");
								}
							}
						}
					}
				}
			}
			catch
			{
			}
		}

		// Token: 0x060001B3 RID: 435 RVA: 0x0001AF4C File Offset: 0x0001914C
		public static void AntiReportDisconnectBeach()
		{
			try
			{
				GameObject gameObject = GameObject.Find("Environment Objects/PersistentObjects_Prefab/GorillaUI");
				Transform transform = gameObject.transform;
				for (int i = 0; i < transform.childCount; i++)
				{
					Transform transform2 = transform.GetChild(i);
					bool flag = transform2.gameObject.name.Contains("Anchor") && transform2.gameObject.activeSelf;
					bool flag2 = flag;
					if (flag2)
					{
						string name = transform2.gameObject.name;
						transform2 = transform2.Find("GorillaScoreBoard/LineParent");
						for (int j = 0; j < transform2.childCount; j++)
						{
							Transform child = transform2.GetChild(j);
							bool flag3 = child.name.Contains("GorillaPlayerScoreboardLine");
							bool flag4 = flag3;
							if (flag4)
							{
								Text component = child.Find("Player Name").GetComponent<Text>();
								Transform transform3 = child.Find("ReportButton");
								bool flag5 = component != null;
								bool flag6 = flag5;
								if (flag6)
								{
									bool flag7 = component.text == PhotonNetwork.LocalPlayer.NickName.ToUpper();
									bool flag8 = flag7;
									if (flag8)
									{
										foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
										{
											bool flag9 = vrrig != GorillaTagger.Instance.offlineVRRig;
											bool flag10 = flag9;
											if (flag10)
											{
												float num = Vector3.Distance(vrrig.rightHandTransform.position, transform3.position);
												float num2 = Vector3.Distance(vrrig.leftHandTransform.position, transform3.position);
												float num3 = 0.45f;
												bool flag11 = !name.Contains("Beach");
												bool flag12 = flag11;
												if (flag12)
												{
													num3 = 0.2f;
												}
												bool flag13 = num < num3 || num2 < num3;
												bool flag14 = flag13;
												if (flag14)
												{
													PhotonNetwork.Disconnect();
													Mods.flushmanually();
													NotifiLib.SendNotification("<color=grey>[</color><color=purple>ANTI-REPORT</color><color=grey>]</color> <color=white>Someone attempted to report you, you have been disconnected.</color>");
												}
											}
										}
									}
								}
								else
								{
									Debug.LogError("Odd error, no name");
								}
							}
						}
					}
				}
			}
			catch
			{
			}
		}

		// Token: 0x060001B4 RID: 436 RVA: 0x0001B1CC File Offset: 0x000193CC
		public static void AntiReportDisconnectMountions()
		{
			try
			{
				GameObject gameObject = GameObject.Find("Environment Objects/PersistentObjects_Prefab/GorillaUI");
				Transform transform = gameObject.transform;
				for (int i = 0; i < transform.childCount; i++)
				{
					Transform transform2 = transform.GetChild(i);
					bool flag = transform2.gameObject.name.Contains("Anchor") && transform2.gameObject.activeSelf;
					bool flag2 = flag;
					if (flag2)
					{
						string name = transform2.gameObject.name;
						transform2 = transform2.Find("GorillaScoreBoard/LineParent");
						for (int j = 0; j < transform2.childCount; j++)
						{
							Transform child = transform2.GetChild(j);
							bool flag3 = child.name.Contains("GorillaPlayerScoreboardLine");
							bool flag4 = flag3;
							if (flag4)
							{
								Text component = child.Find("Player Name").GetComponent<Text>();
								Transform transform3 = child.Find("ReportButton");
								bool flag5 = component != null;
								bool flag6 = flag5;
								if (flag6)
								{
									bool flag7 = component.text == PhotonNetwork.LocalPlayer.NickName.ToUpper();
									bool flag8 = flag7;
									if (flag8)
									{
										foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
										{
											bool flag9 = vrrig != GorillaTagger.Instance.offlineVRRig;
											bool flag10 = flag9;
											if (flag10)
											{
												float num = Vector3.Distance(vrrig.rightHandTransform.position, transform3.position);
												float num2 = Vector3.Distance(vrrig.leftHandTransform.position, transform3.position);
												float num3 = 0.45f;
												bool flag11 = !name.Contains("Mountains");
												bool flag12 = flag11;
												if (flag12)
												{
													num3 = 0.2f;
												}
												bool flag13 = num < num3 || num2 < num3;
												bool flag14 = flag13;
												if (flag14)
												{
													PhotonNetwork.Disconnect();
													Mods.flushmanually();
													NotifiLib.SendNotification("<color=grey>[</color><color=purple>ANTI-REPORT</color><color=grey>]</color> <color=white>Someone attempted to report you, you have been disconnected.</color>");
												}
											}
										}
									}
								}
								else
								{
									Debug.LogError("Odd error, no name");
								}
							}
						}
					}
				}
			}
			catch
			{
			}
		}

		// Token: 0x060001B5 RID: 437 RVA: 0x0001B44C File Offset: 0x0001964C
		public static void AntiReportDisconnectClouds()
		{
			try
			{
				GameObject gameObject = GameObject.Find("Environment Objects/PersistentObjects_Prefab/GorillaUI");
				Transform transform = gameObject.transform;
				for (int i = 0; i < transform.childCount; i++)
				{
					Transform transform2 = transform.GetChild(i);
					bool flag = transform2.gameObject.name.Contains("Anchor") && transform2.gameObject.activeSelf;
					bool flag2 = flag;
					if (flag2)
					{
						string name = transform2.gameObject.name;
						transform2 = transform2.Find("GorillaScoreBoard/LineParent");
						for (int j = 0; j < transform2.childCount; j++)
						{
							Transform child = transform2.GetChild(j);
							bool flag3 = child.name.Contains("GorillaPlayerScoreboardLine");
							bool flag4 = flag3;
							if (flag4)
							{
								Text component = child.Find("Player Name").GetComponent<Text>();
								Transform transform3 = child.Find("ReportButton");
								bool flag5 = component != null;
								bool flag6 = flag5;
								if (flag6)
								{
									bool flag7 = component.text == PhotonNetwork.LocalPlayer.NickName.ToUpper();
									bool flag8 = flag7;
									if (flag8)
									{
										foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
										{
											bool flag9 = vrrig != GorillaTagger.Instance.offlineVRRig;
											bool flag10 = flag9;
											if (flag10)
											{
												float num = Vector3.Distance(vrrig.rightHandTransform.position, transform3.position);
												float num2 = Vector3.Distance(vrrig.leftHandTransform.position, transform3.position);
												float num3 = 0.45f;
												bool flag11 = !name.Contains("skyjungle");
												bool flag12 = flag11;
												if (flag12)
												{
													num3 = 0.2f;
												}
												bool flag13 = num < num3 || num2 < num3;
												bool flag14 = flag13;
												if (flag14)
												{
													PhotonNetwork.Disconnect();
													Mods.flushmanually();
													NotifiLib.SendNotification("<color=grey>[</color><color=purple>ANTI-REPORT</color><color=grey>]</color> <color=white>Someone attempted to report you, you have been disconnected.</color>");
												}
											}
										}
									}
								}
								else
								{
									Debug.LogError("Odd error, no name");
								}
							}
						}
					}
				}
			}
			catch
			{
			}
		}

		// Token: 0x060001B6 RID: 438 RVA: 0x0001B6CC File Offset: 0x000198CC
		public static void UnlockCom1p()
		{
			int num = 1;
			PlayerPrefs.SetInt("allowedInCompetitive", num);
			PlayerPrefs.Save();
		}

		// Token: 0x060001B7 RID: 439 RVA: 0x0001B6F0 File Offset: 0x000198F0
		public static void lowhz()
		{
			GorillaZiplineSettings[] array = Object.FindObjectsOfType<GorillaZiplineSettings>();
			GorillaZipline[] array2 = Object.FindObjectsOfType<GorillaZipline>();
			foreach (GorillaZiplineSettings gorillaZiplineSettings in array)
			{
				gorillaZiplineSettings.minSlidePitch = 50f;
				gorillaZiplineSettings.maxSlidePitch = 50f;
				gorillaZiplineSettings.maxSlideVolume = 50f;
				gorillaZiplineSettings.maxSpeed = 50f;
				gorillaZiplineSettings.gravityMulti = 50f;
				gorillaZiplineSettings.friction = 50f;
				gorillaZiplineSettings.maxFriction = 50f;
				gorillaZiplineSettings.maxFrictionSpeed = 50f;
			}
		}

		// Token: 0x060001B8 RID: 440 RVA: 0x0001B784 File Offset: 0x00019984
		public static void fpc()
		{
			Mods.fpcc = true;
			bool flag = GameObject.Find("Third Person Camera") != null;
			if (flag)
			{
				Mods.funn = GameObject.Find("Third Person Camera");
				Mods.funn.SetActive(false);
			}
			bool flag2 = GameObject.Find("CameraTablet(Clone)") != null;
			if (flag2)
			{
				Mods.funn = GameObject.Find("CameraTablet(Clone)");
				Mods.funn.SetActive(false);
			}
		}

		// Token: 0x060001B9 RID: 441 RVA: 0x0001B7FC File Offset: 0x000199FC
		public static void fpcoff()
		{
			Mods.fpcc = false;
			bool flag = Mods.funn != null;
			if (flag)
			{
				Mods.funn.SetActive(true);
				Mods.funn = null;
			}
		}

		// Token: 0x060001BA RID: 442 RVA: 0x0001B834 File Offset: 0x00019A34
		public static void SaveMain()
		{
			WristMenu.buttons[1].enabled = new bool?(false);
			WristMenu.DestroyMenu();
			WristMenu.instance.Draw();
			List<string> list = new List<string>();
			foreach (ButtonInfo buttonInfo in WristMenu.buttons)
			{
				bool? enabled = buttonInfo.enabled;
				bool flag = true;
				bool flag2 = enabled.GetValueOrDefault() == flag & enabled != null;
				if (flag2)
				{
					list.Add(buttonInfo.buttonText);
				}
			}
			Directory.CreateDirectory("TemplatePrefs");
			File.WriteAllLines("TemplatePrefs\\templateSavedMainPrefs.txt", list);
		}

		// Token: 0x060001BB RID: 443 RVA: 0x0001B8FC File Offset: 0x00019AFC
		public static void SpazHands()
		{
			GorillaTagger.Instance.offlineVRRig.leftHand.rigTarget.eulerAngles = new Vector3((float)Random.Range(0, 360), (float)Random.Range(0, 360), (float)Random.Range(0, 360));
			GorillaTagger.Instance.offlineVRRig.rightHand.rigTarget.eulerAngles = new Vector3((float)Random.Range(0, 360), (float)Random.Range(0, 360), (float)Random.Range(0, 360));
			GorillaTagger.Instance.offlineVRRig.leftHand.rigTarget.eulerAngles = new Vector3((float)Random.Range(0, 360), (float)Random.Range(0, 180), (float)Random.Range(0, 180));
			GorillaTagger.Instance.offlineVRRig.rightHand.rigTarget.eulerAngles = new Vector3((float)Random.Range(0, 360), (float)Random.Range(0, 180), (float)Random.Range(0, 180));
		}

		// Token: 0x060001BC RID: 444 RVA: 0x0001BA18 File Offset: 0x00019C18
		public static void LoadMain()
		{
			WristMenu.buttons[2].enabled = new bool?(false);
			WristMenu.DestroyMenu();
			WristMenu.instance.Draw();
			string[] array = File.ReadAllLines("TemplatePrefs\\templateSavedMainPrefs.txt");
			foreach (string b in array)
			{
				foreach (ButtonInfo buttonInfo in WristMenu.buttons)
				{
					bool flag = buttonInfo.buttonText == b;
					if (flag)
					{
						buttonInfo.enabled = new bool?(true);
					}
				}
			}
		}

		// Token: 0x060001BD RID: 445 RVA: 0x0001BAD8 File Offset: 0x00019CD8
		public static void Save()
		{
			WristMenu.settingsbuttons[1].enabled = new bool?(false);
			WristMenu.DestroyMenu();
			WristMenu.instance.Draw();
			List<string> list = new List<string>();
			foreach (ButtonInfo buttonInfo in WristMenu.settingsbuttons)
			{
				bool? enabled = buttonInfo.enabled;
				bool flag = true;
				bool flag2 = enabled.GetValueOrDefault() == flag & enabled != null;
				if (flag2)
				{
					list.Add(buttonInfo.buttonText);
				}
			}
			Directory.CreateDirectory("TemplatePrefs");
			File.WriteAllLines("TemplatePrefs\\templateSavedPrefs.txt", list);
		}

		// Token: 0x060001BE RID: 446 RVA: 0x0001BBA0 File Offset: 0x00019DA0
		public static void Load()
		{
			string[] array = File.ReadAllLines("TemplatePrefs\\templateSavedPrefs.txt");
			foreach (string b in array)
			{
				foreach (ButtonInfo buttonInfo in WristMenu.settingsbuttons)
				{
					bool flag = buttonInfo.buttonText == b;
					if (flag)
					{
						buttonInfo.enabled = new bool?(true);
					}
				}
			}
		}

		// Token: 0x060001BF RID: 447 RVA: 0x0001BC38 File Offset: 0x00019E38
		public static void ZeroGravityForward()
		{
			Rigidbody attachedRigidbody = Player.Instance.bodyCollider.attachedRigidbody;
			Vector3 forward = Player.Instance.bodyCollider.transform.forward;
			forward.y = 0f;
			forward.Normalize();
			float num = 0.1f;
			attachedRigidbody.AddForce(forward * (num / Time.deltaTime), 5);
		}

		// Token: 0x060001C0 RID: 448 RVA: 0x0001BC9C File Offset: 0x00019E9C
		public static void HitTargetGunfix()
		{
			bool rightGrab = ControllerInputPoller.instance.rightGrab;
			if (rightGrab)
			{
			}
			RaycastHit raycastHit;
			Physics.Raycast(Player.Instance.rightControllerTransform.position, -Player.Instance.rightControllerTransform.up, ref raycastHit);
			Mods.pointer = GameObject.CreatePrimitive(0);
			Mods.pointer.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
			Mods.pointer.GetComponent<Renderer>().material.shader = Shader.Find("GorillaTag/UberShader");
			Mods.pointer.GetComponent<Renderer>().material.color = Color.red;
			Mods.pointer.transform.position = raycastHit.point;
			Object.Destroy(Mods.pointer.GetComponent<BoxCollider>());
			Object.Destroy(Mods.pointer.GetComponent<Rigidbody>());
			Object.Destroy(Mods.pointer.GetComponent<Collider>());
			bool flag = Mods.pointer.transform.position == Object.FindObjectOfType<HitTargetWithScoreCounter>().transform.position;
			if (flag)
			{
				bool flag2 = ControllerInputPoller.instance.rightControllerIndexFloat > 1f;
				if (flag2)
				{
				}
				RigShit.GetOwnVRRig().enabled = false;
				RigShit.GetOwnVRRig().transform.position = raycastHit.point;
				Mods.BetaFireProjectile("SnowBall_Projectile", GorillaTagger.Instance.offlineVRRig.transform.position, Player.Instance.currentVelocity, Mods.ProjColor, false);
			}
			bool flag3 = Mods.pointer != null;
			if (flag3)
			{
			}
			Object.Destroy(Mods.pointer, Time.deltaTime);
			RigShit.GetOwnVRRig().enabled = true;
		}

		// Token: 0x060001C1 RID: 449 RVA: 0x0001BE5C File Offset: 0x0001A05C
		public static void changecolorboard()
		{
			GameObject.Find("CodeOfConduct").GetComponent<Renderer>().material.color = Color.blue;
			GameObject.Find("motd").GetComponent<Renderer>().material.color = Color.blue;
		}

		// Token: 0x060001C2 RID: 450 RVA: 0x0001BEA8 File Offset: 0x0001A0A8
		public static void Fixchangecolorboard()
		{
			GameObject.Find("CodeOfConduct").GetComponent<Renderer>().material.color = Color.green;
			GameObject.Find("motd").GetComponent<Renderer>().material.color = Color.green;
		}

		// Token: 0x060001C3 RID: 451 RVA: 0x0001BEF4 File Offset: 0x0001A0F4
		public static void CasualBoxESP()
		{
			foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
			{
				bool flag = vrrig != GorillaTagger.Instance.offlineVRRig;
				if (flag)
				{
					Color playerColor = vrrig.playerColor;
					GameObject gameObject = GameObject.CreatePrimitive(3);
					gameObject.transform.position = vrrig.transform.position;
					gameObject.transform.LookAt(GorillaTagger.Instance.headCollider.transform.position);
					gameObject.GetComponent<Renderer>().material.color = Color.Lerp(new Color(0f, 1f, 0f, 0.5f), new Color(0f, 1f, 1f, 0.5f), Mathf.PingPong(Time.time, 1f));
					Object.Destroy(gameObject, Time.deltaTime);
				}
			}
		}

		// Token: 0x060001C4 RID: 452 RVA: 0x0001C018 File Offset: 0x0001A218
		public static void FingerPainter()
		{
			GameObject.Find("Player Objects/Local VRRig/Local Gorilla Player/rig/body/2023_04DungeonV2 Body/LBADE.").SetActive(true);
		}

		// Token: 0x060001C5 RID: 453 RVA: 0x0001C02C File Offset: 0x0001A22C
		public static void OffFingerPainter()
		{
			GameObject.Find("Player Objects/Local VRRig/Local Gorilla Player/rig/body/2023_04DungeonV2 Body/LBADE.").SetActive(false);
		}

		// Token: 0x060001C6 RID: 454 RVA: 0x0001C040 File Offset: 0x0001A240
		public static void AdminBadge()
		{
			GameObject.Find("Player Objects/Local VRRig/Local Gorilla Player/rig/body/Old Cosmetics Body/ADMINISTRATOR BADGE").SetActive(true);
		}

		// Token: 0x060001C7 RID: 455 RVA: 0x0001C054 File Offset: 0x0001A254
		public static void OffAdminBadge()
		{
			GameObject.Find("Player Objects/Local VRRig/Local Gorilla Player/rig/body/Old Cosmetics Body/ADMINISTRATOR BADGE").SetActive(false);
		}

		// Token: 0x060001C8 RID: 456 RVA: 0x0001C068 File Offset: 0x0001A268
		public static void SodaSelf()
		{
			ScienceExperimentManager.instance.photonView.RPC("PlayerEnteredGameAreaRPC", 2, Array.Empty<object>());
			ScienceExperimentManager.instance.photonView.RPC("PlayerTouchedLavaRPC", 2, Array.Empty<object>());
			Mods.flushmanually();
		}

		// Token: 0x060001C9 RID: 457 RVA: 0x0001C0B8 File Offset: 0x0001A2B8
		public static void UnsodaSelf()
		{
			ScienceExperimentManager.instance.photonView.RPC("PlayerTouchedRefreshWaterRPC", 0, Array.Empty<object>());
			ScienceExperimentManager.instance.photonView.RPC("PlayerExitedGameAreaRPC", 0, Array.Empty<object>());
			Mods.flushmanually();
		}

		// Token: 0x060001CA RID: 458 RVA: 0x0001C108 File Offset: 0x0001A308
		public static void SeizureBug()
		{
			GameObject gameObject = GameObject.Find("Floating Bug Holdable");
			ThrowableBug component = GameObject.Find("Floating Bug Holdable").GetComponent<ThrowableBug>();
			bool flag = component.IsMyItem();
			bool flag2 = flag;
			if (flag2)
			{
				bool rightGrab = ControllerInputPoller.instance.rightGrab;
				if (rightGrab)
				{
					float num = 500f;
					gameObject.transform.Rotate(Vector3.up, num * Time.deltaTime);
					gameObject.transform.Rotate(Vector3.forward, num * Time.deltaTime);
					gameObject.transform.Rotate(Vector3.right, num * Time.deltaTime);
				}
			}
		}

		// Token: 0x060001CB RID: 459 RVA: 0x0001C1A8 File Offset: 0x0001A3A8
		public static void SeizureBall()
		{
			GameObject gameObject = GameObject.Find("Ball");
			ThrowableBug component = GameObject.Find("Ball").GetComponent<ThrowableBug>();
			bool flag = component.IsMyItem();
			bool flag2 = flag;
			if (flag2)
			{
				bool rightGrab = ControllerInputPoller.instance.rightGrab;
				if (rightGrab)
				{
					float num = 500f;
					gameObject.transform.Rotate(Vector3.up, num * Time.deltaTime);
					gameObject.transform.Rotate(Vector3.forward, num * Time.deltaTime);
					gameObject.transform.Rotate(Vector3.right, num * Time.deltaTime);
				}
			}
		}

		// Token: 0x060001CC RID: 460 RVA: 0x0001C248 File Offset: 0x0001A448
		public static void SeizureBat()
		{
			GameObject gameObject = GameObject.Find("Cave Bat Holdable");
			ThrowableBug component = GameObject.Find("Cave Bat Holdable").GetComponent<ThrowableBug>();
			bool flag = component.IsMyItem();
			bool flag2 = flag;
			if (flag2)
			{
				bool rightGrab = ControllerInputPoller.instance.rightGrab;
				if (rightGrab)
				{
					float num = 500f;
					gameObject.transform.Rotate(Vector3.up, num * Time.deltaTime);
					gameObject.transform.Rotate(Vector3.forward, num * Time.deltaTime);
					gameObject.transform.Rotate(Vector3.right, num * Time.deltaTime);
				}
			}
		}

		// Token: 0x060001CD RID: 461 RVA: 0x0001C2E8 File Offset: 0x0001A4E8
		public static void FreezeAll()
		{
			foreach (Player player in PhotonNetwork.PlayerListOthers)
			{
				PhotonNetwork.CurrentRoom.StorePlayer(player);
				PhotonNetwork.CurrentRoom.Players.Remove(player.ActorNumber);
				PhotonNetwork.OpRemoveCompleteCacheOfPlayer(player.ActorNumber);
			}
		}

		// Token: 0x060001CE RID: 462 RVA: 0x0001C340 File Offset: 0x0001A540
		public static void acid()
		{
			Traverse.Create(ScienceExperimentManager.instance).Field("inGamePlayerCount").SetValue(10);
			ScienceExperimentManager.PlayerGameState[] array = new ScienceExperimentManager.PlayerGameState[10];
			for (int i = 0; i < 10; i++)
			{
				array[i].touchedLiquid = true;
				array[i].playerId = ((PhotonNetwork.PlayerList[i] == null) ? 0 : PhotonNetwork.PlayerList[i].ActorNumber);
			}
			Traverse.Create(ScienceExperimentManager.instance).Field("inGamePlayerStates").SetValue(array);
		}

		// Token: 0x060001CF RID: 463 RVA: 0x0001C3DC File Offset: 0x0001A5DC
		public static void WheelMod()
		{
			bool rightGrab = ControllerInputPoller.instance.rightGrab;
			if (rightGrab)
			{
				GameObject gameObject = GameObject.CreatePrimitive(0);
				GameObject gameObject2 = GameObject.CreatePrimitive(0);
				GameObject gameObject3 = GameObject.CreatePrimitive(0);
				gameObject.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
				gameObject2.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
				gameObject3.transform.localScale = new Vector3(0.55f, 0.3f, 0.55f);
				gameObject.transform.rotation = Player.Instance.bodyCollider.transform.rotation;
				gameObject2.transform.rotation = Player.Instance.bodyCollider.transform.rotation;
				gameObject3.transform.rotation = Player.Instance.bodyCollider.transform.rotation;
				gameObject.transform.position = Player.Instance.bodyCollider.transform.position + new Vector3(0.25f, -0.15f, 0f);
				gameObject2.transform.position = Player.Instance.bodyCollider.transform.position + new Vector3(0f, -0.15f, 0.3f);
				gameObject3.transform.position = Player.Instance.bodyCollider.transform.position + new Vector3(0f, -0.15f, 0.25f);
				gameObject.GetComponent<Renderer>().material.color = new Color32(92, 52, 3, 1);
				gameObject2.GetComponent<Renderer>().material.color = new Color32(92, 52, 3, 1);
				gameObject3.GetComponent<Renderer>().material.color = new Color32(64, 37, 3, 1);
				Object.Destroy(gameObject.GetComponent<MeshCollider>());
				Object.Destroy(gameObject2.GetComponent<MeshCollider>());
				Object.Destroy(gameObject3.GetComponent<MeshCollider>());
				Object.Destroy(gameObject, Time.deltaTime);
				Object.Destroy(gameObject2, Time.deltaTime);
				Object.Destroy(gameObject3, Time.deltaTime);
			}
		}

		// Token: 0x060001D0 RID: 464 RVA: 0x0001C62C File Offset: 0x0001A82C
		public static void FlipHands()
		{
			Vector3 position = GorillaTagger.Instance.leftHandTransform.position;
			Vector3 position2 = GorillaTagger.Instance.rightHandTransform.position;
			Quaternion rotation = GorillaTagger.Instance.leftHandTransform.rotation;
			Quaternion rotation2 = GorillaTagger.Instance.rightHandTransform.rotation;
			Player.Instance.rightControllerTransform.transform.position = position;
			Player.Instance.leftControllerTransform.transform.position = position2;
			Player.Instance.rightControllerTransform.transform.rotation = rotation;
			Player.Instance.leftControllerTransform.transform.rotation = rotation2;
		}

		// Token: 0x060001D1 RID: 465 RVA: 0x0001C6D4 File Offset: 0x0001A8D4
		public static void crashallbyred()
		{
			foreach (CosmeticsController cosmeticsController in Resources.FindObjectsOfTypeAll<CosmeticsController>())
			{
				cosmeticsController.currentTime = new DateTime(99999999L);
				cosmeticsController.Awake();
			}
		}

		// Token: 0x060001D2 RID: 466 RVA: 0x0001C718 File Offset: 0x0001A918
		public static void MakeEveryoneRGB()
		{
			float time = Time.time;
			float num = Mathf.Sin(time * 2f) * 0.5f + 0.5f;
			float num2 = Mathf.Sin(time * 1.5f) * 0.5f + 0.5f;
			float num3 = Mathf.Sin(time * 2.5f) * 0.5f + 0.5f;
			foreach (VRRig vrrig in (VRRig[])Object.FindObjectsOfType(typeof(VRRig)))
			{
				vrrig.mainSkin.material.color = new Color(num, num2, num3);
			}
		}

		// Token: 0x060001D3 RID: 467 RVA: 0x0001C7C4 File Offset: 0x0001A9C4
		public static void Nowind()
		{
			bool flag = Player.Instance != null;
			if (flag)
			{
				bool flag2 = GorillaGameManager.instance != null;
				if (flag2)
				{
					GameObject.Find("Environment Objects/LocalObjects_Prefab/Forest/Environment/Forest_ForceVolumes").SetActive(false);
					GameObject.Find("Environment Objects/LocalObjects_Prefab/Basement/DungeonRoomAnchor/DungeonBasement/BasementMouseHoleWindPrefab").SetActive(false);
					GameObject.Find("Environment Objects/LocalObjects_Prefab/Basement/DungeonRoomAnchor/DungeonBasement/BasementMouseHoleWindPrefab (1)").SetActive(false);
					GameObject.Find("Environment Objects/LocalObjects_Prefab/Basement/DungeonRoomAnchor/DungeonBasement/BasementMouseHoleWindPrefab (2)").SetActive(false);
					GameObject.Find("Environment Objects/LocalObjects_Prefab/Canyon/Canyon/Canyon_ForceVolumes").SetActive(false);
					GameObject.Find("Environment Objects/LocalObjects_Prefab/Beach/ForceVolumesOcean_Combo_V2").SetActive(false);
					GameObject.Find("Environment Objects/LocalObjects_Prefab/skyjungle/Force Volumes").SetActive(false);
				}
			}
		}

		// Token: 0x060001D4 RID: 468 RVA: 0x0001C870 File Offset: 0x0001AA70
		public static void nosnitch()
		{
			Hashtable hashtable = new Hashtable();
			hashtable.Add("mods", null);
			PhotonNetwork.LocalPlayer.SetCustomProperties(hashtable, null, null);
		}

		// Token: 0x060001D5 RID: 469 RVA: 0x0001C89F File Offset: 0x0001AA9F
		public static void huntwatch()
		{
			PhotonNetwork.Instantiate("GorillaPrefabs/Gorilla Hunt Manager", GorillaTagger.Instance.myVRRig.transform.position, Quaternion.identity, 0, null);
		}

		// Token: 0x060001D6 RID: 470 RVA: 0x0001C8C8 File Offset: 0x0001AAC8
		public static void SetOwner()
		{
			GorillaTagger.Instance.myVRRig.RPC("RequestCurrentOwnerFromAuthorityRPC", 2, new object[]
			{
				PhotonNetwork.LocalPlayer
			});
		}

		// Token: 0x060001D7 RID: 471 RVA: 0x0001C8F0 File Offset: 0x0001AAF0
		public static void ChangeName(string PlayerName)
		{
			try
			{
				bool inRoom = PhotonNetwork.InRoom;
				if (inRoom)
				{
					bool flag = GorillaComputer.instance.friendJoinCollider.playerIDsCurrentlyTouching.Contains(PhotonNetwork.LocalPlayer.UserId);
					if (flag)
					{
						GorillaComputer.instance.currentName = PlayerName;
						PhotonNetwork.LocalPlayer.NickName = PlayerName;
						GorillaComputer.instance.offlineVRRigNametagText.text = PlayerName;
						GorillaComputer.instance.savedName = PlayerName;
						PlayerPrefs.SetString("playerName", PlayerName);
						PlayerPrefs.Save();
						Mods.ChangeColor(GorillaTagger.Instance.offlineVRRig.playerColor);
					}
					else
					{
						Mods.isUpdatingValues = true;
						Mods.valueChangeDelay = Time.time + 0.5f;
						Mods.changingName = true;
						Mods.nameChange = PlayerName;
					}
				}
				else
				{
					GorillaComputer.instance.currentName = PlayerName;
					PhotonNetwork.LocalPlayer.NickName = PlayerName;
					GorillaComputer.instance.offlineVRRigNametagText.text = PlayerName;
					GorillaComputer.instance.savedName = PlayerName;
					PlayerPrefs.SetString("playerName", PlayerName);
					PlayerPrefs.Save();
					Mods.ChangeColor(GorillaTagger.Instance.offlineVRRig.playerColor);
				}
			}
			catch (Exception ex)
			{
				Debug.LogError(string.Format("iiMenu <b>NAME ERROR</b> {1} - {0}", ex.Message, ex.StackTrace));
			}
		}

		// Token: 0x060001D8 RID: 472 RVA: 0x0001CA60 File Offset: 0x0001AC60
		public static void BetaSetStatus(int state, RaiseEventOptions balls)
		{
			object[] array = new object[]
			{
				state
			};
			PhotonNetwork.RaiseEvent(3, new object[]
			{
				PhotonNetwork.ServerTimestamp,
				2,
				array
			}, balls, SendOptions.SendUnreliable);
		}

		// Token: 0x060001D9 RID: 473 RVA: 0x0001CAB0 File Offset: 0x0001ACB0
		public static void SlowGun()
		{
			bool rightGrab = ControllerInputPoller.instance.rightGrab;
			if (rightGrab)
			{
				RaycastHit raycastHit;
				Physics.Raycast(GorillaTagger.Instance.rightHandTransform.position, GorillaTagger.Instance.rightHandTransform.forward, ref raycastHit);
				bool flag = Mods.shouldBePC;
				if (flag)
				{
					Ray ray = Mods.TPC.ScreenPointToRay(Mouse.current.position.ReadValue());
					Physics.Raycast(ray, ref raycastHit, 100f);
				}
				GameObject gameObject = GameObject.CreatePrimitive(0);
				gameObject.GetComponent<Renderer>().material.color = Mods.bgColorA;
				gameObject.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
				gameObject.transform.position = raycastHit.point;
				Object.Destroy(gameObject.GetComponent<BoxCollider>());
				Object.Destroy(gameObject.GetComponent<Rigidbody>());
				Object.Destroy(gameObject.GetComponent<Collider>());
				Object.Destroy(gameObject, Time.deltaTime);
				bool flag2 = ControllerInputPoller.instance.rightControllerIndexFloat > 1f && Time.time > Mods.kgDebounce;
				if (flag2)
				{
					VRRig componentInParent = raycastHit.collider.GetComponentInParent<VRRig>();
					bool flag3 = componentInParent && componentInParent != GorillaTagger.Instance.offlineVRRig;
					if (flag3)
					{
						Player playerFromRig = RigShit.GetPlayerFromRig(componentInParent);
						Mods.BetaSetStatus(0, new RaiseEventOptions
						{
							TargetActors = new int[]
							{
								playerFromRig.ActorNumber
							}
						});
						Mods.flushmanually();
						Mods.kgDebounce = Time.time + 0.2f;
					}
				}
			}
		}

		// Token: 0x060001DA RID: 474 RVA: 0x0001CC56 File Offset: 0x0001AE56
		internal static void NW()
		{
			throw new NotImplementedException();
		}

		// Token: 0x0400005A RID: 90
		public static bool oiwefkwenfjk;

		// Token: 0x0400005B RID: 91
		private static GameObject balls;

		// Token: 0x0400005C RID: 92
		public static float c1;

		// Token: 0x0400005D RID: 93
		public static bool inSettings = false;

		// Token: 0x0400005E RID: 94
		public static bool inProjectile = false;

		// Token: 0x0400005F RID: 95
		public static bool invisplat = false;

		// Token: 0x04000060 RID: 96
		public static bool stickyplatforms = false;

		// Token: 0x04000061 RID: 97
		public static GameObject funn;

		// Token: 0x04000062 RID: 98
		public static bool fpcc;

		// Token: 0x04000063 RID: 99
		public static float ba = 0f;

		// Token: 0x04000064 RID: 100
		public static float ba2 = 0f;

		// Token: 0x04000065 RID: 101
		public static float ba3 = 0f;

		// Token: 0x04000066 RID: 102
		private static ControllerInputPoller input;

		// Token: 0x04000067 RID: 103
		private static bool widhcnkesdj = false;

		// Token: 0x04000068 RID: 104
		private static bool widhcnkesdj9 = false;

		// Token: 0x04000069 RID: 105
		private static bool widhcnkesdj1 = false;

		// Token: 0x0400006A RID: 106
		private static int espcolor;

		// Token: 0x0400006B RID: 107
		public static Vector3 walkPos;

		// Token: 0x0400006C RID: 108
		public static Vector3 walkNormal;

		// Token: 0x0400006D RID: 109
		public static bool walkonwater = false;

		// Token: 0x0400006E RID: 110
		public static bool swimeverywhere = false;

		// Token: 0x0400006F RID: 111
		public static bool disablewater = false;

		// Token: 0x04000070 RID: 112
		public static bool fixwater = false;

		// Token: 0x04000071 RID: 113
		public static GameObject drawcube = null;

		// Token: 0x04000072 RID: 114
		public static float drawsize = 0.2f;

		// Token: 0x04000073 RID: 115
		public static bool stuiejrf3 = true;

		// Token: 0x04000074 RID: 116
		public static bool weufe123wfjdfjn = false;

		// Token: 0x04000075 RID: 117
		public static bool weufewfjdfjn = false;

		// Token: 0x04000076 RID: 118
		public static bool antiRepeat = false;

		// Token: 0x04000077 RID: 119
		private static bool teleportGunAntiRepeat = false;

		// Token: 0x04000078 RID: 120
		public static float smth46 = 0f;

		// Token: 0x04000079 RID: 121
		public static Vector3[] lastLeft = new Vector3[]
		{
			Vector3.zero,
			Vector3.zero,
			Vector3.zero,
			Vector3.zero,
			Vector3.zero,
			Vector3.zero,
			Vector3.zero,
			Vector3.zero,
			Vector3.zero,
			Vector3.zero
		};

		// Token: 0x0400007A RID: 122
		public static Vector3[] lastRight = new Vector3[]
		{
			Vector3.zero,
			Vector3.zero,
			Vector3.zero,
			Vector3.zero,
			Vector3.zero,
			Vector3.zero,
			Vector3.zero,
			Vector3.zero,
			Vector3.zero,
			Vector3.zero
		};

		// Token: 0x0400007B RID: 123
		private static GameObject menu = null;

		// Token: 0x0400007C RID: 124
		public static Vector2 ljoy;

		// Token: 0x0400007D RID: 125
		private static GradientColorKey[] ihate = new GradientColorKey[6];

		// Token: 0x0400007E RID: 126
		private static bool gunLock;

		// Token: 0x0400007F RID: 127
		private static object NewGamemodeType;

		// Token: 0x04000080 RID: 128
		private static float cooldown2;

		// Token: 0x04000081 RID: 129
		private static float ropetimeout;

		// Token: 0x04000082 RID: 130
		private static float cooldown;

		// Token: 0x04000083 RID: 131
		private static float balll2;

		// Token: 0x04000084 RID: 132
		private static float ropedelay;

		// Token: 0x04000085 RID: 133
		public static bool rightHand;

		// Token: 0x04000086 RID: 134
		private static bool baweiofjwf = true;

		// Token: 0x04000087 RID: 135
		private static Player beesPlayer;

		// Token: 0x04000088 RID: 136
		public static int[] timers = new int[10];

		// Token: 0x04000089 RID: 137
		public static bool back;

		// Token: 0x0400008A RID: 138
		public static bool upside;

		// Token: 0x0400008B RID: 139
		public static float projDebounce;

		// Token: 0x0400008C RID: 140
		public static Color currentProjectileColor;

		// Token: 0x0400008D RID: 141
		public static bool shibaimage = false;

		// Token: 0x0400008E RID: 142
		public static bool binaryimage = false;

		// Token: 0x0400008F RID: 143
		public static Color maincolor = Mods.black;

		// Token: 0x04000090 RID: 144
		public static Color buttoncolor = Color.gray;

		// Token: 0x04000091 RID: 145
		public static bool animated = true;

		// Token: 0x04000092 RID: 146
		public static Color activatedcolor = Color.blue;

		// Token: 0x04000093 RID: 147
		public static float projDebounceType;

		// Token: 0x04000094 RID: 148
		public static int thememnumber = 5;

		// Token: 0x04000095 RID: 149
		public static float balll = 0f;

		// Token: 0x04000096 RID: 150
		public static Camera TPC = null;

		// Token: 0x04000097 RID: 151
		public static bool shouldBePC;

		// Token: 0x04000098 RID: 152
		public static Color bgColorA;

		// Token: 0x04000099 RID: 153
		public static VRRig whoCopy = null;

		// Token: 0x0400009A RID: 154
		public static bool isCopying = false;

		// Token: 0x0400009B RID: 155
		public string overlapText = null;

		// Token: 0x0400009C RID: 156
		public static bool iirejri = false;

		// Token: 0x0400009D RID: 157
		public static GameObject airSwimPart = null;

		// Token: 0x0400009E RID: 158
		public static float laggyRigDelay = 0f;

		// Token: 0x0400009F RID: 159
		public static bool lastprimaryhit = false;

		// Token: 0x040000A0 RID: 160
		public static bool idiotfixthingy = false;

		// Token: 0x040000A1 RID: 161
		public static bool destroymenu = true;

		// Token: 0x040000A2 RID: 162
		public static bool dontdestroymenu;

		// Token: 0x040000A3 RID: 163
		private static bool erihu = false;

		// Token: 0x040000A4 RID: 164
		private static List<GameObject> leaves = new List<GameObject>();

		// Token: 0x040000A5 RID: 165
		private static bool AllowProjChange = false;

		// Token: 0x040000A6 RID: 166
		private static int ProjType = 0;

		// Token: 0x040000A7 RID: 167
		private static int Projhash = -820530352;

		// Token: 0x040000A8 RID: 168
		public static int projgunhash = -820530352;

		// Token: 0x040000A9 RID: 169
		public static int projguntype = 0;

		// Token: 0x040000AA RID: 170
		public static int projhalohash = -820530352;

		// Token: 0x040000AB RID: 171
		public static int projhalotype = 0;

		// Token: 0x040000AC RID: 172
		public static bool isUpdatingValues = false;

		// Token: 0x040000AD RID: 173
		public static float valueChangeDelay = 0f;

		// Token: 0x040000AE RID: 174
		public static bool changingColor = false;

		// Token: 0x040000AF RID: 175
		public static Color colorChange = Color.black;

		// Token: 0x040000B0 RID: 176
		public static float updateTimer = 0f;

		// Token: 0x040000B1 RID: 177
		public static bool RandomColor = false;

		// Token: 0x040000B2 RID: 178
		public static Color color;

		// Token: 0x040000B3 RID: 179
		public static float GlowAmount = 1f;

		// Token: 0x040000B4 RID: 180
		public static float timer = 0f;

		// Token: 0x040000B5 RID: 181
		public static float hue = 0f;

		// Token: 0x040000B6 RID: 182
		public static float CycleSpeed = 0.07f;

		// Token: 0x040000B7 RID: 183
		public static float updateRate = 0f;

		// Token: 0x040000B8 RID: 184
		public static bool lefthandd;

		// Token: 0x040000B9 RID: 185
		private static GameObject C4;

		// Token: 0x040000BA RID: 186
		public static bool esiuhkfdjmcsl = false;

		// Token: 0x040000BB RID: 187
		private static bool bothhands = false;

		// Token: 0x040000BC RID: 188
		private static float balll21111;

		// Token: 0x040000BD RID: 189
		private static bool stuiejrf2 = false;

		// Token: 0x040000BE RID: 190
		private static bool stuiejrf99 = true;

		// Token: 0x040000BF RID: 191
		public static RaycastHit raycastHit;

		// Token: 0x040000C0 RID: 192
		public static float distance = 2f;

		// Token: 0x040000C1 RID: 193
		public static Vector3[] positions = new Vector3[]
		{
			new Vector3(Mods.distance, 0f, Mods.distance),
			new Vector3(0f, 0f, Mods.distance),
			new Vector3(-Mods.distance, 0f, Mods.distance),
			new Vector3(Mods.distance, 0f, 0f),
			new Vector3(0f, 0f, 0f),
			new Vector3(-Mods.distance, 0f, 0f),
			new Vector3(Mods.distance, 0f, -Mods.distance),
			new Vector3(0f, 0f, -Mods.distance),
			new Vector3(-Mods.distance, 0f, -Mods.distance)
		};

		// Token: 0x040000C2 RID: 194
		public static GameObject pookiebear;

		// Token: 0x040000C3 RID: 195
		public static float balll2111;

		// Token: 0x040000C4 RID: 196
		public static bool cycle = false;

		// Token: 0x040000C5 RID: 197
		public static int fuckyoucsharp = 0;

		// Token: 0x040000C6 RID: 198
		public static int projectile = 0;

		// Token: 0x040000C7 RID: 199
		public static int projectilehash = -820530352;

		// Token: 0x040000C8 RID: 200
		public static int projectiletrail = 0;

		// Token: 0x040000C9 RID: 201
		public static int projectiletrailhash = 1432124712;

		// Token: 0x040000CA RID: 202
		public static int projectilecycle1 = 0;

		// Token: 0x040000CB RID: 203
		public static int projectilehashc1 = -820530352;

		// Token: 0x040000CC RID: 204
		public static int projectilecycle2 = 0;

		// Token: 0x040000CD RID: 205
		public static int projectilehashc2 = -820530352;

		// Token: 0x040000CE RID: 206
		public static int projectilecycle3 = 0;

		// Token: 0x040000CF RID: 207
		public static int projectilehashc3 = -820530352;

		// Token: 0x040000D0 RID: 208
		public static int projectilecycle4 = 0;

		// Token: 0x040000D1 RID: 209
		public static int projectilehashc4 = -820530352;

		// Token: 0x040000D2 RID: 210
		public static int currentPositionIndex = 0;

		// Token: 0x040000D3 RID: 211
		public static GameObject erm = null;

		// Token: 0x040000D4 RID: 212
		public static float moveSpeed = 5f;

		// Token: 0x040000D5 RID: 213
		public static bool rainboww = false;

		// Token: 0x040000D6 RID: 214
		private static int colorproj;

		// Token: 0x040000D7 RID: 215
		private static List<VRRig> validRigs = new List<VRRig>();

		// Token: 0x040000D8 RID: 216
		public static bool weuhfewh;

		// Token: 0x040000D9 RID: 217
		public static int rock = PoolUtils.GameObjHashCode(GameObject.Find("Environment Objects/PersistentObjects_Prefab/GlobalObjectPools/LavaRockProjectile(Clone)"));

		// Token: 0x040000DA RID: 218
		public static int moltenrock = PoolUtils.GameObjHashCode(GameObject.Find("Environment Objects/PersistentObjects_Prefab/GlobalObjectPools/MoltenRockSlingshot_Projectile(Clone)"));

		// Token: 0x040000DB RID: 219
		public static int Cane = PoolUtils.GameObjHashCode(GameObject.Find("Environment Objects/PersistentObjects_Prefab/GlobalObjectPools/BucketGift_Cane_Projectile Variant(Clone)"));

		// Token: 0x040000DC RID: 220
		public static int Coal = PoolUtils.GameObjHashCode(GameObject.Find("Environment Objects/PersistentObjects_Prefab/GlobalObjectPools/BucketGift_Coal_Projectile Variant(Clone)"));

		// Token: 0x040000DD RID: 221
		public static int Roll = PoolUtils.GameObjHashCode(GameObject.Find("Environment Objects/PersistentObjects_Prefab/GlobalObjectPools/BucketGift_Roll_Projectile Variant(Clone)"));

		// Token: 0x040000DE RID: 222
		public static int Round = PoolUtils.GameObjHashCode(GameObject.Find("Environment Objects/PersistentObjects_Prefab/GlobalObjectPools/BucketGift_Round_Projectile Variant(Clone)"));

		// Token: 0x040000DF RID: 223
		public static int Square = PoolUtils.GameObjHashCode(GameObject.Find("Environment Objects/PersistentObjects_Prefab/GlobalObjectPools/BucketGift_Square_Projectile Variant(Clone)"));

		// Token: 0x040000E0 RID: 224
		private static float chatgpt;

		// Token: 0x040000E1 RID: 225
		public static float projectiletimeout = 0f;

		// Token: 0x040000E3 RID: 227
		public static float orbitSpeed = 5f;

		// Token: 0x040000E4 RID: 228
		private static float angle;

		// Token: 0x040000E5 RID: 229
		public static int platnum = 0;

		// Token: 0x040000E6 RID: 230
		public static Color platcolor = Color.black;

		// Token: 0x040000E7 RID: 231
		public static int[] bones = new int[]
		{
			4,
			3,
			5,
			4,
			19,
			18,
			20,
			19,
			3,
			18,
			21,
			20,
			22,
			21,
			25,
			21,
			29,
			21,
			31,
			29,
			27,
			25,
			24,
			22,
			6,
			5,
			7,
			6,
			10,
			6,
			14,
			6,
			16,
			14,
			12,
			10,
			9,
			7
		};

		// Token: 0x040000E8 RID: 232
		private static bool eirsukdjyfj = false;

		// Token: 0x040000E9 RID: 233
		public static VRRig lockedrig;

		// Token: 0x040000EA RID: 234
		private static VRRig chosenplayer = GorillaTagger.Instance.offlineVRRig;

		// Token: 0x040000EB RID: 235
		public static GameObject rPlat;

		// Token: 0x040000EC RID: 236
		public static GameObject lPlat;

		// Token: 0x040000ED RID: 237
		public static bool RightToggle;

		// Token: 0x040000EE RID: 238
		public static bool LeftToggle;

		// Token: 0x040000EF RID: 239
		public static Material PlatColor = new Material(Shader.Find("GorillaTag/UberShader"));

		// Token: 0x040000F0 RID: 240
		public static Vector3 scale = new Vector3(0.01f, 0.23f, 0.3625f);

		// Token: 0x040000F1 RID: 241
		public static List<string> namelist = new List<string>();

		// Token: 0x040000F2 RID: 242
		private static bool freezetrainbool;

		// Token: 0x040000F3 RID: 243
		private static float aaa;

		// Token: 0x040000F4 RID: 244
		public static GameObject pointer;

		// Token: 0x040000F5 RID: 245
		public static Color ProjColor = Color.white;

		// Token: 0x040000F6 RID: 246
		public static bool changingName = false;

		// Token: 0x040000F7 RID: 247
		public static string nameChange = "";

		// Token: 0x040000F8 RID: 248
		public static float kgDebounce = 0f;

		// Token: 0x040000F9 RID: 249
		private static bool once_left;

		// Token: 0x040000FA RID: 250
		private static bool once_right;

		// Token: 0x040000FB RID: 251
		private static bool once_left_false;

		// Token: 0x040000FC RID: 252
		private static bool once_right_false;

		// Token: 0x040000FD RID: 253
		private static bool once_networking;

		// Token: 0x040000FE RID: 254
		private static GameObject[] jump_left_network = new GameObject[9999];

		// Token: 0x040000FF RID: 255
		private static GameObject[] jump_right_network = new GameObject[9999];

		// Token: 0x04000100 RID: 256
		private static GameObject jump_left_local = null;

		// Token: 0x04000101 RID: 257
		private static GameObject jump_right_local = null;

		// Token: 0x04000102 RID: 258
		private static GradientColorKey[] colorKeysPlatformMonke = new GradientColorKey[4];

		// Token: 0x04000103 RID: 259
		private static Vector3? checkpointPos;

		// Token: 0x04000104 RID: 260
		private static bool flag4;

		// Token: 0x04000105 RID: 261
		private static bool flag1;

		// Token: 0x04000106 RID: 262
		private static bool flag2;

		// Token: 0x04000107 RID: 263
		private static bool flag28;

		// Token: 0x04000108 RID: 264
		private static object MathF;

		// Token: 0x04000109 RID: 265
		private static string projectilePath;

		// Token: 0x02000019 RID: 25
		internal class Reconnect
		{
			// Token: 0x04000118 RID: 280
			public static string rejRoom;

			// Token: 0x04000119 RID: 281
			public static float rejDebounce;
		}

		// Token: 0x0200001A RID: 26
		public class RGBSkeletonESPClass : MonoBehaviour
		{
			// Token: 0x06000307 RID: 775 RVA: 0x0001DCA0 File Offset: 0x0001BEA0
			private void Start()
			{
				this.lineRenderer = base.gameObject.AddComponent<LineRenderer>();
				this.lineRenderer.material = new Material(Shader.Find("GUI/Text Shader"));
				this.lineRenderer.startWidth = this.lineWidth;
				this.lineRenderer.endWidth = this.lineWidth;
			}

			// Token: 0x06000308 RID: 776 RVA: 0x0001DCFE File Offset: 0x0001BEFE
			private void Update()
			{
				this.DrawSkeleton();
			}

			// Token: 0x06000309 RID: 777 RVA: 0x0001DD08 File Offset: 0x0001BF08
			private void OnDestroy()
			{
				this.ClearLineObjects();
			}

			// Token: 0x0600030A RID: 778 RVA: 0x0001DD14 File Offset: 0x0001BF14
			public void DrawSkeleton()
			{
				this.ClearLineObjects();
				VRRig component = base.GetComponent<VRRig>();
				bool flag = component == null;
				if (flag)
				{
					Debug.LogWarning("niga2");
				}
				else
				{
					Color animatedColor = this.GetAnimatedColor();
					this.DrawLine(component.headMesh.transform.position - new Vector3(0f, 0.35f, 0f), component.headMesh.transform.position, animatedColor);
					this.DrawLine(component.headMesh.transform.position - new Vector3(0f, 0.05f, 0f), component.headMesh.transform.position + component.headMesh.transform.up * 0.2f, animatedColor);
					this.DrawLine(component.headMesh.transform.position - new Vector3(0f, 0.05f, 0f), component.headMesh.transform.position + component.transform.right * -0.15f, animatedColor);
					this.DrawLine(component.headMesh.transform.position - new Vector3(0f, 0.05f, 0f), component.headMesh.transform.position + component.transform.right * 0.15f, animatedColor);
					this.DrawLine(component.headMesh.transform.position + component.transform.right * -0.15f, component.myBodyDockPositions.leftArmTransform.position, animatedColor);
					this.DrawLine(component.headMesh.transform.position + component.transform.right * 0.15f, component.myBodyDockPositions.rightArmTransform.position, animatedColor);
					this.DrawLine(component.myBodyDockPositions.leftArmTransform.position, component.leftHandTransform.position, animatedColor);
					this.DrawLine(component.myBodyDockPositions.rightArmTransform.position, component.rightHandTransform.position, animatedColor);
					this.DrawLine(component.rightHandTransform.position, component.rightThumb.fingerBone1.position, animatedColor);
					this.DrawLine(component.rightThumb.fingerBone1.position, component.rightThumb.fingerBone2.position, animatedColor);
					this.DrawLine(component.rightHandTransform.position, component.rightIndex.fingerBone1.position, animatedColor);
					this.DrawLine(component.rightIndex.fingerBone1.position, component.rightIndex.fingerBone2.position, animatedColor);
					this.DrawLine(component.rightIndex.fingerBone2.position, component.rightIndex.fingerBone3.position, animatedColor);
					this.DrawLine(component.rightHandTransform.position, component.rightMiddle.fingerBone1.position, animatedColor);
					this.DrawLine(component.rightMiddle.fingerBone1.position, component.rightMiddle.fingerBone2.position, animatedColor);
					this.DrawLine(component.rightMiddle.fingerBone2.position, component.rightMiddle.fingerBone3.position, animatedColor);
					this.DrawLine(component.leftHandTransform.position, component.leftThumb.fingerBone1.position, animatedColor);
					this.DrawLine(component.leftThumb.fingerBone1.position, component.leftThumb.fingerBone2.position, animatedColor);
					this.DrawLine(component.leftHandTransform.position, component.leftIndex.fingerBone1.position, animatedColor);
					this.DrawLine(component.leftIndex.fingerBone1.position, component.leftIndex.fingerBone2.position, animatedColor);
					this.DrawLine(component.leftIndex.fingerBone2.position, component.leftIndex.fingerBone3.position, animatedColor);
					this.DrawLine(component.leftHandTransform.position, component.leftMiddle.fingerBone1.position, animatedColor);
					this.DrawLine(component.leftMiddle.fingerBone1.position, component.leftMiddle.fingerBone2.position, animatedColor);
					this.DrawLine(component.leftMiddle.fingerBone2.position, component.leftMiddle.fingerBone3.position, animatedColor);
				}
			}

			// Token: 0x0600030B RID: 779 RVA: 0x0001E1D8 File Offset: 0x0001C3D8
			private Color GetAnimatedColor()
			{
				float time = Time.time;
				float num = Mathf.Sin(time * 2f) * 0.5f + 0.5f;
				float num2 = Mathf.Sin(time * 1.5f) * 0.5f + 0.5f;
				float num3 = Mathf.Sin(time * 2.5f) * 0.5f + 0.5f;
				return new Color(num, num2, num3);
			}

			// Token: 0x0600030C RID: 780 RVA: 0x0001E248 File Offset: 0x0001C448
			private void ClearLineObjects()
			{
				foreach (GameObject gameObject in this.lineObjects)
				{
					Object.Destroy(gameObject);
				}
				this.lineObjects.Clear();
			}

			// Token: 0x0600030D RID: 781 RVA: 0x0001E2AC File Offset: 0x0001C4AC
			private GameObject CreateLineObject()
			{
				GameObject gameObject = new GameObject("LineObject");
				gameObject.transform.SetParent(base.transform);
				this.lineObjects.Add(gameObject);
				return gameObject;
			}

			// Token: 0x0600030E RID: 782 RVA: 0x0001E2EC File Offset: 0x0001C4EC
			private void DrawLine(Vector3 startPos, Vector3 endPos, Color color)
			{
				LineRenderer lineRenderer = this.CreateLineObject().AddComponent<LineRenderer>();
				lineRenderer.material = new Material(Shader.Find("GUI/Text Shader"));
				lineRenderer.startColor = color;
				lineRenderer.endColor = color;
				lineRenderer.startWidth = this.lineWidth;
				lineRenderer.endWidth = this.lineWidth;
				lineRenderer.positionCount = 2;
				lineRenderer.SetPositions(new Vector3[]
				{
					startPos,
					endPos
				});
			}

			// Token: 0x0400011A RID: 282
			public Color lineColor = Color.white;

			// Token: 0x0400011B RID: 283
			public float lineWidth = 0.02f;

			// Token: 0x0400011C RID: 284
			private LineRenderer lineRenderer;

			// Token: 0x0400011D RID: 285
			private List<GameObject> lineObjects = new List<GameObject>();

			// Token: 0x0400011E RID: 286
			public static bool RGBSkeletonESP;
		}

		// Token: 0x0200001B RID: 27
		public class SkeletonESPClass : MonoBehaviour
		{
			// Token: 0x06000310 RID: 784 RVA: 0x0001E398 File Offset: 0x0001C598
			private void Start()
			{
				this.lineRenderer = base.gameObject.AddComponent<LineRenderer>();
				this.lineRenderer.material = new Material(Shader.Find("GUI/Text Shader"));
				this.lineRenderer.startWidth = this.lineWidth;
				this.lineRenderer.endWidth = this.lineWidth;
			}

			// Token: 0x06000311 RID: 785 RVA: 0x0001E3F6 File Offset: 0x0001C5F6
			private void Update()
			{
				this.DrawSkeleton();
			}

			// Token: 0x06000312 RID: 786 RVA: 0x0001E400 File Offset: 0x0001C600
			private void OnDestroy()
			{
				this.ClearLineObjects();
			}

			// Token: 0x06000313 RID: 787 RVA: 0x0001E40C File Offset: 0x0001C60C
			public void DrawSkeleton()
			{
				this.ClearLineObjects();
				VRRig component = base.GetComponent<VRRig>();
				bool flag = component == null;
				if (flag)
				{
					Debug.LogWarning("niga");
				}
				else
				{
					Color color = component.mainSkin.material.color;
					bool rgbskeletonESP = Mods.SkeletonESPClass.RGBSkeletonESP;
					if (rgbskeletonESP)
					{
						color = this.GetAnimatedColor();
					}
					this.DrawLine(component.headMesh.transform.position - new Vector3(0f, 0.35f, 0f), component.headMesh.transform.position, color);
					this.DrawLine(component.headMesh.transform.position - new Vector3(0f, 0.05f, 0f), component.headMesh.transform.position + component.headMesh.transform.up * 0.2f, color);
					this.DrawLine(component.headMesh.transform.position - new Vector3(0f, 0.05f, 0f), component.headMesh.transform.position + component.transform.right * -0.15f, color);
					this.DrawLine(component.headMesh.transform.position - new Vector3(0f, 0.05f, 0f), component.headMesh.transform.position + component.transform.right * 0.15f, color);
					this.DrawLine(component.headMesh.transform.position + component.transform.right * -0.15f, component.myBodyDockPositions.leftArmTransform.position, color);
					this.DrawLine(component.headMesh.transform.position + component.transform.right * 0.15f, component.myBodyDockPositions.rightArmTransform.position, color);
					this.DrawLine(component.myBodyDockPositions.leftArmTransform.position, component.leftHandTransform.position, color);
					this.DrawLine(component.myBodyDockPositions.rightArmTransform.position, component.rightHandTransform.position, color);
					this.DrawLine(component.rightHandTransform.position, component.rightThumb.fingerBone1.position, color);
					this.DrawLine(component.rightThumb.fingerBone1.position, component.rightThumb.fingerBone2.position, color);
					this.DrawLine(component.rightHandTransform.position, component.rightIndex.fingerBone1.position, color);
					this.DrawLine(component.rightIndex.fingerBone1.position, component.rightIndex.fingerBone2.position, color);
					this.DrawLine(component.rightIndex.fingerBone2.position, component.rightIndex.fingerBone3.position, color);
					this.DrawLine(component.rightHandTransform.position, component.rightMiddle.fingerBone1.position, color);
					this.DrawLine(component.rightMiddle.fingerBone1.position, component.rightMiddle.fingerBone2.position, color);
					this.DrawLine(component.rightMiddle.fingerBone2.position, component.rightMiddle.fingerBone3.position, color);
					this.DrawLine(component.leftHandTransform.position, component.leftThumb.fingerBone1.position, color);
					this.DrawLine(component.leftThumb.fingerBone1.position, component.leftThumb.fingerBone2.position, color);
					this.DrawLine(component.leftHandTransform.position, component.leftIndex.fingerBone1.position, color);
					this.DrawLine(component.leftIndex.fingerBone1.position, component.leftIndex.fingerBone2.position, color);
					this.DrawLine(component.leftIndex.fingerBone2.position, component.leftIndex.fingerBone3.position, color);
					this.DrawLine(component.leftHandTransform.position, component.leftMiddle.fingerBone1.position, color);
					this.DrawLine(component.leftMiddle.fingerBone1.position, component.leftMiddle.fingerBone2.position, color);
					this.DrawLine(component.leftMiddle.fingerBone2.position, component.leftMiddle.fingerBone3.position, color);
				}
			}

			// Token: 0x06000314 RID: 788 RVA: 0x0001E8EC File Offset: 0x0001CAEC
			private Color GetAnimatedColor()
			{
				float time = Time.time;
				float num = Mathf.Sin(time * 2f) * 0.5f + 0.5f;
				float num2 = Mathf.Sin(time * 1.5f) * 0.5f + 0.5f;
				float num3 = Mathf.Sin(time * 2.5f) * 0.5f + 0.5f;
				return new Color(num, num2, num3);
			}

			// Token: 0x06000315 RID: 789 RVA: 0x0001E95C File Offset: 0x0001CB5C
			private void ClearLineObjects()
			{
				foreach (GameObject gameObject in this.lineObjects)
				{
					Object.Destroy(gameObject);
				}
				this.lineObjects.Clear();
			}

			// Token: 0x06000316 RID: 790 RVA: 0x0001E9C0 File Offset: 0x0001CBC0
			private GameObject CreateLineObject()
			{
				GameObject gameObject = new GameObject("LineObject");
				gameObject.transform.SetParent(base.transform);
				this.lineObjects.Add(gameObject);
				return gameObject;
			}

			// Token: 0x06000317 RID: 791 RVA: 0x0001EA00 File Offset: 0x0001CC00
			private void DrawLine(Vector3 startPos, Vector3 endPos, Color color)
			{
				LineRenderer lineRenderer = this.CreateLineObject().AddComponent<LineRenderer>();
				lineRenderer.material = new Material(Shader.Find("GUI/Text Shader"));
				lineRenderer.startColor = color;
				lineRenderer.endColor = color;
				lineRenderer.startWidth = this.lineWidth;
				lineRenderer.endWidth = this.lineWidth;
				lineRenderer.positionCount = 2;
				lineRenderer.SetPositions(new Vector3[]
				{
					startPos,
					endPos
				});
			}

			// Token: 0x0400011F RID: 287
			public Color lineColor = Color.white;

			// Token: 0x04000120 RID: 288
			public float lineWidth = 0.02f;

			// Token: 0x04000121 RID: 289
			private LineRenderer lineRenderer;

			// Token: 0x04000122 RID: 290
			private List<GameObject> lineObjects = new List<GameObject>();

			// Token: 0x04000123 RID: 291
			public static bool RGBSkeletonESP;
		}
	}
}
