using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using Demo.Services.Contracts.Common;

namespace Demo.Services.Common
{
    public class ModelDataAnnotationValidator : IModelDataAnnotationValidator
    {
        public void ValidateDataAnnotations<TModel>(TModel model)
        {
            var validationResultList = new List<ValidationResult>();
            var validationContext = new ValidationContext(model);

            if (Validator.TryValidateObject(
                    model, 
                    validationContext, 
                    validationResultList, 
                    true)) 
                return;

            if (!validationResultList.Any()) return;

            var sb = new StringBuilder();
            foreach (var err in validationResultList)
            {
                sb.Append(err.ErrorMessage).AppendLine();
            }

            throw new ArgumentException(sb.ToString());
        }
    }
}
