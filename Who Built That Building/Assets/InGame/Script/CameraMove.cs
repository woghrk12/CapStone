using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    GameObject Target;
    Camera MainCamera;
    public GameManager Manager;
    public GameObject ScoreCanvas;
    public GameObject ReturnInGameCanvas;
    public GameObject[] BuildingPosition;

    public float MoveSpeed;
    public int BuildingNum;
    bool isFollowing;
    bool isShowing;

    Vector3 TargetPosition;
    Vector3 ReturnPosition;

    void Awake()
    {
        isFollowing = true;
        isShowing = false;
        Target = GameObject.FindGameObjectWithTag("Marker");

        MainCamera = GetComponent<Camera>();
        Rect rect = MainCamera.rect;

        float scaleheight = ((float)Screen.width / Screen.height) / ((float)16 / 9);
        float scalewidth = 1f / scaleheight;

        if (scaleheight < 1)
        {
            rect.height = scaleheight;
            rect.y = (1f - scaleheight) / 2f;
        }
        else 
        {
            rect.width = scalewidth;
            rect.x = (1f - scalewidth) / 2f;
        }

        MainCamera.rect = rect;
    }

    void Update()
    {
        if (!isShowing)
        {
            if (isFollowing) SetLand();

            TargetPosition.Set(Target.transform.position.x, Target.transform.position.y, this.transform.position.z);

            this.transform.position = Vector3.Lerp(this.transform.position, TargetPosition, MoveSpeed * Time.deltaTime);
        }
    }

    void SetLand() 
    {
        BuildingNum = Manager.LandNum;
    }

    public void FindMarker() 
    {
        isFollowing = true;
        Target = GameObject.FindGameObjectWithTag("Marker");
    }

    public void ShowMap() 
    {
        isShowing = true;

        MainCamera.transform.position = new Vector3(43, 35, -10);
        MainCamera.orthographicSize = 40f;

        ScoreCanvas.transform.position += new Vector3(0f, 0f, 60f);
        Manager.UICanvas.SetActive(false);
        ReturnInGameCanvas.SetActive(true);
    }

    public void ReturnToInGame() 
    {
        isShowing = false;
        MainCamera.orthographicSize = 10f;

        ScoreCanvas.transform.position += new Vector3(0f, 0f, -60f);
        Manager.UICanvas.SetActive(true);
        ReturnInGameCanvas.SetActive(false);
    }

    public void FindBeforeLand() 
    {
        isFollowing = false;

        BuildingNum -= 1;
        if (BuildingNum == 0) BuildingNum = Manager.MaxLandNum;
        Target = BuildingPosition[BuildingNum - 1];
    }

    public void FindAfterLand()
    {
        isFollowing = false;

        BuildingNum += 1;
        if (BuildingNum > Manager.MaxLandNum) BuildingNum = 1;
        Target = BuildingPosition[BuildingNum - 1];
    }
}
