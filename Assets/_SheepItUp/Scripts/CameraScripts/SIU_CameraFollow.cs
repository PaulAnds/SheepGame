using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SIU_CameraFollow : MonoBehaviour
{
    private Transform player;

    private float damping = 2f;
    private float height = 10f;

    private Vector3 startPosition;

    private bool canFollow;

    private void Start() {
        player = GameObject.FindWithTag("Player").transform;

        startPosition = transform.position;
        
        canFollow = true;
    }

    private void Update(){
        Follow();
    }

    private void Follow(){
        if(canFollow){
            transform.position = Vector3.Lerp(transform.position,new Vector3(player.position.x + 10f, player.position.y + height, player.position.z - 10f),Time.deltaTime * damping);
        }
    }

    public bool CanFollow(){
        get
        {
            return canFollow;
        }
        set
        {
            canFollow = value;
        }
    }
}
