using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.UIElements;

public class RecogerObjeto : MonoBehaviour
{
    public Door door;

    [SerializeField]
    GameObject handPoint;
    private GameObject pickedObject = null;

    [SerializeField]
    private Collider pedestal;
    [SerializeField]
    GameObject objetopedestal;


    public bool isOpen = false;

    [SerializeField]
    private float Speed = 1f;

    [Header("Sliding Configs")]
    [SerializeField]
    private Vector3 SlideDirection = Vector3.back;
    [SerializeField]
    private float SlideAmount = 1.9f;
    private Vector3 StartPosition;
    private Coroutine AnimationCoroutine;


    private void Start()
    {
       
    }

    void Update()
    {
        print(isOpen);

        if (pickedObject != null)
        {
          if(Input.GetKey("r"))
          {
                if (isOpen == true)
                {
                    print("entrandocorutina");
                    AnimationCoroutine = StartCoroutine(DoSlidingOpen());
                    
                }
                if (pedestal.isTrigger)
                {
                    pickedObject.GetComponent<Rigidbody>().useGravity = false;
                    pickedObject.GetComponent<Rigidbody>().isKinematic = false;
                    pickedObject.gameObject.transform.SetParent(null);
                    pickedObject.transform.position = objetopedestal.transform.position;
                    pickedObject.gameObject.transform.SetParent(objetopedestal.gameObject.transform);
                    isOpen = true;
                    return;
                }
            pickedObject.GetComponent<Rigidbody>().useGravity = true;
            pickedObject.GetComponent<Rigidbody>().isKinematic = false;
            pickedObject.gameObject.transform.SetParent(null);
            pickedObject = null;
               
            }
        }
        
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.CompareTag("Objeto"))
        {
            if(Input.GetKey("e") && pickedObject == null)
            {
                other.GetComponent<Rigidbody>().useGravity = false;
                other.GetComponent<Rigidbody>().isKinematic = true;
                other.transform.position = handPoint.transform.position;
                other.gameObject.transform.SetParent(handPoint.gameObject.transform);
                pickedObject = other.gameObject;
            }
        }

    }
    public void Open()
    {
        if (isOpen == true)
        {

            AnimationCoroutine = StartCoroutine(DoSlidingOpen());

        }
        print(isOpen);
    }
    private IEnumerator DoSlidingOpen()
    {
        print("a");
        Vector3 endPosition = StartPosition + SlideAmount * SlideDirection;
        Vector3 startPosition = transform.position;

        float time = 0;
        isOpen = true;
        while (time < 1)
        {
            transform.position = Vector3.Lerp(startPosition, endPosition, time);
            yield return null;
            time += Time.deltaTime * Speed;
        }
    }
}
