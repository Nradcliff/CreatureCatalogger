using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneInScene : MonoBehaviour
{
    void Start()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Additive);
    }

    private void Update()
    {
        Destroy(gameObject);
    }
}
