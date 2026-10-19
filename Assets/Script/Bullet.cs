using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Speed = 8f;
    public float Timer;
    public bool isHit;
    private Rigidbody rb;    
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.linearVelocity = transform.forward * Speed;
        isHit = false;
    }

    private void Update()
    {
        Timer += Time.deltaTime;
        if (Timer == 50000)
        {
            isHit = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            PlayerController playerController = other.GetComponent<PlayerController>();
            if (!isHit)
            {
                playerController.Hit();
                isHit = true;
                Timer = 0;
            }
        
        }

        if (!other.CompareTag("Bullet"))
        {
            Destroy(gameObject);
        }        
    }
}