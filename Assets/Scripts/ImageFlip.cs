using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class ImageFlip : MonoBehaviour
{

    // constants / public vars
    public int ANIMATION_SPEED;

        // sprite data
    public Sprite[] sprites = { };

    // public references
    public GameObject obj;

    // variable initialisation

        // objects/components
    UnityEngine.UI.Image image;

        // regular data
    float timeElapsed = 0f;

    void Start()
    {

        // component initialisation
        image = obj.GetComponent<UnityEngine.UI.Image>();

    }

    void Update()
    {

        // switch spritesheet frame
        if (Mathf.Floor(timeElapsed * ANIMATION_SPEED) % 2 == 0)
        {
            image.sprite = sprites[0];
        }
        else
        {
            image.sprite = sprites[1];
        }

        timeElapsed += Time.deltaTime;

    }

}
