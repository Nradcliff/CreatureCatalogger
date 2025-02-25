using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScene : MonoBehaviour
{
    protected float timer1Goal,timer2Goal,timer3Goal,timer4Goal,timer;
    public GameObject loadHDD, hddC, loadProgram, programC, loadReports, reportsC, loadDesktop;
    public Scene loadTo;
    void Start()
    {
        timer1Goal = 1;
        timer2Goal = Random.Range(.5f, 1.25f)+timer1Goal/2;
        timer3Goal = 1+timer2Goal/2;
        timer4Goal = Random.Range(1, 1.25f)+timer3Goal/2;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= timer4Goal)
        {
            SceneManager.LoadScene("MainLevel");
        }
        else if (timer >= timer3Goal)
        {
            reportsC.SetActive(true);
            loadDesktop.SetActive(true);
        }
        else if (timer >= timer2Goal)
        {
            programC.SetActive(true);
            loadReports.SetActive(true);
        }
        else if (timer >= timer1Goal)
        {
            hddC.SetActive(true);
            loadProgram.SetActive(true);
        }
    }
}
