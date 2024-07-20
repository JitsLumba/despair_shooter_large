using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class helppanelcall : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject main_menu_ui;
    [SerializeField] private GameObject main_tutorial_panel;
    [SerializeField] private GameObject ui_tutorial;
    [SerializeField] private GameObject control_tutorial;
    [SerializeField] private GameObject normal_enemy_tutorial;
    [SerializeField] private GameObject break_tutorial;
    [SerializeField] private GameObject metal_enemy_tutorial;
    [SerializeField] private GameObject elec_tutorial;
    [SerializeField] private GameObject bomber_enemy_tutorial;
    [SerializeField] private GameObject knockback_tutorial;
    private GameObject current_hold_object;
    private bool has_hold_object = false;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && has_hold_object) {
            return_to_main_menu();
        }
    }
    public void callhelp()
    {
        main_menu_ui.SetActive(false);
        main_tutorial_panel.SetActive(true);
        current_hold_object = ui_tutorial;
        has_hold_object = true;
        switch_tutorial_panel(0);
    }
    public void switch_tutorial_panel(int panel_num) {
        current_hold_object.SetActive(false);
        if (panel_num == 0) {
            
            ui_tutorial.SetActive(true);
            current_hold_object = ui_tutorial;
        }
        else if (panel_num == 1) {
            control_tutorial.SetActive(true);
            current_hold_object = control_tutorial;
        }
        else if (panel_num == 2) {
            normal_enemy_tutorial.SetActive(true);
            current_hold_object = normal_enemy_tutorial;
        }
        else if (panel_num == 3) {
            break_tutorial.SetActive(true);
            current_hold_object = break_tutorial;
        }
        else if (panel_num == 4) {
            metal_enemy_tutorial.SetActive(true);
            current_hold_object = metal_enemy_tutorial;
        }
        else if (panel_num == 5) {
            elec_tutorial.SetActive(true);
            current_hold_object = elec_tutorial;
        }
        else if (panel_num == 6) {
            bomber_enemy_tutorial.SetActive(true);
            current_hold_object = bomber_enemy_tutorial;
        }
        else if (panel_num == 7) {
            knockback_tutorial.SetActive(true);
            current_hold_object = knockback_tutorial;
        }
    }
    public void return_to_main_menu() {
        has_hold_object = false;
        current_hold_object.SetActive(false);
        ui_tutorial.SetActive(false);
        control_tutorial.SetActive(false);
        normal_enemy_tutorial.SetActive(false);
        break_tutorial.SetActive(false);
        metal_enemy_tutorial.SetActive(false);
        elec_tutorial.SetActive(false);
        bomber_enemy_tutorial.SetActive(false);
        knockback_tutorial.SetActive(false);
        main_tutorial_panel.SetActive(false);
        main_menu_ui.SetActive(true);
    }
}
