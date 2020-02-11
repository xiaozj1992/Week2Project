using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public GameObject settingButton;//左上角按钮
    public GameObject[] childButton;//菜单里的按钮
    public GameObject pausePanel;//暂停后的全屏蒙版
    public GameObject settingMenu;//设置窗口
    public GameObject[] childMenu;//子菜单窗口

    void Start()
    {


        SetButtons();
    }

    // Update is called once per frame
    void Update()
    {
    }
    void SetButtons()
    {


       
        //左上角菜单,设置状态,开启窗口
        settingButton.GetComponent<Button>().onClick.AddListener(() =>
        {
            Global.isPause = true;
            pausePanel.SetActive(true);
            settingMenu.SetActive(true);
            //Debug.Log("弹出菜单");
        });
        //蒙版什么也不做
        pausePanel.GetComponent<Button>().onClick.AddListener(() =>
        {

        });
        //继续游戏,设置状态,关闭窗口
        childButton[0].GetComponent<Button>().onClick.AddListener(() =>
        {
            Global.isPause = false;
            settingMenu.SetActive(false);
            pausePanel.SetActive(false);
        });
        //进入设置,开关窗口
        //childButton[1].GetComponent<Button>().onClick.AddListener(() =>
        //{
        //    settingMenu.SetActive(false);
        //    childMenu[0].SetActive(true);
        //});

        //返回标题界面,加载场景
        childButton[2].GetComponent<Button>().onClick.AddListener(() =>
        {
            SceneManager.LoadSceneAsync("Title");
        });
        //退出游戏
        childButton[3].GetComponent<Button>().onClick.AddListener(() =>
        {
            Application.Quit();
        });

    }
}
