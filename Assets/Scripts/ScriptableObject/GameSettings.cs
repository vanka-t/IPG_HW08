
using UnityEngine;

[CreateAssetMenu (fileName = "GameSettings",
    menuName = "ScriptableObjects/GameSettings",
    order = 1)]

public class GameSettings : ScriptableObject
{
    public float gameTimer = 0;
    public int selectedIndex = 1;

    //u can use this on inspector (3 dotted icon > Reset)
    public void Reset()
    {
        //resetting to default value
        selectedIndex = -1;
        gameTimer = -99;

    }

}
