using CommunityToolkit.Mvvm.Input;

namespace Video_001_Components.SDK.UI;

public partial class HeaderViewModel : BaseViewModel
{
    [RelayCommand]
    public override  async Task Atualizar()
    {
        IsBusy = true; //anima o componente automaticamente
        
        await Task.Delay(5000);
        
        IsBusy = false; 
    }
}