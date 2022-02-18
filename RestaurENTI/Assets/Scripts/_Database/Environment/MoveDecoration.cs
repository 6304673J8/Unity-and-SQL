using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDecoration : MonoBehaviour
{
    public float Speed = 1.5f;

    private int mCurrentIndex;

    public Transform[] Positions;

    // Start is called before the first frame update
    void Start()
    {
        mCurrentIndex = 0;

        transform.position = GetCurrentTarget();
    }
    private Vector3 GetCurrentTarget()
    {
        if (Positions.Length == 0)
            return transform.position;

        return Positions[mCurrentIndex].position;
    }
    void Update()
    {
        var targetPos = GetCurrentTarget() - transform.position;

        var moveDir = targetPos.normalized * Speed * Time.deltaTime;

        if (targetPos.magnitude < 0.05f || moveDir.magnitude > targetPos.magnitude)
        {
            if (++mCurrentIndex == Positions.Length) mCurrentIndex = 0;
            moveDir = targetPos;
        }

        
        transform.position += moveDir;

    }
}

