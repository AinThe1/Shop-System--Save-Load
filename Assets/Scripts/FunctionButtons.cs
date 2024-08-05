using UnityEngine;
using UnityEngine.SceneManagement;

public class FunctionButtons : MonoBehaviour
{
    public void ResetData()
    {
        SaveLoad.Data.money = 5000;
        SaveLoad.Data.buyItem.Clear();
        SaveLoad.Save();
        SceneManager.LoadScene(0);
    }
}
