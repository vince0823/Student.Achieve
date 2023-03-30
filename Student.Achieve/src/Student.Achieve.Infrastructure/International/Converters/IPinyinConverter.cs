using Fabricdot.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Achieve.Infrastructure.International.Converters
{
    public interface IPinyinConverter: IDomainService
    {
        string ToPinyin(string text);
    }
}
