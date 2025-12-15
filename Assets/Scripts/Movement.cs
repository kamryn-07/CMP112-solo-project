using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{

    // constants
    const float SPEED_FACTOR_X = 0.075f;
    const float SPEED_FACTOR_Y = 0.05f;

    // public references
    public GameObject player;

    // variable initialisation

        // objects/components
    Rigidbody playerRigidbody;
    InputAction moveAction;
    
        // regular data
    Vector2 moveVector = Vector2.zero;
    float xSpeed = 0f;
    float ySpeed = 0f;

    void Start()
    {

        // component initialisation
        playerRigidbody = player.GetComponent<Rigidbody>();

        // action initialisation
        moveAction = InputSystem.actions.FindAction("Move");

    }

    void Update()
    {

        // read movement data
        moveVector = moveAction.ReadValue<Vector2>();
        xSpeed = moveVector.x * SPEED_FACTOR_X;
        ySpeed = moveVector.y * SPEED_FACTOR_Y;

        // apply movement to playerRigidbody
        if (moveVector.magnitude > 0)
        {
            playerRigidbody.AddForce(xSpeed, 0, ySpeed, ForceMode.Impulse);
        }

    }

}
