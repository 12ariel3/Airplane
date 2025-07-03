using System.Collections;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    [HideInInspector]
    public Transform target;
    [SerializeField] float speed = 1f;
    [SerializeField] float turnSpeed = 100f;
    [SerializeField] ParticleSystem explosion;
    


    Rigidbody2D rb2D;
    float rocketsCount;
    float creditsFormula;

    private void Awake() {
        rb2D = GetComponent<Rigidbody2D>();
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
            //StartCoroutine(collision.GetComponent<Plane>().Dead());
            StartCoroutine(RocketExplosionPlayer());
        }else{
            StartCoroutine(RocketExplosion());
        }
    }

    IEnumerator RocketExplosion(){
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        explosion.Play();
        rocketsCount++;
        creditsFormula = Random.Range(2f, 3.5f)* rocketsCount;
        GameManager.Instance.Credits = (int)creditsFormula;
        GameManager.Instance.CreditsUI.text = GameManager.Instance.Credits.ToString();
        yield return new WaitForSeconds(1f);
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
        gameObject.SetActive(false);
    }

    IEnumerator RocketExplosionPlayer(){
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        Instantiate(explosion, transform.position, Quaternion.identity);
        //explosion.Play();
        yield return new WaitForSeconds(1f);
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
        gameObject.SetActive(false);
    }
}
