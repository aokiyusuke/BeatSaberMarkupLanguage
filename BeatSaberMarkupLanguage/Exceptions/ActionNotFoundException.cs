﻿namespace BeatSaberMarkupLanguage
{
    public class ActionNotFoundException : BSMLException
    {
        internal ActionNotFoundException(string valueName, object host)
            : base($"Value '{valueName}' not found on object of type {host.GetType().FullName}")
        {
            this.ValueName = valueName;
            this.Host = host;
        }

        public string ValueName { get; }

        public object Host { get; }
    }
}
