using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeroData: MonoBehaviour {
    [SerializeField] private string heroName;
    [SerializeField][TextArea] private string heroDesc;
    [SerializeField] private Texture heroIcon;

    [SerializeField] private SkillData[] skillset;

    public string GetHeroName() {
        return this.heroName;
    }

    public string GetHeroDesc() {
        return this.heroDesc;
    }

    public Texture GetHeroIcon() {
        return this.heroIcon;
    }

    public SkillData[] GetSkillData() {
        return this.skillset;
    }

    
}
