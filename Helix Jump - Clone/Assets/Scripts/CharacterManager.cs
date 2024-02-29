using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Input = UnityEngine.Windows.Input;

namespace DefaultNamespace
{
    public class CharacterManager : MonoBehaviour
    {
        public CharacterDataBase characterDB;
        public TextMeshProUGUI nameText;

        private int selectedOption = 0;

        private void Start()
        {
           // UpdateCharacter(selectedOption);
            
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
            Character character = characterDB.GetCharacter(selectedOption);
            nameText.text = character.CharacterName;
            character.CharacterMaterial.SetActive(true);
            Instantiate(character.CharacterMaterial);
        }

        private void DeleteCharacter(int selectedOption)
        {
            Character character = characterDB.GetCharacter(selectedOption);
            character.CharacterMaterial.SetActive(false);
        }
    }
}