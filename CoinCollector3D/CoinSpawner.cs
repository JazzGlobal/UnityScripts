using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public float secondsBetweenSpawn;
    private float elapsedTime = 0.0f;
    private System.Random rand = new System.Random();
    public GameObject bronze_coin;
    public GameObject silver_coin;
    public GameObject gold_coin;
    public bool on = false;
    private Bounds bounds;
    void Start()
    {
        UnityEngine.Debug.Log(gameObject.transform.parent.position);
        CalculateBounds();
        UnityEngine.Debug.Log(bounds);
    }
    // Update is called once per frame
    void Update()
    {
        if(on)
        {
            elapsedTime += Time.deltaTime;
            if (elapsedTime > secondsBetweenSpawn)
            {
                elapsedTime = 0;
                UnityEngine.Debug.Log("Spawning new Coin!");
                SpawnCoin(); ;
            }
        }

       //  UnityEngine.Debug.Log($"Coin Spawner Transform: {gameObject.transform.parent.transform.position}");
    }
    private void CalculateBounds()
    {
        bounds.size = Vector3.zero; // reset 
        GameObject level = gameObject.transform.parent.gameObject;
        Collider[] colliders = level.GetComponentsInChildren<Collider>(); 
        foreach(Collider col in colliders)
        {
            bounds.Encapsulate(col.bounds);
        }
    }
    void SpawnCoin()
    {
        var coin_type = rand.Next(0, 3);
        var x_position = rand.Next(-31, -16);
        var z_position = rand.Next(-45, -28);
        GameObject newCoin = null; 
        switch(coin_type)
        {
            case 0:
                newCoin = bronze_coin;
                break;
            case 1:
                newCoin = silver_coin;
                break;
            case 2:
                newCoin = gold_coin;
                break; 
        }

        var y_rotation = rand.Next(-360, 360);
        var x_rotation = rand.Next(-360, 360);
        var z_rotation = rand.Next(-360, 360);

        GameObject spawned_newCoin = (GameObject)Instantiate(newCoin, new Vector3(x_position, 61.70f, z_position), new Quaternion(x_rotation, y_rotation, z_rotation,0));
    }
}
