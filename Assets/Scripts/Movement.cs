using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{

    // constants / public vars
    const int ANIMATION_SPEED = 3;
    public float SPEED_FACTOR_X;
    public float SPEED_FACTOR_Y;
    public bool isWalking = false;
    public bool playSound = false;
    public float walkVolume = 0.15f;

        // sprite data
    public Sprite[] idleFrames = { };
    public Sprite[] walkingFrames = { };
    Sprite[] currentAnim;

    // public references
    public GameObject player;
    public GameObject sprite;
    public SoundController soundController;
    public AudioSource walk;

    // variable initialisation

        // objects/components
    Rigidbody playerRigidbody;
    InputAction moveAction;
    SpriteRenderer spriteRenderer;
    
        // regular data
    Vector2 moveVector = Vector2.zero;
    float xSpeed = 0f;
    float ySpeed = 0f;
    float timeElapsed = 0f;

    void Start()
    {

        // component initialisation
        playerRigidbody = player.GetComponent<Rigidbody>();
        spriteRenderer = sprite.GetComponent<SpriteRenderer>();

        // action initialisation
        moveAction = InputSystem.actions.FindAction("Move");

        // sprite initialisation
        currentAnim = idleFrames;

    }

    void Update()
    {

        // read movement data
        moveVector = moveAction.ReadValue<Vector2>();
        xSpeed = moveVector.x * SPEED_FACTOR_X * Time.deltaTime * 2;
        ySpeed = moveVector.y * SPEED_FACTOR_Y * Time.deltaTime * 2;

        // apply movement to playerRigidbody
        if (moveVector.magnitude > 0)
        {
            isWalking = true;
            currentAnim = walkingFrames;
            playerRigidbody.AddForce(xSpeed, 0, ySpeed, ForceMode.Impulse);
        }
        else
        {
            isWalking = false;
            currentAnim = idleFrames;
        }

        // switch spritesheet frame
        if (Mathf.Floor(timeElapsed * ANIMATION_SPEED) % 2 == 0)
        {
            spriteRenderer.sprite = currentAnim[0];
            playSound = true;
        }
        else
        {
            spriteRenderer.sprite = currentAnim[1];

            // play walking sfx (if player is moving)
            if (isWalking && playSound)
            {
                soundController.RandomiseAudioProperties(walk, walkVolume);
                walk.Play();
                playSound = false;
            }
        }

        // flip sprite depending on direction of movement
        if (moveVector.x > 0)
        {
            spriteRenderer.flipX = false;
        }
        else if (moveVector.x < 0)
        {
            spriteRenderer.flipX = true;
        }

        timeElapsed += Time.deltaTime;

    }

}
