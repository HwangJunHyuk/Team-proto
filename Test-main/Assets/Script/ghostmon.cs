using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ghostmon : MonoBehaviour
{
    public float moveSpeed = 2.5f;
    public float followDistance = 5.0f;

    // > 추후에 빠르게 수정 가능한 부분으로 구현해놓긴 했습니다. 충돌처리 안넣었어요.

    private Transform player;

    void Start()
    {

        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        if (distanceToPlayer <= followDistance)
        {
            Vector3 direction = (player.position - transform.position).normalized;
            transform.Translate(direction * moveSpeed * Time.deltaTime);
        }

    }

    //완성형


}
