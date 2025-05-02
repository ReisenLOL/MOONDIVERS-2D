using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SpellListUI : MonoBehaviour
{
    public List<Spell> spellListToDisplay = new();
    public PlayerSpellHandler spellHandler;
    public GameObject TemplateSpellUI;

    private void Start()
    {
        spellHandler = FindFirstObjectByType<PlayerSpellHandler>();
        spellListToDisplay = spellHandler.spellsToAdd;
        foreach (Spell spell in spellListToDisplay)
        {
            AddSpellToDisplay(spell);
        }
    }
    private void AddSpellToDisplay(Spell spell)
    {
        GameObject newSpellUI = Instantiate(TemplateSpellUI, transform);
        newSpellUI.transform.Find("SpellNameLabel").GetComponent<TextMeshProUGUI>().text = spell.spellName;
        string newInputDisplay = "";
        for (int i = 0; i < spell.inputCode.Count; i++)
        {
            newInputDisplay += spell.inputCode[i].ToString();
        }
        newSpellUI.transform.Find("SpellInputLabel").GetComponent<TextMeshProUGUI>().text = newInputDisplay;
        newSpellUI.SetActive(true);
    }
}
