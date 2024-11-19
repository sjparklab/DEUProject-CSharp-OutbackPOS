using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using DEUProject_CSharp_OutbackPOS.Properties;

public static class FontControl
{
    private static PrivateFontCollection privateFonts = new PrivateFontCollection();
    private static Dictionary<string, FontFamily> fontFamilies = new Dictionary<string, FontFamily>();

    /// <summary>
    /// 리소스에서 폰트를 로드합니다.
    /// </summary>
    public static void LoadFont(string fontName, byte[] fontData)
    {
        if (fontFamilies.ContainsKey(fontName)) return; // 이미 로드된 폰트 무시

        // 메모리에 폰트를 로드
        IntPtr fontPtr = Marshal.AllocCoTaskMem(fontData.Length);
        Marshal.Copy(fontData, 0, fontPtr, fontData.Length);
        privateFonts.AddMemoryFont(fontPtr, fontData.Length);
        Marshal.FreeCoTaskMem(fontPtr);

        // FontFamily 저장
        fontFamilies[fontName] = privateFonts.Families[privateFonts.Families.Length - 1];
    }

    /// <summary>
    /// 특정 이름, 크기 및 스타일의 폰트를 반환합니다.
    /// </summary>
    public static Font GetFont(string fontName, float size, FontStyle style = FontStyle.Regular)
    {
        if (!fontFamilies.ContainsKey(fontName))
            throw new InvalidOperationException($"'{fontName}' 폰트가 로드되지 않았습니다.");

        return new Font(fontFamilies[fontName], size, style);
    }

    public static void ApplyFontToAllControls(Control parent, string fontName)
    {
        foreach (Control control in parent.Controls)
        {
            float fontSize = control.Font.Size;
            control.Font = GetFont(fontName, fontSize);

            if (control.HasChildren)
            {
                ApplyFontToAllControls(control, fontName);
            }
        }
    }

    public static void LoadPretendardFonts()
    {
        LoadFont("Pretendard-Regular", Resources.Pretendard_Regular);
        LoadFont("Pretendard-Bold", Resources.Pretendard_Bold);
        LoadFont("Pretendard-Light", Resources.Pretendard_Light);
        LoadFont("Pretendard-SemiBold", Resources.Pretendard_SemiBold);
        LoadFont("Pretendard-Thin", Resources.Pretendard_Thin);
        LoadFont("Pretendard-ExtraBold", Resources.Pretendard_ExtraBold);
        LoadFont("Pretendard-ExtraLight", Resources.Pretendard_ExtraLight);
        LoadFont("Pretendard-Medium", Resources.Pretendard_Medium);
        LoadFont("Pretendard-Black", Resources.Pretendard_Black);
    }

    /// <summary>
    /// 모든 폰트를 해제합니다.
    /// </summary>
    public static void Dispose()
    {
        if (privateFonts != null)
        {
            privateFonts.Dispose();
            privateFonts = null;
            fontFamilies.Clear();
        }
    }
}
