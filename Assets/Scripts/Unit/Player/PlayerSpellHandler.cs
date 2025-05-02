using System.Collections.Generic;
using UnityEngine;

public class PlayerSpellHandler : MonoBehaviour
{
    public List<Spell> spellList;
    public PlayerController player;
    public GameObject spellListUI;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
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
