using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DamageReceiver  : ModelMonoBehaviour
{
    [SerializeField] protected int CurrentHP ;
    [SerializeField] protected int MaxHP;
    [SerializeField] protected bool IsDead;

    // Player is being hit
    [SerializeField] protected bool IsBeingHit ;

    public bool Add(int amount)
    {
        if (IsDead) return false;

        CurrentHP += amount;

        if (CurrentHP > MaxHP)
        {
            CurrentHP = MaxHP;
            return false;
        }

        return true;
    }

    public void Deduct(int amount)
    {
        if (IsDead || IsBeingHit) return;

        CurrentHP -= amount;

        Debug.Log("damage Deduct from " + transform.parent.name);

        if (CurrentHP <= 0)
        {
            CurrentHP = 0;
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
