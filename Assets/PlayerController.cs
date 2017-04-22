using UnityEngine;

public class PlayerController : MonoBehaviour {

    [SerializeField]
    private PaddleController _paddleController;
    
    private void Update() {
        float direction = Input.GetAxis( "Vertical" );
        _paddleController.Direction = direction;
    }
}
