using System.Collections.Generic;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;

namespace TextEditor;

public class TextProps
{
    public double FontSize { get; set; } = 12;
    public FontFamily FontFamily { get; set; } = new("Consolas");
    public List<FontFamily> FontFamilies { get; set; } = new List<FontFamily>()
    {
        new ("Consolas"),
        new ("Arial"),
        new ("Times New Roman")
    };
}