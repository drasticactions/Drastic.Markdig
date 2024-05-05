using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

namespace Markdig.UWP;

public sealed partial class MarkdownViewer : UserControl
{
    public static DependencyProperty ConfigProperty = DependencyProperty.Register(
        nameof(Config),
        typeof(MarkdownConfig),
        typeof(MarkdownViewer),
        new PropertyMetadata(null, ConfigChanged)
    );

    public static void ConfigChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        if (d is MarkdownViewer self && e.NewValue != null)
        {
            self.Config = (MarkdownConfig)e.NewValue;
            self.Update();
        }
    }

    public void Update()
    {
        this.ViewModel.Loading = true;
        var uiElement = MarkdownUIBuilder.Build(this.Config);
        this.MarkdownContainer.Children.Clear();
        this.MarkdownContainer.Children.Add(uiElement);
        this.ViewModel.Loading = false;
    }

    public MarkdownConfig Config
    {
        get => (MarkdownConfig)GetValue(ConfigProperty);
        set => SetValue(ConfigProperty, value);
    }

    public MarkdownViewer()
    {
        this.InitializeComponent();
    }
}
