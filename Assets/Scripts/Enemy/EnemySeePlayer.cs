using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySeePlayer : ModelMonoBehaviour
{
    // do khoảng cách khi nhìn thấy player
    [SerializeField] private float disLimit = 5.0f;
    [SerializeField] private float distance = 0.0f;
    // lấy vị trí của player
    [SerializeField] private Transform player;
    //biến bool kiểm tra khi nhìn thấy player
    [SerializeField] private bool seePlayer;
    public bool SeePlayer { get => seePlayer; }

    //biến float lấy khoảng cách từ enemy đến player
    [SerializeField] private Vector3 distanceEnemyToPlayer;
    public Vector3 DistanceEnemyToPlayer { get => distanceEnemyToPlayer;}
    
    protected override void Awake()
    {
        base.Awake();
        player = GameObject.Find("Player").GetComponent<Transform>();
    }

    void Update()
    {
        this.CheckseePlayer();
        this.CaculateDistanceEnemyToPlayer();
    }

    private void CaculateDistanceEnemyToPlayer()
    {
        distanceEnemyToPlayer = transform.parent.position - player.position;
    }

    private void CheckseePlayer()
    {
        distance = Vector3.Distance(transform.parent.position , player.position);
        if (distance <= disLimit) seePlayer =true;
        else seePlayer = false;
    }

}
