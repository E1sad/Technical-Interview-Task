using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Candles {
	public class Candle : MonoBehaviour {
		[Header("Variables")]
		[SerializeField] private int _candleID;
		[SerializeField] private float _candleOffTime;

		[Header("Links")]
		[SerializeField] private SpriteRenderer _spriteRenderer;

		//Internal varibales

		#region My Methods
		//This fucntion will be called when clicked to this candle
		public void Clicked() {
			FlamesOff();
			ClickedEvent.Raise(new ClickedEventArgs(_candleID));
			FlamesOn();
			Invoke("FlamesOff",_candleOffTime);
		}
		public int GetID() {
			return _candleID;
		}

		public void FlamesOn() {
			_spriteRenderer.enabled = true;
		}
		public void FlamesOff() {
			_spriteRenderer.enabled = false;
		}
		#endregion

		#region Unity's Methods
		private void Start() {
			_spriteRenderer.enabled = false;
		}
		private void OnCollisionEnter2D(Collision2D collision) {
			if(collision.gameObject.CompareTag("Lighter")) {
				//Debug.Log("Alma");
			}
		}
		private void OnCollisionExit2D(Collision2D collision) {
			if(collision.gameObject.CompareTag("Lighter")) {
				//Debug.Log("Armud");
			}
		}
		#endregion
	}
}