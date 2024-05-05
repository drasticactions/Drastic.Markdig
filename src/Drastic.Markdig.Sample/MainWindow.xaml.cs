using Markdig.UWP;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Drastic.Markdig.Sample
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        private MarkdownConfig markdownConfig;

        public MainWindow()
        {
            this.InitializeComponent();
            this.SystemBackdrop = new MicaBackdrop();
            markdownConfig = new MarkdownConfig();
            markdownConfig.Markdown = @"Testing Links: [OneOf](https://github.com/mcintyre321/OneOf)";
            this.MarkdownTestViewer.Config = markdownConfig;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            markdownConfig.Markdown = @"Testing Links: [Test](https://github.com/mcintyre321/OneOf)";
            this.MarkdownTestViewer.Update();
        }
    }
}
