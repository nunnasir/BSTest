using System;
using System.Collections.Generic;
using System.Text;

namespace BSTest.Data
{
    public interface IEntity<T>
    {
        T Id { get; set; }
        DateTime Created_at { get; set; }
    }
}
