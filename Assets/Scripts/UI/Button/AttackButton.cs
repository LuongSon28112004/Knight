using System;
using UnityEngine;
using UnityEngine.UI;

public class AttackButton : MonoBehaviour
{
    [SerializeField] private Button attackButton;
    public event Action onAttackButtonClicked;

    void Start()
    {
        attackButton = GetComponent<Button>();
        attackButton.onClick.AddListener(() => onAttackButtonClicked?.Invoke());
    }
}
