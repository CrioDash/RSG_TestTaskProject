using Core.CustomCodeGeneratorModule.Scripts.Editor.Core;
using Core.SourceGeneratorModule.Scripts.Tools;
using Global.Scripts.Generated;

namespace Core.SourceGeneratorModule.Scripts.Generators {
    [Generator]
    public class PrefabNamesGenerator : ICodeGenerator {
        private const string FILE_NAME = "PrefabNames";
        
        public void Execute(GeneratorContext context) {
            ClassInstance classInstance = new ClassInstance()
                .AddNamespace(GeneratorConstants.DefaultNameSpace)
                .SetPublic()
                .SetStatic()
                .SetName(FILE_NAME);

            foreach (string prefabName in Address.Prefabs.AllKeys) {
                classInstance
                    .AddField(new FieldInstance()
                    .SetPublic()
                    .SetConst()
                    .SetStringType()
                    .SetName(prefabName.Replace(" ", string.Empty))
                    .SetAssignedValue($"\"{prefabName}\""));
            }
            
            context.OverrideFolderPath(GeneratorConstants.ContentFilePath);
            context.AddFile(FILE_NAME + GeneratorConstants.GeneratedFileEnding, classInstance.GetString());
        }
    }
}