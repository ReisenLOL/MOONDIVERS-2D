using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ObjectiveInteractable : MonoBehaviour
{
    public GameObject displayInteractionKey;
    public bool playerInRange = false;
    public bool isBeingInteractedWith = false;
    public TextMeshProUGUI inputDisplay;
    public KeyCode interactionKey;
    public List<KeyCode> keycodeCombinations = new();
    public int currentIndex = 0;
    protected virtual void Start()
    {
        ResetInputDisplay(keycodeCombinations, inputDisplay);
    }
    protected virtual void Update()
    {
        if (playerInRange)
        {
            if (Input.GetKeyDown(interactionKey))
            {
                displayInteractionKey.SetActive(false);
                ProcessInteraction();
                isBeingInteractedWith = true;
            }
            if (isBeingInteractedWith && (Input.GetKeyDown(KeyCode.Escape) || Input.GetMouseButtonDown(1)))
            {
                displayInteractionKey.SetActive(true);
                inputDisplay.gameObject.SetActive(false);
                isBeingInteractedWith = false;
            }
            if (isBeingInteractedWith)
            {
                if (Input.anyKeyDown)
                {
                    if (Input.GetKeyDown(keycodeCombinations[currentIndex]))
                    {
                        if (inputDisplay.text != null && inputDisplay.text[0] == keycodeCombinations[currentIndex].ToString()[0])
                        {
                            string changeInputText = inputDisplay.text.Substring(1);
                            inputDisplay.text = changeInputText;
                            //i'm so good at this...
                        }
                        currentIndex++;
                        if (currentIndex >= keycodeCombinations.Count)
                        {
                            Debug.Log("congrats");
                        }
                    }
                    else
                    {
                        currentIndex = 0;
                        ResetInputDisplay(keycodeCombinations, inputDisplay);
                        Debug.Log("loser");
                    }
                }
            }
        }
    }
    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        displayInteractionKey.SetActive(true);
        playerInRange = true;
    }
    protected virtual void OnTriggerExit2D(Collider2D other)
    {
        displayInteractionKey.SetActive(false);
        playerInRange = false;
    }
    protected virtual void ProcessInteraction()
    {
        inputDisplay.gameObject.SetActive(true);
    }    
    protected virtual void ResetInputDisplay(List<KeyCode> keyCodesToDisplay, TextMeshProUGUI inputUI)
    {
        string newInputText = "";
        for (int i = 0; i < keyCodesToDisplay.Count; i++)
        {
            newInputText += keyCodesToDisplay[i].ToString();
        }
        inputUI.text = newInputText;
    }
}
