using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Keypad : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI Ans;
    [SerializeField] private Animator Door;
    private bool ItsAtDoor = false;
    public GameObject CodePanel;

    private string Answer = "3295";


    public void Number(int number)
    {
        Ans.text += number.ToString();
    }

    public void Intro()
    {
        if (Ans.text == Answer)
        {
            Ans.text = "Correct";
            Door.SetBool("Open", true);
            StartCoroutine("StopDoor");
        }
        else
        {
            Ans.text = "Invalid";
        }
    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.E) && ItsAtDoor == true)
        {
            CodePanel.SetActive(true);
        }

   
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            ItsAtDoor = true;
        }
        Cursor.lockState = CursorLockMode.None;
    }

    private void OnTriggerExit(Collider other)
    {
        ItsAtDoor = false;
        CodePanel.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
    }

    IEnumerator StopDoor()
    {
        yield return new WaitForSeconds(0.5f);
        Door.SetBool("Open", false);
        Door.enabled = false;
    }

    public void Clear()
    {
        Ans.text = "";
    }
}
