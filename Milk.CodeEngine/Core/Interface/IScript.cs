namespace Milk.CodeEngine.Core.Interface;

public interface IScript
{
    void Execute();
    void OnError(Exception ex);
    void OnSuccess();
}