using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class MonsterSpawner : MonoBehaviour
{
    private List<GameObject> spawnerList = new List<GameObject>();
    private List<bool> spawnerBoolList = new List<bool>();
    
    public GameObject spawner1;
    public GameObject spawner2;
    public GameObject spawner3;
    public GameObject spawner4;
    public GameObject spawner5;

    private bool spawner1available = false;
    private bool spawner2available = false;
    private bool spawner3available = false;
    private bool spawner4available = false;
    private bool spawner5available = false;

    // Start is called before the first frame update
    void Start()
    {
        spawnerList.Add(spawner1);
        spawnerList.Add(spawner2);
        spawnerList.Add(spawner3);
        spawnerList.Add(spawner4);
        spawnerList.Add(spawner5);

        spawnerBoolList.Add(spawner1available);
        spawnerBoolList.Add(spawner2available);
        spawnerBoolList.Add(spawner3available);
        spawnerBoolList.Add(spawner4available);
        spawnerBoolList.Add(spawner5available);

        


    }

    // Update is called once per frame
    void Update()
    {
        
        

    }

   
   
}
