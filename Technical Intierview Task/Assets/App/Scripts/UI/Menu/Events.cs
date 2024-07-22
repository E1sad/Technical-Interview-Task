using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.UI.Menu {
	public class HardnessEventArgs : EventArgs {
		public HardnessEnum Hardness;
		public HardnessEventArgs(HardnessEnum Hardness) { this.Hardness = Hardness; }
	}

	public static class HardnessChangedEvent {
		public delegate void HardnessDelegate(HardnessEventArgs eventArgs);
		public static event HardnessDelegate EventHardnessChanged;
		public static void Raise(HardnessEventArgs eventArgs) {
			EventHardnessChanged?.Invoke(eventArgs);
		}
	}

	public class ScoreEventArgs: EventArgs {
		public int Score;
		public ScoreEventArgs(int score) {Score = score;}
	}
	public static class ScoreChangedEvent {
		public delegate void ScoreDelegate(ScoreEventArgs eventArgs);
		public static event ScoreDelegate EventScoreChanged;
		public static void Raise(ScoreEventArgs eventArgs) {EventScoreChanged?.Invoke(eventArgs);}
	}

	public static class PlayButtonPressedEvent {
		public static event Action EventPlayButtonPressed;
		public static void Raise() { EventPlayButtonPressed?.Invoke(); }
	}
	public static class GameOverEvent {
		public static event Action EventGameOver;
		public static void Raise() { EventGameOver?.Invoke(); }
	}
}