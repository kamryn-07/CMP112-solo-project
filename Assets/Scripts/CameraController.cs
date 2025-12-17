using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{

    // constants / public vars
    Vector3 CAMERA_START_OFFSET_POS = new Vector3(0f, 1000f, -300f);
    Vector3 CAMERA_OFFSET_POS = new Vector3(0, 20f, -40f);
    Vector3 CAMERA_OFFSET_ROT = new Vector3(27.5f, 0, 0);

    // public references
    public GameObject player;
    public Camera plrCamera;

    // variable initialisation

        // objects/components
    Transform plrCameraTransform;
    Transform playerTransform;

    void Start()
    {

        // component initialisation
        plrCameraTransform = plrCamera.GetComponent<Transform>();
        playerTransform = player.GetComponent<Transform>();

        // initialise camera position
        plrCameraTransform.position = playerTransform.position + CAMERA_START_OFFSET_POS;

    }

    void Update()
    {

        // attach camera to player
        plrCameraTransform.position = Vector3.Lerp(plrCameraTransform.position, playerTransform.position + CAMERA_OFFSET_POS, 2 * Time.deltaTime);
        plrCameraTransform.rotation = Quaternion.Euler(CAMERA_OFFSET_ROT);

    }

}
