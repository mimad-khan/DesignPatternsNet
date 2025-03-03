using System.Collections.Generic;

namespace DesignPatternsNet.Creational.Singleton
{
    /// <summary>
    /// Singleton configuration manager for application settings
    /// </summary>
    public sealed class AppConfigurationManager
    {
        // The single instance of the class
        private static AppConfigurationManager? _instance;
        
        // Lock object for thread safety
        private static readonly object _lock = new();
        
        // Dictionary to store configuration settings
        private readonly Dictionary<string, string> _settings;
        
        // Private constructor to prevent direct instantiation
        private AppConfigurationManager()
        {
            _settings = new Dictionary<string, string>();
            LoadDefaultSettings();
        }
        
        // Public method to get the singleton instance
        public static AppConfigurationManager Instance
        {
            get
            {
                // Double-check locking pattern
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new AppConfigurationManager();
                        }
                    }
                }
                return _instance;
            }
        }
        
        // Load some default settings
        private void LoadDefaultSettings()
        {
            _settings["Theme"] = "Light";
            _settings["Language"] = "English";
            _settings["FontSize"] = "12";
            _settings["LogLevel"] = "Info";
        }
        
        // Get a configuration setting
        public string GetSetting(string key)
        {
            if (_settings.TryGetValue(key, out var value))
            {
                return value;
            }
            return string.Empty;
        }
        
        // Set a configuration setting
        public void SetSetting(string key, string value)
        {
            _settings[key] = value;
        }
        
        // Get all settings
        public Dictionary<string, string> GetAllSettings()
        {
            return new Dictionary<string, string>(_settings);
        }
        
        // Clear all settings and reset to defaults
        public void ResetToDefaults()
        {
            _settings.Clear();
            LoadDefaultSettings();
        }
    }
}
