using System.Drawing;
using System;
using System.Drawing.Text;
using System.Runtime.InteropServices;
using DEUProject_CSharp_OutbackPOS.Properties;

public class FontManager
{
    private static FontManager instance;
    private PrivateFontCollection privateFonts = new PrivateFontCollection();
    public bool IsFontLoaded { get; private set; } = false;

    public static FontManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new FontManager();
            }
            return instance;
        }
    }

    private FontManager() { }

    public void LoadFont()
    {
        if (IsFontLoaded) return;
        byte[] fontData = Resources.Pretendard_Regular; // Pretendard 임베디드 리소스
        IntPtr fontPtr = Marshal.AllocCoTaskMem(fontData.Length);
        Marshal.Copy(fontData, 0, fontPtr, fontData.Length);
        privateFonts.AddMemoryFont(fontPtr, fontData.Length);
        Marshal.FreeCoTaskMem(fontPtr);

        IsFontLoaded = true;
    }

    public Font GetFont(float size, FontStyle style = FontStyle.Regular)
    {
        if (!IsFontLoaded) throw new InvalidOperationException("Font not loaded.");
        return new Font(privateFonts.Families[0], size, style);
    }
}
