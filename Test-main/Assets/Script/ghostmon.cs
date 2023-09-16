using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ghostmon : MonoBehaviour
{
    public float moveSpeed = 2.5f;
    public float followDistance = 5.0f;

    // > ���Ŀ� ������ ���� ������ �κ����� �����س��� �߽��ϴ�. �浹ó�� �ȳ־����.

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

    //�ϼ���


}
