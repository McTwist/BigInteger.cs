// ===============
// Big Integer library for unlimited size integer arithmetics
// ===============
// Author: McTwist
// Version: 2018-01-19
// This library is a pure port. Few, if none, is edited and just
// made to work out of the box with TorqueScript.
// Source: https://github.com/peterolson/BigInteger.js
//
// This file is for direct manipulation through functions

// Add two values together and return their sum
function bigint_add(%a, %b)
{
	%a_l = strlen(%a);
	%b_l = strlen(%b);
	if (%a_l < 6 || %b_l < 6)
	{
		return %a + %b;
	}
	else if (%a_l < 8 && %b_l < 8)
	{
		return uint_add(%a, %b);
	}

	%a = bigint__parseValue(%a);
	%b = bigint__parseValue(%b);
	if (%a.sign != %b.sign)
	{
		%b.sign = !%b.sign;
		%value = bigint__subtract(%a, %b);
	}
	else
	{
		%value = bigint__addAny(%a, %b);
	}

	%ret = bigint__toString(%value);
	
	%a.delete();
	%b.delete();
	%value.delete();
	return %ret;
}

// Subtract two values and retiurn their difference
function bigint_subtract(%a, %b)
{
	%a_l = strlen(%a);
	%b_l = strlen(%b);
	if (%a_l < 6 && %b_l < 6)
	{
		return %a - %b;
	}
	else if (%a_l < 8 && %b_l < 8)
	{
		return uint_sub(%a, %b);
	}

	%a = bigint__parseValue(%a);
	%b = bigint__parseValue(%b);
	//if (%a.sign != %b.sign)
	if (!%a.sign && %b.sign) // if a is positive and b is negative
	{
		%b.sign = !%b.sign;
		//%value = bigint__add(%a, %b);
		%value = bigint__addAny(%a, %b);
		%b.sign = !%b.sign;
	}
	else
	{
		%value = bigint__subtract(%a, %b);
	}

	%ret = bigint__toString(%value);

	%a.delete();
	%b.delete();
	%value.delete();
	return %ret;
}

// Multiply two values together and return their product
function bigint_multiply(%a, %b)
{
	%a_l = strlen(%a);
	%b_l = strlen(%b);
	if (%a_l < 4 && %b_l < 4)
	{
		return %a * %b;
	}
	else if (%a_l < 5 && %b_l < 5)
	{
		return uint_mul(%a, %b);
	}

	%a = bigint__parseValue(%a);
	%b = bigint__parseValue(%b);
	%sign = %a.sign != %b.sign;

	if (bigint__useKaratsuba(%a.length(), %b.length()))
		%value = bigint__multiplyKaratsuba(%a, %b);
	else
		%value = bigint__multiplyLong(%a, %b);

	%value.sign = %sign;

	%ret = bigint__toString(%value);

	%a.delete();
	%b.delete();
	%value.delete();
	return %ret;
}

// Divide two values and return their quotition
// Get the remainder from $bigint::remainder
function bigint_divmod(%a, %b)
{
	%a_l = strlen(%a);
	%b_l = strlen(%b);
	if (%a_l < 6 && %b_l < 6)
	{
		$bigint::remainder = %a % %b;
		return mFloor(%a / %b);
	}
	else if (%a_l < 8 && %b_l < 8)
	{
		%ret = uint_div(%a, %b);
		$bigint::remainder = $uint::remainder;
		return %ret;
	}

	%a = bigint__parseValue(%a);
	%b = bigint__parseValue(%b);
	%sign = %a.sign != %b.sign;

	%value = bigint__divMod(%a, %b);

	%value.sign = %sign;
	$bigint::_remainder.sign = %a.sign;

	$bigint::remainder = bigint__toString($bigint::_remainder);
	%ret = bigint__toString(%value);

	%a.delete();
	%b.delete();
	%value.delete();
	$bigint::_remainder.delete();
	return %ret;
}

function bigint_equal(%a, %b)
{
	return (%a.sign == %b.sign && bigint__compareAbs(%a, %b) == 0); // compareAbs returns 0 if they are equal but ignores sign, which is why I also compare signs here
}

function bigint_greaterequal(%a, %b)
{
	//if (!%a.sign && %b.sign)
	//	return true;
	if (%a.length() > %b.length())
		return true;
	if (%a.length() < %b.length())
		return false;
	%isGreaterEqual = true;
	for (%i = %a.length() - 1; %i >= 0; %i--)
	{
		%valA = %a.get(%i) * (%a.sign ? -1 : 1);
		%valB = %b.get(%i) * (%b.sign ? -1 : 1);
		if (%valA < %valB)
			%isGreaterEqual = false;
	}
	return %isGreaterEqual;
}

function bigint_greater(%a, %b)
{
	//if (!%a.sign && %b.sign)
	//	return true;
	if (%a.length() > %b.length())
		return true;
	if (%a.length() < %b.length())
		return false;
	for (%i = %a.length() - 1; %i >= 0; %i--)
	{
		%valA = %a.get(%i) * (%a.sign ? -1 : 1);
		%valB = %b.get(%i) * (%b.sign ? -1 : 1);
		if (%valA > %valB)
			return true;
	}
	return false;
}

function bigint_lesserequal(%a, %b)
{
	//if (%a.sign && !%b.sign)
	//	return true;
	if (%a.length() < %b.length())
		return true;
	if (%a.length() > %b.length())
		return false;
	%isLesserEqual = true;
	for (%i = %a.length() - 1; %i >= 0; %i--)
	{
		%valA = %a.get(%i) * (%a.sign ? -1 : 1);
		%valB = %b.get(%i) * (%b.sign ? -1 : 1);
		if (%valA > %valB)
			%isLesserEqual = false;
	}
	return %isLesserEqual;
}

function bigint_lesser(%a, %b)
{
	//if (%a.sign && !%b.sign)
	//	return true;
	if (%a.length() < %b.length())
		return true;
	if (%a.length() > %b.length())
		return false;
	for (%i = %a.length() - 1; %i >= 0; %i--)
	{
		%valA = %a.get(%i) * (%a.sign ? -1 : 1);
		%valB = %b.get(%i) * (%b.sign ? -1 : 1);
		if (%valA < %valB)
			return true;
	}
	return false;
}
