using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public bool isOpen = false;

     [SerializeField]
    private float Speed = 1f;

    [Header ("Sliding Configs")]
    [SerializeField]
     private Vector3 SlideDirection = Vector3.back;
    [SerializeField] 
     private float SlideAmount = 1.9f;
     private Vector3 StartPosition;
    private Coroutine AnimationCoroutine;
    
    void Awake()
    {
        StartPosition = transform.position;
    }
    public void Open()
    {
        if(isOpen==true)
        {
    
              AnimationCoroutine = StartCoroutine(DoSlidingOpen());
        
        }
    }
    private IEnumerator DoSlidingOpen()
    {
        print("a");
        Vector3 endPosition =  StartPosition + SlideAmount * SlideDirection;
        Vector3 startPosition = transform.position;

        float time = 0;
        isOpen = true;
        while(time < 1)
        {
            transform.position = Vector3.Lerp(startPosition, endPosition, time);
            yield return null;
            time += Time.deltaTime * Speed; 
        }
    }
    /*public void Close()
    {
        if(isOpen)
        {
             AnimationCoroutine = StartCoroutine(DoSlidingClose());
        }
    }
    private IEnumerator DoSlidingClose()
    {
        Vector3 endPosition =  StartPosition;
        Vector3 startPosition = transform.position;

        float time = 0;
        isOpen = false;
        while(time < 1)
        {
            transform.position = Vector3.Lerp(startPosition, endPosition, time);
            yield return null;
            time += Time.deltaTime * Speed; 
        }
    }*/
    
}
