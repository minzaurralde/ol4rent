using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Ol4RentAPI.Model.Helpers
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    public class PostedFileBaseFileExtensionsAttribute: DataTypeAttribute
    {
        private readonly FileExtensionsAttribute _innerAttribute = new FileExtensionsAttribute();
        // Summary:
        //     Initializes a new instance of the System.ComponentModel.DataAnnotations.FileExtensionsAttribute
        //     class.
        public PostedFileBaseFileExtensionsAttribute()
            : base(DataType.Upload)
        {
            ErrorMessage = _innerAttribute.ErrorMessage;
        }

        // Summary:
        //     Gets or sets the file name extensions.
        //
        // Returns:
        //     The file name extensions, or the default file extensions (".png", ".jpg",
        //     ".jpeg", and ".gif") if the property is not set.
        public string Extensions
        {
            get
            {
                return _innerAttribute.Extensions;
            }
            set
            {
                _innerAttribute.Extensions = value;
            }
        }

        // Summary:
        //     Applies formatting to an error message, based on the data field where the
        //     error occurred.
        //
        // Parameters:
        //   name:
        //     The name of the field that caused the validation failure.
        //
        // Returns:
        //     The formatted error message.
        public override string FormatErrorMessage(string name)
        {
            return _innerAttribute.FormatErrorMessage(name);
        }
        //
        // Summary:
        //     Checks that the specified file name extension or extensions is valid.
        //
        // Parameters:
        //   value:
        //     A comma delimited list of valid file extensions.
        //
        // Returns:
        //     true if the file name extension is valid; otherwise, false.
        public override bool IsValid(object value)
        {
            if (value is HttpPostedFileBase)
            {
                var file = value as HttpPostedFileBase;
                if (file != null)
                {
                    return _innerAttribute.IsValid(file.FileName);
                }
            }
            else if (value is List<HttpPostedFileBase>)
            {
                var files = value as List<HttpPostedFileBase>;
                if (files != null)
                {
                    bool isValid = true;
                    foreach (var file in files)
                    {
                        if (file != null)
                        {
                            isValid = isValid && _innerAttribute.IsValid(file.FileName);
                        }
                    }
                    return isValid;
                }
            }
            return _innerAttribute.IsValid(value);
        }
    }
}
