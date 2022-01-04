using UnityEngine;

[CreateAssetMenu(fileName = "New Sword")]
public class Sword : ScriptableObject
{
    public int num;
    public Sprite sprite;
    public float damageAmount;
    public float pushForce;
    Damage dmg;

    public Damage GetDamage()
    {
        if (dmg.damageAmount == 0)
        {
            dmg.damageAmount = damageAmount;
            dmg.pushForce = pushForce;
        }
        return dmg;
    }
}
