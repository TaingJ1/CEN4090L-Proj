using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BootSceneManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(bootCountdown());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public IEnumerator bootCountdown()
    {
        yield return new WaitForSeconds(0.25f);
        SceneManager.LoadScene(1);
    }
}
