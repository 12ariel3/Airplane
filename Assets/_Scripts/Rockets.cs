using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rockets : MonoBehaviour
{
    [SerializeField] GameObject rocketPrefab;
    [SerializeField] Plane plane;

    [SerializeField] float spawnRateMin = 3f;
    [SerializeField] float spawnRateMax = 6;

    Camera cam;
    float camHeight;
    float camWidth;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        camHeight = cam.orthographicSize;
        camWidth = cam.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x;
        StartCoroutine(RocketSpawner());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator RocketSpawner(){
        yield return new WaitForSeconds(spawnRateMin);
        while(!plane.isDead){
            float rndPosY = Random.Range(-camHeight * 1.3f, camHeight * 1.3f);
            float rndPosX = (Random.Range(0, 100) %2) ==0? (2*camWidth) : (-2*camWidth);
            Vector2 spawnPoint = new Vector2(cam.transform.position.x + rndPosX, cam.transform.position.y + rndPosY);

            GameObject newRocket = Instantiate(rocketPrefab, spawnPoint, Quaternion.identity);
            newRocket.GetComponent<Rocket>().target = plane.transform;

            yield return new WaitForSeconds(Random.Range(spawnRateMin, spawnRateMax));
        }
    }
}
