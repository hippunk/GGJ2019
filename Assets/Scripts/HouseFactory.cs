using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseFactory : MonoBehaviour
{
    public GameObject camera;
    public List<GameObject> pool;
    public GameObject currentObject;
    public Vector3 genPos = new Vector3(0, 20, 0);


    private static HouseFactory instance = null;

    public void Start()
    {
        instance = this;
        Generate();
    }

    public static HouseFactory GetInstance()
    {
        return instance;
    }

    public void InitGenerateWithDelay(float delay)
    {
        if (enabled == true)
        {
            StartCoroutine(instance.GenerateWithDelay(delay));
        }
    }

    public IEnumerator GenerateWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Generate();
    }

    public static void Generate()
    {
        GameObject gen = instance.pool[Random.Range(0, instance.pool.Count)];

        instance.currentObject = Instantiate(gen);
        instance.currentObject.transform.position = instance.genPos;
        GameObject group = instance.currentObject.GetComponent<GroupAccess>().group;
        instance.camera.GetComponent<CameraTracker>().trackedObject = group;
    }
}
