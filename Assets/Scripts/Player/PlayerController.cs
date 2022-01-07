using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float Speed = 5.0f;

    private Rigidbody _rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        float xSpeed = xInput * Speed;
        float zSpeed = zInput * Speed;

        Vector3 newVelocity = new Vector3(xSpeed, 0f, zSpeed);

        _rigidbody.velocity = newVelocity;
    }

    public void Die()
    {
        gameObject.SetActive(false);

        GameManager gameManager = FindObjectOfType<GameManager>();

        gameManager.FinishGame();
    }
}
