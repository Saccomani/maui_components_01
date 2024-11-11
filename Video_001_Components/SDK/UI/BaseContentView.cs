using System.ComponentModel;

namespace Video_001_Components.SDK.UI;

public class BaseContentView: ContentView, IBaseComponent
{

    private CancellationTokenSource? _animacaoCancellationTokenSource;
    /// <summary>
    /// Indica se ja foi inicializado
    /// </summary>
    private bool _jaFoiInicializado = false;

    
    /// <summary>
    /// Componente carregado com sucesso;
    /// </summary>
    public event EventHandler ComponenteCarregado;

    private IViewModel ViewModel;
    
    /// <summary>
    /// Guarda o conteúdo original da view
    /// </summary>
    private View ContentViewOriginal;
    
    protected override void OnParentSet()
    {
        if (!_jaFoiInicializado && Parent != null)
        {
            
            //guarda uma cópia do conteúdo original
            ContentViewOriginal = Content;
            
            //recuperar a instancia da viewModel
            ViewModel = Content.BindingContext as IViewModel ??
                        throw new InvalidOperationException("É necessário informar a ViewModel");
            
            ViewModel.PropertyChanged+= AnimaOSkeleton;
            
            _jaFoiInicializado = true;
            
            //Registra mensagens
            
            //auto load
        }
    }

    private void AnimaOSkeleton(object? sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(ViewModel.IsBusy))
        {
            if (ViewModel.IsBusy)
            {
                _animacaoCancellationTokenSource?.Cancel();
                _animacaoCancellationTokenSource = new CancellationTokenSource();
                ExecutaAnimacaoDaViewAsync(_animacaoCancellationTokenSource.Token, ContentViewOriginal);
            }
            else
            {
                _animacaoCancellationTokenSource?.Cancel();
                ContentViewOriginal.FadeTo(1, 500).ContinueWith((t) =>
                {
                    //todo: fazer algo quando terminar a animação
                    //avisa que o carregamento terminou
                    ComponenteCarregado?.Invoke(this, EventArgs.Empty);
                });
            }
        }
    }
    
    private async Task ExecutaAnimacaoDaViewAsync(CancellationToken cancellationToken, View view)
    {
        try
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                await view.FadeTo(0.3,500, Easing.Linear);
                await view.FadeTo(1,500, Easing.Linear);
            }
        }
        catch (Exception e)
        {
           //try catch cala boca.
        }
    }
    
    

    public void Reset()
    {
        throw new NotImplementedException();
    }

    public void Atualizar()
    {
        throw new NotImplementedException();
    }

    public bool Validar()
    {
        throw new NotImplementedException();
    }

    public void Remover()
    {
        throw new NotImplementedException();
    }

    public void NotificarErro(Exception ex)
    {
        throw new NotImplementedException();
    }

    public string ObterDiagnosticos()
    {
        throw new NotImplementedException();
    }
    
    
    public void Dispose()
    {
        ViewModel.PropertyChanged -= AnimaOSkeleton;
        
        //todo muito cuidado com isso
        //GC.Collect();
    }
}