﻿using BeatSaberMarkupLanguage.Components;
using BeatSaberMarkupLanguage.Components.Settings;
using BS_Utils.Utilities;
using HMUI;
using System;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace BeatSaberMarkupLanguage.Tags.Settings
{
    public class DropdownListSettingTag : BSMLTag
    {
        public override string[] Aliases => new[] { "temp-disabled-dropdown-list-setting" };

        private LabelAndValueDropdownWithTableView safePrefab;
        public override void Setup()
        {
            safePrefab = MonoBehaviour.Instantiate(Resources.FindObjectsOfTypeAll<LabelAndValueDropdownWithTableView>().First(x => x.name == "NormalLevels"), null, false);
            safePrefab.gameObject.SetActive(false);
            safePrefab.name = "BSMLDropDownListPrefab";
        }

        public override GameObject CreateObject(Transform parent)
        {
            LabelAndValueDropdownWithTableView dropdown = MonoBehaviour.Instantiate(safePrefab, parent, false);
            dropdown.gameObject.SetActive(false);
            dropdown.name = "BSMLDropDownList";
            TextMeshProUGUI text = dropdown.GetPrivateField<TextMeshProUGUI>("_labelText");
            text.fontSize = 5;
            dropdown.gameObject.AddComponent<ExternalComponents>().components.Add(text);

            LayoutElement layoutElement = dropdown.gameObject.AddComponent<LayoutElement>();
            layoutElement.preferredHeight = 8;
            layoutElement.preferredWidth = 90;
            dropdown.SetLabelText("Default Text");
            dropdown.SetValueText("Default Text");

            DropDownListSetting dropDownListSetting = dropdown.gameObject.AddComponent<DropDownListSetting>();
            dropDownListSetting.tableView = dropdown.GetPrivateField<TableView>("_tableView");
            dropDownListSetting.dropdown = dropdown;
            dropDownListSetting.tableView.dataSource = dropDownListSetting;

            return dropdown.gameObject;
        }
    }
}
