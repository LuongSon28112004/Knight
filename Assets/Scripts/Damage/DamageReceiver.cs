using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DamageReceiver  : ModelMonoBehaviour
{
    [SerializeField] protected int currentHP;
    [SerializeField] protected int maxHP;
    [SerializeField] protected bool IsDead;

    // Player is being hit
    [SerializeField] protected bool IsBeingHit ;

    public int CurrentHP { get => currentHP; }
    public int MaxHP { get => maxHP; }

    public bool Add(int amount)
    {
        if (IsDead) return false;

        currentHP += amount;

        if (currentHP > maxHP)
        {
            currentHP = maxHP;
            return false;
        }

        return true;
    }

    public void Deduct(int amount)
    {
        Debug.Log("yes yes yes");
        if (IsDead || IsBeingHit ) return;

        currentHP -= amount;

        Debug.Log("damage Deduct from " + transform.parent.name);

        if (currentHP <= 0)
        {
            currentHP = 0;
            IsDead = true;
            DeadHandle();
            return;
        }

        IsBeingHit = true;
        HitHandle();
    }

    public void ResetIsBeingHit()
    {
        IsBeingHit = false;
    }

    protected abstract void HitHandle();

    protected abstract void DeadHandle();
}
