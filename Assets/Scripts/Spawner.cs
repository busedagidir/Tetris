using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    //tetrominolari inspectorda cekmek icin
    public GameObject[] groups;


    // Start is called before the first frame update
    void Start()
    {
        SpawnNext();   
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void SpawnNext()
    {
        int i = Random.Range(0, groups.Length);

        Instantiate(groups[i], transform.position, Quaternion.identity);
    }
}
