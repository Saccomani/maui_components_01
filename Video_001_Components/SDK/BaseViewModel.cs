using CommunityToolkit.Mvvm.ComponentModel;

namespace Video_001_Components.SDK;

public abstract partial class BaseViewModel : ObservableObject , IViewModel
{
    public abstract Task Atualizar();

    [ObservableProperty] public bool isBusy;


    [ObservableProperty] private string mensagemDeErro;
    
    
    public BaseViewModel()
    {
        
    }
}