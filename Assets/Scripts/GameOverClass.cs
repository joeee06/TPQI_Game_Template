using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameOverClass : MonoBehaviour
{
    public string sceneName = "GameScene";
    public string sceneName2 = "GameScene";
    void Start()
    {
        GameObject startBtnObj = GameObject.Find("ButtonGameOver");
        GameObject backBtnObj = GameObject.Find("BacktoTitle"); 

        if (startBtnObj != null)
        {
            Button btn = startBtnObj.GetComponent<Button>();
            if (btn != null)
            {
                btn.onClick.AddListener(LoadScene);
            }
            else
            {
                Debug.LogWarning("StartButton ไม่พบ component Button");
            }
        }
        else
        {
            Debug.LogWarning("ไม่พบ GameObject ชื่อ StartButton ใน Hierarchy");
        }

        if (backBtnObj != null)
        {
            Button btn = backBtnObj.GetComponent<Button>();
            if (btn != null)
            {
                btn.onClick.AddListener(LoadScene2);
            }
            else
            {
                Debug.LogWarning("StartButton ไม่พบ component Button");
            }
        }
        else
        {
            Debug.LogWarning("ไม่พบ GameObject ชื่อ StartButton ใน Hierarchy");
        }
    }

    public void LoadScene()
    {
        if (!string.IsNullOrEmpty(sceneName))
        {
            SceneManager.LoadScene(sceneName);
            Debug.LogWarning("เล่นใหม่");
        }
        
        else
        {
            Debug.LogWarning("sceneName ไม่ได้ถูกตั้งค่า");
        }
    }

    public void LoadScene2() // เพิ่มฟังก์ชัน LoadScene2 เพิ่อโหลด sceneName2 กลับไปยัง Title Scene
    {
        if (!string.IsNullOrEmpty(sceneName2))
        {
            SceneManager.LoadScene(sceneName2);
            Debug.LogWarning("กลับไป Main Scense");
        }

        else
        {
            Debug.LogWarning("sceneName2 ไม่ได้ถูกตั้งค่า");
        }
    }
}
