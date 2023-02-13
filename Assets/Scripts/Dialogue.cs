using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TMPro.TMP_Text dialogueText;
    [SerializeField, TextArea(4, 6)] private string[] dialogueLines;
    private float typingTime = 0.05f;
    private bool isPlayerInRange;
    private bool didDialogueStart;
    private int lineInDex;
    void Update()
    {
        //para empezar y pasar dialogos
        if (isPlayerInRange && Input.GetKey(KeyCode.E))
        {
            if (!didDialogueStart)
            {
                StartDialogue();
            }
            else if (dialogueText.text == dialogueLines[lineInDex])
            {
                NextDialogueLine();
            }
            else
            {
                StopAllCoroutines();
                dialogueText.text = dialogueLines[lineInDex];
            }
        }
    }
    private void StartDialogue()
    //esto determina cuando puede empezar el dialogo
    {
        didDialogueStart = true;
        dialoguePanel.SetActive(true);
        lineInDex = 0;
        Time.timeScale = 0;
        StartCoroutine(ShowLine());
    }
    private void NextDialogueLine()
    {
        lineInDex++;
        if (lineInDex < dialogueLines.Length)
        {
            StartCoroutine(ShowLine());
        }
        else
        {
            didDialogueStart = false;
            dialoguePanel.SetActive(false);
            Time.timeScale = 1;
        }
    }
    private IEnumerator ShowLine()
    {
        dialogueText.text = string.Empty;

        foreach (char ch in dialogueLines[lineInDex])
        {
            dialogueText.text += ch;
            yield return new WaitForSecondsRealtime(typingTime);
        }
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerInRange = true;
        }
    }
    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerInRange = false;
        }
    }
}
