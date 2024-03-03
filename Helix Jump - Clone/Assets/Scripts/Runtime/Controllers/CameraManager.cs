using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using Unity.VisualScripting;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public CharacterManager _Character;
    private Transform target;
    public Vector3 offset;
    public float smoothSpeed = 0.04f;
    
    private void Start()
    {
        target = _Character.currentCharacterObject.transform;
        offset = transform.position - target.position;
    }

    private void LateUpdate()
    {
        Vector3 newPos = Vector3.Lerp(transform.position, target.position + offset, smoothSpeed);
        transform.position = newPos;
    }
}
