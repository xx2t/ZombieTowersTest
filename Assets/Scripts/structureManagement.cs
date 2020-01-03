using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class structureManagement : MonoBehaviour
{
    public List<GameObject> targets;
    public int cost;
    public void LinkToTargets(GameObject selected){
        if(targets.Count==0){
            cost=0;
            targets.Add(selected);
            Debug.Log(selected.name +"added");
            cost+=selected.GetComponent<buildingGuides>().cost;
        }else{
            targets.Add(selected);
            Debug.Log(selected.name +"added");
            cost+=selected.GetComponent<buildingGuides>().cost;
        }
    }
    void Update(){
        if(Input.GetMouseButtonDown(1)&&!Input.GetKey(KeyCode.LeftControl)){
            ClearTargets();
        }
    }
    public void RemoveFromTargets(GameObject selected){
        if(targets.Contains(selected)){
            targets.Remove(selected);
        }
    }
    public void ClearTargets(){
        foreach(GameObject selected in targets){
            targets.Remove(selected);
        }
    }
}
