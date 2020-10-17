using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetResolution : MonoBehaviour
{
    Dropdown mdropdown;
    private void Start()
    {
        mdropdown = GetComponent<Dropdown>();
        mdropdown.onValueChanged.AddListener(delegate
        {
            DropdownValueChanged(mdropdown);
        });
    }

    public void DropdownValueChanged(Dropdown change)
    {
        if(change.value == 0)
        {
            ChangeResolution1();
        }
        else if(change.value == 1)
        {
            ChangeResolution2();
        }
        else if (change.value == 2)
        {
            ChangeResolution3();
        }
        else if (change.value == 3)
        {
            ChangeResolution4();
        }
        else if (change.value == 4)
        {
            ChangeResolution5();
        }
        else if (change.value == 5)
        {
            ChangeResolution6();
        }
        else if (change.value == 6)
        {
            ChangeResolution7();
        }
        else if (change.value == 7)
        {
            ChangeResolution8();
        }
        else if (change.value == 8)
        {
            ChangeResolution9();
        }
        else if (change.value == 9)
        {
            ChangeResolution10();
        }
        else if (change.value == 10)
        {
            ChangeResolution11();
        }
        else if (change.value == 11)
        {
            ChangeResolution12();
        }
        else if (change.value == 12)
        {
            ChangeResolution13();
        }
        else if (change.value == 13)
        {
            ChangeResolution14();
        }
        else if (change.value == 14)
        {
            ChangeResolution15();
        }
        else if (change.value == 15)
        {
            ChangeResolution16();
        }
    }
    public void ChangeResolution1()
    {
        if(Screen.fullScreen)
            Screen.SetResolution(640, 480, true);
        else
            Screen.SetResolution(640, 480, false);
    }
    public void ChangeResolution2()
    {
        if (Screen.fullScreen)
            Screen.SetResolution(800, 600, true);
        else
            Screen.SetResolution(800, 600, false);
    }
    public void ChangeResolution3()
    {
        if (Screen.fullScreen)
            Screen.SetResolution(1024, 768, true);
        else
            Screen.SetResolution(1024, 768, false);
    }
    public void ChangeResolution4()
    {
        if (Screen.fullScreen)
            Screen.SetResolution(1152, 864, true);
        else
            Screen.SetResolution(1152, 864, false);
    }
    public void ChangeResolution5()
    {
        if (Screen.fullScreen)
            Screen.SetResolution(1176, 664, true);
        else
            Screen.SetResolution(1176, 664, false);
    }
    public void ChangeResolution6()
    {
        if (Screen.fullScreen)
            Screen.SetResolution(1280, 720, true);
        else
            Screen.SetResolution(1280, 720, false);
    }
    public void ChangeResolution7()
    {
        if (Screen.fullScreen)
            Screen.SetResolution(1280, 800, true);
        else
            Screen.SetResolution(1280, 800, false);
    }
    public void ChangeResolution8()
    {
        if (Screen.fullScreen)
            Screen.SetResolution(1280, 960, true);
        else
            Screen.SetResolution(1280, 960, false);
    }
    public void ChangeResolution9()
    {
        if (Screen.fullScreen)
            Screen.SetResolution(1360, 768, true);
        else
            Screen.SetResolution(1360, 768, false);
    }
    public void ChangeResolution10()
    {
        if (Screen.fullScreen)
            Screen.SetResolution(1366, 768, true);
        else
            Screen.SetResolution(1366, 768, false);
    }
    public void ChangeResolution11()
    {
        if (Screen.fullScreen)
            Screen.SetResolution(1400, 1050, true);
        else
            Screen.SetResolution(1400, 1050, false);
    }
    public void ChangeResolution12()
    {
        if (Screen.fullScreen)
            Screen.SetResolution(1440, 900, true);
        else
            Screen.SetResolution(1440, 900, false);
    }
    public void ChangeResolution13()
    {
        if (Screen.fullScreen)
            Screen.SetResolution(1600, 900, true);
        else
            Screen.SetResolution(1600, 900, false);
    }
    public void ChangeResolution14()
    {
        if (Screen.fullScreen)
            Screen.SetResolution(1600, 1024, true);
        else
            Screen.SetResolution(1600, 1024, false);
    }
    public void ChangeResolution15()
    {
        if (Screen.fullScreen)
            Screen.SetResolution(1680, 1050, true);
        else
            Screen.SetResolution(1680, 1050, false);
    }
    public void ChangeResolution16()
    {
        if (Screen.fullScreen)
            Screen.SetResolution(1920, 1080, true);
        else
            Screen.SetResolution(1920, 1080, false);
    }

}
