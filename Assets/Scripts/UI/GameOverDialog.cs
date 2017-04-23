using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverDialog : MonoBehaviour {

    [SerializeField]
    private Text _gameOverTitle;

    [SerializeField]
    private Text _gameOverMessage;

    [SerializeField]
    private Text _retryButtonLabel;

    public void OnGameOver( bool isPlayer ) {
        if( isPlayer ) {
            SetLoseContent();
            Show();
        } else {
            SetWinContent();
            Show();
        }
    }

    public void Show() {
        gameObject.SetActive( true );
    }

    public void Hide() {
        gameObject.SetActive( false );
    }

    public void SetWinContent() {
        _gameOverTitle.text = "Congratulations, Pluto!";
        _gameOverMessage.text = "You're a planet! A lonely, lonely planet.";
        _retryButtonLabel.text = "Play Again";
    }

    public void SetLoseContent() {
        _gameOverTitle.text = "Game Over";
        _gameOverMessage.text = "Rest in pieces Pluto.";
        _retryButtonLabel.text = "Try Again";
    }
}
