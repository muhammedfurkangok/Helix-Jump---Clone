﻿using TMPro;
using UnityEngine ;
using UnityEngine.UI ;

public class LevelProgressUI : MonoBehaviour {

   [Header ("UI references :")]
   [SerializeField] private Image uiFillImage ;
   [SerializeField] private TextMeshProUGUI uiStartText ;
   [SerializeField] private TextMeshProUGUI uiEndText ;

   [Header ("Player & Endline references :")]
   [SerializeField] private Transform playerTransform ;
   
   private Vector3 endLinePosition = new Vector3(0,-100,0) ;
   
   private float fullDistance = -100f;




   private void Start () {
      fullDistance = GetDistance() ;
   }


   public void SetLevelTexts (int level) {
      uiStartText.text = level.ToString () ;
      uiEndText.text = (level + 1).ToString () ;
   }


   private float GetDistance () {
    return Vector3.Distance (playerTransform.position, endLinePosition) ;
   }


   private void UpdateProgressFill (float value) {
      uiFillImage.fillAmount = value ;
   }


   private void Update () {
      // check if the player doesn't pass the End Line
      if (playerTransform.position.z <= endLinePosition.z) {
         float newDistance = GetDistance () ;
         float progressValue = Mathf.InverseLerp (fullDistance, 0f, newDistance) ;

         UpdateProgressFill (progressValue) ;
      }
   }

   /*
      Mathf.InverseLerp (fullDistance, 0f, newDistance) ;

      InverseLerp( min , max , v ) : always returns a value between 0 & 1

      v is between min and max, 
         if v is close to min InverseLerp returns a number closed to 0 
         if v is close to max InverseLerp returns a number closed to 1 



      Example ( min = 0  , max = 50 ) :

         InverseLerp( min , max , 0 )  =>  0
         InverseLerp( min , max , 50 )  =>  1
         InverseLerp( min , max , 25 )  =>  0.5
         InverseLerp( min , max , -10 )  =>  0
         InverseLerp( min , max , 250 )  =>  1
         InverseLerp( min , max , 55 )  =>  1
         InverseLerp( min , max , 10 )  =>  (10-min)/(max-min) => 0.2
         ...
         ...

   */
}