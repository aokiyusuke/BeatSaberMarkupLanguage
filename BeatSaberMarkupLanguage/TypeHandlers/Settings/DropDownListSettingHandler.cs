﻿using System.Collections;
using System.Collections.Generic;
using BeatSaberMarkupLanguage.Components.Settings;
using BeatSaberMarkupLanguage.Parser;
using static BeatSaberMarkupLanguage.BSMLParser;

namespace BeatSaberMarkupLanguage.TypeHandlers.Settings
{
    [ComponentHandler(typeof(DropDownListSetting))]
    public class DropDownListSettingHandler : TypeHandler
    {
        public override Dictionary<string, string[]> Props => new()
        {
            { "options", new[] { "options", "choices" } },
        };

        public override void HandleType(ComponentTypeWithData componentType, BSMLParserParams parserParams)
        {
            DropDownListSetting listSetting = componentType.component as DropDownListSetting;
            if (componentType.data.TryGetValue("options", out string options))
            {
                if (!parserParams.values.TryGetValue(options, out BSMLValue values))
                {
                    throw new ValueNotFoundException(options, parserParams.host);
                }

                listSetting.values = values.GetValueAs<IList>();
            }
            else
            {
                throw new MissingAttributeException(this, "options");
            }
        }
    }
}
