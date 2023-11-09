using FlowTool.Application.Dtos;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowTool.Application.Extensions
{
    public static class ValidationExtensions
    {
        public static List<ErrorMessage> ToMap(this List<ValidationFailure> errors)
        {
            var list = new List<ErrorMessage>();

            foreach (var error in errors)
            {
                list.Add(new ErrorMessage(error.PropertyName, error.ErrorMessage));
            }

            return list;
        }
    }
}
