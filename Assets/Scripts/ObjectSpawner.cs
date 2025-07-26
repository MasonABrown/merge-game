using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public List<GameObject> objectPrefabs;
    public float spawnInterval = 2f;

    private List<GameObject> objectList = new List<GameObject>();

    private GameObject currObject;

    private void Start()
    {
        SpawnObject();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            DropNextObject();
        }
    }


    private void ListController()
    {
        while (objectList.Count < 2)
        {
            objectList.Add(GetRandomObject());
        }
    }

    private void SpawnObject()
    {
        ListController();

        //Instatiates next item on deck to spawner
        currObject = Instantiate(objectList[0], transform.position, Quaternion.identity);

        //keeps item attached to spawner until dropped
        currObject.transform.parent = transform;

        objectList.RemoveAt(0);
    }



    /*private IEnumerator SpawnObjects()
    {
        while (true)
        {
            GameObject nextObject = GetRandomObject();
            objectQueue.Enqueue(nextObject);
            Debug.Log(objectQueue.Count);   
            yield return new WaitForSeconds(spawnInterval);
        }
    }*/

    private GameObject GetRandomObject()
    {
        return objectPrefabs[Random.Range(0, objectPrefabs.Count)];
    }

    private void DropNextObject()
    {
        Transform transform = currObject.transform;
        Rigidbody2D rb = currObject.GetComponent<Rigidbody2D>();

        //Applied physics drops the ball from held point
        rb.bodyType = RigidbodyType2D.Dynamic;

        //un-parents items from spawner, causes funny issues without.
        transform.parent = null;

        SpawnObject();
    }
}