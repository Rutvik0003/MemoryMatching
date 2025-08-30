using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    // This will store the selected value
    public static int selectedValue;

    // This function will be assigned to buttons with different values
    public void SetValueAndLoadScene(int value)
    {
        selectedValue = value;
        SceneManager.LoadScene(2);
    }
}

