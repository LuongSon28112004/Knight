using System;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public static CoinManager Instance { get; private set; }

    private int coinCount;

    public int CoinCount => coinCount; // sửa lại để lấy đúng giá trị

    public event Action<int> OnCoinCountChanged; // event coin thay đổi

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        LoadCountCoin();
    }

    private void LoadCountCoin()
    {
        coinCount = PlayerPrefs.GetInt("CoinCount", 0);
        Debug.Log("Coins: " + CoinCount);
        OnCoinCountChanged?.Invoke(coinCount); // cũng nên invoke ở đây
    }

    public void AddCoin(int amount)
    {
        coinCount += amount;
        PlayerPrefs.SetInt("CoinCount", coinCount);
        Debug.Log("Coins: " + CoinCount);
        OnCoinCountChanged?.Invoke(coinCount); // gọi sự kiện mỗi lần thay đổi
    }

    public void RemoveCoin(int amount)
    {
        coinCount -= amount;
        PlayerPrefs.SetInt("CoinCount", coinCount);
        Debug.Log("Coins: " + CoinCount);
        OnCoinCountChanged?.Invoke(coinCount); // gọi sự kiện mỗi lần thay đổi
    }
}
