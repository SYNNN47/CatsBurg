using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float FollowSpeed = 2f;
    public Transform target;
    public Transform background; // Latar belakang
    public float backgroundParallax = 0.5f; // Efek paralaks untuk latar belakang
    public float yOffset = 1f;

    // Update is called once per frame
    void Update()
    {
        // Gerakan kamera mengikuti target
        Vector3 newPos = new Vector3(target.position.x, target.position.y + yOffset, -10f);
        transform.position = Vector3.Slerp(transform.position, newPos, FollowSpeed * Time.deltaTime);

        // Gerakan latar belakang dengan efek paralaks
        if (background != null)
        {
            Vector3 backgroundPos = new Vector3(target.position.x * backgroundParallax, target.position.y * backgroundParallax, background.position.z);
            background.position = Vector3.Lerp(background.position, backgroundPos, FollowSpeed * Time.deltaTime);
        }
    }
}
