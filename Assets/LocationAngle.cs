using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationAngle : MonoBehaviour
{
    Transform planet;


    void Start(){
        planet=GameObject.Find("Planet").transform;
        this.transform.LookAt(planet);
        this.GetComponent<MeshRenderer>().enabled=false;
    }
}
