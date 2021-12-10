using UnityEngine;

public class WeaponAttack : MonoBehaviour
{
    [SerializeField] protected Damage selfdDamage;
    protected float characterDamageAmount;
    protected Damage calculateSumDamage()
    {
        Damage sumDamage = new Damage();
        sumDamage.damageAmount = selfdDamage.damageAmount + characterDamageAmount;
        return sumDamage;
    }
    public void setCharacterDamageAmount(float characterDamageAmount)
    {
        this.characterDamageAmount = characterDamageAmount;
    }

    public void setSelfDamage(Damage damage)
    {
        selfdDamage = damage;
    }
}
