using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public GameObject splitPrefab;
    public float bounceForce = 400f;
    private AudioManager audio;
    void Start()
    {
       audio = FindObjectOfType<AudioManager>();
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision other)
    {
        rb.velocity = new Vector3(rb.velocity.x, bounceForce * Time.deltaTime, rb.velocity.z);
             GameObject newSplit = Instantiate(splitPrefab, 
            new Vector3(transform.position.x, other.transform.position.y +0.19f, transform.position.z), transform.rotation);
            audio.Play("Land");
             newSplit.transform.localScale = Vector3.one * Random.Range(0.7f, 1.3f);
             newSplit.transform.parent = other.transform;

             string materialName = other.transform.GetComponent<MeshRenderer> ().material.name;

             if (materialName == "Safe (Instance)")
             {
                 
             }
             if (materialName == "UnSafe (Instance)")
             {
                 GameManager.gameOver = true;
                 audio.Play("GameOver");
             }
             if (materialName == "LastRing (Instance)" && !GameManager.levelWin)
             {
                 GameManager.levelWin = true;
                 audio.Play("LevelWin");
             }

    }
}
