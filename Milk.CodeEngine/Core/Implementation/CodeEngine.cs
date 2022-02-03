
using CSScriptLib;
using Milk.CodeEngine.Core.Interface;
using System;
using System.Reflection;

namespace Milk.CodeEngine.Core.Implementation
{
    public class CodeEngine : ICodeEngine
    {
        public CodeEngineResult CompileCode(string source)
        {
            CodeEngineResult result = new CodeEngineResult()
            {
                Success = true
            };
            try
            {
                var script = CSScript.Evaluator
                    .ReferenceAssembliesFromCode(source)
                    .ReferenceAssemblyByName("System")
                    .LoadCode<IScript>(source);
                try
                {
                    script.Execute();
                    script.OnSuccess();
                }
                catch (Exception ex)
                {
                    script.OnError(ex);
                    result.Success = false;
                    result.Errors = ex.Message;
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Errors = ex.Message;
            }

            return result;

        }

    }
}
