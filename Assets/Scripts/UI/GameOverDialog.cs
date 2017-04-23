using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverDialog : MonoBehaviour {

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
        _gameOverMessage.text = "Congratulations Pluto, you're a planet! A lonely, lonely planet.";
        _retryButtonLabel.text = "Play Again";
    }

    public void SetLoseContent() {
        _gameOverMessage.text = "Game Over, rest in pieces Pluto.";
        _retryButtonLabel.text = "Try Again";
    }
}
