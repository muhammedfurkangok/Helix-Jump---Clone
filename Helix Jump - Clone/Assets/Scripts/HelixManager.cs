using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class HelixManager : MonoBehaviour
{
    #region Self Veriables

    #region public variables

    public GameObject[] rings;
    
    public int noOfRings = 10;
    public float ringDistance = 5f;

    #region Private Veriables
    
    private float yPos;
    #endregion

    #endregion

    #endregion
    private void Start()
    {
        for (int i = 0; i < noOfRings; i++)
        {
            if (i == 0)
            {
                SpawnRings(0);
            }
            else
            {
                SpawnRings(Random.Range(1, rings.Length -1));
            }
        }
        SpawnRings(rings.Length - 1 );
    }

     void SpawnRings(int index)
    {
        GameObject newRing = Instantiate (rings[index], new Vector3(transform.position.x, yPos, transform.position.z),
            Quaternion.identity);
           yPos -= ringDistance;
           newRing.transform.parent = transform;
    }
}
