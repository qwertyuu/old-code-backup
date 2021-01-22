#region UICode
#endregion

void Render(Surface dst, Surface src, Rectangle rect)
{
    // Delete any of these lines you don't need
    Rectangle selection = EnvironmentParameters.GetSelection(src.Bounds).GetBoundsInt();
    int CenterX = ((selection.Right - selection.Left) / 2)+selection.Left;
    int CenterY = ((selection.Bottom - selection.Top) / 2)+selection.Top;
    ColorBgra PrimaryColor = (ColorBgra)EnvironmentParameters.PrimaryColor;
    ColorBgra SecondaryColor = (ColorBgra)EnvironmentParameters.SecondaryColor;
    int BrushWidth = (int)EnvironmentParameters.BrushWidth;
    ColorBgra CurrentPixel;
    Random r = new Random();
    int RTotal = 0;
    int GTotal = 0;
    int BTotal = 0;
    int totalPix = 0;
    for (int y = rect.Top; y < rect.Bottom; y++)
    {
        for (int x = rect.Left; x < rect.Right; x++)
        {
            CurrentPixel = src[x,y];
            RTotal += (int)CurrentPixel.R;
            GTotal += (int)CurrentPixel.G;
            BTotal += (int)CurrentPixel.B;
            totalPix++;
        }
    }
    CurrentPixel = ColorBgra.FromBgr((byte)(BTotal / totalPix), (byte)(GTotal / totalPix), (byte)(RTotal / totalPix));
        for (int y = rect.Top; y < rect.Bottom; y++)
    {
        for (int x = rect.Left; x < rect.Right; x++)
        {
            dst[x,y] = CurrentPixel;
        }
    }
}
