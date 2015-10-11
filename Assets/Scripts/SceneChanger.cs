using UnityEngine;
using System.Collections;

public class SceneChanger : MonoBehaviour {

    public void ChangeToScene(string sceneToChangeTo)
    {
        Application.LoadLevel(sceneToChangeTo);
    }
}
