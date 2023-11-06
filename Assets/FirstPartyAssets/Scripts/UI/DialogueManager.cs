using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Cinemachine;
using UnityEditor.Rendering;

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

    public GameObject cameraA, cameraB;

    public void OpenDialogue(Message[] messages, Actor[] actors)
    {
        //DialogueCamera();
        currentActors = actors;
        currentMessages = messages;
        StartCoroutine(StartDialogue());
    }

    private IEnumerator StartDialogue()
    {
        yield return new WaitForSeconds(0.2f);
        activeMessage = 0;
        startConversation = true;
        Time.timeScale = 0.0f;
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
            //ThirdPersonCamera();
            Time.timeScale = 1.0f;

        }
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(1) && startConversation == true)
        {
            NextMessage();
        }
    }

    public void DialogueCamera()
    {
        cameraA.SetActive(false);
        cameraB.SetActive(true);
    }

    public void ThirdPersonCamera()
    {
        cameraA.SetActive(true);
        cameraB.SetActive(false);
    }

}

