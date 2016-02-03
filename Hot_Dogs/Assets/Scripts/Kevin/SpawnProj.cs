using UnityEngine;
using System.Collections;

public class SpawnProj : MonoBehaviour {
    [SerializeField]
    private GameObject prefab;
    private Vector3 randomvector;
    private float timer = 5;

    // Update is called once per frame
    void Update()
    {
        Debug.Log(timer);
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            for (int i = 0; i < 2; i++)
            {
                randomvector = new Vector3(Random.Range(-10, 10), 10, -8);
                Instantiate(prefab, randomvector, transform.rotation);
                timer = 5;
            }
        }
    }

    }
