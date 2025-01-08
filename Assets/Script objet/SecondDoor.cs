using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondDoor : MonoBehaviour
{
    public MeshRenderer DoorRenderer;
    public BoxCollider BoxCol;

    // Start is called before the first frame update
    void Start()
    {
        DoorRenderer = GetComponent<MeshRenderer>();
        BoxCol = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CloseDoor() 
    {
        DoorRenderer.enabled = true;
        BoxCol.isTrigger = false;
    }

    public void OpenDoor()
    {
        DoorRenderer.enabled = false;
        BoxCol.isTrigger = true;
    }
}
