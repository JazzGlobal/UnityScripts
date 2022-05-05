using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float secondsBetweenSpawn;
    private float elapsedTime = 0.0f;
    private System.Random rand = new System.Random();
    public GameObject object_1;
    public GameObject object_2;
    public GameObject object_3;
    public bool on = false;

    void Start()
    {
    }

    void Update()
    {
        if(on)
        {
            elapsedTime += Time.deltaTime;
            if (elapsedTime > secondsBetweenSpawn)
            {
                elapsedTime = 0;
                SpawnCoin();
            }
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
                newCoin = object_1;
                break;
            case 1:
                newCoin = object_2;
                break;
            case 2:
                newCoin = object_3;
                break; 
        }

        var y_rotation = rand.Next(-360, 360);
        var x_rotation = rand.Next(-360, 360);
        var z_rotation = rand.Next(-360, 360);

        TransformData data = new TransformData(this.gameObject.transform);
        data.ApplyTo (newCoin.transform);
        GameObject spawned_newCoin = (GameObject)Instantiate(newCoin, newCoin.transform.position, new Quaternion(x_rotation, y_rotation, z_rotation,0));
    }

    public class TransformData
    {
        public Vector3 LocalPosition = Vector3.zero;
        public Vector3 LocalEulerRotation = Vector3.zero;
        public Vector3 LocalScale = Vector3.one;

        // Unity requires a default constructor for serialization
        public TransformData() { }

        public TransformData(Transform transform)
        {
            LocalPosition = transform.localPosition;
            LocalEulerRotation = transform.localEulerAngles;
            LocalScale = transform.localScale;
        }

        public void ApplyTo(Transform transform)
        {
            transform.localPosition = LocalPosition;
            transform.localEulerAngles = LocalEulerRotation ;
            transform.localScale = LocalScale;
        }
    }
}