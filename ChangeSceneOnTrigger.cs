using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneOnTrigger : MonoBehaviour
{
    public string SceneToChangeTo;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(SceneToChangeTo);
        }
    }
}
