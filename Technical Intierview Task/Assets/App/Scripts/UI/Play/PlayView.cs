using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Scripts.UI.Play {
  public class PlayView : MonoBehaviour {
    [Header("Properties")]
    [SerializeField] private TMP_Text _scoreText;

    [Header("Links")]
    [SerializeField] private PlayController _controller;

    //Internal varibales

    #region My Methods
    public void SetScore(int score) {
      _scoreText.text = score.ToString();
    }
    #endregion

    #region Unity's Methods

    #endregion
  }
}