namespace Demo.Services.Contracts.Common
{
    public interface IModelDataAnnotationValidator
    {
        void ValidateDataAnnotations<TModel>(TModel model);
    }
}