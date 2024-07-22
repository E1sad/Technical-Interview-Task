using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Scripts.GameManager;
using Scripts.UI.Menu;

namespace Scripts.Candles {
	public class CandleMechanic : MonoBehaviour {
		[Header("Easy settings")]
		[SerializeField] private float _timeIntervalForNewCandleEasy;
		[SerializeField] private float _timeIntervalForAfterCandleEasy;
		[SerializeField] private int _numberOfNewOrdersEasy = 1;

		[Header("Medium settings")]
		[SerializeField] private float _timeIntervalForNewCandleMedium;
		[SerializeField] private float _timeIntervalForAfterCandleMedium;
		[SerializeField] private int _numberOfNewOrdersMedium = 1;

		[Header("Hard settings")]
		[SerializeField] private float _timeIntervalForNewCandleHard;
		[SerializeField] private float _timeIntervalForAfterCandleHard;
		[SerializeField] private int _numberOfNewOrdersHard = 1;

		[Header("Links")]
		[SerializeField] List<GameObject> _list;

		// Internal variables
		private List<int> _order = new List<int>();
		private Coroutine _orderToRemember;
		private int _currentOrder;
		private float _timeIntervalForNewCandle;
		private float _timeIntervalForAfterCandle;
		private int _numberOfNewOrders;
		private int _score = 0;

		#region My Methods
		//Coroutine to remember the order of candles and manage the display intervals.
		private IEnumerator OrderToRemember(int numberOfNewOrders) {
			int count = 0;
			int size = _order.Count;
			while(count < size + numberOfNewOrders) {
				if(_order.Count > count) {
					Candle candle = _list[_order[count]].GetComponent<Candle>();
					candle.FlamesOff();
					candle.FlamesOn();
					yield return new WaitForSeconds(_timeIntervalForNewCandle);
					candle.FlamesOff();
					yield return new WaitForSeconds(_timeIntervalForAfterCandle);
					Debug.Log("Orders: " + _order[count]);
					count++;
				}
				else {
					_order.Add(Random.Range(0,_list.Count));
					Candle candle = _list[_order[count]].GetComponent<Candle>();
					candle.FlamesOff();
					candle.FlamesOn();
					yield return new WaitForSeconds(_timeIntervalForNewCandle);
					candle.FlamesOff();
					yield return new WaitForSeconds(_timeIntervalForAfterCandle);
					Debug.Log("Orders: " + _order[count]);
					count++;
				}
			}
			GameStateChangedEvent.Rais(new GameStateEventArgs(GameStateEnum.PLAYING));
		}

		private void StartOrderToRememberCoroutine() {
			if(_orderToRemember != null) StopCoroutine(_orderToRemember);
			_orderToRemember = StartCoroutine(OrderToRemember(_numberOfNewOrders));
		}

		private void StopOrderToRememberCoroutine() {
			if(_orderToRemember != null) StopCoroutine(_orderToRemember);
			_orderToRemember = null;
		}
		//Handles the Clicked event. Checks if the clicked candle is in the correct order.
		private void ClickedEventHandler(ClickedEventArgs eventArgs) {
			if(GameManager.GameManager.Instance.GameState == GameStateEnum.PLAYING) {
				if(_currentOrder < _order.Count) {
					Candle candle = _list[_order[_currentOrder]].GetComponent<Candle>();
					if(candle.GetID() == eventArgs.ID) { 
						Debug.Log("CurrentOrder: " + _currentOrder + " | ClickedID: " + candle.GetID() + " | ID: " + eventArgs.ID);
						_currentOrder++;
						if(_currentOrder >= _order.Count) {
							_score++;
							ScoreChangedEvent.Raise(new ScoreEventArgs(_score));
							GameStateChangedEvent.Rais(new GameStateEventArgs(GameStateEnum.REMEMBERING_PHASE));
						}
					}
					else {
						Debug.Log("Wrong: CurrentOrder: " + _currentOrder + " | Order: " + _order[_currentOrder] + " | ID: " + eventArgs.ID);
						GameStateChangedEvent.Rais(new GameStateEventArgs(GameStateEnum.GAMEOVER));
						_score = 0;
					}
				}
			}
		}

		private void GameStateChangedEventHandler(GameStateEventArgs eventArgs) {
			if(eventArgs.State == GameStateEnum.GAMEOVER) {
				_order = new List<int>();
				_currentOrder = 0; // Reset current order
			}
			else if(eventArgs.State == GameStateEnum.REMEMBERING_PHASE) {
				_currentOrder = 0;
				StartOrderToRememberCoroutine();
			}
			if(_order.Count == 0) {
				ScoreChangedEvent.Raise(new ScoreEventArgs(_score));
			}
		}

		private void EventHardnessChangedHandler(HardnessEventArgs eventArgs) {
			if(eventArgs.Hardness == HardnessEnum.EASY) {
				_numberOfNewOrders = _numberOfNewOrdersEasy;
				_timeIntervalForAfterCandle = _timeIntervalForAfterCandleEasy;
				_timeIntervalForNewCandle = _timeIntervalForNewCandleEasy;
			}
			else if(eventArgs.Hardness == HardnessEnum.MEDIUM) {
				_numberOfNewOrders = _numberOfNewOrdersMedium;
				_timeIntervalForAfterCandle = _timeIntervalForAfterCandleMedium;
				_timeIntervalForNewCandle = _timeIntervalForNewCandleMedium;
			}
			else if(eventArgs.Hardness == HardnessEnum.HARD) {
				_numberOfNewOrders = _numberOfNewOrdersHard;
				_timeIntervalForAfterCandle = _timeIntervalForAfterCandleHard;
				_timeIntervalForNewCandle = _timeIntervalForNewCandleHard;
			}
		}
		#endregion

		#region Unity's Methods
		private void Start() {
			// Initialize internal variables if necessary
			_timeIntervalForNewCandle = _timeIntervalForNewCandleEasy;
			_timeIntervalForAfterCandle = _timeIntervalForAfterCandleEasy;
			_numberOfNewOrders = _numberOfNewOrdersEasy;
		}

		private void OnEnable() {
			ClickedEvent.EventClicked += ClickedEventHandler;
			GameStateChangedEvent.EventGameStateChanged += GameStateChangedEventHandler;
			HardnessChangedEvent.EventHardnessChanged += EventHardnessChangedHandler;
		}

		private void OnDisable() {
			ClickedEvent.EventClicked -= ClickedEventHandler;
			GameStateChangedEvent.EventGameStateChanged -= GameStateChangedEventHandler;
			HardnessChangedEvent.EventHardnessChanged -= EventHardnessChangedHandler;
		}
		#endregion
	}
}
