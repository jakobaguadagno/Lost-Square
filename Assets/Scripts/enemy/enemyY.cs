using UnityEngine;

public class enemyY : MonoBehaviour
{

    public enemyMovement enemy;

    void OnCollisionEnter2D(Collision2D other)
    {
        if(enemy.yAxis)
        {
            enemy.SwitchY();
        }
    }
}
