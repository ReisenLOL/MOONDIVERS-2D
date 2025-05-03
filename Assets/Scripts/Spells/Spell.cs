using System.Collections.Generic;
using UnityEngine;

public class Spell : MonoBehaviour
{
    public SpellListUI spellListUI;
    public Sprite icon;
    public string spellName;
    public List<KeyCode> inputCode = new();
    public float cooldown;
    public float castingTime;
    public float castingTimeElapsed = 0;
    public bool playerIsCasting;
    private int currentIndex = 0;
    public bool thisSpellIsCasting;
    public Vector2 spellLocation;
    public bool hasChosenLocation;

    protected virtual void Start()
    {
        spellListUI = FindFirstObjectByType<SpellListUI>();
    }
    protected virtual void Update()
    {
        if (playerIsCasting)
        {
            if (Input.anyKeyDown)
            {
                if (Input.GetKeyDown(inputCode[currentIndex]))
                {
                    currentIndex++;
                    if (currentIndex >= inputCode.Count)
                    {
                        startCastingSpell();
                        currentIndex = 0;
                    }
                }
                else
                {
                    currentIndex = 0;
                }
            }
        }
        if (thisSpellIsCasting)
        {
            if (!hasChosenLocation && Input.GetMouseButton(0))
            {
                Vector3 mousePos = Input.mousePosition;
                mousePos.z = Camera.main.nearClipPlane + 10;
                spellLocation = Camera.main.ScreenToWorldPoint(mousePos);
                hasChosenLocation = true;
            }
            if (!hasChosenLocation && Input.GetKeyUp(KeyCode.LeftControl))
            {
                thisSpellIsCasting = false;
            }
            if (hasChosenLocation)
            {
                castingTimeElapsed += Time.deltaTime;
                if (castingTimeElapsed > castingTime)
                {
                    CastSpell();
                    castingTimeElapsed = 0;
                    thisSpellIsCasting = false;
                }
            }
        }
    }
    protected virtual void startCastingSpell()
    {
        thisSpellIsCasting = true;
    }
    protected virtual void CastSpell()
    {
        Debug.Log("Casted Spell: " + spellName + " at " + spellLocation);
    }
}
