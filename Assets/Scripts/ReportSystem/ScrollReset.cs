using UnityEngine;
using UnityEngine.UI;

public class ScrollReset : MonoBehaviour
{
    public Scrollbar scroll;

    public void Reset()
    {
        scroll.value = 1;
    }
}
