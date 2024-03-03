using System;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Input = UnityEngine.Windows.Input;

namespace DefaultNamespace
{
    public class CharacterManager : MonoBehaviour
    {
        public Vector3 playerSpawnPosition = new(0f, 2.75f, 0f);
        public GameObject currentCharacterObject;
        public CharacterDataBase characterDB;
        public TextMeshProUGUI nameText;
       
       

        private int selectedOption = 0;

        private void Start()
        {
            selectedOption = PlayerPrefs.GetInt(nameof(selectedOption));
            UpdateCharacter(selectedOption);
        }

        public void NextOption()
        {
            selectedOption++;
          
            if (selectedOption >= characterDB.CharacterCount)
            {
                selectedOption = 0;
            }

            UpdateCharacter(selectedOption);
        }

        public void BackOption()
        {
            selectedOption--;
           
            if (selectedOption < 0)
            {
                selectedOption = characterDB.CharacterCount - 1;
            }
            UpdateCharacter(selectedOption);
            
        }
        private void UpdateCharacter(int selectedOption)
        {
            Destroy(currentCharacterObject);
            
            Character character = characterDB.GetCharacter(selectedOption);
            nameText.text = character.CharacterName;
            character.CharacterMaterial.SetActive(true);
            
            currentCharacterObject = Instantiate(character.CharacterMaterial);
            currentCharacterObject.transform.position = playerSpawnPosition;
            
            PlayerPrefs.SetInt(nameof(this.selectedOption), selectedOption);
        }
        
    }
}