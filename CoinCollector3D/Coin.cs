using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public string Coin_Type = "";
    public int Caught_Multiplier = 1;
    public int Coin_Value = 0;
    private BoxCollider bc;
    private bool grounded = false;
    public bool can_die = false;
    private float elapsedTime = 0.0f;
    public float lifeTime;
    // Start is called before the first frame update
    void Start()
    {
        bc = GetComponent<BoxCollider>(); 
        if(Caught_Multiplier <= 0)
        {
            Caught_Multiplier = 1;
        }
    }

    void CleanUpCoin()
    {
       //  UnityEngine.Debug.Log("Coin has been cleaned up!");
        Destroy(gameObject);
    }

    void OnTriggerEnter(Collider col)
    {
        // UnityEngine.Debug.Log("Coin Collision");
        if(col.gameObject.tag == "Player")
        {
            if(grounded)
            {
                EventManager.FireCoinCollected(this.Coin_Type, this.Coin_Value);
            } else
            {
                EventManager.FireCoinCollected(this.Coin_Type, this.Coin_Value * Caught_Multiplier);
            }
            CleanUpCoin(); 
        } 
        else if (col.gameObject.tag == "Floor")
        {
            // UnityEngine.Debug.Log("Coin collided with floor!");
            grounded = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Add destroy logic based on timer after coin hits ground. This will prevent a memory leak.
        if (grounded && can_die)
        {
            elapsedTime += Time.deltaTime; 
            if(elapsedTime > lifeTime)
            {
                elapsedTime = 0;
                CleanUpCoin();
            }
        }
    }
}
