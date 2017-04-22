using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverDialog : MonoBehaviour {

    [SerializeField]
    private Text _gameOverMessage;

    [SerializeField]
    private Text _retryButtonLabel;

    public void Show() {
        gameObject.SetActive( true );
    }

    public void Hide() {
        gameObject.SetActive( false );
    }    

    public void SetWinContent() {
        _gameOverMessage.text = "Congratulations, Pluto!";
        _retryButtonLabel.text = "Play Again";
    }

    public void SetLoseContent() {
        _gameOverMessage.text = "Game Over";
        _retryButtonLabel.text = "Try Again";
    }
}
