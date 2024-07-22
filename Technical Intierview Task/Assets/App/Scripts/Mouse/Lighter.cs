using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Mouse {
	public class Lighter : MonoBehaviour {
		//[Header("Variables")]

		//[Header("Links")]

		//Internal varibales

		#region My Methods

		#endregion

		#region Unity's Methods
		private void Update() {
			Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			mousePos.z = 0;
			gameObject.transform.position = mousePos;
		}
		#endregion
	}
}