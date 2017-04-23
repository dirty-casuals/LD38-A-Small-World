using System;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public enum ControlType {
        Keyboard,
        Mouse,
        Touch
    }

    [SerializeField]
    private PaddleController _paddleController;

    [SerializeField, Range( 0.1f, 10 )]
    private float _pointerResponsiveness = 3;

    private ControlType controlType;

    private Vector3 previouMousePosition;
    private float halfScreenHeight;

    private void Start() {
        halfScreenHeight = Screen.height / 2;
    }

    private void Update() {
        HandleMouseInput();
        HandleTouchInput();
        HandleKeyboardInput();
    }

    private void HandleKeyboardInput() {
        float direction = Input.GetAxis( "Vertical" );

        if( direction != 0 ) {
            controlType = ControlType.Keyboard;
        }

        if( controlType == ControlType.Keyboard ) {
            _paddleController.Direction = direction;
        }
    }

    private void HandleTouchInput() {
        if( Input.touchCount > 0 ) {
            controlType = ControlType.Touch;
        }

        if( controlType == ControlType.Touch ) {
            MoveToPoint( Input.GetTouch( 0 ).position );
        }
    }

    private void HandleMouseInput() {

        if( !Input.mousePresent ) {
            return;
        }

        Vector3 mousePosition = Input.mousePosition;
        Vector3 mouseDelta = previouMousePosition - mousePosition;

        if( mouseDelta.magnitude > float.Epsilon ) {
            previouMousePosition = mousePosition;
            controlType = ControlType.Mouse;
        }

        if( controlType == ControlType.Mouse ) {
            MoveToPoint( mousePosition );
        }
    }

    private void MoveToPoint( Vector3 screenPoint ) {

        Vector3 paddleScreenPosition =
            Camera.main.WorldToScreenPoint( _paddleController.transform.position );

        Vector3 planetScreenPosition =
            Camera.main.WorldToScreenPoint( _paddleController.Planet.transform.position );

        Vector3 paddleVector = paddleScreenPosition - planetScreenPosition;
        Vector3 pointerVector = screenPoint - planetScreenPosition;

        paddleVector.z = 0;
        pointerVector.z = 0;

        float paddleAngle = Mathf.Atan2( paddleVector.y, paddleVector.x );
        float pointerAngle = Mathf.Atan2( pointerVector.y, pointerVector.x );
        float angle = pointerAngle - paddleAngle;

        angle = Mathf.Repeat( angle, Mathf.PI * 2 );
        if( angle > Mathf.PI ) { angle -= Mathf.PI * 2; }

        _paddleController.Direction = angle * _pointerResponsiveness;
    }
}
