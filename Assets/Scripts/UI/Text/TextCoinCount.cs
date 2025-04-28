using System;
using UnityEngine;

public class TextCoinApple : BaseText
{
    private void Start() {
        CoinManager.Instance.OnCoinCountChanged += UpdateCoinCount; // Đăng ký sự kiện
        UpdateCoinCount(CoinManager.Instance.CoinCount); // Cập nhật ngay khi bắt đầu
    }

    private void UpdateCoinCount(int coinCount)
    {
        text.SetText(coinCount.ToString());
    }
}
