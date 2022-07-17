using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SpaceshipScript : MonoBehaviour
{
    Vector3 startPosition;
    bool didSceneEnd = false;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(didSceneEnd)
        {
            gameObject.transform.position = startPosition;
            didSceneEnd = false;
        }

        if(gameObject.transform.position.z > 60 || gameObject.transform.position.y < -4)
        {
            //losing
            didSceneEnd = true;
            SceneManager.LoadScene(5);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            didSceneEnd = true;
            NextLevel();
        }
    }

    private void NextLevel()
    {
        SceneManager.LoadScene(2);
    }
}
