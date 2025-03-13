using System.Linq;
using UnityEngine;

public class HeartBarManager : ModelMonoBehaviour
{
    [SerializeField]
    private GameObject[] hearts;

    [SerializeField]
    private PlayerDamagerReceiver playerDamagerReceiver;

    protected override void Awake()
    {
        base.Awake();
        hearts = GameObject
            .FindGameObjectsWithTag("HeartPlayer")
            .OrderBy(heart => heart.name)
            .ToArray();
        playerDamagerReceiver = GameObject
            .Find("Player")
            .GetComponentInChildren<PlayerDamagerReceiver>();
    }

    void Update()
    {
        this.setActiveHearts();
        this.setInActiveHearts();
    }

    private void setActiveHearts()
    {
        for (int i = 0; i < playerDamagerReceiver.CurrentHP; i++)
        {
            hearts[i].SetActive(true);
        }
    }

    private void setInActiveHearts()
    {
        for (int i = playerDamagerReceiver.CurrentHP; i < playerDamagerReceiver.MaxHP; i++)
        {
            hearts[i].SetActive(false);
        }
    }
}
