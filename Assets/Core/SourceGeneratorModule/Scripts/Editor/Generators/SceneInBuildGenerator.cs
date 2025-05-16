using System.IO;
using System.Linq;
using Core.CustomCodeGeneratorModule.Scripts.Editor.Core;
using Core.SourceGeneratorModule.Scripts.Tools;
using UnityEditor;

namespace Core.SourceGeneratorModule.Scripts.Generators {
    [Generator]
    public class SceneInBuiltGenerator : ICodeGenerator {
        private const string FILE_NAME = "SceneInBuild";
        public void Execute(GeneratorContext context) {
            ClassInstance classInstance = new ClassInstance()
                .AddNamespace(GeneratorConstants.DefaultNameSpace)
                .SetPublic()
                .SetStatic()
                .SetName(FILE_NAME);

            foreach (string sceneName in EditorBuildSettings.scenes.Select(sceneInBuild => Path.GetFileNameWithoutExtension(sceneInBuild.path))) {
                classInstance.AddField(new FieldInstance()
                    .SetPublic()
                    .SetConst()
                    .SetStringType()
                    .SetName(sceneName.Replace(" ", string.Empty))
                    .SetAssignedValue($"\"{sceneName}\""));
            }
            
            context.OverrideFolderPath(GeneratorConstants.ContentFilePath);
            context.AddFile(FILE_NAME + GeneratorConstants.GeneratedFileEnding, classInstance.GetString());
        }
    }
}