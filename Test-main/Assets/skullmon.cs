using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skullmon : MonoBehaviour
{
    public float skullspeed = 2.0f; // 이속 
    public float skullmovearea = 5.0f; // 이동 거리 
                                       // 개선 여지가 있어요. 이건 회의를 좀 해봐야할듯


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

        // 애니메이션 넣을 때 만지시면 됩니다.
        Vector3 newScale = transform.localScale;
        newScale.x *= -1;
        transform.localScale = newScale;
    }
}
