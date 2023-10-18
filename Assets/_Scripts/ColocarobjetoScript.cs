using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class ColocarobjetoScript : MonoBehaviour
{
    public RecogerObjeto rec;
    public Door door;
    [SerializeField]
    GameObject objetopedestal;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Objeto") && rec.pickedObject == null)
        {
            other.GetComponent<Rigidbody>().useGravity = false;
            other.GetComponent<Rigidbody>().isKinematic = false;
            other.gameObject.transform.SetParent(null);
            other.transform.position = objetopedestal.transform.position;
            other.gameObject.transform.SetParent(objetopedestal.gameObject.transform);
            door.isOpen = true;
            door.Open();
        }
    }
}
