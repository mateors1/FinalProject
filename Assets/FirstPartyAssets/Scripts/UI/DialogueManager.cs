using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public Image actorImage;
    public TextMeshProUGUI actorName;
    public TextMeshProUGUI messageText;
    public RectTransform backgroundBox;

    Message[] currentMessages;
    Actor[] currentActors;
    int activeMessage = 0;
    private bool startConversation = false;
    public GameObject dialogueBox;

    public void OpenDialogue(Message[] messages, Actor[] actors)
    {
        currentActors = actors;
        currentMessages = messages;
        activeMessage = 0;
        startConversation = true;

        DisplayMessage();
    }

    void DisplayMessage()
    {
        Message messageToDisplay = currentMessages[activeMessage];
        messageText.text = messageToDisplay.message;

        Actor actorToDisplay = currentActors[messageToDisplay.actorId];
        actorName.text = actorToDisplay.name;
        actorImage.sprite = actorToDisplay.sprite;
    }

    public void NextMessage()
    {
        activeMessage++;
        if(activeMessage < currentMessages.Length)
        {
            DisplayMessage();
        }
        else
        {
            Debug.Log("Conversation ended");
            startConversation = false;
            dialogueBox.SetActive(false);
        }
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(1) && startConversation == true)
        {
            NextMessage();
        }
    }
}

