using UnityEngine;

public class enemyX : MonoBehaviour
{

    public enemyMovement enemy;

    void OnCollisionEnter2D(Collision2D other)
    {
        if(enemy.xAxis)
        {
            enemy.SwitchX();
        }
    }
}
