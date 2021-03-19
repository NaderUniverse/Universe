using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ImpactPhysicsLevelLoader : MonoBehaviour
{
    public Animator transition;
    public float transitionTime =1f;
 
    // Update is called once per frame
    void Update()
    {
       
       /*  if(Input.GetMouseButtonDown(0))
        {
            LoadNextLevel();
        }
        */
    }
    
    public void  LoadNextLevel(){
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex +1));
    }

    IEnumerator LoadLevel( int levelIndex){
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(levelIndex); 
        
        if(SceneManager.GetActiveScene () == SceneManager.GetSceneByName ("SampleScene" )){
        transition.ResetTrigger("Start");
        }
    }
}
