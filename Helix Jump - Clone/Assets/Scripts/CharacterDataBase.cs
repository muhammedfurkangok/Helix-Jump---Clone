using UnityEngine;
[CreateAssetMenu]
    public class CharacterDataBase: ScriptableObject
    {
        public Character[] character;

        public int CharacterCount
        {
            get
                {
                    return character.Length;
                }
        }

        public Character GetCharacter(int index)
        {
            return character[index];
        }
    }
