using Scripts.UI.Menu;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Scripts.GameManager {
  public class GameManager : MonoBehaviour {
    //[Header("Variables")]

    //[Header("Links")]

    //Internal varibales
    public GameStateEnum GameState { get; private set; }
		public static GameManager Instance;

		#region My Methods
		private void GameStateChangedEventHandler(GameStateEventArgs eventArgs) {
			GameState = eventArgs.State;
			if(GameState == GameStateEnum.GAMEOVER) {GameOverEvent.Raise();}
			if(GameState == GameStateEnum.REMEMBERING_PHASE) {
			}
		}
		private void ChangeState() {
			GameStateChangedEvent.Rais(new GameStateEventArgs(GameStateEnum.REMEMBERING_PHASE));
		}
		private void PlayButtonPressedEventHandler() {
			GameState = GameStateEnum.PLAYING;
			Invoke("ChangeState",0.5f);
		}
		#endregion

		#region Unity's Methods
		private void Awake() {
			if(Instance != null && Instance != this) {Destroy(this);}
			else {Instance = this;}
		}
		private void Start() {
			GameState = GameStateEnum.GAMEOVER;
			Debug.Log("Alma");
			GameStateChangedEvent.Rais(new GameStateEventArgs(GameStateEnum.GAMEOVER));
		}
		private void Update() {
			if(Input.GetKeyDown(KeyCode.R)) {
				GameStateChangedEvent.Rais(new GameStateEventArgs(GameStateEnum.GAMEOVER));
				Debug.Log("Armud");
			}
		}

		private void OnEnable() {
			GameStateChangedEvent.EventGameStateChanged += GameStateChangedEventHandler;
			PlayButtonPressedEvent.EventPlayButtonPressed += PlayButtonPressedEventHandler;
		}
		private void OnDisable() {
			GameStateChangedEvent.EventGameStateChanged -= GameStateChangedEventHandler;
			PlayButtonPressedEvent.EventPlayButtonPressed -= PlayButtonPressedEventHandler;
		}
		#endregion
	}
}