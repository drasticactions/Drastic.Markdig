﻿using Markdig.Syntax.Inlines;
using System;
using Microsoft.UI.Text;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Documents;

namespace Markdig.UWP.TextElements;

internal class MyEmphasisInline : IAddChild
{
    private Span _span;
    private EmphasisInline _markdownObject;

    private bool _isBold;
    private bool _isItalic;
    private bool _isStrikeThrough;

    public TextElement TextElement
    {
        get => _span;
    }

    public MyEmphasisInline(EmphasisInline emphasisInline)
    {
        _span = new Span();
        _markdownObject = emphasisInline;
    }

    public void AddChild(IAddChild child)
    {
        try
        {
            if (child is MyInlineText inlineText)
            {
                _span.Inlines.Add((Run)inlineText.TextElement);
            }
            else if (child is MyEmphasisInline emphasisInline)
            {
                if (emphasisInline._isBold) { SetBold(); }
                if (emphasisInline._isItalic) { SetItalic(); }
                if (emphasisInline._isStrikeThrough) { SetStrikeThrough(); }
                _span.Inlines.Add(emphasisInline._span);
            }
        }
        catch (Exception ex)
        {
            throw new Exception($"Error in {nameof(MyEmphasisInline)}.{nameof(AddChild)}: {ex.Message}");
        }
    }

    public void SetBold()
    {
        _span.FontWeight = FontWeights.Bold;
        _isBold = true;
    }

    public void SetItalic()
    {
        _span.FontStyle = Windows.UI.Text.FontStyle.Italic;
        _isItalic = true;
    }

    public void SetStrikeThrough()
    {
        _span.TextDecorations = Windows.UI.Text.TextDecorations.Strikethrough;
        _isStrikeThrough = true;
    }

    public void SetSubscript()
    {
        _span.SetValue(Typography.VariantsProperty, FontVariants.Subscript);
    }

    public void SetSuperscript()
    {
        _span.SetValue(Typography.VariantsProperty, FontVariants.Superscript);
    }
}
