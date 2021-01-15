using System;

namespace Framework.Core.Attributes
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public sealed class CustomDisplayAttribute : Attribute
    {
        public CustomDisplayAttribute(string name, string nameEn, short displayOrder)
        {
            Title = name;
            TitleEn = nameEn;
            DisplayOrder = displayOrder;
        }

        public string Title { get; }
        public string TitleEn { get; }
        public short DisplayOrder { get; }
        public short Value { get; set; }

        public void setValue(short value)
        {
            this.Value = value;
        }
    }
}