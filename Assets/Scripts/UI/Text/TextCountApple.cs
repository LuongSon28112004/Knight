using JetBrains.Annotations;
using UnityEngine;

public class TextCountApple : BaseText
{
    void Update()
    {
        this.updateCountApple();
    }

    private void updateCountApple()
    {
        // PlayerItem item = new PlayerItem("apple",null);
        // int count = PlayerInventory.Instance.PlayerItems[item] == null ? 0 : PlayerInventory.Instance.PlayerItems[item];
        //text.SetText("x"+ count.ToString() );
    }
}
