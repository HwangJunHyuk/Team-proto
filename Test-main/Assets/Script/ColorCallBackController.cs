using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorCallBackController : MonoBehaviour
{
    public event Action<Collider2D> onColiderEnter;
    public event Action<Collider2D> onColiderExit;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        onColiderEnter?.Invoke(other);
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        onColiderExit?.Invoke(other);
    }
}
