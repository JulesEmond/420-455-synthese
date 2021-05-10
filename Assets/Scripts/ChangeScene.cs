using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void btn_change_scene(int scene_id)
    {
        SceneManager.LoadScene(scene_id);
    }
}
