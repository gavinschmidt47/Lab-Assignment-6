using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using JetBrains.Annotations;
using Unity.Mathematics;
using UnityEngine;

public class DesertScene : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject baseObject = GameObject.CreatePrimitive(PrimitiveType.Plane);
        baseObject.transform.position = new Vector3(0, 0, 0);
        baseObject.AddComponent<Renderer>();
        baseObject.GetComponent<Renderer>().material.color = Color.yellow;

        GameObject forest = new GameObject("Forest");

        int x = UnityEngine.Random.Range(5, 10);
        for (int i = 0; i < x; i++)
        {
            int objectType = UnityEngine.Random.Range(0, 2);
            GameObject tree;
            float height = UnityEngine.Random.Range(0.8f, 2);
            if (objectType == 0)
            {
                tree = GameObject.CreatePrimitive(PrimitiveType.Cube);

                tree.transform.parent = forest.transform;
                
                tree.transform.position = new Vector3(UnityEngine.Random.Range(-4, 0), height/2, UnityEngine.Random.Range(-4, 0));
                tree.transform.localScale = new Vector3(UnityEngine.Random.Range(0.1f, 0.6f), height, UnityEngine.Random.Range(0.1f, 0.6f));

                tree.AddComponent<Renderer>();
                tree.GetComponent<Renderer>().material.color = UnityEngine.Random.ColorHSV(0.33f, 0.33f, UnityEngine.Random.Range(0.3f, 0.5f), UnityEngine.Random.Range(0.6f, 1));
            }
            else
            {
                tree = GameObject.CreatePrimitive(PrimitiveType.Cylinder);

                tree.transform.parent = forest.transform;
            
                tree.transform.position = new Vector3(UnityEngine.Random.Range(-4, 0), height, UnityEngine.Random.Range(-4, 0));
                tree.transform.localScale = new Vector3(UnityEngine.Random.Range(0.1f, 0.6f), height, UnityEngine.Random.Range(0.1f, 0.6f));

                tree.AddComponent<Renderer>();
                tree.GetComponent<Renderer>().material.color = UnityEngine.Random.ColorHSV(0.33f, 0.33f, UnityEngine.Random.Range(0.3f, 0.5f), UnityEngine.Random.Range(0.6f, 1));
            }
            
        }

        StartCoroutine(GeneratePyramid());

    }

    IEnumerator GeneratePyramid()
    {
        
        GameObject pyramid = new GameObject("Pyramid");

        for (int i = 0; i < 5; i++)
        {
            switch (i)
            {
                case 0:
                    for(int j = 0; j < 5; j++)
                    {
                        for(int k = 0; k < 5; k++)
                        {
                            yield return new WaitForSeconds(0.2f);
                            GameObject brick = GameObject.CreatePrimitive(PrimitiveType.Cube);
                            brick.transform.localScale = new Vector3(0.85f, 0.85f, 0.85f);
                            brick.transform.parent = pyramid.transform;
                            brick.transform.position = new Vector3(k, 0.425f, j);
                            brick.AddComponent<Renderer>();
                            brick.GetComponent<Renderer>().material.color = Color.red;
                        }
                    }
                    break;
                case 1:
                    for(int j = 0; j < 4; j++)
                    {
                        for(int k = 0; k < 4; k++)
                        {
                            yield return new WaitForSeconds(0.2f);
                            GameObject brick = GameObject.CreatePrimitive(PrimitiveType.Cube);
                            brick.transform.localScale = new Vector3(0.75f, 0.75f, 0.75f);
                            brick.transform.parent = pyramid.transform;
                            brick.transform.position = new Vector3(k + 0.5f, 1.25f, j + 0.5f);
                            brick.AddComponent<Renderer>();
                            brick.GetComponent<Renderer>().material.color = Color.yellow;
                        }
                    }
                    break;
                case 2:
                    for(int j = 0; j < 3; j++)
                    {
                        for(int k = 0; k < 3; k++)
                        {
                            yield return new WaitForSeconds(0.2f);
                            GameObject brick = GameObject.CreatePrimitive(PrimitiveType.Cube);
                            brick.transform.localScale = new Vector3(0.65f, 0.65f, 0.65f);
                            brick.transform.parent = pyramid.transform;
                            brick.transform.position = new Vector3(k + 1, 2f, j + 1);
                            brick.AddComponent<Renderer>();
                            brick.GetComponent<Renderer>().material.color = Color.green;
                        }
                    }
                    break;
                case 3:
                for(int j = 0; j < 2; j++)
                    {
                        for(int k = 0; k < 2; k++)
                        {
                            yield return new WaitForSeconds(0.2f);
                            GameObject brick = GameObject.CreatePrimitive(PrimitiveType.Cube);
                            brick.transform.localScale = new Vector3(0.55f, 0.55f, 0.55f);
                            brick.transform.parent = pyramid.transform;
                            brick.transform.position = new Vector3(k + 1.5f, 2.64f, j + 1.5f);
                            brick.AddComponent<Renderer>();
                            brick.GetComponent<Renderer>().material.color = Color.blue;
                        }
                    }
                    break;
                case 4:
                            yield return new WaitForSeconds(0.2f);
                            GameObject topBrick = GameObject.CreatePrimitive(PrimitiveType.Cube);
                            topBrick.transform.localScale = new Vector3(0.45f, 0.45f, 0.45f);
                            topBrick.transform.parent = pyramid.transform;
                            topBrick.transform.position = new Vector3(2, 3.22f, 2);
                            topBrick.AddComponent<Renderer>();
                            topBrick.GetComponent<Renderer>().material.color = Color.white;
                    break;
            }
        }
        yield break;
    }
}
