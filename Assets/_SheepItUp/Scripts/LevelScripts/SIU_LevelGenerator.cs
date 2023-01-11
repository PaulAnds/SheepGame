using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SIU_LevelGenerator : MonoBehaviour
{
#region Variables
    [SerializeField]
    private GameObject startPlatform, endPlatform, platformPrefab;

    private float blockWidth = 0.5f;
    private float blockHeight = 0.2f;

    [Header("Cantidad de Plataformas a generar")]
    [SerializeField]
    private int amountToSpawn = 100;
    private int startAmount = 0;

    private Vector3 lastPosition;

    private List<GameObject> spawnedPlatforms = new List<GameObject>();

    [Header("Prefab de Jugador")]
    [SerializeField]
    private GameObject playerPrefab;

#endregion

    private void Awake(){
        InstantiateLevel();
    }

    void InstantiateLevel(){
        for (int i = startAmount; i < amountToSpawn; i++)
        {
            GameObject _newPlatform;
            if(i == 0){
                _newPlatform = Instantiate(startPlatform);
            }
            else if(i == amountToSpawn - 1){
                _newPlatform = Instantiate(endPlatform);
                _newPlatform.tag = "EndPlatform";
            }
            else{
                _newPlatform = Instantiate(platformPrefab);
            }

            _newPlatform.transform.parent = transform;
            spawnedPlatforms.Add(_newPlatform);

            if(i == 0){
                lastPosition = _newPlatform.transform.position;
                
                continue;
            }

            int _left = Random.Range(0,2);

            if(_left == 0){
                _newPlatform.transform.position = new Vector3(lastPosition.x - blockWidth, lastPosition.y + blockHeight, lastPosition.z);
            }
            else{
                _newPlatform.transform.position = new Vector3(lastPosition.x, lastPosition.y + blockHeight, lastPosition.z + blockWidth);
            }

            lastPosition = _newPlatform.transform.position;

            //animaciones, animar las primeras 25 plataformas
            if(i < 25){
                float _endPosY = _newPlatform.transform.position.y;

                _newPlatform.transform.position = new Vector3(_newPlatform.transform.position.x, _newPlatform.transform.y - blockHeight * 3f, _newPlatform.transform.position.z);
                
            }
        }
    }

}
