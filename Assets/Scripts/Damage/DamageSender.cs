using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract  class DamageSender : ModelMonoBehaviour
{
     // Amount damge to send
    [SerializeField] protected int amount;

    [SerializeField] protected DamageReceiver damageReceiver;

    protected abstract void InitialAmountDamage(); // Initial amount damage to send

    public void SendDamage(Transform obj)
    {
        damageReceiver = obj.GetComponentInChildren<DamageReceiver>();
        if (damageReceiver == null)
        {
            Debug.LogWarning("None");
            return;
        } 
        SendDamge(damageReceiver);
    }

    public void SendDamge(DamageReceiver damgeReceiver)
    {
        damgeReceiver.Deduct(amount);
    }
}
