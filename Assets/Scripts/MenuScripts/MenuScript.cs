using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public Canvas quitMenu;
    public Button playBtn;
    public Button exitBtn;

    // Start is called before the first frame update
    void Start()
    {
        quitMenu.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ExitPress()
    {
        quitMenu.enabled = true;
        playBtn.enabled = false;
        exitBtn.enabled = false;
    }

    public void NoPress()
    {
        quitMenu.enabled = false;
        playBtn.enabled = true;
        exitBtn.enabled = true;
    }

    public void StartLevel()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
