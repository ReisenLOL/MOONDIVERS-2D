using System.Collections.Generic;
using UnityEngine;

public class Spell : MonoBehaviour
{
    public SpellListUI spellListUI;
    public Sprite icon;
    public string spellName;
    public List<KeyCode> inputCode = new();
    public float cooldown;
    public float cooldownTime;
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
        if (cooldownTime > 0)
        {
            cooldownTime -= Time.deltaTime;
        }
        if (playerIsCasting)
        {
            if (Input.anyKeyDown)
            {
                if (Input.GetKeyDown(inputCode[currentIndex]))
                {
                    for (int i = 0; i < spellListUI.spellInputList.Count; i++)
                    {
                        if (spellListUI.spellInputList[i].text[0] == inputCode[currentIndex].ToString()[0])
                        {
                            string changeInputText = spellListUI.spellInputList[i].text.Substring(1);
                            spellListUI.spellInputList[i].text = changeInputText;
                        }
                    }
                    currentIndex++;
                    if (currentIndex >= inputCode.Count)
                    {
                        spellListUI.ResetSpellInputText();
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
                Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);
                spellLocation = worldPos;
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
                    hasChosenLocation = false;
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
