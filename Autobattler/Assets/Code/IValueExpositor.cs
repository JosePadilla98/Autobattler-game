using System;

namespace Autobattler
{
    public interface IValueExpositor
    {
        public float Get();
        Action OnValueChanged { get; set; }
    }
}