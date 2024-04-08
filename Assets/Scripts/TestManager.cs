using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;



public class TestManager : MonoBehaviour
{
    [SerializeField]
    ChatGPTExample example;

    string url1 = "https://jsonplaceholder.typicode.com/todos/1"; //basic
    
    //jsonplaceholder.typicode.com/todos/1

    string url2 = "https://jsonplaceholder.typicode.com/comments";//longer jsons script

    string url3 = "https://www.justice.gov/api/v1/blog_entries.json?amp%3Bpagesize=2"; // departament of justice - blog entries!


   // public static string emailTest;

    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(GetJsonFromUrl(url1, ReceivedJson1));
       StartCoroutine(GetJsonFromUrl(url2, ReceivedJson2));
        //StartCoroutine(GetJsonFromUrl(url3, ReceivedJson3));
    }

    IEnumerator GetJsonFromUrl(string url, System.Action<string> callback)
    {
        //string for json container
        string jsonText;

        //sending web request 
        UnityWebRequest www = UnityWebRequest.Get(url);
        //header for request, lets server know this is a request for json
        www.SetRequestHeader("Content-Type", "application/json");

        yield return www.SendWebRequest(); //yield = ensures function is returned until after receiving response from server (time usually varies so its important to icnlude this)

        //callback function
        if (www.result != UnityWebRequest.Result.Success)
        {
            //error connecting to server
            jsonText = www.error;


        }
        else
        {
            //success
            jsonText = www.downloadHandler.text;
        }

        callback(jsonText);
        www.Dispose();

    }

    //callback function
    public void ReceivedJson1 (string jsonTextReceived)
    {
       // print(jsonTextReceived); //pastes raw json file

        JsonReceiver1 receiver = JsonUtility.FromJson<JsonReceiver1>(jsonTextReceived);
       // print(receiver.userId + "\n" + receiver.title);
        receiver.id += 1;//becomes peoper data from the game instead of one long stream -- separated data basically

    }

    void ReceivedJson2(string jsonTextReceived)
    {
        //consider array within curly brackets...
        jsonTextReceived = "{\"comments\":" + jsonTextReceived + "}";
  
        JsonReceiver2 receiver = JsonUtility.FromJson<JsonReceiver2>(jsonTextReceived);

        Comment[] comments = receiver.comments;

        //foreach(Comment comment in comments)
        //{
        //    print(comment.email + " : " + comment.body);


        //}

       // emailTest = comments[0].email;
        //example.StartChatGPT(); //trigger awake event from chatgpt script
    }

    //void ReceivedJson3(string jsonTextReceived)
    //{
    //   // jsonTextReceived = "{\"results\":" + jsonTextReceived + "}";
    //    JusticeJSONReceiver receiver = JsonUtility.FromJson<JusticeJSONReceiver>(jsonTextReceived);

    //    Result[] results = receiver.results;

    //   foreach (Result result in results)
    //    {
    //        print("In "+  result.date + ", " + result.title + " . Basically..." + result.body);
    //    }


    //}
}
