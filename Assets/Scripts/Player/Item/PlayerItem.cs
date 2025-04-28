using UnityEngine;

public class PlayerItem : MonoBehaviour
{
    private string name;
    private string spriteIcon;

    public PlayerItem(string name, string spriteIcon)
    {
        this.name = name;
        this.spriteIcon = spriteIcon;
    }

    public string Name { get => name; set => name = value; }
    public string SpriteIcon { get => spriteIcon; set => spriteIcon = value; }
    public string Name1 { get => name;}

    // Định nghĩa Equals và GetHashCode để Dictionary hoạt động chính xác
    public override bool Equals(object obj)
    {
        if (obj is PlayerItem otherItem)
        {
            return name == otherItem.Name;
        }
        return false;
    }

    public override int GetHashCode()
    {
        return name.GetHashCode();
    }
}
