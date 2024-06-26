﻿using Markdig.Syntax;
using Microsoft.UI;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Documents;
using Microsoft.UI.Xaml.Media;

namespace Markdig.UWP.TextElements;

internal class MyThematicBreak : IAddChild
{
    private ThematicBreakBlock _thematicBreakBlock;
    private Paragraph _paragraph;

    public TextElement TextElement
    {
        get => _paragraph;
    }

    public MyThematicBreak(ThematicBreakBlock thematicBreakBlock)
    {
        _thematicBreakBlock = thematicBreakBlock;
        _paragraph = new Paragraph();

        var inlineUIContainer = new InlineUIContainer();
        var border = new Border();
        border.Width = 500;
        border.BorderThickness = new Thickness(1);
        border.Margin = new Thickness(0, 4, 0, 4);
        border.BorderBrush = new SolidColorBrush(Colors.White);
        border.Height = 1;
        border.HorizontalAlignment = HorizontalAlignment.Stretch;
        inlineUIContainer.Child = border;
        _paragraph.Inlines.Add(inlineUIContainer);
    }

    public void AddChild(IAddChild child) {}
}
