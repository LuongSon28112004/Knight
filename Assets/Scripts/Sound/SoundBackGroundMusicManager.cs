using UnityEngine;

public class SoundBackGroundMusicManager : SoundManager
{
    public static SoundBackGroundMusicManager Instance { get; private set; }

    private new void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        base.Awake();

        //DontDestroyOnLoad(transform.parent.gameObject);
    }

    void Start()
    {
        this.PlaySound("BackGroundMusic");
    }
}
