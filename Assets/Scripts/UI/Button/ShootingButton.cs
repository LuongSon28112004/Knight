using System;
using UnityEngine;
using UnityEngine.UI;

public class ShootingButton : MonoBehaviour
{
    [SerializeField] private Button button;
    public event Action OnShooting;
    void Start()
    {
        Debug.Log("ShootingButton started.");
        button = GetComponent<Button>();
        button.onClick.AddListener(Shooting);
    }

    private void Shooting()
    {
        if(OnShooting == null)
        {
            Debug.LogWarning("OnShooting event has no subscribers.");
            return;
        }
        Debug.Log("ShootingButton clicked.");       
        OnShooting?.Invoke();
    }
}
