using UnityEngine;
using System.Collections;

public class SpawnProj : MonoBehaviour {
    [SerializeField]
    //The hotDog
    private GameObject _prefab;
    //spawn on right side
    private Vector3 _randomVectorA;
    //spawn left side
    private Vector3 _randomVectorB;
    //timer for hotdogs to spawn
    [SerializeField]
    private float _timer = 1;
    //timer how long the game is
    private float _gameTimer;
    private bool Spawn = true;

    // Update is called once per frame
    void Update()
    {
        _gameTimer += Time.deltaTime;
        _timer -= Time.deltaTime;
        if (_timer < 0)
        { 
            _randomVectorA = new Vector3(Random.Range(1, 5), 10, -8);
            _randomVectorB = new Vector3(Random.Range(-5, -1), 10, -8);
            if (Spawn == true)
            {
                Instantiate(_prefab, _randomVectorA, transform.rotation);
                Instantiate(_prefab, _randomVectorB, transform.rotation);
            }
            _timer = 1 - (Mathf.Round(_gameTimer)/10000);
        }

    }

    public void StopSpawn()
    {
            Spawn = false;
    }

    }
