using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillData : MonoBehaviour {
    [SerializeField] private string skillName;
    [SerializeField][TextArea] private string skillDesc;
    [SerializeField] private Texture skillIcon;

    public string GetSkillName() {
        return this.skillName;
    }

    public string GetSkillDesc() {
        return this.skillDesc;
    }

    public Texture GetSkillIcon() {
        return this.skillIcon;
    }
    
}
