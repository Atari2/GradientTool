// Decompiled with JetBrains decompiler
// Type: SFXProductions.GradientTool.CodeGen
// Assembly: GradientTool, Version=0.8.2.1, Culture=neutral, PublicKeyToken=null
// MVID: 818AB9B3-796A-4A49-8B90-C00D066A321B
// Assembly location: C:\Users\aless\Downloads\gradient-tool-v0.8.2.1\GradientTool.exe

using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace SFXProductions.GradientTool
{
    internal sealed class CodeGen
    {
        private StringBuilder m_rtf;
        private StringBuilder m_plain;

        public CodeGen()
        {
            this.m_rtf = new StringBuilder();
            this.m_plain = new StringBuilder();
        }

        public void AppendPlainText(string text)
        {
            this.m_rtf.Append(text);
            this.m_plain.Append(text);
        }

        public void AppendPlainText(char ch)
        {
            this.m_rtf.Append(ch);
            this.m_plain.Append(ch);
        }

        public void AppendComment(string text)
        {
            this.m_rtf.Append("\\cf1" + text + "\\cf0");
            this.m_plain.Append(text);
        }

        public void AppendKeyword(string text)
        {
            this.m_rtf.Append("\\cf2" + text + "\\cf0");
            this.m_plain.Append(text);
        }

        public void AppendNumeric(string text)
        {
            this.m_rtf.Append("\\cf3" + text + "\\cf0");
            this.m_plain.Append(text);
        }

        public void AppendNumeric(char ch)
        {
            this.m_rtf.Append("\\cf3" + (object)ch + "\\cf0");
            this.m_plain.Append(ch);
        }

        public void AppendLabel(string text)
        {
            this.m_rtf.Append("\\cf4" + text + "\\cf0");
            this.m_plain.Append(text);
        }

        public void AppendLine()
        {
            this.m_rtf.Append("\\line");
            this.m_plain.AppendLine();
        }

        public void AppendHardTab()
        {
            this.m_rtf.Append("\\tab");
            this.m_plain.Append('\t');
        }

        public void AppendSpace()
        {
            this.m_rtf.Append("\\ ");
            this.m_plain.Append(' ');
        }

        public void WriteComment(string comment = null, bool tab = false, bool space = false)
        {
            if (tab)
                this.AppendHardTab();
            else if (space)
                this.AppendSpace();
            string text = "; ";
            if (comment != null)
                text += comment;
            this.AppendComment(text);
            this.AppendLine();
        }

        public void WriteBanner()
        {
            this.AppendComment(";=======================================");
            this.AppendLine();
        }

        public void Write16BitMode(int w = 0, bool tab = true)
        {
            if (tab)
                this.AppendHardTab();
            this.AppendKeyword("REP".PadRight(w));
            this.AppendSpace();
            this.AppendNumeric("#$20");
            this.AppendSpace();
            this.AppendComment("; 16-bit A");
            this.AppendLine();
        }

        public void Write8BitMode(int w = 0, bool tab = true)
        {
            if (tab)
                this.AppendHardTab();
            this.AppendKeyword("SEP".PadRight(w));
            this.AppendSpace();
            this.AppendNumeric("#$20");
            this.AppendSpace();
            this.AppendComment("; 8-bit A");
            this.AppendLine();
        }

        public void WriteTSB(ushort addr, int w = 0, bool tab = true)
        {
            if (tab)
                this.AppendHardTab();
            this.AppendKeyword("TSB".PadRight(w));
            this.AppendSpace();
            this.WriteHexAddress(addr);
            this.AppendLine();
        }

        public void WriteLDAIfNonzero(ushort value, int w = 0, bool tab = true)
        {
            if (value == (ushort)0)
                return;
            int w1 = w;
            bool tab1 = tab;
            this.WriteLDA_c(value, w1, tab1);
        }

        public void WriteSTAIfNonzero(ushort addr, ushort value, int w = 0, string comment = null, bool tab = true)
        {
            if (value != (ushort)0)
            {
                int w1 = w;
                string comment1 = comment;
                bool tab1 = tab;
                this.WriteSTA(addr, w1, comment1, tab1);
            }
            else
            {
                int w2 = w;
                string comment2 = comment;
                bool tab2 = tab;
                this.WriteSTZ(addr, w2, comment2, tab2);
            }
        }

        public void WriteKeywordLine(string keyword, bool tab = true)
        {
            if (tab)
                this.AppendHardTab();
            this.AppendKeyword(keyword);
            this.AppendLine();
        }

        public void WriteHexAddress(byte address) => this.AppendNumeric('$'.ToString() + address.ToString("X2"));

        public void WriteHexAddress(ushort address) => this.AppendNumeric('$'.ToString() + address.ToString("X4"));

        public void WriteHexConstant(byte constant) => this.AppendNumeric("#$" + constant.ToString("X2"));

        public void WriteHexConstant(ushort constant) => this.AppendNumeric("#$" + constant.ToString("X4"));

        public void WriteBinaryConstant(byte constant) => this.AppendNumeric("#%" + Convert.ToString(constant, 2).PadLeft(8, '0'));

        private void WriteLDAInternal(string addr, int w, bool tab)
        {
            if (tab)
                this.AppendHardTab();
            this.AppendKeyword("LDA".PadRight(w));
            this.AppendSpace();
            this.AppendNumeric(addr);
            this.AppendLine();
        }

        public void WriteLDA(byte addr, int w = 0, bool tab = true) => this.WriteLDAInternal('$'.ToString() + addr.ToString("X2"), w, tab);

        public void WriteLDA(ushort addr, int w = 0, bool tab = true) => this.WriteLDAInternal('$'.ToString() + addr.ToString("X4"), w, tab);

        public void WriteLDA(int addr, int w = 0, bool tab = true) => this.WriteLDAInternal('$'.ToString() + (addr & 16777215).ToString("X6"), w, tab);

        public void WriteLDA_c(byte addr, int w = 0, bool tab = true) => this.WriteLDAInternal("#$" + addr.ToString("X2"), w, tab);

        public void WriteLDA_c(ushort addr, int w = 0, bool tab = true) => this.WriteLDAInternal("#$" + addr.ToString("X2"), w, tab);

        public void WriteLDA_b_c_bin(byte val, int w = 0, bool tab = true)
        {
            if (tab)
                this.AppendHardTab();
            this.AppendKeyword("LDA.b".PadRight(w));
            this.AppendSpace();
            this.WriteBinaryConstant(val);
            this.AppendLine();
        }

        public void WriteLDA_Label(string label, int w = 0, bool tab = true)
        {
            if (tab)
                this.AppendHardTab();
            this.AppendKeyword("LDA".PadRight(w));
            this.AppendSpace();
            this.AppendNumeric('#');
            this.AppendLabel(label);
            this.AppendLine();
        }

        private void WriteSTAInternal(
          string addr,
          int w,
          bool storeAccumulator,
          string comment,
          bool tab)
        {
            if (tab)
                this.AppendHardTab();
            this.AppendKeyword((storeAccumulator ? "STA" : "STZ").PadRight(w));
            this.AppendSpace();
            this.AppendNumeric(addr);
            if (comment != null)
            {
                this.AppendSpace();
                this.AppendComment("; " + comment);
            }
            this.AppendLine();
        }

        public void WriteSTA(byte addr, int w = 0, string comment = null, bool tab = true) => this.WriteSTAInternal('$'.ToString() + addr.ToString("X2"), w, true, comment, tab);

        public void WriteSTA(ushort addr, int w = 0, string comment = null, bool tab = true) => this.WriteSTAInternal('$'.ToString() + addr.ToString("X4"), w, true, comment, tab);

        public void WriteSTA(int addr, int w = 0, string comment = null, bool tab = true) => this.WriteSTAInternal('$'.ToString() + (addr & 16777215).ToString("X6"), w, true, comment, tab);

        public void WriteSTZ(byte addr, int w = 0, string comment = null, bool tab = true) => this.WriteSTAInternal('$'.ToString() + addr.ToString("X2"), w, false, comment, tab);

        public void WriteSTZ(ushort addr, int w = 0, string comment = null, bool tab = true) => this.WriteSTAInternal('$'.ToString() + addr.ToString("X4"), w, false, comment, tab);

        public void SetTextBoxText(RichTextBox textBox) => textBox.Rtf = "{\\rtf1\\ansi\\deff0{\\colortbl;\\red0\\green127\\blue0;\\red0\\green0\\blue255;\\red64\\green64\\blue64;\\red127\\green0\\blue127;}" + this.m_rtf.ToString() + "\\line}";

        public string GetText() => this.m_plain.ToString();

        public void WriteToFile(string filename, Encoding encoding = null)
        {
            if (encoding == null)
                encoding = (Encoding)new UTF8Encoding(false);
            File.WriteAllText(filename, this.m_plain.ToString(), encoding);
        }

        ~CodeGen() => this.m_rtf = this.m_plain = (StringBuilder)null;
    }
}
