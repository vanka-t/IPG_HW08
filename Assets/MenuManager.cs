using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.SceneManagement;




public class MenuManager : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI tX_Selected;
    [SerializeField]
    PersonalityDatabase personDB;
    [SerializeField]
    ToggleGroup toggleGroup;
    [SerializeField]
    Toggle[] toggles;
    [SerializeField]
    GameSettings gameSettings;




    // Start is called before the first frame update
    void Start()
    {
        //saves data from last time (whichever toggle u picked last)
        gameSettings.gameTimer = PlayerPrefs.GetFloat("GameTimer", 0);
        gameSettings.selectedIndex = PlayerPrefs.GetInt("SelectedIndex", 0);
        print("Selected index: " + personDB.personalities[gameSettings.selectedIndex]);
        tX_Selected.text = "Current selected personality: " + personDB.personalities[gameSettings.selectedIndex].name;

        toggles[gameSettings.selectedIndex].isOn = true;
    }



    public void StartGame()
    {
        //set to default in start of game
        PlayerPrefs.SetFloat("GameTimer", gameSettings.gameTimer);
        PlayerPrefs.SetInt("SelectedIndex", gameSettings.selectedIndex);

        SceneManager.LoadScene("GameState");
    }

    public void OnValueChanged()
    {
        //get the activated toggle component
        var currentToggle = toggleGroup.ActiveToggles().FirstOrDefault();


        //loop through all  the toggles, find out the current selected toggle
        // get index for activated toggle based on currentToggle
        int currentSelectedIndex = 0;
        for (int i = 0; i< toggles.Length; i++)
        {
            if(currentToggle == toggles[i])
            {
                currentSelectedIndex = i;
                break;
            }
        }

        //assign the index to the game setting
        tX_Selected.text = "Current selected personality: " + personDB.personalities[currentSelectedIndex].name;


        gameSettings.selectedIndex = currentSelectedIndex;
         
    }
}
