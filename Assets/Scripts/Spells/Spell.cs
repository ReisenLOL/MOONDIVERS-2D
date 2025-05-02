using System.Collections.Generic;
using UnityEngine;

public class Spell : MonoBehaviour
{
    public Sprite icon;
    public string spellName;
    public List<KeyCode> inputCode = new();
    public float cooldown;
    public float castingTime;
    public float castingTimeElapsed = 0;
    public bool playerIsCasting;
    private int currentIndex = 0;
    public bool thisSpellIsCasting;

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
            castingTimeElapsed += Time.deltaTime;
            if (castingTimeElapsed > castingTime)
            {
                CastSpell();
                castingTimeElapsed = 0;
                thisSpellIsCasting = false;
            }
        }
    }
    protected virtual void startCastingSpell()
    {
        thisSpellIsCasting = true;
    }
    protected virtual void CastSpell()
    {
        Debug.Log("Casted Spell: " + spellName);
    }
}
