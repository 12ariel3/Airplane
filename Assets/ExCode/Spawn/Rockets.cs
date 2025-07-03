using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rockets : MonoBehaviour
{
    [SerializeField] GameObject rocketPrefab;
    List<GameObject> rocketsList; 
    [SerializeField] Plane plane;

    [SerializeField] float spawnRateMin = 3f;
    [SerializeField] float spawnRateMax = 6;

    Camera cam;
    float camHeight;
    float camWidth;

    // Start is called before the first frame update
    void Start()
    {
        rocketsList = new List<GameObject>();
        cam = Camera.main;
        camHeight = cam.orthographicSize;
        camWidth = cam.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x;
        StartCoroutine(Spawn());
    }


    IEnumerator Spawn(){
        yield return new WaitForSeconds(spawnRateMin);
        while(!GameManager.Instance.gameOver){
            float rndPosY = Random.Range(-camHeight * 1.3f, camHeight * 1.3f);
            float rndPosX = (Random.Range(0, 100) %2) ==0? (2*camWidth) : (-2*camWidth);
            Vector2 spawnPoint = new Vector2(cam.transform.position.x + rndPosX, cam.transform.position.y + rndPosY);

            GameObject newRocket = GetFirstRocketNoActive();

            newRocket.transform.position = spawnPoint;
            newRocket.GetComponent<Rocket>().target = plane.transform;
            newRocket.SetActive(true);

            yield return new WaitForSeconds(Random.Range(spawnRateMin, spawnRateMax));
        }
        if(GameManager.Instance.gameOver){
            for(int i = 0; i< rocketsList.Count; i++){
                rocketsList[i].SetActive(false);
            }
        }
    }

    GameObject GetFirstRocketNoActive(){
        for(int i = 0; i< rocketsList.Count; i++){
            if(!rocketsList[i].activeInHierarchy){
                return rocketsList[i];
            }
        }
        return CreateNewRocket();
    }

    GameObject CreateNewRocket(){
        GameObject newRocket = Instantiate(rocketPrefab);
        newRocket.transform.parent = gameObject.transform;
        newRocket.SetActive(false);
        rocketsList.Add(newRocket);
        return newRocket;
    }
}

