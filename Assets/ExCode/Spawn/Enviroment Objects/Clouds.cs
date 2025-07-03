using UnityEngine;

public class Clouds : MonoBehaviour
{

    [SerializeField] GameObject cloudPrefab;
    [SerializeField] float spawnRate = 0.2f;

    Camera cam;
    float camHeight;
    float camWidth;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        camHeight = cam.orthographicSize;
        camWidth = cam.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x;

        FirstClouds();
        InvokeRepeating(nameof(Spawn), spawnRate, spawnRate);
    }

    // Update is called once per frame
    void Update()
    {
    }

    void Spawn(){
        if(!GameManager.Instance.gameOver){
            DeactivateClouds();
            float rndPosY;
            float rndPosX;
        
            if(Random.Range(0,100)< 30){
                rndPosY = (Random.Range(0,100)%2)==0? (-camHeight- 2f) : (camHeight + 2f);
                rndPosX = Random.Range(-camWidth, camWidth);
            }else{
                rndPosY = Random.Range(-camHeight, camHeight);
                rndPosX = (Random.Range(0,100)%2)==0? (camWidth +2) : (-camWidth-2);
            }

            Vector2 spawnPos = new Vector2(cam.transform.position.x + rndPosX, cam.transform.position.y + rndPosY);

            CreateNewCloudInPosition(spawnPos);
        }
    }

    void DeactivateClouds(){
        foreach (Transform t in transform){
            if(t.position.x > cam.transform.position.x + 2*camWidth ||
            t.position.x < cam.transform.position.x - 2*camWidth ||
            t.position.y > cam.transform.position.y + 1.5*camHeight ||
            t.position.y < cam.transform.position.y - 1.5*camHeight){
                t.gameObject.SetActive(false);
            }
        }
    }

    GameObject NewCloud(){
        foreach(Transform t in transform){
            if(!t.gameObject.activeInHierarchy){
                return t.gameObject;
            }
        }
        if(transform.childCount < 20){
            return Instantiate(cloudPrefab, transform);
        }
        return transform.GetChild(19).gameObject;
    }

    void CreateNewCloudInPosition(Vector2 pos){
        
        GameObject newCloud = NewCloud();
        newCloud.transform.position = pos;

        //Random Size
        float rndScale = Random.Range(0.7f, 2f);
        newCloud.transform.localScale = Vector2.one * rndScale;
        //Random Rotation
        Vector3 euler = newCloud.transform.eulerAngles;
        euler.z = Random.Range(0f, 360f);
        newCloud.transform.eulerAngles = euler;
        //Random Alpha
        Color rndColor = new Color(Random.Range(0.75f, 0.9f), 1f, 1f, Random.Range(0.25f, 1f));
        newCloud.GetComponent<SpriteRenderer>().color = rndColor;

        newCloud.GetComponent<Renderer>().sortingOrder = Random.Range(-10, 4);

        newCloud.SetActive(true);
    }

    void FirstClouds(){
        int rndClouds = Random.Range(2, 5);
        for(int i = 0; i<=rndClouds; i++){
            float rndPosX = Random.Range(-camWidth, camWidth);
            float rndPosY = Random.Range(-camHeight, camHeight);
            
            Vector2 spawnPos = new Vector2(cam.transform.position.x + rndPosX, cam.transform.position.y + rndPosY);
            CreateNewCloudInPosition(spawnPos);
        }
    }
}
