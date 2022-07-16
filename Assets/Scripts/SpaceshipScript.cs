using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SpaceshipScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.transform.position.y > 10 || gameObject.transform.position.y < 10)
        {
            //losing
            SceneManager.LoadScene(5);
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            NextLevel();
        }
    }

    private void NextLevel()
    {
        SceneManager.LoadScene(2);
    }
}
