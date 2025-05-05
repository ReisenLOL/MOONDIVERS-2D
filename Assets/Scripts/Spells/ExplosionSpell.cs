using UnityEngine;

public class ExplosionSpell : Spell
{
    public float blastRadius;
    public LayerMask unitLayer;
    public float blastDamage;
    public GameObject explosionVisual;
    private Collider2D[] DetectUnits(Vector2 location, float radius)
    {
        return Physics2D.OverlapCircleAll(location, radius, unitLayer);
    }
    protected override void CastSpell()
    {
        base.CastSpell();
        Collider2D[] unitList = DetectUnits(spellLocation, blastRadius);
        foreach (Collider2D unit in unitList)
        {
            //unit.GetComponent<Unit>().TakeDamage(blastDamage);
            Debug.Log(unit);
        }
        GameObject newExplosionVisual = Instantiate(explosionVisual);
        newExplosionVisual.transform.position = spellLocation;
    }
}
