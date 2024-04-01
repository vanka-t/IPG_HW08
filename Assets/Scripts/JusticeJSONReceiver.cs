using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class JusticeJSONReceiver
{
    public Result[] results;
   
}


[System.Serializable]
public class Result
{
    public string body;
    public int date;
    public string title;


}
