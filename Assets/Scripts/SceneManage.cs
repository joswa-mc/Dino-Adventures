using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManage : MonoBehaviour
{
    public void StartRun()
    {
        GameObject.Find("Switch").GetComponent<GameManage>().ChangeScene(1);
        SceneManager.LoadSceneAsync(1);
    }
}
