using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ObjectiveInteractable : MonoBehaviour
{
    public GameObject displayInteractionKey;
    public PlayerController playerThatIsInRange;
    public bool playerInRange = false;
    public bool isBeingInteractedWith = false;
    public GameObject inputDisplayUI;
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
                isBeingInteractedWith = true;
                ProcessInteraction();
            }
            if (isBeingInteractedWith && (Input.GetKeyDown(KeyCode.Escape) || Input.GetMouseButtonDown(1)))
            {
                displayInteractionKey.SetActive(true);
                inputDisplayUI.SetActive(false);
                isBeingInteractedWith = false;
            }
            if (isBeingInteractedWith)
            {
                playerThatIsInRange.GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
                if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D)) //what have you done, sylvia...
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
                            ProcessSuccess();
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
        playerThatIsInRange = other.gameObject.GetComponent<PlayerController>();
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
        Debug.Log("INTERACTED");
        inputDisplayUI.SetActive(true);
    }
    protected virtual void ProcessSuccess()
    {
        isBeingInteractedWith = false;
        inputDisplayUI.SetActive(false);
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
