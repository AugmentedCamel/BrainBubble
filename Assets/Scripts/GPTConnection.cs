using System.Collections;
using System.Collections.Generic;
using BitSplash.AI.GPT;
using NaughtyAttributes;
using UnityEngine;

public class GPTConnection : MonoBehaviour
{
    // Start is called before the first frame update
    ChatGPTConversation Conversation;
    public TMPro.TextMeshProUGUI Answer;
    
    
    [Button]
    void enablechatGPt()
    {
        // call ChatGPTConversation.Start to start a conversation at any time
        Conversation = ChatGPTConversation.Start(this)
            .System("Answer as a helpful unity developer") // sets the identity of the chat ai agent
            .MaximumLength(2048); // set the maximum length of tokens per request

        //call Conversation.Say to say something. Make sure not to call it again until you get a response or error
        Conversation.Say("who are you?");
        Answer.text += "Me: who are you?\r\n";
    }

    void OnConversationResponse(string text)
    {
        Debug.Log(text);
    }
    
    void OnConversationError(string error)
    {
        Debug.LogError(error);
    }
}
