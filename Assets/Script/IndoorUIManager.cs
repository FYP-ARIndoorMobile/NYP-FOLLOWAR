using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class IndoorUIManager : MonoBehaviour
{
    private IndoorUIComponent[] indoorUIComponents;

    private Vector3 LevelsUIPos, Level1UIPos, Level2UIPos, Level3UIPos, Level4UIPos;
    private bool LevelsStatus;
    private IndoorUIComponent LevelsUI, Level1UI, Level2UI, Level3UI, Level4UI;

    
    private TouchScreenKeyboard keyboard;

    private IndoorUIComponent InputBoxUI, RoomInputUI, CancelUI, OkayUI, InfoUI, ToiletUI;

    private DestinationManager destinationManager;
    private bool once;


    //private RootController rootController2;
    //[SerializeField] private GameObject Controller2;

    public GameObject PopOutObj;
    //public float PopSpeed = 4.0f;

    // Start is called before the first frame update
    void Start()
    {
        //Store all UI components
        indoorUIComponents = GetComponentsInChildren<IndoorUIComponent>();
        //rootController2 = Controller2.GetComponent<RootController>();

        //Store Level objects
        //LevelsUI = GetUIComponent("Levels");
        //Level1UI = GetUIComponent("Level 1");
        //Level2UI = GetUIComponent("Level 2");
        //Level3UI = GetUIComponent("Level 3");
        //Level4UI = GetUIComponent("Level 4");

        //Store end posiitons
        //LevelsUIPos = LevelsUI.transform.position;
        //Level1UIPos = Level1UI.transform.position;
        //Level2UIPos = Level2UI.transform.position;
        //Level3UIPos = Level3UI.transform.position;
        //Level4UIPos = Level4UI.transform.position;

        //Set position to start position
        //Level1UI.transform.position = LevelsUI.transform.position;
        //Level2UI.transform.position = LevelsUI.transform.position;
        //Level3UI.transform.position = LevelsUI.transform.position;
        //Level4UI.transform.position = LevelsUI.transform.position;

        InputBoxUI = GetUIComponent("Input Box");
        RoomInputUI = GetUIComponent("Room Input");
        CancelUI = GetUIComponent("Cancel");
        OkayUI = GetUIComponent("Okay");
        OkayUI.GetComponent<Button>().interactable = false;
        InputBoxUI.gameObject.SetActive(false);

        InfoUI = GetUIComponent("Info");
        InfoUI.GetComponent<Button>().interactable = false;
        ToiletUI = GetUIComponent("Toilet");
        ToiletUI.GetComponent<Button>().interactable = false;   
    }

    // Update is called once per frame
    void Update()
    {
        //Moving level buttons
        //MovingUI();
    }

    public void OnClick(GameObject obj)
    {
        DebugUIManager.instance.DebugLog(obj.name);
        switch (obj.name)
        {
            case "Levels":
                LevelsStatus = !LevelsStatus;
                break;
            case "Okay":
                SubmitRoom(RoomInputUI.GetComponent<TMP_InputField>().text);
                if (InputBoxUI.gameObject.activeSelf == false)
                    RoomInputUI.GetComponent<TMP_InputField>().text = "";
                InputBoxUI.gameObject.SetActive(!InputBoxUI.gameObject.activeSelf);
                break;
            case "Room Number":
            case "Cancel":
                if (InputBoxUI.gameObject.activeSelf == false)
                    RoomInputUI.GetComponent<TMP_InputField>().text = "";
                InputBoxUI.gameObject.SetActive(!InputBoxUI.gameObject.activeSelf);
                break;
            case "Room Input":
                RoomInput();            
                break;
            case "Info":
                destinationManager.Reset();
                destinationManager.Reset2();

                destinationManager.TogglePointOfInterets();
                break;
            case "Reset":
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

    /*
    private void MovingUI()
    {
        if (LevelsStatus == true)
        {
            //Move out
            Level1UI.transform.position = Vector3.Lerp(Level1UI.transform.position, Level1UIPos, Time.deltaTime * PopSpeed);
            Level2UI.transform.position = Vector3.Lerp(Level2UI.transform.position, Level2UIPos, Time.deltaTime * PopSpeed);
            Level3UI.transform.position = Vector3.Lerp(Level3UI.transform.position, Level3UIPos, Time.deltaTime * PopSpeed);
            Level4UI.transform.position = Vector3.Lerp(Level4UI.transform.position, Level4UIPos, Time.deltaTime * PopSpeed);
        }
        else
        {
            //Move in
            Level1UI.transform.position = Vector3.Lerp(Level1UI.transform.position, LevelsUIPos, Time.deltaTime * PopSpeed);
            Level2UI.transform.position = Vector3.Lerp(Level2UI.transform.position, LevelsUIPos, Time.deltaTime * PopSpeed);
            Level3UI.transform.position = Vector3.Lerp(Level3UI.transform.position, LevelsUIPos, Time.deltaTime * PopSpeed);
            Level4UI.transform.position = Vector3.Lerp(Level4UI.transform.position, LevelsUIPos, Time.deltaTime * PopSpeed);
        }
    }
    */

    /*
    private void RoomInput()
    {
        if (keyboard == null)
            keyboard = TouchScreenKeyboard.Open("", TouchScreenKeyboardType.NumberPad, false, false, false, false, "Input 3 digit room number", 3);
        else
            keyboard = TouchScreenKeyboard.Open(keyboard.text, TouchScreenKeyboardType.NumberPad, false, false, false, false, "Input 3 digit room number", 3);
    }
    */

    private void RoomInput()
    {
        //Check input
        if (RoomInputUI.GetComponent<TMP_InputField>().text.Length < 4)
            OkayUI.GetComponent<Button>().interactable = false;
        else
            OkayUI.GetComponent<Button>().interactable = true;
    }

    private void SubmitRoom(string roomNum)
    {
        //Tranlate door number to door game object
        string buttonCode ="";
        switch (roomNum)
        {
            case "0601":
                buttonCode = "R_Door1";
                break;
            case "0615":
                buttonCode = "R_Door2";
                break;
            case "0602":
                buttonCode = "R_Door3";
                break;
            case "0603":
                buttonCode = "R_Door4";
                break;
            //case "0615":
            //    buttonCode = "R_Door5";
            //   break;
            case "0614":
                buttonCode = "R_Door6";
                break;
            case "0604":
                buttonCode = "R_Door7";
                break;
            case "0605":
                buttonCode = "R_Door8";
                break;
            case "0606":
                buttonCode = "R_Door9";
                break;
            //case "0614":
            //    buttonCode = "R_Door10";
            //    break;
            case "0607":
                buttonCode = "R_Door11";
                break;
            case "0608":
                buttonCode = "R_Door12";
                break;
            case "0610":
                buttonCode = "R_Door13";
                break;

            case "0622":
                buttonCode = "L_Door1";
                break;
            case "0623":
                buttonCode = "L_Door2";
                break;
            //case "0615":
            //    buttonCode = "L_Door3";
            //    break;
            case "0625":
                buttonCode = "L_Door4";
                break;
            case "0624":
                buttonCode = "L_Door5";
                break;
            case "0626":
                buttonCode = "L_Door6";
                break;
            case "0613":
                buttonCode = "L_Door7";
                break;
            case "0627":
                buttonCode = "L_Door8";
                break;
        }
        destinationManager.DestinationSelect(buttonCode);
    }

    public void SetDestinationManager(DestinationManager DM)
    {
        destinationManager = DM;
        InfoUI.GetComponent<Button>().interactable = true;
        ToiletUI.GetComponent<Button>().interactable = true;
    }
}
