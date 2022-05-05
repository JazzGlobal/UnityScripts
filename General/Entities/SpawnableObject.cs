using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(BoxCollider))]
public class SpawnableObject : MonoBehaviour
{
    // Start is called before the first frame update
    public float lifeTime = 10f;
    public AudioClip bounceSound;

    private bool destroyable = false;
    private float elapsedTime = 0.0f;
    
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.y < -10)
        {
            Object.Destroy(gameObject);
        }

        if(destroyable)
        {
            elapsedTime += Time.deltaTime;
            if (elapsedTime > lifeTime)
            {
                Object.Destroy(gameObject);
                elapsedTime = 0.0f;
            }
        } else
        {
            elapsedTime = 0;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Colliding with unknown object!!!");
        if (other.gameObject.tag == "DestroyableContact")
        {
            Debug.Log("Colliding with floor!!!");
            destroyable = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "DestroyableContact")
        {
            destroyable = false;
        }
    }
}
