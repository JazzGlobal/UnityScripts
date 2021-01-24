using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Threading;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public float rotation_speed; 

    private Vector3 velocity;
    private Rigidbody rb;
    private CharacterController p_controller;
    public int score = 0;

    private Vector3 rotation; 

    // Start is called before the first frame update
    void Start()
    {
        p_controller = GetComponent<CharacterController>();
    }

    void FixedUpdate()
    {
        // Movement Logic
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        this.rotation = new Vector3(Input.GetAxisRaw("Mouse Y") * rotation_speed * Time.deltaTime, 0, Input.GetAxisRaw("Mouse X") * rotation_speed * Time.deltaTime);
        this.transform.Rotate(this.rotation);
        p_controller.Move(move * Time.deltaTime * speed);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void IncreaseScore(string coin_type, int coin_value)
    {
        UnityEngine.Debug.Log($"Player Score Has Increased by {coin_value} because a {coin_type} coin was caught!");
        score += coin_value;
        UnityEngine.Debug.Log($" !! Wallet is now ${score}$ !!");
    }

    void OnEnable()
    {
        EventManager.OnCoinCollected += IncreaseScore; 
    }
    
    void OnDisable()
    {
        EventManager.OnCoinCollected -= IncreaseScore;
    }
}
