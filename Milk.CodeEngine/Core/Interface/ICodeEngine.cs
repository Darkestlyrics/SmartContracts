using Milk.CodeEngine.Core.Implementation;

namespace Milk.CodeEngine.Core.Interface;

public interface ICodeEngine
{
    public CodeEngineResult CompileCode(string source);
}