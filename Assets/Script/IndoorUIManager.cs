using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndoorUIManager : MonoBehaviour
{
    private IndoorUIComponent[] indoorUIComponents;

    private Vector3 LevelsUIPos, Level1UIPos, Level2UIPos, Level3UIPos, Level4UIPos;
    private bool LevelsStatus;
    private IndoorUIComponent LevelsUI, Level1UI, Level2UI, Level3UI, Level4UI;
    public float LevelsSpeed = 1.0f;

    private TouchScreenKeyboard keyboard;

    // Start is called before the first frame update
    void Start()
    {
        //Store all UI components
        indoorUIComponents = GetComponentsInChildren<IndoorUIComponent>();

        //Store Level objects
        LevelsUI = GetUIComponent("Levels");
        Level1UI = GetUIComponent("Level 1");
        Level2UI = GetUIComponent("Level 2");
        Level3UI = GetUIComponent("Level 3");
        Level4UI = GetUIComponent("Level 4");

        //Store end posiitons
        LevelsUIPos = LevelsUI.transform.position;
        Level1UIPos = Level1UI.transform.position;
        Level2UIPos = Level2UI.transform.position;
        Level3UIPos = Level3UI.transform.position;
        Level4UIPos = Level4UI.transform.position;

        //Set position to start position
        Level1UI.transform.position = LevelsUI.transform.position;
        Level2UI.transform.position = LevelsUI.transform.position;
        Level3UI.transform.position = LevelsUI.transform.position;
        Level4UI.transform.position = LevelsUI.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //Moving level buttons
        MovingUI();      
    }

    public void OnClick(GameObject obj)
    {
        Debug.Log(obj.name);
        switch (obj.name)
        {
            case "Levels":
                LevelsStatus = !LevelsStatus;
                break;
            case "Test":
                RoomInput();
                break;
        }
    }

    //Find UI componenets from their name
    private IndoorUIComponent GetUIComponent(string name)
    {
        foreach (IndoorUIComponent component in indoorUIComponents)
        {
            if (component.name == name)
                return component;
        }
        return null;
    }

    private void MovingUI()
    {
        if (LevelsStatus == true)
        {
            //Move out
            Level1UI.transform.position = Vector3.Lerp(Level1UI.transform.position, Level1UIPos, Time.deltaTime * LevelsSpeed);
            Level2UI.transform.position = Vector3.Lerp(Level2UI.transform.position, Level2UIPos, Time.deltaTime * LevelsSpeed);
            Level3UI.transform.position = Vector3.Lerp(Level3UI.transform.position, Level3UIPos, Time.deltaTime * LevelsSpeed);
            Level4UI.transform.position = Vector3.Lerp(Level4UI.transform.position, Level4UIPos, Time.deltaTime * LevelsSpeed);
        }
        else
        {
            //Move in
            Level1UI.transform.position = Vector3.Lerp(Level1UI.transform.position, LevelsUIPos, Time.deltaTime * LevelsSpeed);
            Level2UI.transform.position = Vector3.Lerp(Level2UI.transform.position, LevelsUIPos, Time.deltaTime * LevelsSpeed);
            Level3UI.transform.position = Vector3.Lerp(Level3UI.transform.position, LevelsUIPos, Time.deltaTime * LevelsSpeed);
            Level4UI.transform.position = Vector3.Lerp(Level4UI.transform.position, LevelsUIPos, Time.deltaTime * LevelsSpeed);
        }
    }

    private void RoomInput()
    {
        if (keyboard == null)
            keyboard = TouchScreenKeyboard.Open("", TouchScreenKeyboardType.NumberPad, false, false, false, false, "Input 3 digit room number", 3);
        else
            keyboard = TouchScreenKeyboard.Open(keyboard.text, TouchScreenKeyboardType.NumberPad, false, false, false, false, "Input 3 digit room number", 3);
    }
}
