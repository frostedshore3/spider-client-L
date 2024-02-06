using System;
using UnityEngine;

namespace ShibaGTTemplate.Backend
{
	// Token: 0x02000015 RID: 21
	public class VelocityTracker : MonoBehaviour
	{
		// Token: 0x060001E1 RID: 481 RVA: 0x0001D2AC File Offset: 0x0001B4AC
		private void Start()
		{
			this.rotationLast = base.transform.rotation.eulerAngles;
		}

		// Token: 0x060001E2 RID: 482 RVA: 0x0001D2D4 File Offset: 0x0001B4D4
		private void Update()
		{
			this.rotationDelta = base.transform.rotation.eulerAngles - this.rotationLast;
			this.rotationLast = base.transform.rotation.eulerAngles;
			this._velocity = (base.transform.position - this._previousvelocity) / Time.deltaTime;
			this._previousvelocity = base.transform.position;
		}

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x060001E3 RID: 483 RVA: 0x0001D358 File Offset: 0x0001B558
		public Vector3 angularVelocity
		{
			get
			{
				return this.rotationDelta;
			}
		}

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x060001E4 RID: 484 RVA: 0x0001D370 File Offset: 0x0001B570
		public Vector3 velocity
		{
			get
			{
				return this._velocity;
			}
		}

		// Token: 0x0400010D RID: 269
		private Vector3 rotationLast;

		// Token: 0x0400010E RID: 270
		private Vector3 rotationDelta;

		// Token: 0x0400010F RID: 271
		private Vector3 _previousvelocity;

		// Token: 0x04000110 RID: 272
		private Vector3 _velocity;
	}
}
