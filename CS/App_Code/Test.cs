using System;
using System.Threading;
using System.Threading.Tasks;

public class Test {
    public Int32 Value { get; set; }

    public override string ToString() {
        return Value.ToString();
    }
}