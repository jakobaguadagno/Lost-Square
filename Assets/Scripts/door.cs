using UnityEngine;
using UnityEngine.SceneManagement;

public class door : MonoBehaviour
{

    private Scene scene;

    void Start()
    {
        scene = SceneManager.GetActiveScene();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            if(scene.name == "Level 1")
            {
                SceneManager.LoadScene("Level 2");
            }
            if(scene.name == "Level 2")
            {
                SceneManager.LoadScene("Level 3");
            }
            if(scene.name == "Level 3")
            {
                SceneManager.LoadScene("Win");
            }
        }
    }
}
