using Video_001_Components.SDK;
using Video_001_Components.SDK.UI;

namespace Video_001_Components;

public partial class MainPage : ContentPage
{
    private readonly HeaderViewModel _headerViewModel; 
     
    public MainPage()
    {
        InitializeComponent();
        _headerViewModel = ServicesProvider.GetService<HeaderViewModel>();
    }

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
        
        _headerViewModel.AtualizarCommand.ExecuteAsync("");
    }

    private void BaseContentView_OnComponenteCarregado(object? sender, EventArgs e)
    {
        this.Dispatcher.Dispatch(() =>
        {
            this.BackgroundColor = Colors.LightGreen;
        });
    }
}