using UnityEngine;

public class BackShopButton : BaseButton
{
    [SerializeField] private GameObject shopPanel; // Reference to the shop panel
    [SerializeField] private GameObject MainMenu; // Reference to the main menu

    protected override void OnClick()
    {
        shopPanel.SetActive(false); // Hide the shop panel
        MainMenu.SetActive(true); // Show the main menu
    }
}