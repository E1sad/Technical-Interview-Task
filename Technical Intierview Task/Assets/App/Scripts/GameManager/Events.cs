using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.GameManager {
	public class GameStateEventArgs : EventArgs {
		public GameStateEnum State;
		public GameStateEventArgs(GameStateEnum state) { this.State = state; }
	}

	public static class GameStateChangedEvent {
		public delegate void GameStateDelegate(GameStateEventArgs eventArgs);
		public static event GameStateDelegate EventGameStateChanged;
		public static void Rais(GameStateEventArgs eventArgs) {
			EventGameStateChanged?.Invoke(eventArgs);
		}
	}
}