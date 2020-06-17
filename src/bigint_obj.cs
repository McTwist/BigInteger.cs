// ===============
// Big Integer library for unlimited size integer arithmetics
// ===============
// Author: McTwist
// Version: 2018-01-19
// This library is a pure port. Few, if none, is edited and just
// made to work out of the box with TorqueScript.
// Source: https://github.com/peterolson/BigInteger.js
//
// This is access through an object, to reduce overhead when reusing
// the same number several times

// Create a new big integer
// First parameter is the value to parse
// Second argument is used internally
function BigInt(%a, %b)
{
	%this = new ScriptObject()
	{
		class = BigInt;
	};

	if (%a !$= "")
		%this.value = bigint__parseValue(%a);
	else if (%b !$= "")
		%this.value = %b;
	else
		%this.value = bigint__parseValue("0");

	return %this;
}


// Clean up the mess when done
function BigInt::onRemove(%this)
{
	%this.value.delete();
}

// Add two integers
function BigInt::add(%this, %v)
{
	%a = %this.value;
	%b = %v.value;
	%makeNegative = false;
	// if (%a.sign != %b.sign)
	// {
	// 	%b.sign = !%b.sign;
	// 	%value = bigint__subtract(%a, %b);
	// 	%b.sign = !%b.sign;
	// }
	// else
	// {
	// 	%value = bigint__addAny(%a, %b);
	// }
	if (%a.sign == %b.sign) // if a and b are the same sign
	{
		if (%a.sign) // if a and b are negative then
			%makeNegative = true; // new value should be negative
	}
	else // a + -b or -a + b
	{
		%signA = %a.sign;
		%signB = %b.sign;
		%newBigInt = BigInt(0);
		%swap = false;

		if (!%a.sign) // if a is positive, then b must be negative, so..
			%b.sign = false; // for (a) - (b) to occur
		else // if a is negative, then b must be positive, so..
		{
			%a.sign = false; // for (b) - (a) to occur
			%swap = true;
		}

		if (%swap)
		{
			%newBigInt = %v.subtract(%this); // swap and let subtract do the hard work
			%makeNegative = bigint__compareAbs(%b, %a) < 0;
		}
		else
		{
			%newBigInt = %this.subtract(%v); // let subtract do the hard work
			%makeNegative = bigint__compareAbs(%a, %b) < 0;
		}
		
		%newBigInt.value.sign = %makeNegative;
		%a.sign = %signA; // restore to original sign in case it was changed in above logic
		%b.sign = %signB; // restore to original sign in case it was changed in above logic
		return %newBigInt;
	}
	
	%value = bigint__addAny(%a, %b);
	%value.sign = %makeNegative;

	return BigInt("", %value);
}

// Subtract two integers
function BigInt::subtract(%this, %v)
{
	%a = %this.value;
	%b = %v.value;
	%makeNegative = false;
	// if (%a.sign != %b.sign)
	// {
	// 	%b.sign = !%b.sign;
	// 	%value = bigint__addAny(%a, %b);
	// 	%b.sign = !%b.sign;
	// }
	// else
	// {
	// 	%value = bigint__subtract(%a, %b);
	// }
	// subtraction is generally "a - b"
	// keep subtracting if:
		// a - b
		// -a - -b
		// and swap signs if the num to subtract is larger, then make the result negative (1 - 2 becomes -1 + 2 becomes 2 - 1 = 1, make negative = -1)
	// change to addition if:
		// -a - b
		// a - -b
	if (!%a.sign && !%b.sign) // if a and b are both positive
	{
		// 999 - 1000 = -1
		// make result negative if |a| < |b|
		%makeNegative = bigint__compareAbs(%a, %b) < 0;
	}
	else if (%a.sign && %b.sign) // if a and b are both negative
	{
		// -999 - -1000 = 1
		// make result negative if |a| > |b|
		%makeNegative = bigint__compareAbs(%a, %b) > 0;
	}
	else // -a - b or a - -b (one positive one negative)
	{
		%signA = %a.sign;
		%signB = %b.sign;
		%newBigInt = BigInt(0);

		if (!%a.sign) // if a is positive, then b must be negative, so..
			%b.sign = false; // for (a) + (b) to occur
		else // if a is negative, then b must be positive, so..
		{
			%a.sign = false; // for (a) + (b) to occur
			%makeNegative = true;
		}

		%newBigInt = %this.add(%v);
		%newBigInt.value.sign = %makeNegative;
		
		%a.sign = %signA; // restore to original sign in case it was changed in above logic
		%b.sign = %signB; // restore to original sign in case it was changed in above logic
		return %newBigInt;
	}
	
	%value = bigint__subtractAny(%a, %b);
	%value.sign = %makeNegative;

	return BigInt("", %value);
}

// Multiply two integers
function BigInt::multiply(%this, %v)
{
	%a = %this.value;
	%b = %v.value;
	%value = Array();

	if (bigint__useKaratsuba(%a.length(), %b.length()))
		%value = bigint__multiplyKaratsuba(%a, %b);
	else
		%value = bigint__multiplyLong(%a, %b);

	%value.sign = %a.sign != %b.sign;

	return BigInt("", %value);
}


// Divide one integer with an another
// Use $bigint::remainder_obj for the remainder
function BigInt::divmod(%this, %v)
{
	%a = %this.value;
	%b = %v.value;
	%value = Array();

	if (isObject($bigint::remainder_obj))
		$bigint::remainder_obj.delete();

	%value = bigint__divMod(%a, %b);

	%value.sign = %a.sign != %b.sign;
	$bigint::_remainder.sign = %a.sign;

	$bigint::remainder_obj = BigInt("", $bigint::_remainder);
	return BigInt("", %value);
}

// Convert the integer to a readable string
function BigInt::toString(%this)
{
	return bigint__toString(%this.value);
}

// Integer comparison
function BigInt::equals(%this, %v)
{
	return bigint_equal(%this.value, %v.value);
}

function BigInt::greaterThanOrEqualTo(%this, %v)
{
	return bigint_greaterequal(%this.value, %v.value);
}

function BigInt::greaterThan(%this, %v)
{
	return bigint_greater(%this.value, %v.value);
}

function BigInt::lessThanOrEqualTo(%this, %v)
{
	return bigint_lesserequal(%this.value, %v.value);
}

function BigInt::lessThan(%this, %v)
{
	return bigint_lesser(%this.value, %v.value);
}
