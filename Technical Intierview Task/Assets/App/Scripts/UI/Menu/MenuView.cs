using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Scripts.UI.Menu {
  public class MenuView : MonoBehaviour {
		[Header("Properties")]
		[SerializeField] private TMP_Text _playButtonText;
		[SerializeField] private TMP_Text _scoreText;

		[Header("Links")]
		[SerializeField] private MenuController _controller;

		//Internal varibales

		#region My Methods
		public void PlayButtonPressed() {
			_controller.PlayButtonPressed();
		}
		public void EasyButtonPressed() {
      _playButtonText.text = "Play Easy";
			_controller.EasyButtonPressed();
		}
		public void MediumButtonPressed() {
			_playButtonText.text = "Play Medium";
			_controller.MediumButtonPressed();
		}
		public void HardButtonPressed() {
			_playButtonText.text = "Play Hard";
			_controller.HardButtonPressed();
		}
		public void SetScore(int Score) {
			_scoreText.text = Score.ToString();
		}
		#endregion

		#region Unity's Methods

		#endregion
	}
}