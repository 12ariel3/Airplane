using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed = 1;
    [SerializeField] float turnSpeed = 100f;
    Rigidbody2D rb2D;
    
    float turnDirection;

    CameraFollow cameraFollow;


     private void Awake() {
        rb2D = GetComponent<Rigidbody2D>();
    }


    // Start is called before the first frame update
    void Start()
    {
        cameraFollow = Camera.main.GetComponent<CameraFollow>();
        cameraFollow.Follow(this.gameObject);
        
    }

    // Update is called once per frame
    void Update()
    {
        turnDirection = Input.GetAxis("Horizontal");

    }

    private void FixedUpdate() {
        if(!GameManager.Instance.gameOver){
            rb2D.velocity = transform.up * speed;
            rb2D.angularVelocity = -turnDirection * turnSpeed;
        }
    }

    
}
