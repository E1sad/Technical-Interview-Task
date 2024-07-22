using Scripts.UI.Menu;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.UI.Menu {
	public class MenuController : MonoBehaviour {
		//[Header("Variables")]

		[Header("Links")]
		[SerializeField] private MenuView _view;

		//Internal varibales

		#region My Methods
		public void PlayButtonPressed() {
			_view.gameObject.SetActive(false);
			PlayButtonPressedEvent.Raise();
		}
		public void EasyButtonPressed() {
			HardnessChangedEvent.Raise(new HardnessEventArgs(HardnessEnum.EASY));
		}
		public void MediumButtonPressed() {
			HardnessChangedEvent.Raise(new HardnessEventArgs(HardnessEnum.MEDIUM));
		}
		public void HardButtonPressed() {
			HardnessChangedEvent.Raise(new HardnessEventArgs(HardnessEnum.HARD));
		}
		public void GameOverEventHandler() {
			_view.gameObject.SetActive(true);
		}
		public void ScoreChangedEventHandler(ScoreEventArgs eventArgs) {
			_view.SetScore(eventArgs.Score);
		}
		#endregion

		#region Unity's Methods
		private void OnEnable() {
			GameOverEvent.EventGameOver += GameOverEventHandler;
			ScoreChangedEvent.EventScoreChanged += ScoreChangedEventHandler;
		}
		private void OnDisable() {
			GameOverEvent.EventGameOver -= GameOverEventHandler;
			ScoreChangedEvent.EventScoreChanged -= ScoreChangedEventHandler;
		}
		#endregion
	}
}