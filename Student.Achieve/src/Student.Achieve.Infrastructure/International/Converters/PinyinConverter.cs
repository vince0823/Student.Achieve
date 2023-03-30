using Microsoft.International.Converters.PinYinConverter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Achieve.Infrastructure.International.Converters
{
    public class PinyinConverter : IPinyinConverter
    {
        public virtual string ToPinyin(string text)
        {
            if (string.IsNullOrEmpty(text))
                return null;

            var builder = new StringBuilder();
            foreach (var @char in text.Trim())
            {
                var chinese = ChineseChar.IsValidChar(@char) ? new ChineseChar(@char) : null;
                if (chinese?.Pinyins.Count > 0)
                {
                    var pinyin = chinese.Pinyins[0];
                    var purePinyin = pinyin.AsSpan()[..(pinyin.Length - 1)];
                    builder.Append(purePinyin);
                }
                else
                {
                    builder.Append(@char);
                }
            }
            return builder.ToString();
        }
    }
}
