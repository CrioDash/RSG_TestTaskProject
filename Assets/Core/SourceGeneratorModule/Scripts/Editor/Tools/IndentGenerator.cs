using System.Linq;

namespace Core.SourceGeneratorModule.Scripts.Tools {
    public class IndentGenerator {
        public static string GetIndent(int indentCount) =>
            string.Concat(Enumerable.Repeat(ToolConstants.DefaultTabString, indentCount));
    }
}