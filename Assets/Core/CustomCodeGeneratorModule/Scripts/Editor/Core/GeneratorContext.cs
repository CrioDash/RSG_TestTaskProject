using System.Collections.Generic;

namespace Core.CustomCodeGeneratorModule.Scripts.Editor.Core {
    public sealed class GeneratorContext {
        
        private readonly List<CodeText> _codeList = new();

        internal IReadOnlyList<CodeText> codeList =>
            _codeList;
        internal string overrideFolderPath { get; private set; } = "Assets/Generated";

        public void AddFile(string fileName, string code) {
            _codeList.Add(new CodeText {
                fileName = fileName,
                text = code
            });
        }

        public void OverrideFolderPath(string path) =>
            overrideFolderPath = path;
    }
}