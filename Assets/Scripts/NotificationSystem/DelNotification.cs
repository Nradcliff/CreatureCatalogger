using UnityEngine;

public class DelNotification : MonoBehaviour
{
    public float speed;
    bool delete = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (delete)
        {
            transform.localScale = Vector3.MoveTowards(this.transform.localScale, Vector3.zero, speed * Time.deltaTime);
            if (this.transform.localScale == Vector3.zero)
            Destroy(this.gameObject);
        }
    }

    public void fancyDelete()
    {
        delete = true;
    }
}
