using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wand : MonoBehaviour
{

    private GameObject cube = null;
    private GameObject circle= null;
    private GameObject cone= null;
    private GameObject cylinder= null;
    private Collider Selected_object = null;

    //if create is selected
    private bool isSelected = false;
    private GameObject currentSelect = null;
    private GameObject formerCreate = null;

    private GameObject wand;
    private GameObject workspace;
    //private GameObject clone;
    // state 1: selection
    //2: creation
    //3: rotation
    //4: transform
    //5: scale
    //6: delete
    //7: 
    public static int state = 2;
    //

    // Use this for initialization
    void Start()
    {
        //GameObject[] creations = GameObject.FindGameObjectsWithTag("create");
        wand = GameObject.Find("wand");
        Debug.Log("wand init :"+ wand);
        cube = GameObject.Find("cube");
        circle = GameObject.Find("circle");
        cone = GameObject.Find("cone");
        cylinder = GameObject.Find("cylinder");
        workspace = GameObject.Find("GroundImageTarget");

    }

    // Mode
    public static void setState(int i){
        state = i;
    }

    // Update is called once per frame
    void Update()
    {
        //RaycastHit hit;
        //Ray downray = new Ray(transform.position, Vector3.forward);

        ////Debug.DrawLine(transform.position, endPos, Color.green, 10);
        //Debug.DrawRay(transform.position, Vector3.left * 40, Color.green);

        //if (Physics.Raycast(downray, out hit, 40))
        //{
        //    //if(hit.collider.tag == "wandtarget")
        //    //{

        //    if(state ==2){
        //        Creation(hit.collider,hit.point);
        //    };


        //    Debug.Log("Hit Something");
        //    Debug.Log(hit.distance + "; name: " + hit.collider.name+ ":  "+hit.point);
        //}

    }




    void OnTriggerEnter(Collider other)
    {

       
        Selected_object = other;
        if (other.name != "wand" && other.tag != "create" && other.tag != "f" && state ==1)
        {
            Selection(other);
        }
        else if(state ==2){
           
                Debug.Log("please select what to create");
            if (other.tag == "create")
            {
                //clear other create selection
                currentSelect = other.gameObject;

                cube.transform.GetComponent<Renderer>().material.color = Color.white;
                cone.transform.GetComponent<Renderer>().material.color = Color.white;
                cylinder.transform.GetComponent<Renderer>().material.color = Color.white;
                circle.transform.GetComponent<Renderer>().material.color = Color.white;

                other.transform.GetComponent<Renderer>().material.color = Color.red;
                isSelected = true;
            }
            else if(isSelected && other.tag == "Ground"){
                Debug.Log("create,  Ground ");
                Creation(other,currentSelect);
            };




            
        };

       

     


        //Destroy(other.gameObject);
    }


    void Selection(Collider collider){
        
        //if (collider.tag == "create")
        //{
        //    if(Selected_object!=null){
        //        Selected_object.transform.GetComponent<Renderer>().material.color = Color.white;
        //    }
            collider.transform.GetComponent<Renderer>().material.color = Color.blue;

        //}

    }

    //void Creation(Collider collider, Vector3 position){
    //    Debug.Log("##creation : "+ collider.name);
    //    //collider.transform.GetComponent<Renderer>().material.color = Color.blue;
    //    if(collider.tag == "Ground"){
    //        //Debug.Log("!!!touch ground, create object"+collider.transform.position);
    //        //four type of creation
    //        Debug.Log(collider.transform.position);
    //        //GameObject clone = Instantiate(cube, workspace.transform);
    //        GameObject clone = Instantiate(cube, workspace.transform.position,Quaternion.identity);

    //        clone.transform.SetParent(workspace.transform);

    //    };
    //}

    void Creation(Collider collider, GameObject cloneObj)
    {
        Debug.Log("##creation : " + collider.name);
        //collider.transform.GetComponent<Renderer>().material.color = Color.blue;
                
            //Debug.Log("!!!touch ground, create object"+collider.transform.position);
            //four type of creation
            Debug.Log(collider.transform.position);
            Vector3 tempPos = wand.transform.position;

            tempPos.y = 0.0f;
            //GameObject clone = Instantiate(cube, workspace.transform);
        if(formerCreate != null ){
            formerCreate.transform.GetComponent<Renderer>().material.color = Color.white;
        }

            GameObject clone = Instantiate(cloneObj, workspace.transform);

            clone.transform.position = tempPos;
             clone.tag = "userCreated";
            formerCreate = clone;

            //clone.transform.SetParent(workspace.transform);

    }

}
