using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HelixRotator : MonoBehaviour
{
    public float rotationSpeed;
    private void Update()
    {
        #if UNITY_EDITOR
        if(Input.GetMouseButton(0))
        {
            float mouseX = Input.GetAxisRaw("Mouse X");
            transform.Rotate(transform.position.x,-mouseX * rotationSpeed * Time.deltaTime, transform.position.z);
        }
        #elif UNITY_ANDROID
        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
                float xDeltaPos = Input.GetTouch(0).deltaPosition.x;
                transform.Rotate(transform.position.x,-xDeltaPos * rotationSpeed * Time.deltaTime, transform.position.z);

        }
        #endif
    }


    
}
