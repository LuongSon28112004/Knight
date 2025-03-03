using TMPro;
using UnityEngine;

public abstract class BaseText : ModelMonoBehaviour
{
    [Header("Base Text")]
    [SerializeField] protected TextMeshProUGUI text;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadText();
    }

    protected virtual void LoadText()
    {
        if (this.text != null) return;
        this.text = GetComponent<TextMeshProUGUI>();
        Debug.Log(transform.name + "Load success" + "Load Text" + gameObject.name + "");
    }
}
