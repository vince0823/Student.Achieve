using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Achieve.Infrastructure.Documents.System.ComponentModel.DataAnnotations
{
    public class NumericAttribute : RegularExpressionAttribute
    {
        private readonly string _maximum;
        private readonly string _minimum;
        public int Precision { get; }
        public int Scale { get; }
        public bool AllowNegative { get; }

        /// <inheritdoc />
        public NumericAttribute(
            int precision,
            int scale,
            bool allowNegative = true) : base(
            $@"^({(allowNegative ? "0|-?" : null)}\d{{0,{precision - scale}}}(\.\d{{0,{scale}}})?)$")
        {
            Precision = precision;
            Scale = scale;
            AllowNegative = allowNegative;

            _maximum = $"{'9'.Repeat(Precision - Scale)}.{'9'.Repeat(Scale)}";
            _minimum = allowNegative ? $"-{_maximum}" : $"0.{'0'.Repeat(Scale - 1)}1";
        }

        /// <inheritdoc />
        public override string FormatErrorMessage(string name)
        {
            var message = ErrorMessage ?? "The {0} field should between {1} and {2}.";
            return string.Format(message, name, _minimum, _maximum);
        }
    }
}
