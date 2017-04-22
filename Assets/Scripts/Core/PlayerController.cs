using UnityEngine;

public class PlayerController : MonoBehaviour {

    [SerializeField]
    private PaddleController _paddleController;

    private float halfScreenHeight;

    private void Start() {
        halfScreenHeight = Screen.height / 2;
    }
    
    private void Update() {
        float direction = 0.0f;
        if (Input.touchCount > 0) {
            Touch touch = Input.touches[0];
            float posY = touch.position.y;
            if ( posY > halfScreenHeight ) {
                direction = 1.0f;
            } else if ( posY < halfScreenHeight ) {
                direction = -1.0f;
            }
        } else {
            direction = Input.GetAxis( "Vertical" );
        }
        _paddleController.Direction = direction;
    }
}
