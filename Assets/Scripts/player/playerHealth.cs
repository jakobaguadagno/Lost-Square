using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class playerHealth : MonoBehaviour
{

    public int health = 100;
    public Text healthUI;

    void Start()
    {
        healthUI.text = "HP: 100/100";
    }

    void Update()
    {
        if(health <= 0)
        {
            SceneManager.LoadScene("Death");
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            health -= 10;
            healthUI.text = "HP: " + health + "/100";
        }
    }

}
