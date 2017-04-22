using UnityEngine;
using UnityEngine.UI;

public class LivesDisplay : MonoBehaviour {

    [SerializeField]
    private Lives _lives;

    private Text _text;
    private int displayedLives = -1;

    private Text Text {
        get {
            if( !_text ) {
                _text = GetComponent<Text>();
            }
            return _text;
        }
    }

    private Lives Lives {
        get { return _lives; }
    }

    void Update() {
        if( Lives ) {
            if( displayedLives != Lives.numberLivesRemaining ) {
                displayedLives = Lives.numberLivesRemaining;
                Text.text = "x" + displayedLives;
            }
        } else {
            Text.text = "";
        }
    }
}
