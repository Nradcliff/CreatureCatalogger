using UnityEngine;

public class ErrorScript : MonoBehaviour
{
    public GameObject errorPrefab;
    public int errorCount;
    public int loopCount = 1;
    public float timer;
    public bool pressedButton;

    public void Update()
    {
        if (pressedButton)
        {
            timer += Time.deltaTime;
        }
        if(timer >= .5f)
        {
            timer = 0;
            
            if (errorCount == 0)
            {
                pressedButton = false;
                loopCount = 1;
            }
            else
            {
                Instantiate(errorPrefab, new Vector3(this.transform.position.x + (.5f * loopCount), this.transform.position.y - (.5f * loopCount), 0), this.transform.rotation);
                errorCount -= 1;
                loopCount += 1;
            }
        }
    }

    public void buttonFunctionfor()
    {
        pressedButton = true;
    }
}
