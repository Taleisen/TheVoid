using UnityEngine;
using UnityEngine.SceneManagement;

public class DelayTransition : MonoBehaviour
{
    public string newSceneName = "";
    public float delay = 5f;
    private float remainingTime;

    void Start()
    {
        remainingTime = delay;
    }

    public void FixedUpdate()
    {
        while (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
        }
        if (remainingTime <= 0)
        {
            SceneManager.LoadScene(newSceneName);
        }

    }
}
