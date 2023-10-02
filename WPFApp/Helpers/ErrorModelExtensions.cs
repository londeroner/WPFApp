using System.Collections.Generic;
using System.Linq;

namespace WPFApp.Helpers
{
    public static class ErrorModelExtensions
    {
        public static List<ErrorModel> RemoveErrorsByField(this List<ErrorModel> errors, string fieldName)
        {
            return errors.Where(x => x.FieldName != fieldName).ToList();
        }
    }
}
