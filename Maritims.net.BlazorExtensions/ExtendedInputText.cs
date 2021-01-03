using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Rendering;
using System;

namespace Maritims.net.BlazorExtensions
{
    public class ExtendedInputText<T> : InputBase<T>
    {
        private static readonly string DateTimeFormat = "yyyy-MM-ddTHH:mm";

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            builder.OpenElement(0, "input");
            builder.AddMultipleAttributes(1, AdditionalAttributes);
            builder.AddAttribute(2, "type", typeof(T) == typeof(DateTime) ? "datetime-local" : "text");
            builder.AddAttribute(3, "class", CssClass);
            builder.AddAttribute(4, "value", BindConverter.FormatValue(CurrentValueAsString));
            builder.AddAttribute(5, "onchange", OnChange());
            builder.CloseElement();

            base.BuildRenderTree(builder);
        }

        protected override bool TryParseValueFromString(string value, out T result, out string validationErrorMessage)
        {
            bool success;

            if (typeof(T) == typeof(string))
            {
                result = (T)(object)value;
                validationErrorMessage = null;
                success = true;
            }
            else if (typeof(T) == typeof(double))
            {
                double.TryParse(value, out var parsedValue);
                result = (T)(object)parsedValue;
                validationErrorMessage = null;
                success = true;
            }
            else if (typeof(T) == typeof(DateTime))
            {
                DateTime.TryParse(value, out var parsedValue);
                result = (T)(object)parsedValue;
                validationErrorMessage = null;
                success = true;
            }
            else
            {
                throw new ArgumentException($"Unsupported type: {typeof(T)}");
            }

            return success;
        }

#nullable enable
        protected override string FormatValueAsString(T? value)
#nullable disable
        {
            if (typeof(T) == typeof(DateTime))
            {
                return ((DateTime)(object)value).ToString(DateTimeFormat);
            }
            else
            {
                return base.FormatValueAsString(value);
            }
        }

        EventCallback<ChangeEventArgs> OnChange() => EventCallback.Factory.CreateBinder<string>(this, __value => CurrentValueAsString = __value, CurrentValueAsString);
    }
}
