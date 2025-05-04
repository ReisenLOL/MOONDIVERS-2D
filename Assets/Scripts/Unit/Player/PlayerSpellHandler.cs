using System.Collections.Generic;
using UnityEngine;

public class PlayerSpellHandler : MonoBehaviour
{
    public List<Spell> spellsToAdd;
    public List<Spell> spellList;
    public PlayerController player;
    public GameObject spellListUI;
    public SpellListUI spellListHandler;
    void Start()
    {
        for (int i = 0; i < spellsToAdd.Count; i++)
        {
            Spell newSpell = Instantiate(spellsToAdd[i], transform);
            spellList.Add(newSpell);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            foreach (Spell spell in spellList)
            {
                spell.playerIsCasting = true;
            }
            Weapon[] weaponList = FindObjectsByType<Weapon>(FindObjectsSortMode.None);
            foreach (Weapon weapon in weaponList)
            {
                weapon.canFire = false;
            }
            player.rb.linearVelocity = Vector2.zero;
            player.isInputtingSpell = true;
            spellListUI.SetActive(true);
        }
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            spellListHandler.ResetSpellInputText();
            foreach (Spell spell in spellList)
            {
                spell.playerIsCasting = false;
            }
            Weapon[] weaponList = FindObjectsByType<Weapon>(FindObjectsSortMode.None);
            foreach (Weapon weapon in weaponList)
            {
                weapon.canFire = true;
            }
            player.isInputtingSpell = false;
            spellListUI.SetActive(false);
        }
    }
}
