using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiltControl : MonoBehaviour
{
    private Touch touch;
    private Quaternion rotationX, rotationZ;
    private float tiltSpeedModifier = 0.1f;
    private Rigidbody rb;
    private float maxTiltX = 30f;
    private float maxTiltZ = 30f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // Keep object grounded
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 1.1f))
        {
            if (hit.collider.gameObject.tag == "Terrain")
            {
                transform.position = new Vector3(transform.position.x, hit.point.y, transform.position.z);
            }
        }

        // Tilt object
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            switch (touch.phase)
            {
                case TouchPhase.Moved:

                    // Calculate rotation on X axis
                    float tiltX = -touch.deltaPosition.x * tiltSpeedModifier;
                    tiltX = Mathf.Clamp(tiltX, -maxTiltX, maxTiltX);
                    rotationX = Quaternion.Euler(tiltX, 0f, 0f);

                    // Calculate rotation on Z axis
                    float tiltZ = -touch.deltaPosition.y * tiltSpeedModifier;
                    tiltZ = Mathf.Clamp(tiltZ, -maxTiltZ, maxTiltZ);
                    rotationZ = Quaternion.Euler(0f, 0f, tiltZ);

                    // Apply rotation
                    transform.rotation = rotationX * transform.rotation * rotationZ;

                    break;
            }
        }
    }
}
