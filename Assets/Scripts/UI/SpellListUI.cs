using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SpellListUI : MonoBehaviour
{
    public List<Spell> spellListToDisplay = new();
    public PlayerSpellHandler spellHandler;
    public GameObject TemplateSpellUI;
    public Transform objectToInstantiateTo;
    public List<TextMeshProUGUI> spellInputList = new();

    private void Start()
    {
        spellHandler = FindFirstObjectByType<PlayerSpellHandler>();
        spellListToDisplay = spellHandler.spellsToAdd;
        foreach (Spell spell in spellListToDisplay)
        {
            AddSpellToDisplay(spell);
        }
        //objectToInstantiateTo.gameObject.SetActive(false);
    }
    private void AddSpellToDisplay(Spell spell)
    {
        GameObject newSpellUI = Instantiate(TemplateSpellUI, objectToInstantiateTo);
        newSpellUI.transform.Find("SpellNameLabel").GetComponent<TextMeshProUGUI>().text = spell.spellName;
        TextMeshProUGUI spellInputLabel = newSpellUI.transform.Find("SpellInputLabel").GetComponent<TextMeshProUGUI>();
        spell.spellListBlock = spellInputLabel;
        //fix this, this does it to the prefab not the instance.
        spellInputList.Add(spellInputLabel);
        newSpellUI.SetActive(true);
    }
    public void ResetSpellInputText()
    {
        for (int i = 0; i < spellInputList.Count; i++)      
        {
            string newInputDisplay = "";
            for (int j = 0; j < spellListToDisplay[i].inputCode.Count; j++)
            {
                newInputDisplay += spellListToDisplay[i].inputCode[j].ToString();
            }
            spellInputList[i].text = newInputDisplay;
        }
        //this code is REAL bad...
    }
}
