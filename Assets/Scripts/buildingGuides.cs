using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buildingGuides : MonoBehaviour
{
    Outline outline;
    structureManagement sm;
    public int cost;
    public bool selected;
    bool over;
    void Start(){
        sm=GameObject.Find("Management").GetComponent<structureManagement>();
        outline=this.GetComponent<Outline>();
        outline.enabled=false;
    }
    void FixedUpdate(){
        if(sm.targets.Contains(this.gameObject)){
            selected=true;
        }else if(over){
            selected=true;
        }else{
            selected=false;
        }
        if(!selected){
            outline.enabled=false;
        }else{
            outline.enabled=true;
        }
    }
    void OnMouseOver(){
        over=true;
        selected=true;
        outline.OutlineColor=Color.red;
        if(Input.GetMouseButtonDown(0)&&Input.GetKey(KeyCode.LeftControl)){
            sm.LinkToTargets(this.gameObject);
        }else if(Input.GetMouseButtonDown(0)){
            sm.ClearTargets();
            sm.LinkToTargets(this.gameObject);
        }
        if(Input.GetMouseButtonDown(1)&&Input.GetKey(KeyCode.LeftControl)){
            sm.RemoveFromTargets(this.gameObject);
        }
    }
    void OnMouseExit(){
        over=false;
        if(!sm.targets.Contains(this.gameObject)){
            selected=false;
        }
    }
}
