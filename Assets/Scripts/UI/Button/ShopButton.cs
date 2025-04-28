using UnityEngine;

public class ButtonShop : BaseButton
{
    [SerializeField] private GameObject shopPanel; // Reference to the shop panel
    [SerializeField] private GameObject MainMenu; // Reference to the shop button
    protected override void OnClick()
    {
        shopPanel.SetActive(true); // Show the shop panel
        MainMenu.SetActive(false); // Hide the main menu
    }
}

