using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    [HideInInspector]
    public Transform target;
    [SerializeField] float speed = 1f;
    [SerializeField] float turnSpeed = 100f;
    


    Rigidbody2D rb2D;
    float turnDirection;

    private void Awake() {
        rb2D = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {  
    }

    private void FixedUpdate() {
        rb2D.velocity = transform.up * speed;

        if(target != null){
            Vector2 direction = (Vector2)target.position - rb2D.position;
            direction.Normalize();
            float angle = Vector3.Cross(direction, transform.up).z;
            rb2D.angularVelocity = -turnSpeed * angle;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.CompareTag("Player")){
            collision.GetComponent<Plane>().Dead();
        }
        Destroy(gameObject);
    }
}
