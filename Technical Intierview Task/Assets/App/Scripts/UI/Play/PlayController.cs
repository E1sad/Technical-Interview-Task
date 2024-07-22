using Scripts.UI.Menu;
using Scripts.UI.Play;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.UI.Play {
  public class PlayController : MonoBehaviour {
    //[Header("Variables")]

    [Header("Links")]
    [SerializeField] private PlayView _view;

		//Internal varibales

		#region My Methods
		public void GameOverEventHandler() {
			_view.gameObject.SetActive(false);
		}
		public void PlayButtonPressedEventHandler() {
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
			PlayButtonPressedEvent.EventPlayButtonPressed += PlayButtonPressedEventHandler;
		}
		private void OnDisable() {
			GameOverEvent.EventGameOver -= GameOverEventHandler;
			ScoreChangedEvent.EventScoreChanged -= ScoreChangedEventHandler;
			PlayButtonPressedEvent.EventPlayButtonPressed -= PlayButtonPressedEventHandler;
		}
		#endregion
	}
}