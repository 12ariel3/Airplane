using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Plane : MonoBehaviour
{
    [SerializeField] float speed = 1;
    [SerializeField] float turnSpeed = 100f;

    Rigidbody2D rb2D;
    float turnDirection;

    public bool isDead;

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
        if(isDead && Input.GetKeyDown(KeyCode.Space)){
            SceneManager.LoadScene(0);
        }
    }

    private void FixedUpdate() {
        if(!isDead){
            rb2D.velocity = transform.up * speed;
            rb2D.angularVelocity = -turnDirection * turnSpeed;
        }
    }

    public void Dead(){
        if(!isDead){
        isDead = true;
        cameraFollow.UnFollow();
        rb2D.isKinematic = false;
        Debug.Log("perdiste papu");
        }
    }
}
