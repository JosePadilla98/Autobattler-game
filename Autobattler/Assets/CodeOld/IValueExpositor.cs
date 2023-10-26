using System;

namespace AutobattlerOld
{
    public interface IValueExpositor
    {
        public float Get();
        Action OnValueChanged { get; set; }
    }
}