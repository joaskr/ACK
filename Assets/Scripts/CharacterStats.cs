using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    [Header("Major stats")]
    public Stat strength; //damage and crit power +1
    public Stat agility; //evasion and crit chance +1%
    public Stat intelligence; //magic resistance and magic damage +1
    public Stat vitality; //health +3

    [Header("Defensive stats")]
    public Stat maxHealth;
    public Stat armor;
    public Stat evasion;


    private int currentHealth;
    public Stat damage;
    // Start is called before the first frame update
    protected virtual void Start()
    {
        currentHealth = maxHealth.GetValue();
    }

    public virtual void DoDamage(CharacterStats _targetStats)
    {
        if (TargetCanAvoidAttack(_targetStats))
            return;

        int totalDamage = damage.GetValue() + strength.GetValue();

        totalDamage = CheckTargetArmor(_targetStats, totalDamage);
        _targetStats.TakeDamage(totalDamage);
    }

    private int CheckTargetArmor(CharacterStats _targetStats, int totalDamage)
    {
        totalDamage -= _targetStats.armor.GetValue();
        totalDamage = Mathf.Clamp(totalDamage, 0, int.MaxValue);
        return totalDamage;
    }

    private bool TargetCanAvoidAttack(CharacterStats _targetStats)
    {
        int totalEvasion = _targetStats.evasion.GetValue() + _targetStats.agility.GetValue();
        if (Random.Range(0, 100) < totalEvasion)
        {
            return true;
        }
        return false;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public virtual void TakeDamage(int _damage)
    {
        currentHealth -= _damage;
        if (currentHealth < 0)
        {
            Die();
        }
    }

    protected virtual void Die()
    {
    }
}
