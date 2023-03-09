using UnityEngine;

public class SphereController : MonoBehaviour
{
    public float speed = 10.0f; // adjust this to change the speed of the sphere
    private Rigidbody rb;
    private Vector2 prevTouchPos;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // get touch input
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            // get touch position relative to the screen
            Vector2 touchPos = touch.position / new Vector2(Screen.width, Screen.height);

            // if this is the first frame of a new touch, save the touch position
            if (touch.phase == TouchPhase.Began)
            {
                prevTouchPos = touchPos;
            }
            // if the touch is moving, rotate the sphere based on the touch delta
            else if (touch.phase == TouchPhase.Moved)
            {
                // calculate the touch delta
                Vector2 touchDelta = touchPos - prevTouchPos;

                // calculate the rotation amount based on the touch delta
                float rotateHorizontal = -touchDelta.x * speed;
                float rotateVertical = touchDelta.y * speed;
                transform.Rotate(rotateVertical, 0.0f, rotateHorizontal, Space.World);

                // save the current touch position for the next frame
                prevTouchPos = touchPos;
            }
        }
    }
}
