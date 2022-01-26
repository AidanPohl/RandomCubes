/***
 * Created by: Aidan Pohl (#1539290)
 * Date Created: Jan 24, 2022
 * 
 * Last Edited by: N/A     
 * Last Edited: Jan 26, 2022
 * 
 * Description: Spawns multiple cube prefabs into scene
 ****/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomCubes : MonoBehaviour
{
    /***VARIABLES***/
    public GameObject cubePrefab; //BEHOLD A CUBE
    public float scalingFactor = 0.95f; //Cube enbiggening factor
    public int numberOfCubes = 0; //Census of the multitudes.
    [HideInInspector]
    public List<GameObject> gameObjectList; //List of all Cubes




    // Start is called before the first frame update
    void Start()
    {
        gameObjectList = new List<GameObject>();//instantiate the list.
    }//end Start()

    // Update is called once per frame
    void Update()
    {
        numberOfCubes++; //Increment the number of Cubes
        GameObject gObj = Instantiate<GameObject>(cubePrefab);//Instantiate new Cube

        gObj.name = "Cube #"+numberOfCubes; //Name the newborn Cube

        gObj.transform.position = Random.insideUnitSphere; // Random point inside a Sphere with
                                                           // radius of one centered on the Spawner.

        Color randomColor = new Color(Random.value, Random.value, Random.value); //Craft a new hue out of randomness
        gObj.GetComponent<Renderer>().material.color = randomColor; //Annoint the cube with the ramdomColor

        gameObjectList.Add(gObj); //Add Cube to List

        List<GameObject> removeList = new List<GameObject>(); //list of game objects to remove

        foreach(GameObject goTemp in gameObjectList)
        {
            float scale = goTemp.transform.localScale.x; //record starting scale
            scale *= scalingFactor; //set scale mulitplied by scalingFactor
            goTemp.transform.localScale = Vector3.one * scale;//transforms the scale

            if(scale <= 0.1f)
            {
                removeList.Add(goTemp);

            }//end if(scale <= 0.1f)

        }//end foreach(GameObject goTemp in gameObjectList)

        foreach (GameObject goTemp in removeList)
        {
            gameObjectList.Remove(goTemp); //remove from gameObjectList
            Destroy(goTemp); //Remove the Cube from the schene. Send it unto the Void.

        }//end foreach (GameObject goTemp in removeList)
    }//end Update()

}//end class

// No Spheres were harmed in the programming of this script.
// Many Cubes however, died horribly.

