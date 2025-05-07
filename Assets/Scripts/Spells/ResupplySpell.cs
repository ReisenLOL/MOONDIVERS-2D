using UnityEngine;

public class ResupplySpell : Spell
{
    public GameObject AmmoCrate;
    protected override void CastSpell()
    {
        base.CastSpell();
        GameObject newAmmoCrate = Instantiate(AmmoCrate);
        newAmmoCrate.transform.position = spellLocation;
    }
}
