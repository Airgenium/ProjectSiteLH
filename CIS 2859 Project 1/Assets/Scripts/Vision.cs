using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Vision : MonoBehaviour
{
    public enum RotationAxes
    {
        MouseXAndY = 0,
        MouseX = 1,
        MouseY= 2,
    }

    [SerializeField]
    private RotationAxes axes = RotationAxes.MouseXAndY;

    [SerializeField]
    private float horizontalSensitivity = 9.0f;

    [SerializeField] 
    private float verticalSensitivity = 9.0f;
    [SerializeField]
    private float minimumVertical = -30.0f;
    [SerializeField]
    private float maximumVertical = 30.0f;

    private float verticalRotation = 0.0f;


    // Update is called once per frame
    void Update()
    {
        if(axes == RotationAxes.MouseX)
        {
            transform.Rotate(0, Input.GetAxis("Mouse X") * horizontalSensitivity, 0);
        }
        else if(axes == RotationAxes.MouseY)
        {
            verticalRotation -= Input.GetAxis("Mouse Y") * verticalSensitivity;
            verticalRotation = Mathf.Clamp(verticalRotation, minimumVertical, 
            maximumVertical);

            float horizontalRotation = transform.localEulerAngles.y;

            transform.localEulerAngles = new Vector3(verticalRotation, 
            horizontalRotation, 0);
        }
        else
        {
            verticalRotation -= Input.GetAxis("Mouse Y") * verticalSensitivity;
            verticalRotation = Mathf.Clamp(verticalRotation, minimumVertical, 
            maximumVertical);

            float delta = Input.GetAxis("Mouse X") * horizontalSensitivity;
            float horizontalRotation = transform.localEulerAngles.y + delta;

            transform.localEulerAngles = new Vector3(verticalRotation, 
            horizontalRotation, 0);
        }
    }
}
