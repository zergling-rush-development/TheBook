using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Control Script/FPS Input")]
public class FPSInput : MonoBehaviour
{
    // Start is called before the first frame update

    
    private CharacterController charController;
    public float speed = 6.0f;
    public float gravity = -9.8f;
    public bool relativeToWorld = true;
    void Start()
    {
        charController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float deltaX = Input.GetAxis("Horizontal") * speed;
        float deltaZ = Input.GetAxis("Vertical") * speed;
        
        Vector3 movement = new Vector3(deltaX, 0, deltaZ);

        //gravity
        movement.y = gravity;

        // limit speed for diagonal move
        movement = Vector3.ClampMagnitude(movement, speed);
        movement *=Time.deltaTime;
        //tranform movement from Local to Global coordinates
        movement = transform.TransformDirection(movement);
        
        charController.Move(movement);

    }
}
