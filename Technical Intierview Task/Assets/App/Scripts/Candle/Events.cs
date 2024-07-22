using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Candles {
	public class ClickedEventArgs : EventArgs{
		public int ID;
		public ClickedEventArgs(int ID) {  this.ID = ID; }
	}

	public static class ClickedEvent {
		public delegate void ClickedDelegate(ClickedEventArgs eventArgs);
		public static event ClickedDelegate EventClicked;
		public static void Raise(ClickedEventArgs eventArgs) {EventClicked?.Invoke(eventArgs);}
	}
}