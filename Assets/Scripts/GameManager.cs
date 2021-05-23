using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        InitKeys();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InitKeys()
    {
        var spawnerNumber = Enumerable.Range(1, 5).OrderBy(n => Guid.NewGuid()).Take(3).ToArray();

        for (int i = 0; i < spawnerNumber.Length; i++)
        {
            KeySpawner keySpawner = GameObject.Find("KeySpawner_" + spawnerNumber[i]).GetComponent<KeySpawner>();
            keySpawner.KeyInstatiate();
        }

    }
}
