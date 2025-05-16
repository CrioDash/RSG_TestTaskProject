using Core.CustomCodeGeneratorModule.Scripts.Editor.Utils;

namespace Core.CustomCodeGeneratorModule.Scripts.Editor.Core {
    public static class UnityCodeGenUtility {
        public static void Generate() {
            ScriptFileGenerator.Generate();
        }

        public const string defaultFolderPath = "Assets/UnityCodeGen.Generated";
    }
}