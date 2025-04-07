using UnityEngine;

public class BulletPlayerFly : BulletFly
{
    [SerializeField] private SpriteRenderer Player;
    protected override void Awake()
    {
        base.Awake();
    }

    protected override void Start()
    {
        base.Start();
        Player = GameObject.Find("Player").GetComponentInChildren<SpriteRenderer>();
        this.ChangeDirection();
    }
    protected override void Update()
    {
        base.Update();
    }


    private void ChangeDirection()
    {
        if (Player.flipX == true)
        {
            this.direction = Vector3.left;
        }
        else this.direction = Vector3.right;
    }

    //khi gameobject được bật lại
    protected void OnEnable()
    {
        //for update
    }
}
