# BigInt

A port from [BigInteger.js](https://github.com/peterolson/BigInteger.js) to TorqueScript.

## Disclaimer

This library is not fullly optimal or finished. There is a lot of things that can be done to improve its performance significantly on some aspects

## Usage

There is currently two ways to use this library. The first one directly by sending in strings of integers and it will return strings.

```
bigint_add("343737", "125246");
bigint_subtract("343737", "125246");
bigint_multiply("343737", "125246");
bigint_divmod("343737", "125246");
```

The other way is through the `BigInt` namespace. This keeps track on the internals and will not touch string manipulation unless through initialization or explicitly telling so. It also keeps the internal state intact after each calculation.

```
%a = BigInt("343737");
%b = BigInt("125246");
%a.add(%b);
%a.subtract(%b);
%a.multiply(%b);
%a.divmod(%b);
```

## Performance

The performance can be read in [perf.txt](perf.txt).

## Credits

Author: McTwist (9845)
Many thanks to BigInteger.js creator
