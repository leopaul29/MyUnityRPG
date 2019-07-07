using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    // UI panel variables
    public GameObject dialoguePanelUI;
    Button continueButton;
    Text dialogueText, nameText;
    int dialogueIndex;

    public string npcName;
    public List<string> dialogueLines = new List<string>();

    #region Singleton
    public static DialogueManager instance;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of DialogueManager found !");
            return;
        }
        instance = this;
    }
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        //continueButton = dialoguePanelUI.GetComponentInChildren<Button>();
        continueButton = dialoguePanelUI.transform.Find("ContinueButton").GetComponent<Button>();
        dialogueText = dialoguePanelUI.transform.Find("DialogueText").GetComponent<Text>();
        nameText = dialoguePanelUI.transform.Find("CharacterName").GetChild(0).GetComponent<Text>();

        dialoguePanelUI.SetActive(false);
    }

    public void AddNewDialogue(string npcName, string[] lines)
    {
        this.npcName = npcName;

        dialogueIndex = 0;
        dialogueLines = new List<string>(lines.Length);
        dialogueLines.AddRange(lines);

        Debug.Log("dialogueLines:"+dialogueLines.Count);
        CreateDialogue();
    }

    /*
     * First display of the dialogue
     */
    public void CreateDialogue()
    {
        dialogueText.text = dialogueLines[dialogueIndex];
        nameText.text = npcName;

        dialoguePanelUI.SetActive(true);
    }
    
    public void OnContinueButton()
    {
        if (dialogueIndex <dialogueLines.Count-1)
        {
            dialogueIndex++;
            dialogueText.text = dialogueLines[dialogueIndex];
        }
        else
        {
            dialoguePanelUI.SetActive(false);
        }


    }
}
