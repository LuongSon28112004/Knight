using UnityEngine;
using UnityEngine.UI;

public abstract class BaseButton : ModelMonoBehaviour
{
    [SerializeField]
    protected Button button;

    protected override void Awake()
    {
        base.Awake();
        this.LoadButton();
        this.addOnClickEvent();
    }

    private void LoadButton()
    {
        button = GetComponent<Button>();
    }

    protected void addOnClickEvent()
    {
        button.onClick.AddListener(OnClick);
    }

    protected abstract void OnClick();
}
