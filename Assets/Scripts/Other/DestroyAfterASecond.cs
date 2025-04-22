using UnityEngine;

public class DestroyAfterASecond : MonoBehaviour
{
    float time;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if(time > .5f)
        {
            Destroy(gameObject);
        }
    }
}
