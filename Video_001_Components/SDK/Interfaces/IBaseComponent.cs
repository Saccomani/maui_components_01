namespace Video_001_Components.SDK;

public interface IBaseComponent : IDisposable
{
    //faz o reset do compoent
    void Reset();

    void Atualizar();

    bool Validar();

    void Remover();

    void NotificarErro(Exception ex);
    
    string ObterDiagnosticos();
}