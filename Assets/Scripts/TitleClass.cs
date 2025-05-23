using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleClass : MonoBehaviour
{
    public string sceneName = "GameScene"; // เปลี่ยนชื่อ scene ได้จาก Inspector

    void Start()
    {
        GameObject startBtnObj = GameObject.Find("StartButton");     // เปลี่ยน ชื่อ GameObject เป็น StartButton
        GameObject quitBtnObj = GameObject.Find("QuitButton");      // เพิ่ม GameObject สำหรับ QuitButton
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

        if (quitBtnObj != null) // ตรวจสอบว่า GameObject QuitButton มีอยู่ใน Hierarchy หรือไม่
        {
            Button btn = quitBtnObj.GetComponent<Button>();
            if (btn != null)
            {
                btn.onClick.AddListener(QuitGame); // เพิ่ม Listener สำหรับ QuitButton เพื่อไปฟังก์ชัน QuitGame
            }
            else
            {
                Debug.LogWarning("QuitButton ไม่พบ component Button");  // ถ้าไม่มี component Button ให้แสดง Warning
            }
        }
        else
        {
            Debug.LogWarning("ไม่พบ GameObject ชื่อ QuitButton ใน Hierarchy"); // ถ้าไม่มี GameObject ชื่อ QuitButton ให้แสดง Warning 
        }
    }

    public void LoadScene()
    {
        if (!string.IsNullOrEmpty(sceneName))
        {
            SceneManager.LoadScene(sceneName);
        }
        else
        {
            Debug.LogWarning("sceneName ไม่ได้ถูกตั้งค่า");
        }
    }

    public void QuitGame() 
    {
        #if UNITY_EDITOR // ถ้าอยู่ใน Unity Editor
            UnityEditor.EditorApplication.isPlaying = false; // ให้หยุดการเล่นใน Editor
        #else
            Application.Quit(); // ให้ออกจากเกม เมื่อ Build เกมแล้ว
        #endif

        Debug.Log("Quit Game");  // แสดงข้อความใน Console ว่า Quit Game
    }
}
