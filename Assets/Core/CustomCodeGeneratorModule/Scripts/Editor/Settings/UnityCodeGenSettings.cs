using UnityEditor;

namespace Core.CustomCodeGeneratorModule.Scripts.Editor.Settings {
    public static class UnityCodeGenSettings {
        public static bool autoGenerateOnCompile {
            get {
                if (bool.TryParse(EditorUserSettings.GetConfigValue(KEY_GENERATE_ON_COMPILE), out bool result))
                    return result;

                return false;
            }
            set =>
                EditorUserSettings.SetConfigValue(KEY_GENERATE_ON_COMPILE, value.ToString());
        }
        private const string KEY_GENERATE_ON_COMPILE = "UnityCodeGen-AutoGenerateOnCompile";
    }
}