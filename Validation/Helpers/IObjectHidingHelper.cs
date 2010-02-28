using System;
using System.ComponentModel;

namespace Validation.Helpers
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IObjectHidingHelper
    {
        [EditorBrowsable(EditorBrowsableState.Never)]    
        int GetHashCode();
 
        [EditorBrowsable(EditorBrowsableState.Never)]
        string ToString();

        [EditorBrowsable(EditorBrowsableState.Never)]
        bool Equals(object obj);
    
        [EditorBrowsable(EditorBrowsableState.Never)]
        Type GetType();
    }
}