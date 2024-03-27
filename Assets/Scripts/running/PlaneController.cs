using UnityEngine;

public class PlaneController : MonoBehaviour
{
    public float speed = 10f;
    public GameObject mObstacle;

    void Start()
    {
        int randValue = Random.Range(0, 3);
        if(randValue != 0){
            mObstacle.SetActive(false);
        }
        
    }

    void Update()
    {
        transform.Translate(speed * Vector3.back * Time.deltaTime);
    }
}
