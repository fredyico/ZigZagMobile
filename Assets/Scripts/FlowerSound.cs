using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerSound : MonoBehaviour
{
    [SerializeField] private AudioClip flowerCollide;
    private static float rotateSpeed = 150;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            AudioSource.PlayClipAtPoint(flowerCollide, transform.position);
        }
    }
    void Update()
    {
        transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime);
    }
}
