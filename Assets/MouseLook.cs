using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    // Start is called before the first frame update
    public float sensitivityHor = 9.0f;
    public float sensitivityVert = 9.0f;

    public float minimumVert = -15.0f;
    public float maximumVert = 15.0f;

    private float verticalRot = 0;

    public enum RotationAxes {
        MouseXAndY = 0,
        MouseX =1,
        MouseY=2
    }


    public RotationAxes axes = RotationAxes.MouseXAndY;


    void Start()
    {
        Rigidbody body = GetComponent<Rigidbody>();
        if(body != null){
            body.freezeRotation = true;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if(axes == RotationAxes.MouseX){
            //horizontal rotation
            transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityHor, 0);
        }

        else if(axes == RotationAxes.MouseY){
            //vertical rotation       
            //transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityHor, 0);
            verticalRot -= Input.GetAxis("Mouse Y") * sensitivityVert;
            verticalRot = Mathf.Clamp(verticalRot, minimumVert, maximumVert);

            float horizontalRot = transform.localEulerAngles.y;

            transform.localEulerAngles = new Vector3(verticalRot, horizontalRot, 0);

        }else{
            //both horizontal and vertical rotation here
             //transform.Rotate( Input.GetAxis("Mouse Y") * sensitivityHor, Input.GetAxis("Mouse X") * sensitivityHor, 0);

            verticalRot -= Input.GetAxis("Mouse Y") * sensitivityVert;
            verticalRot = Mathf.Clamp(verticalRot, minimumVert, maximumVert);

            float delta = Input.GetAxis("Mouse X") * sensitivityHor;
            float horizontalRot = transform.localEulerAngles.y + delta;

            transform.localEulerAngles = new Vector3(verticalRot, horizontalRot, 0);
        }        
    }
}
