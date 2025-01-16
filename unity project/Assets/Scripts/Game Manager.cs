using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] GameObject menuactive;
    [SerializeField] GameObject menupause;
    [SerializeField] GameObject menuwin;
    [SerializeField] GameObject menulose;

    public bool ispaused;
    int goalcount;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            if (menuactive == null)
            {
                statepause();
                menuactive = menupause;
                menupause.SetActive(true);
            }
            else if (menuactive == menupause)
            {
                stateunpause();
            }
        }
    }

    public void statepause()
    {
        ispaused = !ispaused;
        Time.timeScale = 0;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
    }

    public void stateunpause()
    {
        ispaused = !ispaused;
        Time.timeScale = 1;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        menuactive.SetActive(false);
        menuactive = null;
    }

    public void updategamegoal(int amount)
    {
        goalcount += amount;
        if (goalcount <= 0)
        {
            statepause();
            menuactive = menuwin;
            menuactive.SetActive(true);
        }
    }

    public void youlose()
    {
        statepause();
        menuactive = menulose;
        menuactive.SetActive(true);
    }
}

