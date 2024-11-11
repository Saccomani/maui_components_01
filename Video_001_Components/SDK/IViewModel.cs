using System.ComponentModel;

namespace Video_001_Components.SDK;

public interface IViewModel : INotifyPropertyChanged
{
    Task Atualizar();

    bool IsBusy { get; set; }
    
    string MensagemDeErro { get; set; }
}