using UnityEngine;

public class enemyMovement : MonoBehaviour
{
    
    public bool xAxis = false;
    public bool yAxis = false;
    public int enemySpeed = 100;

    private bool goUp = true;
    private bool goRight = true;

    void Update()
    {
        if(xAxis)
        {
            if(goRight)
            {
                transform.Translate(Vector2.right * enemySpeed * Time.deltaTime);
            }
            if(!goRight)
            {
                transform.Translate(-Vector2.right * enemySpeed * Time.deltaTime);
            }
        }
        if(yAxis)
        {
            if(goUp)
            {
                transform.Translate(Vector2.up * enemySpeed * Time.deltaTime);
            }
            if(!goUp)
            {
                transform.Translate(-Vector2.up * enemySpeed * Time.deltaTime);
            }
        }
    }

    public void SwitchY()
    {
        if(!goUp)
        {
            goUp = true;
        }
        else
        {
            goUp = false;
        }
    }

    public void SwitchX()
    {
        if(!goRight)
        {
            goRight = true;
        }
        else
        {
            goRight = false;
        }
    }
}
