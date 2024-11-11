namespace Video_001_Components.SDK.UI;

public partial class HeaderComponentView : BaseContentView
{
    private readonly HeaderViewModel viewModel;
    
    public HeaderComponentView()
    {
        InitializeComponent();

        BindingContext = viewModel = ServicesProvider.GetService<HeaderViewModel>();
    }
}