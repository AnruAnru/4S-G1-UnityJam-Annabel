using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveStones : MonoBehaviour
{
    [SerializeField] private float stoneSpeed = 5f;

    void Update()
    {
        transform.position += Vector3.left * stoneSpeed * Time.deltaTime;
    }
}
