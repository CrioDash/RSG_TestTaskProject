using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Core.CustomCodeGeneratorModule.Scripts.Editor.Core;
using Core.CustomCodeGeneratorModule.Scripts.Editor.Settings;
using UnityEditor;

namespace Core.CustomCodeGeneratorModule.Scripts.Editor.Utils {
    internal static class ScriptFileGenerator {
        internal static void Generate() {
            IEnumerable<Type> generatorTypes = TypeCache.GetTypesDerivedFrom<ICodeGenerator>().Where(x => !x.IsAbstract && x.GetCustomAttribute<GeneratorAttribute>() != null);

            bool changed = false;
            foreach (Type generatorType in generatorTypes) {
                ICodeGenerator generator = (ICodeGenerator)Activator.CreateInstance(generatorType);
                GeneratorContext context = new();
                generator.Execute(context);

                if (GenerateScriptFromContext(context))
                    changed = true;
            }

            if (!changed)
                return;

            AssetDatabase.Refresh();
            AssetDatabase.SaveAssets();
        }

        [InitializeOnLoadMethod]
        private static void Initialize() {
            if (UnityCodeGenSettings.autoGenerateOnCompile)
                Generate();
        }

        private static bool GenerateScriptFromContext(GeneratorContext context) {
            bool changed = false;

            string folderPath = context.overrideFolderPath ?? UnityCodeGenUtility.defaultFolderPath;

            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);

            foreach (CodeText code in context.codeList) {
                string[] hierarchy = code.fileName.Split('/');
                string path = folderPath;
                for (int i = 0; i < hierarchy.Length; i++) {
                    path += "/" + hierarchy[i];
                    if (i == hierarchy.Length - 1)
                        break;

                    if (!Directory.Exists(path))
                        Directory.CreateDirectory(path);
                }

                if (File.Exists(path)) {
                    string text = File.ReadAllText(path);
                    if (text == code.text)
                        continue;
                }

                File.WriteAllText(path, code.text);
                changed = true;
            }

            return changed;
        }
    }
}