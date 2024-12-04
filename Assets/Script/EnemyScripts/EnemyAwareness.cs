using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAwareness : MonoBehaviour
{
    public float awarenessRadius = 8f;
    public bool isAggro;
    private Transform playersTransform;

    // Start is called before the first frame update
    private void Start()
    {
        playersTransform = FindObjectOfType<PlayerMove>().transform;
    }


    // Update is called once per frame
    private void Update()
    {
        var dist = Vector3.Distance(transform.position, playersTransform.position);

        if (dist < awarenessRadius)
        {
            isAggro = true;
        }
    }

}
