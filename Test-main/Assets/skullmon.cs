using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skullmon : MonoBehaviour
{
    public float skullspeed = 2.0f; // �̼� 
    public float skullmovearea = 5.0f; // �̵� �Ÿ� 
                                       // ���� ������ �־��. �̰� ȸ�Ǹ� �� �غ����ҵ�


    private Vector3 inpo;
    private int direction = -1;

    void Start()
    {
        inpo = transform.position;
    }

    void Update()
    {

        transform.Translate(Vector3.right * direction * skullspeed * Time.deltaTime);


        if (Mathf.Abs(transform.position.x - inpo.x) >= skullmovearea)
        {
            ChangeDirection();


        }
    }

    void ChangeDirection()
    {

        direction *= -1;

        // �ִϸ��̼� ���� �� �����ø� �˴ϴ�.
        Vector3 newScale = transform.localScale;
        newScale.x *= -1;
        transform.localScale = newScale;
    }
}
