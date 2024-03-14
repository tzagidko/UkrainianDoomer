using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float timeBeforeChange;
    private Rigidbody2D enemyBody;
    private enum MoveDirection{movingHorizontal, movingVertical};
    [SerializeField] private MoveDirection enemyDirection;
   // private float xPos, yPos;
    // Start is called before the first frame update
    void Start()
    {
        enemyBody= GetComponent<Rigidbody2D>();
        StartCoroutine(Walk());
    }

    IEnumerator Walk() {
        while(true) {
            
            switch(enemyDirection){
                case MoveDirection.movingHorizontal:
            enemyBody.velocity = new Vector2(moveSpeed, 0);
            yield return new WaitForSeconds(timeBeforeChange);
            enemyBody.velocity = new Vector2(-moveSpeed, 0);
            yield return new WaitForSeconds(timeBeforeChange);
            break;
            
                case MoveDirection.movingVertical:
            enemyBody.velocity = new Vector2(0, moveSpeed);
            yield return new WaitForSeconds(timeBeforeChange);
            enemyBody.velocity = new Vector2(0, -moveSpeed);
            yield return new WaitForSeconds(timeBeforeChange);
            break;
            }
            
        }
    }
    public void SetMoveSpeed(int newSpeed){
        moveSpeed=newSpeed;
    }
}
