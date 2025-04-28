using System.Collections;
using UnityEngine;

public class BuyButton : BaseButton
{
    [SerializeField] private GameObject Success;
    [SerializeField] private GameObject Fail; // Reference to the failure message
    protected override void OnClick()
    {
        int totalCoins = QuantityAppleController.Instance.Quantity * 10; // Assuming each apple costs 10 coins
        if (CoinManager.Instance.CoinCount >= totalCoins)
        {
            CoinManager.Instance.RemoveCoin(totalCoins); // Deduct coins from the player
            PlayerInventory.Instance.AddPlayerItem(new PlayerItem("Apple", "none"), totalCoins / 10); // Add apples to the inventory
            PlayerPrefs.SetInt("Apple", PlayerInventory.Instance.PlayerItems[new PlayerItem("Apple", "none")]); // Save the quantity of apples in PlayerPrefs
            StartCoroutine(showSuccessMessage()); // Show success message
        }
        else
        {
            Debug.Log("Not enough coins!"); // Not enough coins message
            Fail.SetActive(true); // Show failure message
            StartCoroutine(showFailMessage()); // Show failure message
        }
    }

    IEnumerator showSuccessMessage()
    {
        Success.SetActive(true); // Show success message
        yield return new WaitForSeconds(2f); // Wait for 2 seconds
        Success.SetActive(false); // Hide success message
    }

    IEnumerator showFailMessage()
    {
        Fail.SetActive(true); // Show failure message
        yield return new WaitForSeconds(2f); // Wait for 2 seconds
        Fail.SetActive(false); // Hide failure message
    }
}
