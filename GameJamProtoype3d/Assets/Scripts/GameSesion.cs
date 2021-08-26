using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSesion : MonoBehaviour
{
    public static int maxEnemies = 30;
    public static int enemyCounter;

    // Start is called before the first frame update
    void Start()
    {
        int numberOfEnemies = FindObjectsOfType<Enemy>().Length;
        GameSesion.enemyCounter += numberOfEnemies;
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
