using System;
using System.Text;

namespace CodeGen.Building
{
    public sealed class Builder
    {
        private readonly StringBuilder _builder;

        public BuilderOptions Options { get; } = new BuilderOptions();

        private int _indent;

        public Builder()
        {
            this._builder = new StringBuilder();
        }

        public Builder(string code)
        {
            this._builder = new StringBuilder(code);
        }

        public void EnterBlock()
        {
            this._indent++;
        }

        public void LeaveBlock()
        {
            this._indent--;
        }

        public void AppendComment(string text)
        {
            if (string.IsNullOrEmpty(text)) return;
            foreach (var line in text.Trim().Split( new[] { "\r\n", "\n" }, StringSplitOptions.None))
            {
                this.AppendLine($"// {line}");
            }
        }

        public void AppendLine()
        {
            this.AppendLine(string.Empty);
        }

        public void AppendLine(string format, params object[] args)
        {
            this.AppendLine(string.Format(format, args));
        }

        public void Append(string format, params object[] args)
        {
            this.Append(string.Format(format, args));
        }

        private bool _newLine = true;

        public void AppendLine(string text)
        {
            this.Append(text);
            this._builder.AppendLine();
            this._newLine = true;
        }

        public void Append(string text)
        {
            var spaces = new string(' ', this._indent * 4);

            if (this._newLine)
            {
                this._builder.Append(spaces);
                this._newLine = false;
            }

            // Ensure multy line text is indented
            var lines = text.Split(new[] { "\n", "\r\n" }, StringSplitOptions.None);
            var endsWithNewLine = lines.Length > 1 && lines[^1].Length == 0;
            if (lines.Length > 1)
            {
                text = string.Join(Environment.NewLine + spaces, lines).Trim();
            }

            this._builder.Append(text);

            if (!endsWithNewLine) return;
            this._builder.AppendLine();
            this._newLine = true;
        }

        public override string ToString()
        {
            return this._builder.ToString();
        }
    }
}