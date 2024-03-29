﻿using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using ReactiveUI;

namespace ImobFeed.UI.ListaAtivos;

public partial class AtualizarListaAtivosView : ReactiveUserControl<AtualizarListaAtivosViewModel>
{
    public AtualizarListaAtivosView()
    {
        InitializeComponent();
        this.WhenActivated(_ => { });
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}