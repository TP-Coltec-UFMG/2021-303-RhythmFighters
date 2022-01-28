using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollowSmooth : MonoBehaviour
{
    [SerializeField]
    private Camera affectedCamera;
    [SerializeField]
    private Transform cameraArm, focus1, focus2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        FixedCameraFollowSmooth(cameraArm, affectedCamera, focus1, focus2);
    }


    // Follow Two Transforms with a Fixed-Orientation Camera
    public void FixedCameraFollowSmooth(Transform arm, Camera cam, Transform t1, Transform t2)
    {
        // How many units should we keep from the players
        float zoomFactor = 1f;
        float followTimeDelta = 1.2f;
    
        // Midpoint we're after
        Vector3 midpoint = ((t1.position + Vector3.up * 2.5f) + (t2.position + Vector3.up * 2.5f)) / 2f;
    
        // Distance between objects
        float distance = (t1.position - t2.position).magnitude;
    
        // Move camera a certain distance
        Vector3 cameraDestination = midpoint - arm.forward * Mathf.Clamp(distance,7.0f,11.0f) * zoomFactor;
    
        // Adjust ortho size if we're using one of those
        if (cam.orthographic)
        {
            // The camera's forward vector is irrelevant, only this size will matter
            cam.orthographicSize = distance;
        }
        // You specified to use MoveTowards instead of Slerp
        arm.position = Vector3.Slerp(arm.position, cameraDestination, followTimeDelta);
            
        // Snap when close enough to prevent annoying slerp behavior
        if ((cameraDestination - arm.position).magnitude <= 2.00f)
            arm.position = cameraDestination;
    }
}
