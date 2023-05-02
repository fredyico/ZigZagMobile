using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    [SerializeField] private GameObject platform;
    [SerializeField] private GameObject flower;

    Vector3 lastPos;
    float size;
    public bool gameOver;




    // Start is called before the first frame update
    void Start()
    {
        lastPos = platform.transform.position;
        size = platform.transform.localScale.x;

        for (int i = 0; i < 4; i++)
        {
            SpawnPlatforms();
        }
        InvokeRepeating("SpawnPlatforms", 2.0f, 0.2f);

    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver)
        {
            CancelInvoke("SpawnPlatforms");
        }
    }

    void SpawnX()
    {
        Vector3 pos = lastPos;
        pos.x += size;
        lastPos = pos;
        Instantiate(platform, pos, Quaternion.identity);

        int rand = Random.Range(0,4);
        if(rand < 1)
        {
            Instantiate(flower, new Vector3(pos.x, pos.y + 1, pos.z), flower.transform.rotation);
        }
    }

    void SpawnZ()
    {
        Vector3 pos = lastPos;
        pos.z += size;
        lastPos = pos;
        Instantiate(platform, pos, Quaternion.identity);

        int rand = Random.Range(0, 4);
        if (rand < 1)
        {
            Instantiate(flower, new Vector3(pos.x, pos.y + 1,pos.z), flower.transform.rotation);
        }
    }

    void SpawnPlatforms()
    {
        int rand = Random.Range(0, 6);
        if(rand < 3)
        {
            SpawnX();
        }
        else if (rand >= 3)
        {
            SpawnZ();
        }
    }
}
