using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Scripts.Candles;

namespace Scripts.Mouse {
	public class Mouse : MonoBehaviour {
		//[Header("Variables")]

		//[Header("Links")]

		//Internal varibales

		#region My Methods
		private void Clicking() {
			if(Input.GetMouseButtonDown(0)) {
				Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
				RaycastHit2D hit = Physics2D.Raycast(mousePosition,Vector2.zero);
				if(hit.collider != null && hit.collider.gameObject.CompareTag("Candle")) {
					Candle candle = hit.collider.gameObject.GetComponent<Candle>();
					candle.Clicked();
				}
			}
		}
		#endregion

		#region Unity's Methods
		private void Update() {
			Clicking();
		}
		#endregion
	}
}