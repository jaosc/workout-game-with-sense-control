using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{

    [SerializeField] private GameObject planePrefab;

    [Header("SETTINGS")]
    public float offset = 3f;
    public float waitTime = 2;
    private List<float> offsets;
    private bool haveBoxObstacle = false;

    void Start()
    {
        offsets = new List<float>(){
            -offset,
            0,
            offset
        };

        StartCoroutine(generateNewPlane());
    }

    IEnumerator generateNewPlane(){

        while(true){

            int randValue = Random.Range(0, 3);

            float newPlaneOffset = offsets[randValue];
        
            Vector3 newPlanePosition = transform.position;
            newPlanePosition.x += newPlaneOffset;

            Instantiate(planePrefab, newPlanePosition, transform.rotation);
            yield return new WaitForSeconds(waitTime);
        
        }
    }
}
