using System;

namespace AnketaPro.Service
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