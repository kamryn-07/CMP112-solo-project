using UnityEngine;
using UnityEngine.InputSystem;

public class ImageRotate : MonoBehaviour
{

    // constants / public vars
    public float ROTATION_SPEED;
    public Vector3 ROTATION_AXIS;

    // variable initialisation

        // regular data
    float timeElapsed = 0f;

    void Update()
    {

        transform.rotation = Quaternion.Euler(timeElapsed * (ROTATION_AXIS.x * ROTATION_SPEED), timeElapsed * (ROTATION_AXIS.y * ROTATION_SPEED), timeElapsed * (ROTATION_AXIS.z * ROTATION_SPEED));
        timeElapsed += Time.deltaTime;

    }

}
