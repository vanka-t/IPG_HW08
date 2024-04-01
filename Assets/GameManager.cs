using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ChatGPTWrapper;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; //making it a singleton
    [SerializeField]
    ChatGPTConversation chatGPT;

    //UI Elements
    [SerializeField]
    TMP_InputField iF_PlayerTalk;
    [SerializeField]
    TextMeshProUGUI tX_AIReply;
    [SerializeField]
    NPCController npc;

    string npcName = "NAme";
    string playerName = "Vanessa";


    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        chatGPT.Init();
    }

    private void Start()
    {
        chatGPT.SendToChatGPT("{\"player_said\":"+ "\"Hello! Who are you?\"}");
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonUp("Submit"))
        {
            SubmitChatMessage();
        }
    }


    //callback function from AI server
    public void ReceiveChatGPTReply(string message)
    {
        //print(message);
        try
        {
           

            ///remoing dumb errors:
            /// case 1 : "{message response} This is my response" --> cuts out the setnece at the end
            /// case 2 : "{message response" ---> adds curly bracket when its missing
            if (!message.EndsWith("}"))
            {
                if (message.Contains("}")) //case 1
                {
                    message = message.Substring(0, message.LastIndexOf("}") + 1);
                }
                else //case 2
                {
                    message += "}";
                }
            }
            //replace \ to \\ so that unity can read it without getting confused
            message = message.Replace("\\", "\\\\");

            NPCJSONReceiver npcJSON = JsonUtility.FromJson<NPCJSONReceiver>(message);
            string talkLine = npcJSON.reply_to_player;
            tX_AIReply.text = "<color=#0000FF>" + npcName + ": </color>" + talkLine;
            npc.ShowAnimation(npcJSON.animation_name);
        }
        catch (System.Exception e) //in case of error in input
        {
            Debug.Log(e.Message);
            string talkLine = "Don't say that :<";
            tX_AIReply.text = "<color=#0000FF>" + npcName + ": </color>" + talkLine;
            

        }
   
    }

    //submitting ms to OpenAI Server
    public void SubmitChatMessage()
    {
        if(iF_PlayerTalk.text != "")
        {
            Debug.Log("Message sent: " + iF_PlayerTalk.text);
            chatGPT.SendToChatGPT("{\"player_said\":\"" + iF_PlayerTalk.text + "\"}");
            ClearText();
        }
    }

    //Reset text after submit
    void ClearText()
    {
        iF_PlayerTalk.text = "";

    }
}
