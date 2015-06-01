using System;

namespace AnketaPro.Forms.OpenForm
{
    [AttributeUsage(AttributeTargets.Property)]
    public class DbColumnAttribute : Attribute
    {
        private string name;

        public DbColumnAttribute(string name)
        {
            this.name = name;
        }
    }
}