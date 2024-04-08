
using UnityEngine;


//manually creating asset menu on interface!
[CreateAssetMenu(fileName = " PersonDB", menuName ="ScriptableObject/PersonalityDatabase", order = 1 )] 


public class PersonalityDatabase : ScriptableObject
{
    //actual array for storing character personality
    public Personality[] personalities;
    [System.Serializable]
    public struct Personality
    {
        //name & system prompt for chatGPT
        public string name;

        [TextArea(4,100)] //enlarges the UI for text input on inspector
        public string initialPrompt;
    }
}
