using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlayer : MonoBehaviour
{
    public enum RotateMode
    {
        X = 0,
        Y = 1
    }
    public RotateMode mode= RotateMode.X;
    public float horSpeed = 5.0f;
    public float vertSpeed = 5.0f;
    public float minVertical = -50.0f;
    public float maxVertical = 50.0f;
    
    private float vertical = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (mode == RotateMode.X)
        {
            transform.Rotate(0, Input.GetAxis("Mouse X") * horSpeed, 0);
        }
        else
        {
            float horizontal = transform.localEulerAngles.y;
            vertical -= vertSpeed * Input.GetAxis("Mouse Y");
            vertical = Mathf.Clamp(vertical, minVertical, maxVertical);
            transform.localEulerAngles = new Vector3(vertical, horizontal, 0);
        }  
    }
}
