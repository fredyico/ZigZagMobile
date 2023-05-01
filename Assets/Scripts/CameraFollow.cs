using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]private GameObject player;
    Vector3 offset;
    [SerializeField] private float lerpRate;
    public bool gameOver;

    void Start()
    {
        offset = player.transform.position - transform.position;
        gameOver = false;
    }

    void Update()
    {
        if (!gameOver)
        {
            Follow();
        }

    }
    void Follow()
    {
        Vector3 pos = transform.position;
        Vector3 targetPos = player.transform.position - offset;
        pos = Vector3.Lerp(pos, targetPos, lerpRate * Time.deltaTime);
        transform.position = pos;
    }

}