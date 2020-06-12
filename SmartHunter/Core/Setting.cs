using System.Collections.Generic;

namespace SmartHunter.Core
{
    public class Setting
    {
        public bool Value { get; set; }
        public string Name { get; }
        public string Description { get; }
        public List<Setting>SubSettings { get; }
        public Command TriggerAction { get; }
        public Setting(bool value, string name, string description, Command action = null)
        {
            Value = value;
            Name = name;
            Description = description;
            SubSettings = new List<Setting>();
            TriggerAction = action;
        }
    }
}
