using WPFApp.ViewModels;

namespace WPFApp.Helpers
{
    public class ErrorModel
    {
        public DomainViewModel ParentViewModelDomain { get; set; }
        public string ModelId { get; set; }
        public string Message { get; set; }
        public string FieldName { get; set; }

        public ErrorModel(DomainViewModel parentViewModelDomain, string modelId, string message, string fieldName)
        {
            ParentViewModelDomain = parentViewModelDomain;
            ModelId = modelId;
            Message = message;
            FieldName = fieldName;
        }
    }
}
