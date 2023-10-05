using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    [SerializeField] private Transform _targetTransform;
    [SerializeField] private float _followSpeed;
    [SerializeField] private float _xFollowDistance = 5f;
    [SerializeField] private float _yFollowDistance = 5f;
    [SerializeField] private float _followMoveThreshhold = 0.02f;


    // Update is called once per frame
    void Update()
    {
    float xDistance = transform.position.x - _targetTransform.position.x;
    float yDistance = transform.position.y - _targetTransform.position.y;

    Vector3 newPosition = transform.position;

    float xMoveThreshold = Mathf.Abs(xDistance - _xFollowDistance);
    float yMoveThreshold = Mathf.Abs(yDistance - _yFollowDistance);
 
        if (xMoveThreshold > _followMoveThreshhold)
        {
             if (xDistance > _xFollowDistance)
             {
              newPosition.x -= transform.right.x;   
             }
             else if (xDistance < _xFollowDistance)
             {
                newPosition.x += transform.right.x;
             }
        }
   
        if(yMoveThreshold > _followMoveThreshhold)
        {
            if (yDistance > _yFollowDistance)
            {
                newPosition.y -= transform.forward.y;
            
            }
            else
            {
                newPosition.y += transform. forward.y;
            }
        }

        transform.position = Vector3.Lerp(transform.position, newPosition, _followSpeed * Time.deltaTime);
    }
}
