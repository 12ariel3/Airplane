using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    Transform target;
    Vector3 offset;
    bool isFollow;
    [SerializeField] float smoothTime = 1f;
    Vector3 velocity = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void FixedUpdate() {
        if(isFollow){
        Vector3 targetPosition = target.position + offset;
        targetPosition.z = transform.position.z;
        //transform.position = targetPosition;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        }
    }

    public void Follow(GameObject player){
        target = player.transform;
        offset = transform.position - target.position;
        isFollow = true;
    }

    public void UnFollow(){
        isFollow = false;
    }
}
